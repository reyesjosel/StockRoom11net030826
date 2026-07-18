/* Warning: Host the assets locally within your project's static assets folder.

   Directory Layout:
  
    YourProjectName
      ├── wwwroot
      │    └── Jscript
      │         └── vis
      │               ├── vis-timeline-graph2d.min.js  <--Copy downloaded script here
      │               ├── vis-timeline-graph2d.min.css <--Copy downloaded style here
      │               └── vis-timeline-bridge.js  <--This file most likely goes here
  
        This file is a bridge between Blazor and the vis - timeline JavaScript library.
   It allows Blazor components to interact with the vis - timeline library by providing a
   set of JavaScript functions that can be called from C# code.The functions are exposed
   globally on the window object, so they can be accessed from anywhere in the application.*/

// Exposed globally on the window object
window.visTimelineBridge = {

    initTimeline: function (element, itemsJson, optionsJson)
    {
        const items = JSON.parse(itemsJson);
        const options = JSON.parse(optionsJson);

        // Remember, when the browser loads (index.html) the standalone vis-timeline.min.js bundle,
        // it attaches the 'vis' object to the global window space.
        //  <!-- 2. Global Third-Party JavaScript Bundle -->
        //  <script src="Jscript/vis/vis-timeline-graph2d.min.js"></script>

        // window.vis is already initialized globally by index.html
        element.timelineInstance = new window.vis.Timeline(element, items, options);
    },

    destroyTimeline: function (element)
    {
        if (element.timelineInstance)
        {
            element.timelineInstance.destroy();
            delete element.timelineInstance;
        }
    }
};