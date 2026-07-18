window.timelineInterop =
{
    create: function (elementId, items, groups, options, dotnetRef, refAppService)
    {
        // Generate HTML content
        const getContent = (title, img) =>
        {
            const item = document.createElement('div');
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

            item.appendChild(name);
            item.appendChild(symbol);

            return item;
        }

        var itemsTemple = new vis.DataSet([
            {
                start: new Date(2010, 7, 23),
                content: getContent('Conversation', './assets/media/avatars/300-6.jpg')
            },
            {
                start: new Date(2010, 7, 23, 23, 0, 0),
                content: getContent('Mail from boss', './assets/media/avatars/300-1.jpg')
            }])

        const el = document.getElementById(elementId);
        // Reference to the timeline div element. if the element is not found, return early.
        if (!el) return;

        // If a timeline instance already exists on the element, destroy it before creating a new one.
        if (el._timeline) el._timeline.destroy();

        // Create a new data set for the items and groups.
        const itemsDataSet = new vis.DataSet(items ?? []);
        const groupDataSet = groups ? new vis.DataSet(groups) : null;

        // Create a new timeline instance with the provided options or an empty object if no options are provided.
        const timeline = new vis.Timeline(el, itemsDataSet, groupDataSet, options || {});

        el._timeline = timeline;
        el._dataSet = itemsDataSet;

        timeline.addCustomTime('2025-12-11T12:00:00', 90);
        timeline.setCustomTimeMarker("title" , 90, true);

        // Call back to C# using the provided dotnetRef ( selfRef ).
        // Selection → C#
        timeline.on("select", function (props)
        {
            const id = props.items.length ? props.items[0] : null;
            refAppService.invokeMethodAsync("NotifySelect", id);
            //dotnetRef.invokeMethodAsync("NotifySelect", id);
        });

        // Drag move → C#
        timeline.setOptions({
            onAdd: async function (item, callback)
            {
                try
                {
                    // 1. Send the add to the backend and wait for a boolean success response
                    const isSuccess = await refAppService.invokeMethodAsync("NotifyAdd", item);

                    if (isSuccess)
                    {
                        // 2. Confirm and apply the add in the UI
                        callback(item);
                    } else
                    {
                        // 3. Rollback: passing null cancels the add and snaps the item back
                        callback(null);
                        alert("Add rejected by the server.");
                    }
                }
                catch (error)
                {
                    // 4. Handle network or application errors by rolling back
                    callback(null);
                    console.error("Failed to notify backend:", error);
                }
            },
            onUpdate: async function (item, callback)
            {
                try
                {
                    // 1. Send the update to the backend and wait for a boolean success response
                    const isSuccess = await refAppService.invokeMethodAsync("NotifyUpdate", item);

                    if (isSuccess)
                    {
                        // 2. Confirm and apply the update in the UI
                        callback(item);
                    } else
                    {
                        // 3. Rollback: passing null cancels the update and snaps the item back
                        callback(null);
                        alert("Update rejected by the server.");
                    }
                }
                catch (error)
                {
                    // 4. Handle network or application errors by rolling back
                    callback(null);
                    console.error("Failed to notify backend:", error);
                }
            },
            onMoving: async function (item, callback)
            {
                try
                {
                    // 1. Send the moving to the backend and wait for a boolean success response
                    const isSuccess = await refAppService.invokeMethodAsync("NotifyMoving", item);

                    if (isSuccess)
                    {
                        // 2. Confirm and apply the moving in the UI
                        callback(item);
                    } else
                    {
                        // 3. Rollback: passing null cancels the moving and snaps the item back
                        callback(null);
                        alert("Moving rejected by the server.");
                    }
                }
                catch (error)
                {
                    // 4. Handle network or application errors by rolling back
                    callback(null);
                    console.error("Failed to notify backend:", error);
                }
            },
            onMove: async function (item, callback)
            {
                try
                {
                    // 1. Send the moved to the backend and wait for a boolean success response
                    const isSuccess = await refAppService.invokeMethodAsync("NotifyMoved", item);

                    if (isSuccess)
                    {
                        // 2. Confirm and apply the moved in the UI
                        callback(item);
                    } else
                    {
                        // 3. Rollback: passing null cancels the moved and snaps the item back
                        callback(null);
                        alert("Move rejected by the server.");
                    }
                }
                catch (error)
                {
                    // 4. Handle network or application errors by rolling back
                    callback(null);
                    console.error("Failed to notify backend:", error);
                }
            },            
            onRemove: async function (item, callback)
            {
                try
                {
                    // 1. Send the remove to the backend and wait for a boolean success response
                    const isSuccess = await refAppService.invokeMethodAsync("NotifyRemove", item);

                    if (isSuccess)
                    {
                        // 2. Confirm and apply the remove in the UI
                        callback(item);
                    } else
                    {
                        // 3. Rollback: passing null cancels the remove and snaps the item back
                        callback(null);
                        alert("Remove rejected by the server.");
                    }
                }
                catch (error)
                {
                    // 4. Handle network or application errors by rolling back
                    callback(null);
                    console.error("Failed to notify backend:", error);
                }
            },            
            onResize: async function (item, callback)
            {
                try
                {
                    // 1. Send the resize to the backend and wait for a boolean success response
                    const isSuccess = await refAppService.invokeMethodAsync("NotifyResize", item);

                    if (isSuccess)
                    {
                        // 2. Confirm and apply the resize in the UI
                        callback(item);
                    } else
                    {
                        // 3. Rollback: passing null cancels the resize and snaps the item back
                        callback(null);
                        alert("Resize rejected by the server.");
                    }
                }
                catch (error)
                {
                    // 4. Handle network or application errors by rolling back
                    callback(null);
                    console.error("Failed to notify backend:", error);
                }
            }
        });
        
        // Range changed (pan / zoom)
        timeline.on("rangechanged", function (props)
        {
            refAppService.invokeMethodAsync("NotifyRangeChanged", props.start, props.end );
        });

        // This is an example of how to add and remove event listeners dynamically.
        // You can call this function whenever you want to add or remove the event listener.
        function toAddRemoveEventListener()
        {
            // add event listener
            timeline.on('select', onSelect),

            // do stuff...

            // remove event listener
            timeline.off('select', onSelect)
        };

        // Example event listener function, you can replace this with your own implementation.
        function onSelect(properties) { alert('selected items: ' + properties.items); };
    },

    // DataSet operations. Add a new item, update an existing item, or remove an item from the timeline.
    addItem: (id, item) => document.getElementById(id)?._dataSet?.add(item),

    updateItem: (id, item) =>
    {
        const el = document.getElementById(id);
        if (!el?._dataSet) return;
        const parsedItem = typeof item === 'string' ? JSON.parse(item) : item;
        el._dataSet.update(parsedItem);
    },

    // Remove an item from the dataSet associated with the timeline by its ID.
    removeItem: (id, itemId) => document.getElementById(id)?._dataSet?.remove(itemId),

    // Zoom + Pan
    zoomIn: id => document.getElementById(id)?._timeline?.zoomIn(0.2),
    zoomOut: id => document.getElementById(id)?._timeline?.zoomOut(0.2),

    moveLeft: id =>
    {
        const t = document.getElementById(id)?._timeline;
        if (!t) return;
        const range = t.getWindow();
        const delta = (range.end - range.start) * -0.2;
        t.moveTo(new Date((range.start + range.end) / 2 + delta));
    },

    moveRight: id =>
    {
        const t = document.getElementById(id)?._timeline;
        if (!t) return;
        const range = t.getWindow();
        const delta = (range.end - range.start) * 0.2;
        t.moveTo(new Date((range.start + range.end) / 2 + delta));
    },

    upDateData: (id, data) =>
    {
        const el = document.getElementById(id);
        if (!el?._dataSet) return;
        const items = typeof data === 'string' ? JSON.parse(data) : data;
        el._dataSet.update(items);
    },

    selectItem: (id, item) =>
    {
        const el = document.getElementById(id);
        if (!el?._dataSet) return;
        const parsedItem = typeof item === 'string' ? JSON.parse(item) : item;

        const t = document.getElementById(id)?._timeline;
        if (!t) return;
        
        t.setSelection([parsedItem.id], { focus: true, zoom: false, animation: { duration: 500, easingFunction: 'easeInOutQuad' } });
    },

};