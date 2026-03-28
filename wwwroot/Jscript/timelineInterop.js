window.timelineInterop =
{
    create: function (elementId, items, groups, options, dotnetRef)
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
        if (!el) return;

        if (el._timeline) el._timeline.destroy();

        const itemsDataSet = new vis.DataSet(items ?? []);
        const groupDataSet = groups ? new vis.DataSet(groups) : null;

        const timeline = new vis.Timeline(el, itemsDataSet, groupDataSet, options || {});

        el._timeline = timeline;
        el._dataSet = itemsDataSet;

        timeline.addCustomTime('2025-12-11T12:00:00', 90);
        timeline.setCustomTimeMarker("title" , 90, true);

        // Selection → C#
        timeline.on("select", function (props)
        {
            const id = props.items.length ? props.items[0] : null;
            dotnetRef.invokeMethodAsync("NotifySelect", id);
        });

        // Drag move → C#
        timeline.on("move", function (item)
        {
            dotnetRef.invokeMethodAsync("NotifyMove", item);
        });

        // Resize → C#
        timeline.on("resize", function (item)
        {
            dotnetRef.invokeMethodAsync("NotifyResize", item);
        });

        // Range changed (pan / zoom)
        timeline.on("rangechanged", function (props)
        {
            dotnetRef.invokeMethodAsync("NotifyRangeChanged", props.start, props.end );
        });

        function toAddRemoveEventListener()
        {
            // add event listener
            timeline.on('select', onSelect),

            // do stuff...

            // remove event listener
            timeline.off('select', onSelect)
        };

        function onSelect(properties) { alert('selected items: ' + properties.items); };
    },

    addItem: (id, item) =>      document.getElementById(id)?._dataSet?.add(item),

    updateItem: (id, item) =>   document.getElementById(id)?._dataSet?.update(item),

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
    
};

      //  import * as Arrow from './vis/arrow.js'; 