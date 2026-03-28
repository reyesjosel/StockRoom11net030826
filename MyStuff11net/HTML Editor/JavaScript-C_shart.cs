namespace MyStuff11net.HTML_Editor
{
    class JavaScript_C_shart
    {
        /*
        Calling JavaScript in a WebBrowser control from C# Embedding a WebBrowser control in a C#
        application is very easy to do.  Simply drag and drop one in the Form editor.  So what can
        you do with it besides writing your own web browser?
            I wanted to load my own HTML page and call JavaScript functions within it and for the
        JavaScript to be able to call functions in C#.  Specifically, I wanted to be able to interact
        with a public JavaScript API from Google (Google Maps) from the application.
            Most of this can be accomplished using a pure JavaScript implementation in a web page,
        but the user interface is limited as is access to local computer resources, such as files.
            With a web server you can process uploaded files, but that requires server resources and
        a scalable infrastructure if you distribute your application.  It is easier and cheaper to do
        file processing on the client, which is even more important in a freely distributed application
        to eliminate extra cost.
            I searched around online and it was difficult to find details on how to call JavaScript from
        a containing C# application.  It turns out to be really easy and worth sharing in case anyone else
        ever wants to do something similar.
        
            Calling JavaScript from C# (See the next section for how to call C# from JavaScript).So how
        can you call JavaScript functions in your WebBrowser control?  Call the InvokeScript method on
        the HtmlDocument.
        
        C#

        namespace System.Windows.Forms
        {
        public sealed class HtmlDocument
        {
            public object InvokeScript(string scriptName);
            public object InvokeScript(string scriptName, object[] args);
        }
        }
        
            For example, let’s assume that you have a System.Windows.Forms.WebBrowser object named webBrowser1
        and you want to call a JavaScript function in the HTML page loaded in your WebBrowser called "showMe()"
        JavaScript

        function showMe()
         {
            ...
         }
         
        C#

        webBrowser1.Document.InvokeScript("showMe");
        
        Adding parameters gets a bit more complicated, but not much.  You can create an array of parameters as
        the API suggests and they will be passed in to the JavaScript function.  However, there is an even simpler
        way to do it.

        We will start by calling the following function

        JavaScript

        function showMe(x,y) 
        {
            ...
        }
        
        Let’s write a wrapper function in C# using the params keyword to let the compiler do the work for us.
        It will automatically convert any extra parameters into an array of objects, just like InvokeScript is expecting.

        C#

        private object MyInvokeScript(string name, params object[] args) 
        { 
            return webBrowser1.Document.InvokeScript(name, args);
        }
        …

        int x = 50; 
        int y = 100; 
        MyInvokeScript("showMe", x, y);

        Note that the InvokeScript will return the value that the JavaScript function returns.  According to the documentation,
        if it is a native type such as a number or string, it will be returned as a string, but it can also return an object.

        JavaScript

        function createPoint(x, y) 
        { 
            // Assume I have a Point object 
            var p = new Point(x,y); 
            return p; 
        }

        function setPoint (p) 
        { 
            // Do something useful with the Point p. 
        }

        C#

        object o = MyInvokeScript("createPoint", 50, 100);

        It is possible to query information about the object using GetType and InvokeMember but I like that the object
        can be passed back into JavaScript

        C#

        MyInvokeScript("setPoint", o);

        
            This is very powerful and, combined with the ability to call from JavaScript into C#, can allow you to embed
        many web applications that provide a JavaScript API into your C# application.
        
        Calling C# from JavaScript

            Simply put, you can expose a C# object to the WebBrowser that the JavaScript can call directly  The WebBrowser
        class exposes a property called ObjectForScripting that can be set by your application and becomes the window.external
        object within JavaScript.  The object must have the ComVisibleAttribute set true

        C#

        [System.Runtime.InteropServices.ComVisibleAttribute(true)]
        public class ScriptInterface 
        { 
            void callMe() 
            { 
                … // Do something interesting 
            } 
        }

        webBrowser1.ObjectForScripting = new ScriptInterface();

        JavaScript

        window.external.callMe();
         

        What next?-pid

            With the ability to call JavaScript from C# and C# from JavaScript you can now embed and extend web applications into
        native applications with ease.  A native application gives you more control over the environment and access to computer
        resources that you cannot access from a web page.  You can merge, or "mashup", web applications with computer hardware or
        software in new and interesting ways.

            Imagine accessing a GPS connected to your computer and view your current location in an embedded map powered by Google Maps.
        What if that included turn by turn directions to your destination?  Why not go even further and convert the directions into speech?
            Doing all this on the client saves costs and pushes processing from expensive server hardware to client hardware and opens up
        interesting mashups to average users who do not have the resources to support their interesting idea for thousands of users.

         * 
         * 
         * 
         * 
        function trackEvent(category, action, opt_label, opt_value)
        {
            _gaq.push(['_trackEvent', category, action, opt_label, opt_value]);
        }

        C#
        webBrowser1.Document.InvokeScript(“trackEvent”, args).ToString();
        
        */
    }
}
