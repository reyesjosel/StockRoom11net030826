//#region Module-level state
let _pageDotnetRef = null;  // set in registerPageContextMenu(), used to call PageContextMenuOpen() /
                            // PageContextMenuClose() from the window - level contextmenu handler.
let _timelineEl    = null;  // set in create(), used to detect clicks inside the timeline
let _timeline      = null;  // vis-timeline instance, used for getEventProperties
let _compDotnetRef = null;  // TimeLineComp dotnetRef, used to call NotifyContextMenuComp() from the page-level contextmenu handler.

//#endregion

//#region Page context menu
// Call once from TimeLinePage.OnAfterRenderAsync(firstRender):
// await module.InvokeVoidAsync("registerPageContextMenu", DotNetObjectReference.Create(this));
// TimeLinePage must expose [JSInvokable] PageContextMenuOpen(TimeLineContextMenuArgs args).
// TimeLinePage must expose [JSInvokable] PageContextMenuClose().
// TimeLineComp must expose [JSInvokable] CloseContextMenu().
let _pageWindowHandler = null;
let _pageBlurHandler   = null;   // closes both menus when the window loses focus

let ShowMajorLabels = false; // Default value for showMajorLabels, can be updated based on the timeline's options.

export function registerPageContextMenu(dotnetRef)
{
    _pageDotnetRef = dotnetRef;

    if (_pageWindowHandler)
        window.removeEventListener("contextmenu", _pageWindowHandler);

    _pageWindowHandler = function (e)
    {
        e.preventDefault();

        // Geometrically check if the click is over the timeline element.
        // This works even when the backdrop (fixed, inset:0) is covering it.
        if (_timelineEl && _timeline)
        {
            const rect = _timelineEl.getBoundingClientRect();
            const isOverTimelineComp = e.clientX >= rect.left && e.clientX <= rect.right &&
                e.clientY >= rect.top && e.clientY <= rect.bottom;

            // If the right-click is over the timeline, call TimeLineComp.NotifyContextMenuComp()
            // with the item / group under the cursor.
            if (isOverTimelineComp)
            {
                // Close the page-level menu before opening the component menu.
                if (_pageDotnetRef)
                    _pageDotnetRef.invokeMethodAsync("PageContextMenuClose");

                // getEventProperties() walks up from e.target to find .vis-item /
                // .vis-group ancestors. If the component's backdrop (position:fixed,
                // inset:0, z-index:999) is open it sits on top of the timeline, so
                // e.target is the backdrop element — and getEventProperties returns
                // item:null no matter where the cursor actually is.
                //
                // Fix: use document.elementsFromPoint() to find the topmost element
                // that lives INSIDE the timeline, then proxy e.target to that element
                // so getEventProperties sees the real hit-target.
                const stackedEls = document.elementsFromPoint(e.clientX, e.clientY);
                const realTarget = stackedEls.find(el => _timelineEl !== el && _timelineEl.contains(el)) ?? _timelineEl;

                const proxyEvent = new Proxy(e, {
                    get(src, prop)
                    {
                        if (prop === "target" || prop === "srcElement") return realTarget;
                        const val = src[prop];
                        return typeof val === "function" ? val.bind(src) : val;
                    }
                });

                const props = _timeline.getEventProperties(proxyEvent);
                _compDotnetRef.invokeMethodAsync("NotifyContextMenuComp", {
                    itemId: props.item ?? null,
                    groupId: props.group ?? null,
                    clientX: e.clientX,
                    clientY: e.clientY,
                    showMajorLabels: ShowMajorLabels,
                    time: props.time ? props.time.toISOString() : null
                });
                return;
            }
            else
            {
                // Close the component menu before opening the page-level menu.
                if (_compDotnetRef)
                    _compDotnetRef.invokeMethodAsync("CompContextMenuClose");

                _pageDotnetRef.invokeMethodAsync("PageContextMenuOpen", {
                    itemId: null,
                    groupId: null,
                    clientX: e.clientX,
                    clientY: e.clientY,
                    showMajorLabels: false,  // Not relevant for the page-level menu yet, but included for consistency with the component menu.
                    time: null
                });
            }
        }               
    };

    window.addEventListener("contextmenu", _pageWindowHandler);

    // Close both menus when the WebView2 / browser window loses focus
    // (e.g. user switches to another app or WinForms window).
    //
    // IMPORTANT — WebView2 / WinForms quirk:
    // Right-clicking sends a brief WM_KILLFOCUS to the WebView2 HWND while
    // Windows processes the input, firing window "blur" before the contextmenu
    // event finishes. A raw blur handler would therefore close the menu before
    // it ever appears. The setTimeout + hasFocus() guard skips the close when
    // focus is restored within one event-loop tick (i.e. a momentary OS blur).
    if (_pageBlurHandler)
        window.removeEventListener("blur", _pageBlurHandler);

    _pageBlurHandler = function()
    {
        setTimeout(function()
        {
            // If the window already has focus again this was just a transient
            // blur (e.g. right-click input processing) — do nothing.
            if (document.hasFocus()) return;

            if (_pageDotnetRef)
                _pageDotnetRef.invokeMethodAsync("PageContextMenuClose");

            if (_compDotnetRef)
                _compDotnetRef.invokeMethodAsync("CompContextMenuClose");
        }, 0);
    };

    window.addEventListener("blur", _pageBlurHandler);
}

export function unregisterPageContextMenu()
{
    if (_pageWindowHandler)
    {
        window.removeEventListener("contextmenu", _pageWindowHandler);
        _pageWindowHandler = null;
    }

    if (_pageBlurHandler)
    {
        window.removeEventListener("blur", _pageBlurHandler);
        _pageBlurHandler = null;
    }

    _pageDotnetRef = null;
}

//#endregion

// #region Timeline lifecycle
export async function create(elementId, items, groups, options, dotnetRef, refAppService)
{
    console.log('create() called, elementId:', elementId);
    // Generate HTML content
    const getContent = (title, img) => {
        
        const name = document.createElement('div');
        const nameClasses = ['fw-bolder', 'mb-2'];
        name.classList.add(...nameClasses);
        name.innerHTML = title;
                
        const image = document.createElement('img');
        image.setAttribute('src', img);
                
        const symbol = document.createElement('div');
        const symbolClasses = ['symbol', 'symbol-circle', 'symbol-30'];
        symbol.classList.add(...symbolClasses);
        symbol.appendChild(image);
                
        const itemContent = document.createElement('div');
        itemContent.appendChild(name);
        itemContent.appendChild(symbol);

        return itemContent;
    }

    const el = document.getElementById(elementId);
    // Reference to the timeline div element. if the element is not found, return early.
    if (!el)
    {
        console.log('el notfound:');
        return;
    }
    else
    {
        console.log('el found:', el);
    }

    // If a timeline instance already exists on the element, destroy it before creating a new one.
    if (el._timeline)
        el._timeline.destroy();
    
    let vis;
    try
    {
        // The vis-timeline-graph2d.min.js file is a UMD bundle, it not work at dynamic import.
        // The vis-timeline-graph2d.min.mjs bundle is an ES module(ESM) that exports its members(Timeline, DataSet, etc.)
        // as named exports directly on the module namespace object.
        vis = await import('/Jscript/vis/vis-timeline-graph2d.min.mjs');
        if (vis)
            console.log('vis loaded:', vis);
        else
            console.log('vis not loaded:', vis);

        /*
        if (!document.querySelector('link[href="/Jscript/vis/vis-timeline-graph2d.min.css"]'))
        {
            const link = document.createElement('link');
            link.rel = 'stylesheet';    //rel="stylesheet"
            link.href = '/Jscript/vis/vis-timeline-graph2d.min.css';
            document.head.appendChild(link);
            console.log('vis-timeline-graph2d.min.css loaded:');
        }*/

        // 2. Ensure the vis-timeline CSS sheet is injected into the head
        if (!document.querySelector('link[href="/Jscript/vis/vis-timeline.css"]'))
        {
            const link = document.createElement('link');
            link.rel = 'stylesheet';
            link.href = '/Jscript/vis/vis-timeline.css';
            document.head.appendChild(link);
            console.log('vis-timeline.css loaded:');
        }
        else
        {
            console.log('CSS already loaded:');
        }
        
    }
    catch (error)
    {
        console.error('Failed to load vis-timeline module:', error);
        return;
    }

    const itemsDataSet = new vis.DataSet(items ?? []);
    const groupDataSet = groups ? new vis.DataSet(groups) : null;

    // Create a new timeline instance with the provided options or an empty object if no options are provided.
    const timeline = new vis.Timeline(el, itemsDataSet, groupDataSet, options || {});
    console.log('timeline created:', timeline);

    el._timeline = timeline;
    el._dataSet  = itemsDataSet;
    _timelineEl = el;           // Reference to the timeline div element, used for geometric hit-testing in the page-level contextmenu handler.
    _timeline = timeline;       // Reference to the timeline instance, used for getEventProperties in the page-level contextmenu handler.
    _compDotnetRef = dotnetRef; // Reference to the TimeLineComp dotnetRef, used to call NotifyContextMenuComp() from the page-level contextmenu handler.

    timeline.addCustomTime('2025-12-11T12:00:00', 90);
    timeline.setCustomTimeMarker("title", 90, true);
    
    // Selection → C#
    timeline.on("select", function (props)
    {
        const id = props.items.length ? props.items[0] : null;
        refAppService.invokeMethodAsync("NotifySelect", id);
    });

    // Drag move → C#
    timeline.setOptions(
    {
        // Disable 15-minute snapping → allows smooth pixel-level resize/move
    snap: null,

        onAdd: async function(item, callback) {
            try {
                // 1. Send the add to the backend and wait for a boolean success response
                const isSuccess = await refAppService.invokeMethodAsync("NotifyAdd", item);

                if (isSuccess) {
                    // 2. Confirm and apply the add in the UI
                    callback(item);
                } else {
                    // 3. Rollback: passing null cancels the add and snaps the item back
                    callback(null);
                    alert("Add rejected by the server.");
                }
            }
            catch (error) {
                // 4. Handle network or application errors by rolling back
                callback(null);
                console.error("Failed to notify backend:", error);
            }
        },
        onUpdate: async function(item, callback) {
            try {
                // 1. Send the update to the backend and wait for a boolean success response
                const isSuccess = await refAppService.invokeMethodAsync("NotifyUpdate", item);

                if (isSuccess) {
                    // 2. Confirm and apply the update in the UI
                    callback(item);
                } else {
                    // 3. Rollback: passing null cancels the update and snaps the item back
                    callback(null);
                    alert("Update rejected by the server.");
                }
            }
            catch (error) {
                // 4. Handle network or application errors by rolling back
                callback(null);
                console.error("Failed to notify backend:", error);
            }
        },
        onMoving: async function(item, callback) {
            try {
                // 1. Send the moving to the backend and wait for a boolean success response
                const isSuccess = await refAppService.invokeMethodAsync("NotifyMoving", item);

                if (isSuccess) {
                    // 2. Confirm and apply the moving in the UI
                    callback(item);
                } else {
                    // 3. Rollback: passing null cancels the moving and snaps the item back
                    callback(null);
                    alert("Moving rejected by the server.");
                }
            }
            catch (error) {
                // 4. Handle network or application errors by rolling back
                callback(null);
                console.error("Failed to notify backend:", error);
            }
        },
        onMove: async function(item, callback) {
            try {
                // Detect resize vs move by comparing start/end against the original DataSet values.
                // vis-timeline fires onMove for both drag-moves and edge-resizes.
                const original  = el._dataSet.get(item.id);
                const startDiff = original ? new Date(item.start) - new Date(original.start) : 0;
                const endDiff   = original && item.end != null ? new Date(item.end) - new Date(original.end) : 0;
                // A resize changes exactly one edge (start OR end moves, not both).
                // A move shifts both edges by the same delta.
                // Point items (no end) can never be resized.
                const isResize  = item.end != null &&
                                  (startDiff === 0) !== (endDiff === 0);

                const method    = isResize ? "NotifyResize" : "NotifyMoved";
                const isSuccess = await refAppService.invokeMethodAsync(method, item);

                if (isSuccess)
                {
                    callback(item);
                }
                else
                {
                    callback(null);
                    alert(`${isResize ? "Resize" : "Move"} rejected by the server.`);
                }
            }
            catch (error) {
                callback(null);
                console.error("Failed to notify backend:", error);
            }
        },            
        onRemove: async function(item, callback) {
            try {
                // 1. Send the remove to the backend and wait for a boolean success response
                const isSuccess = await refAppService.invokeMethodAsync("NotifyRemove", item);

                if (isSuccess) {
                    // 2. Confirm and apply the remove in the UI
                    callback(item);
                } else {
                    // 3. Rollback: passing null cancels the remove and snaps the item back
                    callback(null);
                    alert("Remove rejected by the server.");
                }
            }
            catch (error) {
                // 4. Handle network or application errors by rolling back
                callback(null);
                console.error("Failed to notify backend:", error);
            }
        },        
    });

    // Range changed (pan / zoom)
    timeline.on("rangechanged", function(props) {
        refAppService.invokeMethodAsync("NotifyRangeChanged", props.start, props.end);
    });

    // Example of how to add and remove event listeners dynamically.
    // You can call this function whenever you want to add or remove the event listener.
    function toAddRemoveEventListener() {
        // add event listener
        timeline.on('select', onSelect),

            // do stuff...

            // remove event listener
            timeline.off('select', onSelect)
    };

    // Example event listener function, you can replace this with your own implementation.
    function onSelect(properties) { alert('selected items: ' + properties.items); };

    // Helper function to inject CSS lazily only once
    function injectStylesheet()
    {
        const cssId = 'vis-timeline-css';
        if (!document.getElementById(cssId))
        {
            const head = document.getElementsByTagName('head')[0];
            const link = document.createElement('link');
            link.id = cssId;
            link.rel = 'stylesheet';
            link.type = 'text/css';
            link.href = '/Jscript/vis/vis-timeline-graph2d.min.css';
            link.media = 'all';
            head.appendChild(link);
        }
    }
}

// Call from C# to toggle major/minor labels at runtime
export async function setMajorLabels(elementId, showMajor, showMinor)
{
    const el = document.getElementById(elementId);
    if (!el || !el._timeline) return;

    ShowMajorLabels = showMajor; // Update the global variable to reflect the current state of major labels

    el._timeline.setOptions({
        showMajorLabels: showMajor,
        showMinorLabels: showMinor
    });
}

// Call from C# to get the current major/minor label settings
export function getOptions(elementId)
{
    const el = document.getElementById(elementId);
    if (!el || !el._timeline) return null;

    return {
        showMajorLabels: el._timeline.options.showMajorLabels,
        showMinorLabels: el._timeline.options.showMinorLabels
    };
}

// #endregion

// #region DataSet operations
export function addItem(id, item)
{
    document.getElementById(id)?._dataSet?.add(item);
}

export function updateItem(id, item)
{
    const el = document.getElementById(id);
    if (!el?._dataSet) return;
    const parsedItem = typeof item === 'string' ? JSON.parse(item) : item;
    el._dataSet.update(parsedItem);
}

// Remove an item from the dataSet associated with the timeline by its ID.
export function removeItem(id, itemId)
{
    document.getElementById(id)?._dataSet?.remove(itemId);
}

// #endregion

// #region Zoom & Pan
export function zoomIn(id)
{
    document.getElementById(id)?._timeline?.zoomIn(0.2);
}

export function zoomOut(id)
{
    document.getElementById(id)?._timeline?.zoomOut(0.2);
}

export function moveLeft(id)
{
    const t = document.getElementById(id)?._timeline;
    if (!t) return;
    const range = t.getWindow();
    const delta = (range.end - range.start) * -0.2;
    t.moveTo(new Date((range.start + range.end) / 2 + delta));
}

export function moveRight(id)
{
    const t = document.getElementById(id)?._timeline;
    if (!t) return;
    const range = t.getWindow();
    const delta = (range.end - range.start) * 0.2;
    t.moveTo(new Date((range.start + range.end) / 2 + delta));
}

// #endregion

// #region Data utilities
export function updateData(id, data)
{
    const el = document.getElementById(id);
    if (!el?._dataSet) return;
    const items = typeof data === 'string' ? JSON.parse(data) : data;
    el._dataSet.update(items);
}

export function initializeData(elementId, data)
{
    const run = () =>
    {
        const items = typeof data === 'string' ? JSON.parse(data) : data;
        // Get the DOM element by its ID and retrieve the associated timeline instance.
        // Remenber that  <footer>
        //                          <div id="@ElementId"></div>
        //                </footer>
        // is the element that will be used to create the timeline, so we need to get it by its ID.
        const elementDOM = document.getElementById(elementId);
        // Get the timeline instance associated with the element.
        const timeline = elementDOM?._timeline;
        if (!elementDOM?._dataSet) return;
        elementDOM._dataSet.update(items);

        if (!timeline || typeof timeline.redraw !== 'function') {
            console.warn('vis-timeline: timeline not ready for element "' + elementId + '", skipping redraw.');
            return;
        }

        //timeline.setItems(JSON.parse(data));
        timeline.redraw();
        timeline.fit();
    };

  //  run();

    if (document.readyState === 'complete')
        run();
    else
        window.addEventListener('load', run, { once: true }); // ✅ fires only once

    // const el = document.getElementById(id);
    // if (!el?._dataSet) return;
    // const items = typeof data === 'string' ? JSON.parse(data) : data;
    // el._dataSet.update(items);
}

// #endregion

// #region Selection
export function selectItem(id, item) {
    const el = document.getElementById(id);
    if (!el?._dataSet) return;
    const parsedItem = typeof item === 'string' ? JSON.parse(item) : item;

    const t = document.getElementById(id)?._timeline;
    if (!t) return;

    t.setSelection([parsedItem.id], { focus: true, zoom: false, animation: { duration: 500, easingFunction: 'easeInOutQuad' } });
}
// #endregion
