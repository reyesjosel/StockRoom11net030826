// 1. Import the third-party library dynamically inside the isolated module
import 'https://unpkg.com';

// 2. Going Local: Shipping Assets with Your NuGet PackageIf you are building this wrapper inside a Razor Class Library (RCL)
// to distribute as a NuGet package or shared library, you should avoid relying on external CDNs(unpkg.com).You can host the
// assets locally within your project's static assets folder.

// Directory Layout:
//  YourProjectName
//    ├── wwwroot
//    │    └── Jscript
//    │         └── vis
//    │               ├── vis-timeline-graph2d.min.js  <--Copy downloaded script here
//    │               └── vis-timeline-graph2d.min.css <--Copy downloaded style here
//    │
//    └── BlazorWebAssembly
//              └── Components
//                    └── Pages
//                          ├── VisTimeline.razor
//                          └── VisTimeline.razor.js

// Import from your local project static assets folder
import '../../_content/YourRclProjectAssemblyName/vis-timeline.min.js';

// Why this approach is ideal:
//   Zero - Configuration for Consumers: Developers who install your Blazor wrapper do not need to paste any <script> or <link> tags
//                                       into their root HTML files.They just drop your < VisTimeline /> component onto a page, and it works.
//   Smart Garbage Collection: The browser downloads the heavy vis - timeline.min.js file only when that specific route is rendered.
//                             If a user never visits the timeline page, they never fetch the asset.


const instances = new Map();

export function initTimeline(element, itemsJson, optionsJson)
{
    // 2. Ensure the vis-timeline CSS sheet is injected into the head
    injectStylesheet();

    const items = JSON.parse(itemsJson);
    const options = JSON.parse(optionsJson);

    // When using the standalone bundle, 'vis' is attached to the window space safely
    const timeline = new window.vis.Timeline(element, items, options);
    instances.set(element, timeline);
}

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
        link.href = '../../_content/YourRclProjectAssemblyName/vis-timeline.min.css';
        link.media = 'all';
        head.appendChild(link);
    }
}

/// 3. Update the timeline items dynamically
/// This function can be called from Blazor to update the timeline items
export function setTimelineOptions(element, optionsJson)
{
    const timeline = instances.get(element);
    if (timeline)
    {
        timeline.setOptions(JSON.parse(optionsJson));
    }
}

/// 4. Destroy the timeline instance when the component is disposed
export function destroyTimeline(element)
{
    const timeline = instances.get(element);
    if (timeline)
    {
        timeline.destroy();
        instances.delete(element);
    }
}