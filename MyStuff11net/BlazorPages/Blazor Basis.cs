namespace MyStuff11net.Blazor_pages
{
    internal class Blazor_Basis
    {
        //   Http://learn.microsoft.com/en-us/aspnet/core/blazor/hybrid/static-files?view=aspnetcore-8.0#windows-forms
        /*
        Windows Forms
        Place the asset into a folder of the app, typically at the project's root, such as a Resources folder.
        The example in this section uses a static text file.

        Resources/Data.txt:

            This is text from a static text file resource.

        Examine the files associated with Form1 in Solution Explorer. If Form1 doesn't have a resource file (.resx),
        add a Form1.resx file with the Add > New Item contextual menu command.

        Double-click the Form1.resx file.

        Select Strings > Files from the dropdown list.

        Select Add Resource > Add Existing File. If prompted by Visual Studio to confirm editing the file,
        select Yes. Navigate to the Resources folder, select the Data.txt file, and select Open.

        In the following example component:

        The app's assembly name is WinFormsBlazor. The ResourceManager's base name is set to the assembly name of
        Form1 ( WinFormsBlazor.Form1).
        ResourceManager.GetString obtains the string resource's text for display.
 
        Warning
        Never use ResourceManager methods with untrusted data.

        StaticAssetExample.razor:


        @page "/static-asset-example"
        @using System.Resources

        <h1>Static Asset Example</h1>

        <p>@dataResourceText</p>

        @code {
                public string dataResourceText = "Loading resource ...";

                protected override async Task OnInitializedAsync()
                {   
                    var resources = new ResourceManager("WinFormsBlazor.Form1", this.GetType().Assembly);
                    dataResourceText = resources.GetString("Data") ?? "'Data' not found.";
                }
        } 


        */

        //   Http://learn.microsoft.com/en-us/aspnet/core/blazor/hybrid/static-files?view=aspnetcore-8.0#static-assets-limited-to-razor-components
        /*
        A BlazorWebView control has a configured host file (HostPage), typically wwwroot/index.html.
        The HostPage path is relative to the project. All static web assets (scripts, CSS files, images,
        and other files) that are referenced from a BlazorWebView are relative to its configured HostPage.

        Static web assets from a Razor class library (RCL) use special paths:
        _content/{PACKAGE ID}/{PATH AND FILE NAME}. The {PACKAGE ID} placeholder is the library's package ID.
        The package ID defaults to the project's assembly name if <PackageId> isn't specified in the project file.
        The {PATH AND FILE NAME} placeholder is path and file name under wwwroot. These paths are logically subpaths
        of the app's wwwroot folder, although they're actually coming from other packages or projects.
        Component-specific CSS style bundles are also built at the root of the wwwroot folder.

        The web root of the HostPage determines which subset of static assets are available:

        wwwroot/index.html (recommended): All assets in the app's wwwroot folder are available (for example:
        wwwroot/image.png is available from /image.png), including subfolders (for example: 
        wwwroot/subfolder/image.png is available from /subfolder/image.png).
        
        RCL static assets in the RCL's wwwroot folder are available (for example:
        wwwroot/image.png is available from the path _content/{PACKAGE ID}/image.png),
        including subfolders (for example:
        wwwroot/subfolder/image.png is available from the path _content/{PACKAGE ID}/subfolder/image.png).

        wwwroot/{PATH}/index.html: All assets in the app's wwwroot/{PATH} folder are available using app web root
        relative paths. RCL static assets in wwwroot/{PATH} aren't because they would be in a non-existent theoretical
        location, such as ../../_content/{PACKAGE ID}/{PATH}, which isn't a supported relative path.
        wwwroot/_content/{PACKAGE ID}/index.html: All assets in the RCL's wwwroot/{PATH} folder are available
        using RCL web root relative paths. The app's static assets in wwwroot/{PATH} are aren't because they would be
        in a non-existent theoretical location, such as ../../{PATH}, which isn't a supported relative path.

        For most apps, we recommend placing the HostPage at the root of the wwwroot folder of the app,
        which provides the greatest flexibility for supplying static assets from the app, RCLs, and via subfolders
        of the app and RCLs.

        The following examples demonstrate referencing static assets from the app's web root (wwwroot folder)
        with a HostPage rooted in the wwwroot folder.

        wwwroot/data.txt:

        This is text from a static text file resource.

        wwwroot/scripts.js:

        export function showPrompt(message)
        {
          return prompt(message, 'Type anything here');
        }

        */

        /* Location of<head> and<body> content
         * 
           In a Blazor Web App, <head> and<body> content is located in the Components/App.razor file.
           In a Blazor WebAssembly app, <head> and<body> content is located in the wwwroot/index.html file.
        */

        /* In WPF and Windows Forms apps, add the following ReadData method to the
        @code block of the preceding component:

        private async Task<string> ReadData()
        {
            using var reader = new StreamReader("wwwroot/data.txt");

            return await reader.ReadToEndAsync();
        }

        https://learn.microsoft.com/en-us/aspnet/core/blazor/javascript-interoperability/location-of-javascript?view=aspnetcore-8.0#load-a-script-from-an-external-javascript-file-js-collocated-with-a-component
        Collocated JavaScript files are also accessible at logical subpaths of wwwroot.
        Instead of using the script described earlier for the showPrompt function in wwwroot/scripts.js,
        the following collocated JavaScript file for the StaticAssetExample2 component also makes the
        function available.

        Pages/StaticAssetExample2.razor.js:


        export function showPrompt(message)
        {
          return prompt(message, 'Type anything here');
        }

        Modify the module object reference in the StaticAssetExample2 component to use the collocated
        JavaScript file path (./Pages/StaticAssetExample2.razor.js):

        module = await JS.InvokeAsync<IJSObjectReference>("import", "./Pages/StaticAssetExample2.razor.js");

        */

        #region "Routing"

        /*
        Routing in a Blazor application is the system that matches URLs to Razor components so that the
        correct view can be rendered to the browser.
        In most web development frameworks, there is usually a one-to-one correlation between the URL and the
        physical location of the resource to be rendered such as the file name and path of the page or view.

        Razor components that act as navigable endpoints or pages in a Blazor application must have either

        --> an @page directive followed by a route template, or
        --> an @attribute directive followed by a RouteAttribute that takes a constant representing a route template
        
        A Route template is a string that specifies the pattern for a route that the page can be reached at.
        At application startup, these templates are used to build a collection of Attribute Routes that match
        a URL to a component. Attribute routing is widely used in many other parts of ASP.NET. In Blazor applications,
        the template must relative to the root of the application and begin with a forward slash (/).

        Often, the template consists solely of literal text, resulting in a one-to-one match between the
        incoming URL and the route template. In the following example, the route template "/about" is
        defined as part of the @page directive. The component is rendered when the user navigates to /about:

        @page "/about"
        <h1>About Us</h1> 

        Here is the same example with a route attribute instead:

        @attribute [Route(Constants.AboutRoute)]
        <h1>About Us</h1> 

        Constants.AboutRoute is defined as a constant value elsewhere within the application:

        public static class Constants
        {
            public const string AboutRoute = "/about";
        }
        
        You can specify multiple routes templates for a single component via additional @page directives
        or Route attributes:

        @attribute [Route(Constants.AboutRoute)]
        @page "/about-us"
        <h1>About Us</h1>
        
        This component will be rendered if the user navigates to /about or /about-us

        The default page for a Blazor application is located at "/". In the standard project template,
        this is applied to the Index.razor file. But you can change that to any file you like.

        */

        #endregion

        #region "Route Parameters"

        /*
        Route parameters are placeholders for values that you want to pass to a specific component via the URL.
        The place holder is represented in a route template as a token within curly braces: { token }.
        The token or parameter name must match a public property within the component that is decorated
        with the[Parameter] attribute.In the next listing, the route parameter is named id,
        and the component includes a parameter with the same name (case-insensitive):

        @page "/details/{id}"
        <h1>Details</h1>
        @code
        {
            [Parameter]
            public string Id { get; set; }
        }

        Blazor will bind the parameter value to the public property automatically.

        The data type of the public property is a string. By default, all route data values are strings.
        Changing the property data type alone will result in a System.InvalidOperationException,
        with the message:

        Unable to set property 'id' on object of type '[name of the component]'.
        The error was: Specified cast is not valid.

        If you want to work with different types, you must apply a constraint to the parameter
        in the route template.You do this by adding a colon, followed by the data type that you want to work with:

        @page "/details/{id:int}"
        <h1>Details</h1>
        @code{
                [Parameter] public int Id { get; set; }
             }

        Attribute routing supports a large number of constraints, but Blazor only supports a subset of them:

        Constraint Description Example
        bool Matches a Boolean value.    {isActive:bool}
        int Matches a 32-bit integer value.	{id:int}
        datetime Matches a DateTime value.	{startdate:datetime}
        decimal Matches a decimal value.	{cost:decimal}
        double Matches a 64-bit floating-point value.	{latitude:double}
        float Matches a 32-bit floating-point value.	{x:float}
        long Matches a 64-bit integer value.	{x:long}
        guid Matches a GUID value.	{id:guid}

        */
        #endregion

        #region "Optional Parameters"
        /*
        Optional parameters, supported in other parts of ASP.NET Core (MVC and Razor Pages),
        are not supported in Blazor.If you want to be able to navigate to a component without providing
        a value for a route parameter, you should specify an alternative route within the component that
        doesn't include the parameter placeholder:

        @page "/details
        @page "/details/{id:int}"
        <h1>Details</h1>

        @code
        {
            [Parameter]
            public int Id { get; set; }
        }

        You can also provide alternative route templates that differ only by data type:

        @page "/details
        @page "/details/{id:int}"
        @page "/details/{title}" // string data type
        <h1>Details</h1>

        @code
            {
                [Parameter]
                public int Id { get; set; }
                [Parameter]
                public string Title { get; set; }
            }
        */
        #endregion

        #region"The Router Component"
        /*

        The Router component is responsible for locating the correct component based on the current URL.
        You will find it in the App component in the project template:

        <Router AppAssembly = "@typeof(App).Assembly" >
            < Found Context="routeData">
                <RouteView RouteData = "@routeData" DefaultLayout="@typeof(MainLayout)" />
                <FocusOnNavigate RouteData = "@routeData" Selector="h1" />
            </Found>
            <NotFound>
                <PageTitle>Not found</PageTitle>
                <LayoutView Layout = "@typeof(MainLayout)" >
                    < p role= "alert" > Sorry, there's nothing at this address.</p>
                </LayoutView>
            </NotFound>
        </Router>

        The AppAssembly parameter value specifies the assembly to be searched for page components
        (those with an @page directive or RouteAttribute) that might match the current URL.By default,
        it specifies the current assembly.If you have page components in numerous assemblies, you can
        specify those via the AdditionalAssemblies parameter which takes an IEnumerable<Assembly> as an argument.

        */
        #endregion
    }
}
