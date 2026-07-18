using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using StockRoom11net.Controls.VisTimeLine;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Text.Json;

namespace StockRoom11net.Docs
{
    internal class Documents
    {
        #region"Info about line breaks"

        // ✅ Option 1 — <br/> for a simple line break (works in VS IntelliSense + Rider)
        /// <summary>
        /// First line.<br/>
        /// Second line.
        /// </summary>

        // ✅ Option 2 — <para> for a full paragraph break (standard XML doc)
        /// <summary>
        /// <para>First paragraph.</para>
        /// <para>Second paragraph.</para>
        /// </summary>

        // ✅ Option 3 — combine both
        /// <summary>
        /// Short one-line description.
        /// <para>
        /// Longer explanation that spans<br/>
        /// multiple lines.
        /// </para>
        /// </summary>

        #endregion"Info about line breaks"
        
        
        public void DocumentRazorJSInterop()
        {
            // This method is a placeholder to demonstrate how to document Razor and JS interop.
            // You can add your implementation here.
        }

       
    }
}
