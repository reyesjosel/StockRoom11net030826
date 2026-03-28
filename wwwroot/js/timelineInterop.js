export function createTimeline(elementId, itemsJson, optionsJson)
    {
        var container = document.getElementById(elementId);
        var items = new vis.DataSet(JSON.parse(itemsJson));
        var options = JSON.parse(optionsJson);
        var timeline = new vis.Timeline(container, items, options);
        // You can store the timeline instance if you need to manipulate it later
        // e.g., window.timelineInstances[elementId] = timeline;
    }
    // Add other functions to update, add items, etc., as needed