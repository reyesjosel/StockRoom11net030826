using System.ComponentModel;
using Save_Requested_EventArgs = MyStuff11net.Custom_Events_Args.Save_Requested_EventArgs;
using Timer = System.Windows.Forms.Timer;


/*
 * This class is free and open source and available for anyone's consumption
 * @Author: Jose C Gomez http://www.josecgomez.com
 */

namespace MyStuff11net
{
    /// <summary>
    /// This class generates a WYSIWYG control for HTML output.
    /// </summary>
    public partial class Htmlwysiwyg : UserControl
    {
        //  mshtml.IHTMLDocument2 doc;
        bool edits = true;
        //   readonly AppState _appState = new();
        //   readonly AppService _appService = new();

        #region"Properties"

        /// <summary>
        ///     Show the ScrollBars.
        /// </summary>
        [Description("Show the ScrollBars or not"),
        Category("Toolbar")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool ShowScrollBars
        {
            get { return true; }//htmlRenderer.ScrollBarsEnabled; }
            set
            {
                //  htmlRenderer.ScrollBarsEnabled = value;
            }
        }

        /// <summary>
        ///     Show the New Engineering change reguest button.
        ///     This stamp Data and label New Engineering change reguest:
        /// </summary>
        [Description("Show the New Engineering change reguest button or not"),
        Category("Toolbar")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool ShowNewEngineeringChange
        {
            get { return toolStripButton_New_Engineering_change_request.Visible; }
            set { toolStripButton_New_Engineering_change_request.Visible = value; UpdateToolbarSeperators(); }
        }

        /// <summary>
        ///     Show the New Engineering change reguest button.
        ///     This stamp Data and label New Engineering change reguest:
        /// </summary>
        [Description("Show the Save button or not"),
        Category("Toolbar")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool ShowSaveButton
        {
            get { return toolStripButton_Save.Visible; }
            set { toolStripButton_Save.Visible = value; UpdateToolbarSeperators(); }
        }

        /// <summary>
        ///     Show the back color button
        /// </summary>
        [Description("Show the back color button or not"),
        Category("Toolbar")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool ShowBackColorButton
        {
            get { return tsBackColor.Visible; }
            set { tsBackColor.Visible = value; UpdateToolbarSeperators(); }
        }

        /// <summary>
        ///     Show the new button
        /// </summary>
        [Description("Show the new button or not"),
        Category("Toolbar")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool ShowNewButton
        {
            get
            {
                return newTS.Visible;
            }
            set
            {
                newTS.Visible = value;
                UpdateToolbarSeperators();
            }
        }

        /// <summary>
        ///     Show the print button
        /// </summary>
        [Description("Show the new button or not"),
        Category("Toolbar")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool ShowPrintButton
        {
            get { return printToolStripButton.Visible; }
            set { printToolStripButton.Visible = value; UpdateToolbarSeperators(); }
        }

        /// <summary>
        ///     Show the cut button
        /// </summary>
        [Description("Show the cut button or not"),
        Category("Toolbar")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool ShowCutButton
        {
            get { return tsCut.Visible; }
            set { tsCut.Visible = value; UpdateToolbarSeperators(); }
        }

        /// <summary>
        ///     Show the copy button
        /// </summary>
        [Description("Show the copy button or not"),
        Category("Toolbar")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool ShowCopyButton
        {
            get { return tsCopy.Visible; }
            set { tsCopy.Visible = value; UpdateToolbarSeperators(); }
        }

        /// <summary>
        ///     Show the cut button
        /// </summary>
        [Description("Show the paste button or not"),
        Category("Toolbar")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool ShowPasteButton
        {
            get { return tsPaste.Visible; }
            set { tsPaste.Visible = value; UpdateToolbarSeperators(); }
        }

        /// <summary>
        ///     Show the cut button
        /// </summary>
        [Description("Show the bold button or not"),
        Category("Toolbar")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool ShowBolButton
        {
            get { return tsBold.Visible; }
            set { tsBold.Visible = value; UpdateToolbarSeperators(); }
        }

        /// <summary>
        ///     Show the cut button
        /// </summary>
        [Description("Show the underline button or not"),
        Category("Toolbar")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool ShowUnderlineButton
        {
            get { return tsUnderline.Visible; }
            set { tsUnderline.Visible = value; UpdateToolbarSeperators(); }
        }

        /// <summary>
        ///     Show the cut button
        /// </summary>
        [Description("Show the italics button or not"),
        Category("Toolbar")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool ShowItalicButton
        {
            get { return tsItalics.Visible; }
            set { tsItalics.Visible = value; UpdateToolbarSeperators(); }
        }

        /// <summary>
        ///     Show the cut button
        /// </summary>
        [Description("Show the Align Left button or not"),
        Category("Toolbar")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool ShowAlignLeftButton
        {
            get { return tsLeft.Visible; }
            set { tsLeft.Visible = value; UpdateToolbarSeperators(); }
        }

        /// <summary>
        ///     Show the cut button
        /// </summary>
        [Description("Show the Align Center button or not"),
        Category("Toolbar")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool ShowAlignCenterButton
        {
            get { return tsCenter.Visible; }
            set { tsCenter.Visible = value; UpdateToolbarSeperators(); }
        }

        private void tsJustify_Click(object sender, EventArgs e)
        {
            //  if (edits)
            //      doc.execCommand("JustifyFull", false, null);
        }
        /// <summary>
        ///     Show the cut button
        /// </summary>
        [Description("Show the Justify button or not"),
        Category("Toolbar")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool ShowJustifyButton
        {
            get { return tsJustify.Visible; }
            set { tsJustify.Visible = value; UpdateToolbarSeperators(); }
        }

        /// <summary>
        ///     Show the cut button
        /// </summary>
        [Description("Show the Align Right button or not"),
        Category("Toolbar")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool ShowAlignRightButton
        {
            get { return tsRight.Visible; }
            set { tsRight.Visible = value; UpdateToolbarSeperators(); }
        }

        /// <summary>
        ///     Show the cut button
        /// </summary>
        [Description("Show the Indent button or not"),
        Category("Toolbar")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool ShowIndentButton
        {
            get { return tsIndent.Visible; }
            set { tsIndent.Visible = value; UpdateToolbarSeperators(); }
        }

        /// <summary>
        ///     Show the cut button
        /// </summary>
        [Description("Show the Outdent button or not"),
        Category("Toolbar")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool ShowOutdentButton
        {
            get { return tsOutdent.Visible; }
            set { tsOutdent.Visible = value; UpdateToolbarSeperators(); }
        }

        [Description("Show the Bullet button or not"),
        Category("Toolbar")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool ShowBulletButton
        {
            get { return tsBullets.Visible; }
            set { tsBullets.Visible = value; UpdateToolbarSeperators(); }
        }

        [Description("Show the OutdentOrdered List button or not"),
        Category("Toolbar")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool ShowOrderedListButton
        {
            get { return tsNumeric.Visible; }
            set { tsNumeric.Visible = value; UpdateToolbarSeperators(); }
        }

        [Description("Show the Text Background color button"),
        Category("Toolbar")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool ShowTxtBGButton
        {
            get { return tsTextColor.Visible; }
            set { tsTextColor.Visible = value; UpdateToolbarSeperators(); }
        }

        [Description("Show the Text color button"),
        Category("Toolbar")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool ShowTxtColorButton
        {

            get { return tsTextColor.Visible; }
            set { tsTextColor.Visible = value; UpdateToolbarSeperators(); }
        }

        [Description("Show the Font Size button"),
        Category("Toolbar")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool ShowFontSizeButton
        {
            get { return tsFontSize.Visible; }
            set { tsFontSize.Visible = value; UpdateToolbarSeperators(); }
        }

        [Description("Show the Font Family button"),
        Category("Toolbar")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool ShowFontFamilyButton
        {
            get { return tsFontFamily.Visible; }
            set { tsFontFamily.Visible = value; UpdateToolbarSeperators(); }
        }

        [Description("Show the Link button"),
        Category("Toolbar")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool ShowLinkButton
        {
            get { return tsLink.Visible; }
            set { tsLink.Visible = value; UpdateToolbarSeperators(); }
        }

        [Description("Show the Unlink button"),
        Category("Toolbar")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool ShowUnlinkButton
        {
            get { return tsRemoveLink.Visible; }
            set { tsRemoveLink.Visible = value; UpdateToolbarSeperators(); }
        }

        #endregion"Properties"

        #region"Custom Controls Events with custom Args.*********************"

        #region "New Engineering Change Request"

        // # 1 ... Declare the event in the control class
        // put some information to Properties Manager.
        [Description("Engineering change request Event.")]
        [Browsable(true), Category("Controls Events")]
        public event NewEngineeringChangeRequest_EventHandler NewEngineeringChangeRequest;

        // # 2 ... ***** New Event Declaration. *****
        // Declare the delegates for this event:
        public delegate void NewEngineeringChangeRequest_EventHandler(object sender, NewEngineeringChangeRequest_EventArgs e);

        // # 3 ... Define and provide implementations for EventArgs
        // Declare the constructor and properties of custom Arg.
        public class NewEngineeringChangeRequest_EventArgs : EventArgs
        {
            // Constructor accepts two integer: the old value and the new value.
            public NewEngineeringChangeRequest_EventArgs(string title, string description, DateTime date)
            {
                Title = title;
                Description = description;
                Date = date;
            }

            public string Title { get; set; }
            public string Description { get; set; }
            public DateTime Date { get; set; }
        }

        // # 4 ... Declare the protected virtual methods for
        // this events, in this procedure we calling the event itself.
        protected virtual void On_NewEngineeringChangeRequest(NewEngineeringChangeRequest_EventArgs e)
        {
            NewEngineeringChangeRequest?.Invoke(this, e);
        }

        #endregion "New Engineering Change Request"

        #region"Save_Requested"

        // # 3 ... Declare the event in the control class
        // put some information to Properties Manager.
        [Category("Controls Events")]
        [Description("The User request a Save action")]
        public event Custom_Events_Args.Save_Requested_EventHandler Save_Requested;

        // # 4 ... Declare the protected virtual methods for
        // this events, in this procedure we calling the event itself.
        public virtual void On_Save_Requested(Save_Requested_EventArgs e)
        {
            Save_Requested?.Invoke(this, e);
        }

        #endregion

        #region"Text_Change"
        // # 1 ... ***** New Event Declaration. *****
        // Declare the delegates for this event:
        public delegate void Text_Change_EventHandler(object sender, Text_Change_EventArgs e);

        // # 2 ... Define and provide implementations for EventArgs
        // Declare the constructor and properties of custom Arg.
        public class Text_Change_EventArgs : EventArgs { }

        // # 3 ... Declare the event in the control class
        // put some information to Properties Manager.
        [Category("Controls Events")]
        [Description("Text Change action")]
        public event Text_Change_EventHandler Text_Change;

        // # 4 ... Declare the protected virtual methods for
        // this events, in this procedure we calling the event itself.
        public virtual void On_Text_Change(Text_Change_EventArgs e)
        {
            Text_Change?.Invoke(this, e);
        }
        #endregion

        #endregion"Custom Controls Events with custom Args.*********************"


        public Htmlwysiwyg()
        {
            InitializeComponent();

            HtmlwysiwygInitialise();
        }

        /// <summary>
        /// Returns the inner html generated
        /// </summary>
        /// <returns>String html</returns>
        public string getHTML()
        {
            return "";//doc.body.innerHTML;
        }

        /// <summary>
        /// Sets the Inner HTML of the documents (used to load docs into the editor)
        /// </summary>
        /// <param name="html"></param>
        public void setHTML(string html)
        {
            // doc.clear();
            // doc.body.innerHTML = html;
        }

        /// <summary>
        /// Returns the plain text without any formatting
        /// </summary>
        /// <returns>String plainText</returns>
        public string getPlainText()
        {
            return "";//doc.body.innerText;
        }

        private string _title;
        private string Title
        {
            get
            {
                return _title;
            }
            set
            {
                _title = value;
            }
        }

        private string _description;
        private string Description
        {
            get
            {
                return _description;
            }
            set
            {
                _description = value;
            }
        }

        //Sets the editor to either allow or disallow edit.
        public void AllowEdit(bool edit)
        {
            edits = edit;
            // if (edit)
            //doc.designMode = "On";
            // else
            //doc.designMode = "Off";
        }

        private void UpdateToolbarSeperators()
        {
            if (newTS.Visible || printToolStripButton.Visible)
                tsSeparator1.Visible = true;
            else
                tsSeparator1.Visible = false;

            if (tsCut.Visible || tsCopy.Visible || tsPaste.Visible)
                toolStripSeparator1.Visible = true;
            else
                toolStripSeparator1.Visible = false;

            if (tsBold.Visible || tsUnderline.Visible || tsItalics.Visible)
                toolStripSeparator2.Visible = true;
            else
                toolStripSeparator2.Visible = false;
            if (tsCenter.Visible || tsJustify.Visible || tsLeft.Visible || tsRight.Visible)
                toolStripSeparator3.Visible = true;
            else
                toolStripSeparator3.Visible = false;
            if (tsIndent.Visible || tsOutdent.Visible)
                toolStripSeparator4.Visible = true;
            else
                toolStripSeparator4.Visible = false;
            if (tsBullets.Visible || tsNumeric.Visible)
                toolStripSeparator5.Visible = true;
            else
                toolStripSeparator5.Visible = false;

            if (tsBackColor.Visible || tsTextColor.Visible)
                toolStripSeparator6.Visible = true;
            else
                toolStripSeparator6.Visible = false;

            if (tsLink.Visible || tsRemoveLink.Visible)
                toolStripSeparator7.Visible = true;
            else
                toolStripSeparator7.Visible = false;

        }


        private void HtmlwysiwygInitialise()
        {
            toolStripButton_Save.Enabled = false;

            // htmlRenderer.PreviewKeyDown += new PreviewKeyDownEventHandler(HtmlRenderer_PreviewKeyDown);

            toolStripButton_New_Engineering_change_request.Click += new EventHandler(ToolStripButton_New_Engineering_change_request_Click);
            toolStripButton_Save.Click += new EventHandler(ToolStripButton_Save_Click);
        }

        Timer tic_Key = new Timer();
        private void HtmlRenderer_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            tic_Key.Tick += new EventHandler(tic_Key_Tick);
            tic_Key.Interval = 50;
            tic_Key.Start();

            toolStripButton_Save.Enabled = true;
        }

        void tic_Key_Tick(object sender, EventArgs e)
        {
            tic_Key.Tick -= tic_Key_Tick;
            tic_Key.Stop();

            On_Text_Change(new Text_Change_EventArgs());
        }

        private void ToolStripButton_Save_Click(object sender, EventArgs e)
        {
            toolStripButton_Save.Enabled = false;
            On_Save_Requested(new Save_Requested_EventArgs(MyCode.NotificationEvents.DataBaseUpDated));
        }

        private void ToolStripButton_New_Engineering_change_request_Click(object sender, EventArgs e)
        {
            toolStripButton_New_Engineering_change_request.Enabled = false;

            using (Engineering_Change_Request engineeringRequestForm = new Engineering_Change_Request())
            {
                if (engineeringRequestForm.ShowDialog() == DialogResult.Cancel)
                    return;

                string ChangeRequest = "<P><FONT color=red><B>Engineering change request </B>(" + DateTime.Now.ToLongDateString() +
                                                                                    ") :</FONT></P><P><FONT color=black></FONT></P>";
                Title = engineeringRequestForm.Title;
                Description = engineeringRequestForm.Description;

                //   doc.body.innerHTML += ChangeRequest + Title + Description;

                toolStripButton_New_Engineering_change_request.Enabled = true;
                On_NewEngineeringChangeRequest(new NewEngineeringChangeRequest_EventArgs(Title, Description, DateTime.Now));
            }
        }

        private void RedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //   if (edits)
            //       doc.execCommand("BackColor", false, "red");
        }

        private void NewTS_Click(object sender, EventArgs e)
        {
            //  if (edits)
            //      doc.body.innerText = "";
        }

        private void PrintToolStripButton_Click(object sender, EventArgs e)
        {
            //  if (edits)
            //      doc.execCommand("Print", true, null);
        }

        private void CutToolStripButton_Click(object sender, EventArgs e)
        {
            if (edits)
                try
                {
                    // doc.execCommand("Cut", false, null);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error Couldn't Cut\n\r" + ex.Message, "Erro Executing Cut Command", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
        }

        private void CopyToolStripButton_Click(object sender, EventArgs e)
        {
            //  if (edits)
            //      doc.execCommand("Copy", false, null);
        }

        private void PasteToolStripButton_Click(object sender, EventArgs e)
        {
            //  if (edits)
            //      doc.execCommand("Paste", false, null);
        }

        private void TsBold_Click(object sender, EventArgs e)
        {
            // if (edits)
            //     doc.execCommand("Bold", false, null);
        }

        private void TsUnderline_Click(object sender, EventArgs e)
        {
            //  if (edits)
            //      doc.execCommand("Underline", false, null);
        }

        private void TsItalics_Click(object sender, EventArgs e)
        {
            //  if (edits)
            //      doc.execCommand("Italic", false, null);
        }

        private void TsLeft_Click(object sender, EventArgs e)
        {
            // if (edits)
            //     doc.execCommand("JustifyLeft", false, null);
        }

        private void TsRight_Click(object sender, EventArgs e)
        {
            //  if (edits)
            //      doc.execCommand("JustifyRight", false, null);
        }

        private void TsCenter_Click(object sender, EventArgs e)
        {
            //  if (edits)
            //      doc.execCommand("JustifyCenter", false, null);
        }

        private void TsIndent_Click(object sender, EventArgs e)
        {
            //  if (edits)
            //      doc.execCommand("Indent", false, null);
        }

        private void TsNumeric_Click(object sender, EventArgs e)
        {
            //   if (edits)
            //       doc.execCommand("InsertOrderedList", false, null);
        }

        private void TsOutdent_Click(object sender, EventArgs e)
        {
            //  if (edits)
            //      doc.execCommand("Outdent", false, null);
        }

        private void TsBullets_Click(object sender, EventArgs e)
        {
            //  if (edits)
            //      doc.execCommand("InsertUnorderedList", false, null);
        }

        private void BlueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //   if (edits)
            //       doc.execCommand("BackColor", false, "blue");
        }

        private void BlackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //   if (edits)
            //       doc.execCommand("BackColor", false, "black");
        }

        private void YellowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //   if (edits)
            //      doc.execCommand("BackColor", false, "yellow");
        }

        private void OrangeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //  if (edits)
            //      doc.execCommand("BackColor", false, "orange");
        }

        private void GreenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //   if (edits)
            //       doc.execCommand("BackColor", false, "green");
        }

        private void BrownToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //   if (edits)
            //       doc.execCommand("BackColor", false, "brown");
        }

        private void RedToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //   if (edits)
            //       doc.execCommand("ForeColor", false, "red");
        }

        private void BlueToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //   if (edits)
            //       doc.execCommand("ForeColor", false, "blue");
        }

        private void BlackToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //  if (edits)
            //      doc.execCommand("ForeColor", false, "black");
        }

        private void YellowToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //  if (edits)
            //      doc.execCommand("ForeColor", false, "yellow");
        }

        private void OrangeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //  if (edits)
            //      doc.execCommand("ForeColor", false, "orange");
        }

        private void GreenToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //  if (edits)
            //      doc.execCommand("ForeColor", false, "green");
        }

        private void BrownToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //  if (edits)
            //      doc.execCommand("ForeColor", false, "brown");
        }

        private void TsLink_Click(object sender, EventArgs e)
        {
            //   if (edits)
            //      doc.execCommand("CreateLink", true, null);
        }

        private void TsRemoveLink_Click(object sender, EventArgs e)
        {
            //   if (edits)
            //      doc.execCommand("Unlink", true, null);
        }

        private void ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            //  if (edits)
            //      doc.execCommand("FontSize", false, 1);
        }

        private void ToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            //   if (edits)
            //       doc.execCommand("FontSize", false, 2);
        }

        private void ToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            //   if (edits)
            //       doc.execCommand("FontSize", false, 3);
        }

        private void ToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            //  if (edits)
            //      doc.execCommand("FontSize", false, 4);
        }

        private void ToolStripMenuItem6_Click(object sender, EventArgs e)
        {
            //   if (edits)
            //       doc.execCommand("FontSize", false, 5);
        }

        private void ToolStripMenuItem7_Click(object sender, EventArgs e)
        {
            //  if (edits)
            //     doc.execCommand("FontSize", false, 6);
        }

        private void ToolStripMenuItem8_Click(object sender, EventArgs e)
        {
            //  if (edits)
            //      doc.execCommand("FontSize", false, 7);
        }

        private void VerdanaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //   if (edits)
            //       doc.execCommand("FontName", false, "Verdana");
        }

        private void AriaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //   if (edits)
            //       doc.execCommand("FontName", false, "Arial");
        }

        private void TimesNewRomanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //   if (edits)
            //       doc.execCommand("FontName", false, "Times New Roman");
        }

        private void CurrierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //   if (edits)
            //      doc.execCommand("FontName", false, "Currier New");
        }

        private void ComicSansToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //  if (edits)
            //      doc.execCommand("FontName", false, "Cambria");
        }

        private void HelveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //  if (edits)
            //      doc.execCommand("FontName", false, "Tahoma");
        }

        private void BookAntiquaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //   if (edits)
            //       doc.execCommand("FontName", false, "Book Antiqua");
        }

        private void TsFontSize_ButtonClick(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Allows you to add custome fonts to the control
        /// </summary>
        /// <param name="fontName"> Name of the font to add</param>
        public void AddFont(string fontName)
        {
            ToolStripMenuItem tsMi = new ToolStripMenuItem
            {
                Font = new Font(fontName, 9F),
                Name = fontName + "ToolStripMenuItem",
                Size = new Size(167, 22),
                Text = fontName
            };
            tsMi.Click += new EventHandler(AddFont_click);
            tsFontFamily.DropDownItems.Add(tsMi);
        }

        private void AddFont_click(object sender, EventArgs e)
        {
            //   if (edits)
            //       doc.execCommand("FontName", false, ((ToolStripMenuItem)sender).Text);
        }

        private void TsTextColor_Click(object sender, EventArgs e)
        {
            if (edits)
            {
                ColorDialog colorDialog = new ColorDialog();
                if (colorDialog.ShowDialog() != DialogResult.Cancel)
                {
                    //   doc.execCommand("ForeColor", false, ColorTranslator.ToHtml(colorDialog.Color).ToString());
                }
            }
        }

        private void TsBackColor_Click(object sender, EventArgs e)
        {
            if (edits)
            {
                ColorDialog colorDialog = new ColorDialog();
                if (colorDialog.ShowDialog() != DialogResult.Cancel)
                {
                    //  doc.execCommand("BackColor", false, ColorTranslator.ToHtml(colorDialog.Color).ToString());
                }
            }
        }

    }
}
