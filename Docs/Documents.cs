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

        #region "Info about code Bold, Italic text"

        // You can use the <b> HTML tag, which is supported by Visual Studio's IntelliSense
        // tooltip rendering and most doc generation tools:

        /// <summary>
        /// <b>First line.</b><br/>
        /// Second line.
        /// </summary>
        string exampleBold = "This is an example of bold text in XML documentation.";

        /// <summary>
        /// <i>First line.</i><br/>
        /// Second line.
        /// </summary>
        string exampleItalic = "This is an example of italic text in XML documentation.";

        /// <summary>
        /// <u>Underline text</u>
        /// </summary>
        string exampleUnderline = "This is an example of underlined text in XML documentation.";

        /// <summary>
        /// <b>Bold text</b> and <i>italic text</i> can be combined in the same documentation comment.<br/>
        /// </summary>
        string exampleBoldItalic = "This is an example of combined bold and italic text in XML documentation.";

        /// <summary>
        /// You can also use <br/> for line breaks within the same documentation comment.<br/>
        /// </summary>
        string exampleLineBreaks = "This is an example of line breaks in XML documentation.";

        /// <summary>
        /// <para> — paragraph break (this is the standard XML<br/> doc tag, preferred over in many style guides)</para>
        /// </summary>
        string exampleParagraphBreak = "This is an example of paragraph breaks in XML documentation.";

        /// <summary>
        /// Returns <c>true</c> if the document is saved; otherwise, <c>false</c>.
        /// Use the <c>DocumentId</c> property to look up the record in the <c>Documents</c> table.
        /// </summary>
        string exampleInlineCode = "This is an example of inline code formatting in XML documentation.";

        //  < -> &lt; > -> &gt;  & -> &amp;
        /// <summary>
        /// &lt;code&gt; is for a full block (often paired with &lt;example&gt;), while &lt;c&gt; is for small inline mentions.
        /// <example>
        /// <code>
        /// var doc = new Document();
        /// doc.Save();
        /// </code>
        /// </example>
        /// </summary>
        string exampleCodeBlock = "This is an example of a code block in XML documentation.";

        /// <summary>
        /// Saves the current <see cref="Document_Save()"/> instance to the database.
        /// </summary>
        /// <seealso cref="Document_Save"/>
        public static void Save() { }

        /// <see cref="Document"/>                        <!-- type -->
        /// <see cref="Document.Save"/>                    <!-- method -->
        /// <see cref="Document.Save()"/>                  <!-- method with overload disambiguation -->
        /// <see cref="Document.Save(int, string)"/>       <!-- specific overload -->
        /// <see cref="Document.Id"/>                      <!-- property/field -->
        /// <see cref="System.IO.File"/>                   <!-- fully qualified external type -->
        /// <see cref="List{T}"/>                          <!-- generic type -->


        public static void Document_Save()
        {
            // This method is a placeholder to demonstrate how creates a live, clickable
            // link to another code element (type, method, property, field, etc.),
        }




        #endregion "Info about code Bold, Italic text"
        
        public void DocumentRazorJSInterop()
        {
            // This method is a placeholder to demonstrate how to document Razor and JS interop.
            // You can add your implementation here.
        }

        
    }
}
