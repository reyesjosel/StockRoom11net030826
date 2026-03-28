using System.Text;

namespace MyStuff11net
{
    public static class HTML_Tags
    {
        public static string newLine = "<p>&nbsp;</p>";

        //   String.Format("<b>{0}</b> - ({1})", c.DepartmentAbbr, c.DepartmentName)

        public static string TextColor(string information, Color color)
        {
            if (information == "" || information == null)
                return newLine;

            var colorString = ColorTranslator.ToHtml(color);

            //return String.Format("<span style=\"color: {0};\">{1}</span>", colorString, information);
            return string.Format(@"<FONT color={0}>{1}</FONT>", colorString, information);
        }

        public static string NewLineColor(string information, Color color)
        {
            if (information == "" || information == null)
                return newLine;

            var InformationColor = TextColor(information, color);

            return string.Format("<p>{0}</p>", InformationColor);
        }

        public static string NewLine(string information)
        {
            if (information == "" || information == null)
                return newLine;

            return string.Format("<p>{0}</p>", information);
        }

        public static string NewLineBold(string information)
        {
            return string.Format("<p><strong>{0}</strong></p>", information);
        }

        public static string NewLineItalic(string information)
        {
            return string.Format("<p><em>{0}</em></p>", information);
        }

        public static string NewLineRed(string information)
        {
            if (information == "" || information == null)
                return newLine;

            return string.Format("<p><span style=\"color: #ff0000;\">{0}</span></p>", information);
        }

        public static string Bold(string information)
        {
            return string.Format("<strong>{0}</strong>", information);
        }

        public static string Italic(string information)
        {
            return string.Format("<em>{0}</em>", information);
        }

        public static string Underline(string information)
        {
            return string.Format("<p><span style=\"text-decoration: underline;\">{0}</span></p>", information);
        }

        public static string Strikethrough(string information)
        {
            return string.Format("<p><span style=\"text-decoration: line-through;\">{0}</span></p>", information);
        }

        public static string StraigthLine = "<hr />";

        /// <summary>
        /// To print pages, pagebreak
        /// </summary>
        /// <returns></returns>
        public static string PageBreak = "<!-- pagebreak --></p>";

        public static string Image(string information)
        {
            return string.Format("<p><img src=\"{0}\" border=\"0\" alt=\"Cool\" title=\"Cool\" />", information);
        }

        public const string TextWhereInsert = "<!-- Insert new information here. -->";

        /// <summary>
        /// Initialize the HTML file, insert head tag and title>!-- Insert Title here. --/title"
        /// the user close the head tag.
        /// </summary>
        /// <returns></returns>
        public static string InitializeHtmlFile()
        {
            var IniFile = "<!DOCTYPE html><html><head><meta http-equiv=\"Content-Type\" " +
                             "content=\"text/html; charset=utf-8\"><title><!-- Insert Title here. --></title>";

            return string.Format(IniFile);
        }

        /// <summary>
        /// Close the head tag ( /head> ) and open
        /// the body tag ( body> ).
        /// </summary>
        /// <returns></returns>
        public static string ClouseHeadOpenBody()
        {
            var HeadBody = "</head><body>";
            return HeadBody;
        }

        public static string ClouseBodyClouseHTML()
        {
            return "</body></html>";
        }

        /// <summary>
        /// Initialize table style CSS, insert into head> tag,
        /// will be effective to all table tag in the page.
        /// </summary>
        /// <returns></returns>
        public static string InitializeStyleCSSTable()
        {
            var tableCSS = "<style type=\"text/css\">" +
                "table{border-spacing: 0;font-family:Arial, Helvetica, sans-serif;color:#666;font-size:12px;background:#eaebec;" +
                "margin:5px;border:#ccc 1px solid;border-radius:10px;box-shadow: 0 1px 2px #d1d1d1;table-layout:fixed;}" +
                "table th {padding:10px;border:1px solid #e0e0e0;background: #ededed; }" +
                "table th:first-child {text-align: left;padding-left:10px; }" +
                "table tr:first-child th:first-child{border-top-left-radius:10px;}" +
                "table tr:first-child th:last-child{border-top-right-radius:10px;}" +
                "table tr{text-align: left;padding-left:20px;}" +
                "table tr td:first-child{text-align: left;padding-left:10px;border-left: 0;}" +
                "table tr td{padding:5px;border-top: 1px solid #e0e0e0;border-left: 1px solid #e0e0e0;background: #fafafa;}" +
                "table tr:nth-child(odd) td{background: #e6e6e6;}" +
                "table tr:last-child td{border-bottom:0;}" +
                "table tr:last-child td:first-child{border-bottom-left-radius:10px;}" +
                "table tr:last-child td:last-child{border-bottom-right-radius:10px;}" +
                "table tr:hover td{background: #d5d5d5;}" +
                                "</style>";

            return tableCSS;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="headers">List of column name.</param>
        /// <param name="rows">List of ComponentInformation, contains all data.</param>
        /// <returns></returns>
        public static string InsertHtmlTable(List<string> headers, List<ComponentInformation> rows)
        {
            var _tableIni = "<table><tbody>";
            var _tableEnd = "</tbody></table>";

            var _tableHeaders = new StringBuilder();
            _tableHeaders.Append("<tr>");
            foreach (string headerName in headers)
            {
                _tableHeaders.Append(string.Format("<th>{0}</th>", headerName));
            }
            _tableHeaders.Append("</tr>");

            var _tableRows = new StringBuilder();
            foreach (object item in rows)
            {
                var row = item as ComponentInformation;

                _tableRows.Append("<tr>");
                _tableRows.Append(string.Format("<td>{0}</td>", row.PartNumber));
                _tableRows.Append(string.Format("<td>{0}</td>", row.Description));
                _tableRows.Append(string.Format("<td>{0}</td>", string.Join(", ", row.Placements.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries))));
                _tableRows.Append(string.Format("<td>{0}</td>", row.Places));
                _tableRows.Append("</tr>");
            }

            return _tableIni + _tableHeaders + _tableRows.ToString() + _tableEnd;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="headers">List of column name.</param>
        /// <param name="rows">List of string arrays, contains all data.</param>
        /// <returns></returns>
        public static string InsertHtmlTable(List<string> headers, List<List<string>> rows)
        {
            var _tableIni = "<table><tbody>";
            var _tableEnd = "</tbody></table>";

            var _tableHeaders = new StringBuilder();
            _tableHeaders.Append("<tr>");
            foreach (string headerName in headers)
            {
                if (headerName.Contains("style"))
                    _tableHeaders.Append(string.Format("<th{0}</th>", headerName));
                else
                    _tableHeaders.Append(string.Format("<th>{0}</th>", headerName));
            }
            _tableHeaders.Append("</tr>");

            var _tableRows = new StringBuilder();
            foreach (List<string> itemList in rows)
            {
                _tableRows.Append("<tr>");
                foreach (string cellValue in itemList)
                {
                    if (cellValue.Contains("style"))
                        _tableRows.Append(string.Format("<td{0}</td>", cellValue));
                    else
                        _tableRows.Append(string.Format("<td>{0}</td>", cellValue));
                }
                _tableRows.Append("</tr>");
            }

            return _tableIni + _tableHeaders + _tableRows.ToString() + _tableEnd;
        }

        public static string Table_CompDescPlacements(List<ComponentInformation> rows)
        {
            var _tableIni = "<table><tbody>" +
                               "<tr><th>PartNumber</th><th>Description</th><th>Placements</th><th> # Places</th></tr>";

            var _tableEnd = "</tbody></table>";

            var _tableRows = new StringBuilder();

            foreach (object item in rows)
            {
                var row = item as ComponentInformation;

                _tableRows.Append("<tr>");
                _tableRows.Append(string.Format("<td>{0}</td>", row.PartNumber));
                _tableRows.Append(string.Format("<td>{0}</td>", row.Description));
                _tableRows.Append(string.Format("<td>{0}</td>", string.Join(", ", row.Placements.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries))));
                _tableRows.Append(string.Format("<td>{0}</td>", row.Places));
                _tableRows.Append("</tr>");
            }

            return _tableIni + _tableRows.ToString() + _tableEnd;
        }

        public static string Table_ReserveComp(List<ComponentInformation> rows)
        {
            var _tableIni = "<table><tbody>" +
                               "<tr><th>PartNumber</th><th>Description</th><th>Placements</th>" +
                               "<th># Places</th> <th>CompForProd</th> <th>OnHandBefore</th> <th>OnAvailable</th></tr>";

            var _tableEnd = "</tbody></table>";

            var _tableRows = new StringBuilder();

            foreach (object item in rows)
            {
                var row = item as ComponentInformation;

                _tableRows.Append("<tr>");
                _tableRows.Append(string.Format("<td>{0}</td>", row.PartNumber));
                _tableRows.Append(string.Format("<td>{0}</td>", row.Description));
                _tableRows.Append(string.Format("<td>{0}</td>", string.Join(", ", row.Placements.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries))));
                _tableRows.Append(string.Format("<td>{0}</td>", row.Places));
                _tableRows.Append(string.Format("<td>{0}</td>", row.CompForProduction));
                _tableRows.Append(string.Format("<td>{0}</td>", row.OnHandBefore));
                _tableRows.Append(string.Format("<td>{0}</td>", row.OnAvailable));
                _tableRows.Append("</tr>");
            }

            return _tableIni + _tableRows.ToString() + _tableEnd;
        }

        public static string Table_DiscountComp(List<ComponentInformation> rows)
        {
            var _tableIni = "<table><tbody>" +
                               "<tr><th>PartNumber</th><th>Description</th><th>Placements</th>" +
                               "<th># Places</th> <th>Discounted Components</th> <th>Reserved Components</th> <th>OnAvailable</th></tr>";

            var _tableEnd = "</tbody></table>";

            var _tableRows = new StringBuilder();

            foreach (object item in rows)
            {
                var row = item as ComponentInformation;

                _tableRows.Append("<tr>");
                _tableRows.Append(string.Format("<td>{0}</td>", row.PartNumber));
                _tableRows.Append(string.Format("<td>{0}</td>", row.Description));
                _tableRows.Append(string.Format("<td>{0}</td>", string.Join(", ", row.Placements.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries))));
                _tableRows.Append(string.Format("<td>{0}</td>", row.Places));
                _tableRows.Append(string.Format("<td>{0}</td>", row.CompForProduction));
                _tableRows.Append(string.Format("<td>{0}</td>", row.OnHandBefore));
                _tableRows.Append(string.Format("<td>{0}</td>", row.OnAvailable));
                _tableRows.Append("</tr>");
            }

            return _tableIni + _tableRows.ToString() + _tableEnd;
        }









        //////////////////////////////////////////////////////////////////////////////
        // This source code and all associated files and resources are copyrighted by
        // the author(s). This source code and all associated files and resources may
        // be used as long as they are used according to the terms and conditions set
        // forth in The Code Project Open License (CPOL), which may be viewed at
        // http://www.blackbeltcoder.com/Legal/Licenses/CPOL.
        //
        // Copyright (c) 2011 Jonathan Wood
        //

        private static string _paraBreak = "\r\n\r\n";
        private static string _link = "<a href=\"{0}\">{1}</a>";
        private static string _linkNoFollow = "<a href=\"{0}\" rel=\"nofollow\">{1}</a>";

        /// <summary>
        /// Returns a copy of this string converted to HTML markup.
        /// </summary>
        /// <param name="s">todo: describe s parameter on ToHtml</param>
        public static string ToHtml(this string s)
        {
            return ToHtml(s, false);
        }

        /// <summary>
        /// Returns a copy of this string converted to HTML markup.
        /// </summary>
        /// <param name="nofollow">If true, links are given "nofollow"
        /// attribute</param>
        /// <param name="s">todo: describe s parameter on ToHtml</param>
        public static string ToHtml(this string s, bool nofollow)
        {
            var sb = new StringBuilder();

            var pos = 0;
            while (pos < s.Length)
            {
                // Extract next paragraph
                var start = pos;
                pos = s.IndexOf(_paraBreak, start);
                if (pos < 0)
                    pos = s.Length;
                var para = s.Substring(start, pos - start).Trim();

                // Encode non-empty paragraph
                if (para.Length > 0)
                    EncodeParagraph(para, sb, nofollow);

                // Skip over paragraph break
                pos += _paraBreak.Length;
            }
            // Return result
            return sb.ToString();
        }

        /// <summary>
        /// Encodes a single paragraph to HTML.
        /// </summary>
        /// <param name="s">Text to encode</param>
        /// <param name="sb">StringBuilder to write results</param>
        /// <param name="nofollow">If true, links are given "nofollow"
        /// attribute</param>
        private static void EncodeParagraph(string s, StringBuilder sb, bool nofollow)
        {
            // Start new paragraph
            sb.AppendLine("<p>");

            // HTML encode text
            //       s = HttpUtility.HtmlEncode(s);

            // Convert single newlines to <br>
            //       s = s.Replace(Environment.NewLine, "<br />\r\n");

            // Encode any hyperlinks
            EncodeLinks(s, sb, nofollow);

            // Close paragraph
            sb.AppendLine("\r\n</p>");
        }

        /// <summary>
        /// Encodes [[URL]] and [[Text][URL]] links to HTML.
        /// </summary>
        /// <param name="text">Text to encode</param>
        /// <param name="sb">StringBuilder to write results</param>
        /// <param name="nofollow">If true, links are given "nofollow"
        /// attribute</param>
        /// <param name="s">todo: describe s parameter on EncodeLinks</param>
        private static void EncodeLinks(string s, StringBuilder sb, bool nofollow)
        {
            // Parse and encode any hyperlinks
            var pos = 0;
            while (pos < s.Length)
            {
                // Look for next link
                int start = pos;
                pos = s.IndexOf("[[", pos);
                if (pos < 0)
                    pos = s.Length;
                // Copy text before link
                sb.Append(s.Substring(start, pos - start));
                if (pos < s.Length)
                {
                    string label, link;

                    start = pos + 2;
                    pos = s.IndexOf("]]", start);
                    if (pos < 0)
                        pos = s.Length;
                    label = s.Substring(start, pos - start);
                    int i = label.IndexOf("][");
                    if (i >= 0)
                    {
                        link = label.Substring(i + 2);
                        label = label.Substring(0, i);
                    }
                    else
                    {
                        link = label;
                    }
                    // Append link
                    sb.Append(string.Format(nofollow ? _linkNoFollow : _link, link, label));

                    // Skip over closing "]]"
                    pos += 2;
                }
            }
        }



        private static void buttonReplaceCharsWithCodes_Click(object sender, EventArgs e)
        {
            var buttonCopyTextToClipboard = new Button();
            var textBoxMassagedResults = new TextBox();
            var labelProgFeedback = new Label();
            var progressBar = new ProgressBar();
            var openFileDialog = new OpenFileDialog();
            var fallName = string.Empty;
            var linesModified = new List<string>();
            StreamReader file = null;

            try // finally
            {
                try // catch
                {
                    var result = openFileDialog.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        fallName = openFileDialog.FileName;
                    }
                    using (file = new StreamReader(fallName, Encoding.Default, true))
                    {
                        string line;
                        while ((line = file.ReadLine()) != null)
                        {
                            linesModified.Add(line);
                        }
                        file.Close();
                    }
                    progressBar.Maximum = linesModified.Count;
                    progressBar.Value = 0;
                    labelProgFeedback.Text = "Replacing accented chars with HTML codes";

                    for (int i = 0; i < linesModified.Count; i++)
                    {
                        linesModified[i] = linesModified[i].Replace("á", "&aacute;");
                        linesModified[i] = linesModified[i].Replace("Á", "&Aacute;");
                        linesModified[i] = linesModified[i].Replace("é", "&eacute;");
                        linesModified[i] = linesModified[i].Replace("É", "&Eacute;");
                        linesModified[i] = linesModified[i].Replace("í", "&iacute;");
                        linesModified[i] = linesModified[i].Replace("Í", "&Iacute;");
                        linesModified[i] = linesModified[i].Replace("ñ", "&ntilde;");
                        linesModified[i] = linesModified[i].Replace("Ñ", "&Ntilde;");
                        linesModified[i] = linesModified[i].Replace("ó", "&oacute;");
                        linesModified[i] = linesModified[i].Replace("Ó", "&Oacute;");
                        linesModified[i] = linesModified[i].Replace("ú", "&uacute;");
                        linesModified[i] = linesModified[i].Replace("Ú", "&Uacute;");
                        linesModified[i] = linesModified[i].Replace("ü", "&uuml;");
                        linesModified[i] = linesModified[i].Replace("Ü", "&Uuml;");
                        linesModified[i] = linesModified[i].Replace("¿", "&iquest;");
                        linesModified[i] = linesModified[i].Replace("¡", "&iexcl;");
                        // Spanish above; German below
                        linesModified[i] = linesModified[i].Replace("Ä", "&Auml;");
                        linesModified[i] = linesModified[i].Replace("ä", "&auml;");
                        linesModified[i] = linesModified[i].Replace("Ö", "&Ouml;");
                        linesModified[i] = linesModified[i].Replace("ö", "&ouml;");
                        // U umlauted and E acutest already done - among the Spanish accents above
                        linesModified[i] = linesModified[i].Replace("ß", "&szlig;");
                        progressBar.PerformStep();
                    }
                    progressBar.Value = 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(string.Format("Exception {0}", ex.Message));
                }
            }
            finally
            {
                textBoxMassagedResults.Text = string.Join(Environment.NewLine, linesModified);
                var massagedFileName = string.Format("{0}_Massaged.txt", fallName);
                File.WriteAllLines(massagedFileName, linesModified, Encoding.UTF8);
                buttonCopyTextToClipboard.Enabled = true;
                labelProgFeedback.Text = string.Format("Finished! Massaged text below and saved as {0}", massagedFileName);
            }
        }

    }
}
