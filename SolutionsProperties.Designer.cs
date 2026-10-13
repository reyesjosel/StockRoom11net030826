using System.Drawing;
using System.Windows.Forms;

namespace StockRoom11net
{
    partial class SolutionsProperties
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            TreeNode treeNode1 = new TreeNode("Department Name");
            TreeNode treeNode2 = new TreeNode("Application DataBase Address");
            TreeNode treeNode3 = new TreeNode("Application Settings", 11, 11, new TreeNode[] { treeNode1, treeNode2 });
            TreeNode treeNode4 = new TreeNode("Send/Receive Notifycations");
            TreeNode treeNode5 = new TreeNode("Notifycations Options", 12, 12, new TreeNode[] { treeNode4 });
            TreeNode treeNode6 = new TreeNode("Recent Attached Dipositive", 7, 7);
            TreeNode treeNode7 = new TreeNode("Recent Detached Dipositive", 7, 7);
            TreeNode treeNode8 = new TreeNode("Recognized Devices in the System", 6, 7);
            TreeNode treeNode9 = new TreeNode("USB Device Utility", 9, 9, new TreeNode[] { treeNode6, treeNode7, treeNode8 });
            TreeNode treeNode10 = new TreeNode("Processor");
            TreeNode treeNode11 = new TreeNode("LogicalDisk");
            TreeNode treeNode12 = new TreeNode("VideoController");
            TreeNode treeNode13 = new TreeNode("System Information");
            TreeNode treeNode14 = new TreeNode("Applications Installed");
            TreeNode treeNode15 = new TreeNode("Installation Log", new TreeNode[] { treeNode10, treeNode11, treeNode12, treeNode13, treeNode14 });
            TreeNode treeNode16 = new TreeNode("Lock System Folder");
            TreeNode treeNode17 = new TreeNode("Security & Lock System Folder", new TreeNode[] { treeNode16 });
            TreeNode treeNode18 = new TreeNode("Register a DLL");
            TreeNode treeNode19 = new TreeNode("System Compatibility", 11, 11);
            TreeNode treeNode20 = new TreeNode("Search for PDF file within");
            TreeNode treeNode21 = new TreeNode("Convert files front this location");
            TreeNode treeNode22 = new TreeNode("Documentation", new TreeNode[] { treeNode20, treeNode21 });
            TreeNode treeNode23 = new TreeNode("Peer To Peer Management");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SolutionsProperties));
            folderBrowserDialog = new FolderBrowserDialog();
            _contextMenuStrip = new ContextMenuStrip(components);
            toolStripMenuItem_ClearDevices = new ToolStripMenuItem();
            toolStripMenuItem_Deleted_USB = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            imageListDrag = new ImageList(components);
            splitContainerSetting = new SplitContainer();
            treeViewApplicationsSetting = new TreeView();
            imageListTreeView = new ImageList(components);
            customTabControlSetting = new CustomTabControl();
            tabPageApplicationSetting = new TabPage();
            grouper7 = new CodeVendor.Controls.Grouper();
            radioButton2 = new RadioButton();
            radioButton1 = new RadioButton();
            grouper_ArgsToInitializarApp = new CodeVendor.Controls.Grouper();
            label_DescriptionInfo = new Label();
            label_Description = new Label();
            label_CompanyInfo = new Label();
            label_company = new Label();
            CheckBox_CreateStartupFolderShortcut = new CheckBox();
            CheckBox_ShowDesktopShortcut = new CheckBox();
            checkBox_CheckInternetAccess = new CheckBox();
            grouper_InfoArgsToInitializarApp = new CodeVendor.Controls.Grouper();
            richTextBox_InfoArgsToInitializarApp = new RichTextBox();
            grouper_DepartProperties = new CodeVendor.Controls.Grouper();
            textBox_DataBaseAddress = new TextBox();
            comboBox_ApplicationDepartmentName = new ComboBox();
            label_DataBaseAddress = new Label();
            label_DepartmentName = new Label();
            textBoxApplicationHTMLtemples = new TextBox();
            button_BrowserDataBase = new Button();
            button_ApplicationHTMLtemples = new Button();
            labelApplicationHTMLtemples = new Label();
            tabPageNotificationsOptions = new TabPage();
            grouper2 = new CodeVendor.Controls.Grouper();
            panel7 = new Panel();
            grouper_Notifycations = new CodeVendor.Controls.Grouper();
            checkBox_ShowEmailsNotifications = new CheckBox();
            checkBox_ShowDataBaseUpdateNotifications = new CheckBox();
            checkBox_ShowWarningsNotifications = new CheckBox();
            grouper3 = new CodeVendor.Controls.Grouper();
            checkBox_ShowMyOwnNotifications = new CheckBox();
            checkBox_SendMyOwnNotifications = new CheckBox();
            grouper4 = new CodeVendor.Controls.Grouper();
            label_IntervalSetTo = new Label();
            trackBar_Interval = new TrackBar();
            radioButton_Hours = new RadioButton();
            radioButton_Minutes = new RadioButton();
            radioButton_secund = new RadioButton();
            panel6 = new Panel();
            label1 = new Label();
            checkBox_EnableSendReceiveNotifycations = new CheckBox();
            checkBox_SetIntervalReadNotifications = new CheckBox();
            tabPageUSB_DeviceUtility = new TabPage();
            splitContainer1 = new SplitContainer();
            richTextBox1 = new RichTextBox();
            grouper_AddNewPrintHelpsButtons = new CodeVendor.Controls.Grouper();
            flowLayoutPanel_AddNewPrintHelpsButton = new FlowLayoutPanel();
            button_Adjustment = new Button();
            button_RemoveScanner = new Button();
            button_PrintHelps = new Button();
            button_AddNew = new Button();
            panel1 = new Panel();
            PicturesBox_Image = new PictureBox();
            tabPage_Documentation = new TabPage();
            grouper_DocumentationBehavior = new CodeVendor.Controls.Grouper();
            panel_NotDocumentToShow = new Panel();
            richTextBox_NotDocumentToShow = new RichTextBox();
            panel16 = new Panel();
            radioButton_NotDocumentToShow = new RadioButton();
            panel_LastTwoVersions = new Panel();
            richTextBox_LastTwoVersions = new RichTextBox();
            panel15 = new Panel();
            radioButton_LastTwoVersions = new RadioButton();
            panel_AllVersionsFound = new Panel();
            richTextBox_AllVersionsFound = new RichTextBox();
            panel13 = new Panel();
            radioButton_AllVersionsFound = new RadioButton();
            panel_TheLastRevision = new Panel();
            richTextBox_TheLastRevision = new RichTextBox();
            panel12 = new Panel();
            radioButton_TheLastRevision = new RadioButton();
            panel_SpecifiedDocument = new Panel();
            richTextBox_SpecifiedDocument = new RichTextBox();
            panel10 = new Panel();
            radioButton_SpecifiedDocument = new RadioButton();
            panel_DefaultDocument = new Panel();
            richTextBox_DefaultDocument = new RichTextBox();
            panel18 = new Panel();
            radioButton_DefaultDocument = new RadioButton();
            grouper_BrowserVersion = new CodeVendor.Controls.Grouper();
            richTextBox5 = new RichTextBox();
            tabPage_SearchForPDFFileWithin = new TabPage();
            grouper_DefinedAddressDocumentation = new CodeVendor.Controls.Grouper();
            documentsAddressGroup_SearchForPDFfileWithin = new StockRoom11net.Controls.DocumentationBehavior.DocumentsAddressGroup();
            panel_Space2 = new Panel();
            grouper_SearchForPDFfileWithin = new CodeVendor.Controls.Grouper();
            richTextBox_SearchForPDFfileWithin = new RichTextBox();
            panel_Space_SearchForPDFfileWithin = new Panel();
            tabPage_ConvertFilesFrontThisLocation = new TabPage();
            grouper_ConvertFilesFrontThisLocation = new CodeVendor.Controls.Grouper();
            scanDocumentsAddressGroup_Default = new StockRoom11net.Controls.DocumentationBehavior.ScanDocumentsAddressGroup();
            panel_ScanTheseFoltherFor = new Panel();
            grouper_ConvertFilesFrontThisLocationInformation = new CodeVendor.Controls.Grouper();
            richTextBox7 = new RichTextBox();
            panel_ScanTheseFoltherForInformation = new Panel();
            tabControlExtendBase = new CustomTabControl();
            grouper_ButtonSaveCancel = new CodeVendor.Controls.Grouper();
            button_Save_Exit = new Button();
            button_Cancel = new Button();
            _contextMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainerSetting).BeginInit();
            splitContainerSetting.Panel1.SuspendLayout();
            splitContainerSetting.Panel2.SuspendLayout();
            splitContainerSetting.SuspendLayout();
            customTabControlSetting.SuspendLayout();
            tabPageApplicationSetting.SuspendLayout();
            grouper7.SuspendLayout();
            grouper_ArgsToInitializarApp.SuspendLayout();
            grouper_InfoArgsToInitializarApp.SuspendLayout();
            grouper_DepartProperties.SuspendLayout();
            tabPageNotificationsOptions.SuspendLayout();
            grouper2.SuspendLayout();
            panel7.SuspendLayout();
            grouper_Notifycations.SuspendLayout();
            grouper3.SuspendLayout();
            grouper4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)trackBar_Interval).BeginInit();
            panel6.SuspendLayout();
            tabPageUSB_DeviceUtility.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            grouper_AddNewPrintHelpsButtons.SuspendLayout();
            flowLayoutPanel_AddNewPrintHelpsButton.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)PicturesBox_Image).BeginInit();
            tabPage_Documentation.SuspendLayout();
            grouper_DocumentationBehavior.SuspendLayout();
            panel_NotDocumentToShow.SuspendLayout();
            panel_LastTwoVersions.SuspendLayout();
            panel_AllVersionsFound.SuspendLayout();
            panel_TheLastRevision.SuspendLayout();
            panel_SpecifiedDocument.SuspendLayout();
            panel_DefaultDocument.SuspendLayout();
            grouper_BrowserVersion.SuspendLayout();
            tabPage_SearchForPDFFileWithin.SuspendLayout();
            grouper_DefinedAddressDocumentation.SuspendLayout();
            grouper_SearchForPDFfileWithin.SuspendLayout();
            tabPage_ConvertFilesFrontThisLocation.SuspendLayout();
            grouper_ConvertFilesFrontThisLocation.SuspendLayout();
            grouper_ConvertFilesFrontThisLocationInformation.SuspendLayout();
            grouper_ButtonSaveCancel.SuspendLayout();
            SuspendLayout();
            // 
            // _contextMenuStrip
            // 
            _contextMenuStrip.BackColor = Color.LightGoldenrodYellow;
            _contextMenuStrip.ImeMode = ImeMode.On;
            _contextMenuStrip.Items.AddRange(new ToolStripItem[] { toolStripMenuItem_ClearDevices, toolStripMenuItem_Deleted_USB, toolStripSeparator1 });
            _contextMenuStrip.LayoutStyle = ToolStripLayoutStyle.HorizontalStackWithOverflow;
            _contextMenuStrip.Name = "PreviewDataGridViewContextMenuStrip";
            _contextMenuStrip.RenderMode = ToolStripRenderMode.Professional;
            _contextMenuStrip.ShowImageMargin = false;
            _contextMenuStrip.Size = new Size(189, 62);
            _contextMenuStrip.Opening += ContextMenuStrip_Opening;
            // 
            // toolStripMenuItem_ClearDevices
            // 
            toolStripMenuItem_ClearDevices.Name = "toolStripMenuItem_ClearDevices";
            toolStripMenuItem_ClearDevices.Size = new Size(188, 26);
            toolStripMenuItem_ClearDevices.Text = "Clear devices.";
            toolStripMenuItem_ClearDevices.Click += ToolStripMenuItem_ClearDevices_Click;
            // 
            // toolStripMenuItem_Deleted_USB
            // 
            toolStripMenuItem_Deleted_USB.ImageTransparentColor = Color.White;
            toolStripMenuItem_Deleted_USB.Name = "toolStripMenuItem_Deleted_USB";
            toolStripMenuItem_Deleted_USB.Size = new Size(188, 26);
            toolStripMenuItem_Deleted_USB.Text = "Deleted this device.";
            toolStripMenuItem_Deleted_USB.Click += ToolStripMenuItem_Deleted_USB_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(185, 6);
            // 
            // imageListDrag
            // 
            imageListDrag.ColorDepth = ColorDepth.Depth32Bit;
            imageListDrag.ImageSize = new Size(16, 16);
            imageListDrag.TransparentColor = Color.Transparent;
            // 
            // splitContainerSetting
            // 
            splitContainerSetting.BorderStyle = BorderStyle.Fixed3D;
            splitContainerSetting.Dock = DockStyle.Fill;
            splitContainerSetting.Font = new Font("Microsoft Sans Serif", 12F);
            splitContainerSetting.Location = new Point(10, 10);
            splitContainerSetting.Name = "splitContainerSetting";
            // 
            // splitContainerSetting.Panel1
            // 
            splitContainerSetting.Panel1.Controls.Add(treeViewApplicationsSetting);
            splitContainerSetting.Panel1MinSize = 125;
            // 
            // splitContainerSetting.Panel2
            // 
            splitContainerSetting.Panel2.Controls.Add(customTabControlSetting);
            splitContainerSetting.Panel2MinSize = 125;
            splitContainerSetting.Size = new Size(1487, 667);
            splitContainerSetting.SplitterDistance = 379;
            splitContainerSetting.TabIndex = 11;
            // 
            // treeViewApplicationsSetting
            // 
            treeViewApplicationsSetting.AllowDrop = true;
            treeViewApplicationsSetting.ContextMenuStrip = _contextMenuStrip;
            treeViewApplicationsSetting.Dock = DockStyle.Fill;
            treeViewApplicationsSetting.Font = new Font("Microsoft Sans Serif", 12F);
            treeViewApplicationsSetting.HideSelection = false;
            treeViewApplicationsSetting.ImageIndex = 0;
            treeViewApplicationsSetting.ImageList = imageListTreeView;
            treeViewApplicationsSetting.Location = new Point(0, 0);
            treeViewApplicationsSetting.Margin = new Padding(16, 11, 16, 11);
            treeViewApplicationsSetting.Name = "treeViewApplicationsSetting";
            treeNode1.Name = "Node_DepartmentName";
            treeNode1.SelectedImageIndex = 7;
            treeNode1.Text = "Department Name";
            treeNode2.Name = "Node_ApplicationDataBaseAddress";
            treeNode2.SelectedImageIndex = 7;
            treeNode2.Text = "Application DataBase Address";
            treeNode3.ImageIndex = 11;
            treeNode3.Name = "Node_ApplicationSettings";
            treeNode3.SelectedImageIndex = 11;
            treeNode3.Text = "Application Settings";
            treeNode4.Name = "Node_SendReceiveNotifycations";
            treeNode4.SelectedImageIndex = 7;
            treeNode4.Text = "Send/Receive Notifycations";
            treeNode5.ImageIndex = 12;
            treeNode5.Name = "Node_NotifycationsOptions";
            treeNode5.SelectedImageIndex = 12;
            treeNode5.Text = "Notifycations Options";
            treeNode6.ImageIndex = 7;
            treeNode6.Name = "Node_RecentAttachedDipositive";
            treeNode6.SelectedImageIndex = 7;
            treeNode6.Text = "Recent Attached Dipositive";
            treeNode7.ImageIndex = 7;
            treeNode7.Name = "Node_RecentDetachedDipositive";
            treeNode7.SelectedImageIndex = 7;
            treeNode7.Text = "Recent Detached Dipositive";
            treeNode8.ImageIndex = 6;
            treeNode8.Name = "Node_RecognizedDevicesSystem";
            treeNode8.SelectedImageIndex = 7;
            treeNode8.Text = "Recognized Devices in the System";
            treeNode9.ImageIndex = 9;
            treeNode9.Name = "Node_USBDeviceUtility";
            treeNode9.SelectedImageIndex = 9;
            treeNode9.Text = "USB Device Utility";
            treeNode10.Name = "Node_Processor";
            treeNode10.SelectedImageIndex = 7;
            treeNode10.Text = "Processor";
            treeNode11.Name = "Node_LogicalDisk";
            treeNode11.SelectedImageIndex = 7;
            treeNode11.Text = "LogicalDisk";
            treeNode12.Name = "Node_VideoController";
            treeNode12.SelectedImageIndex = 7;
            treeNode12.Text = "VideoController";
            treeNode13.Name = "Node_SystemInformation";
            treeNode13.SelectedImageIndex = 7;
            treeNode13.Text = "System Information";
            treeNode14.Name = "Node_AppIntalled";
            treeNode14.SelectedImageIndex = 7;
            treeNode14.Text = "Applications Installed";
            treeNode15.ImageKey = "Display2.png";
            treeNode15.Name = "Node_InstallationLog";
            treeNode15.SelectedImageIndex = 0;
            treeNode15.Text = "Installation Log";
            treeNode16.Name = "Node_LockSystemFolder";
            treeNode16.Text = "Lock System Folder";
            treeNode17.Name = "Node_SecurityLockSystemFolder";
            treeNode17.Text = "Security & Lock System Folder";
            treeNode18.Name = "Node_RegisteraDLL";
            treeNode18.Text = "Register a DLL";
            treeNode19.ImageIndex = 11;
            treeNode19.Name = "Node_SystemCompatibility";
            treeNode19.SelectedImageIndex = 11;
            treeNode19.Text = "System Compatibility";
            treeNode20.Name = "Node_SearchForPDFFileWithin";
            treeNode20.Text = "Search for PDF file within";
            treeNode21.Name = "Node_ConvertFilesFrontThisLocation";
            treeNode21.Text = "Convert files front this location";
            treeNode22.Name = "Node_Documentation";
            treeNode22.Text = "Documentation";
            treeNode23.Name = "Node_PeerToPeerManagement";
            treeNode23.Text = "Peer To Peer Management";
            treeViewApplicationsSetting.Nodes.AddRange(new TreeNode[] { treeNode3, treeNode5, treeNode9, treeNode15, treeNode17, treeNode18, treeNode19, treeNode22, treeNode23 });
            treeViewApplicationsSetting.SelectedImageIndex = 0;
            treeViewApplicationsSetting.Size = new Size(375, 663);
            treeViewApplicationsSetting.TabIndex = 0;
            // 
            // imageListTreeView
            // 
            imageListTreeView.ColorDepth = ColorDepth.Depth32Bit;
            imageListTreeView.ImageStream = (ImageListStreamer)resources.GetObject("imageListTreeView.ImageStream");
            imageListTreeView.TransparentColor = Color.Transparent;
            imageListTreeView.Images.SetKeyName(0, "");
            imageListTreeView.Images.SetKeyName(1, "Select.ico");
            imageListTreeView.Images.SetKeyName(2, "Stop.ico");
            imageListTreeView.Images.SetKeyName(3, "Tips.png");
            imageListTreeView.Images.SetKeyName(4, "Delete.png");
            imageListTreeView.Images.SetKeyName(5, "Yellow flag.png");
            imageListTreeView.Images.SetKeyName(6, "Green flag.png");
            imageListTreeView.Images.SetKeyName(7, "Red flag.png");
            imageListTreeView.Images.SetKeyName(8, "newfeature.png");
            imageListTreeView.Images.SetKeyName(9, "USB1.png");
            imageListTreeView.Images.SetKeyName(10, "Settings.png");
            imageListTreeView.Images.SetKeyName(11, "Windows_Tools.png");
            imageListTreeView.Images.SetKeyName(12, "Warning48.png");
            imageListTreeView.Images.SetKeyName(13, "download.jpg");
            imageListTreeView.Images.SetKeyName(14, "Display2.png");
            imageListTreeView.Images.SetKeyName(15, "Arrow.png");
            imageListTreeView.Images.SetKeyName(16, "Task_Manager.ico");
            // 
            // customTabControlSetting
            // 
            customTabControlSetting.Alignment = TabAlignment.Bottom;
            customTabControlSetting.AlignmentExtended = TabAlignment.Bottom;
            customTabControlSetting.AppearanceExtended = TabAppearance.Normal;
            customTabControlSetting.Controls.Add(tabPageApplicationSetting);
            customTabControlSetting.Controls.Add(tabPageNotificationsOptions);
            customTabControlSetting.Controls.Add(tabPageUSB_DeviceUtility);
            customTabControlSetting.Controls.Add(tabPage_Documentation);
            customTabControlSetting.Controls.Add(tabPage_SearchForPDFFileWithin);
            customTabControlSetting.Controls.Add(tabPage_ConvertFilesFrontThisLocation);
            customTabControlSetting.DisplayStyle = TabStyle.Chrome;
            customTabControlSetting.Dock = DockStyle.Fill;
            customTabControlSetting.HotTrack = true;
            customTabControlSetting.HotTrackExtended = true;
            customTabControlSetting.Location = new Point(0, 0);
            customTabControlSetting.Margin = new Padding(16, 11, 16, 11);
            customTabControlSetting.MultilineExtended = false;
            customTabControlSetting.Name = "customTabControlSetting";
            customTabControlSetting.Padding = new Point(21, 5);
            customTabControlSetting.PaddingExtended = new Point(7, 5);
            customTabControlSetting.SelectedIndex = 0;
            customTabControlSetting.Size = new Size(1100, 663);
            customTabControlSetting.TabIndex = 0;
            // 
            // tabPageApplicationSetting
            // 
            tabPageApplicationSetting.Controls.Add(grouper7);
            tabPageApplicationSetting.Controls.Add(grouper_ArgsToInitializarApp);
            tabPageApplicationSetting.Controls.Add(grouper_DepartProperties);
            tabPageApplicationSetting.Location = new Point(4, 4);
            tabPageApplicationSetting.Margin = new Padding(16, 11, 16, 11);
            tabPageApplicationSetting.Name = "tabPageApplicationSetting";
            tabPageApplicationSetting.Padding = new Padding(16, 11, 16, 11);
            tabPageApplicationSetting.Size = new Size(1092, 625);
            tabPageApplicationSetting.TabIndex = 0;
            tabPageApplicationSetting.Text = "   Application Settings";
            tabPageApplicationSetting.UseVisualStyleBackColor = true;
            // 
            // grouper7
            // 
            grouper7.BackgroundColor = SystemColors.Control;
            grouper7.BackgroundGradientColor = Color.White;
            grouper7.BackgroundGradientMode = CodeVendor.Controls.Grouper.GroupBoxGradientMode.None;
            grouper7.BorderColor = Color.Black;
            grouper7.BorderThickness = 1F;
            grouper7.Controls.Add(radioButton2);
            grouper7.Controls.Add(radioButton1);
            grouper7.CustomGroupBoxColor = Color.White;
            grouper7.Dock = DockStyle.Fill;
            grouper7.GroupTitle = "Pictures.";
            grouper7.Location = new Point(16, 216);
            grouper7.Margin = new Padding(1, 14, 1, 1);
            grouper7.Name = "grouper7";
            grouper7.Padding = new Padding(113, 86, 113, 71);
            grouper7.PaintGroupBox = false;
            grouper7.RoundCorners = 10;
            grouper7.ShadowColor = Color.DarkGray;
            grouper7.ShadowControl = false;
            grouper7.ShadowThickness = 3;
            grouper7.Size = new Size(1060, 158);
            grouper7.TabIndex = 15;
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Location = new Point(55, 88);
            radioButton2.Margin = new Padding(12, 2, 12, 2);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(74, 24);
            radioButton2.TabIndex = 23;
            radioButton2.Text = "Hours.";
            radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Location = new Point(55, 45);
            radioButton1.Margin = new Padding(12, 2, 12, 2);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(74, 24);
            radioButton1.TabIndex = 22;
            radioButton1.Text = "Hours.";
            radioButton1.UseVisualStyleBackColor = true;
            // 
            // grouper_ArgsToInitializarApp
            // 
            grouper_ArgsToInitializarApp.BackgroundColor = SystemColors.Control;
            grouper_ArgsToInitializarApp.BackgroundGradientColor = Color.White;
            grouper_ArgsToInitializarApp.BackgroundGradientMode = CodeVendor.Controls.Grouper.GroupBoxGradientMode.None;
            grouper_ArgsToInitializarApp.BorderColor = Color.Black;
            grouper_ArgsToInitializarApp.BorderThickness = 1F;
            grouper_ArgsToInitializarApp.Controls.Add(label_DescriptionInfo);
            grouper_ArgsToInitializarApp.Controls.Add(label_Description);
            grouper_ArgsToInitializarApp.Controls.Add(label_CompanyInfo);
            grouper_ArgsToInitializarApp.Controls.Add(label_company);
            grouper_ArgsToInitializarApp.Controls.Add(CheckBox_CreateStartupFolderShortcut);
            grouper_ArgsToInitializarApp.Controls.Add(CheckBox_ShowDesktopShortcut);
            grouper_ArgsToInitializarApp.Controls.Add(checkBox_CheckInternetAccess);
            grouper_ArgsToInitializarApp.Controls.Add(grouper_InfoArgsToInitializarApp);
            grouper_ArgsToInitializarApp.CustomGroupBoxColor = Color.White;
            grouper_ArgsToInitializarApp.Dock = DockStyle.Bottom;
            grouper_ArgsToInitializarApp.GroupTitle = "Args to initializar the App.";
            grouper_ArgsToInitializarApp.Location = new Point(16, 374);
            grouper_ArgsToInitializarApp.Margin = new Padding(1, 14, 1, 1);
            grouper_ArgsToInitializarApp.Name = "grouper_ArgsToInitializarApp";
            grouper_ArgsToInitializarApp.Padding = new Padding(25, 25, 25, 20);
            grouper_ArgsToInitializarApp.PaintGroupBox = false;
            grouper_ArgsToInitializarApp.RoundCorners = 10;
            grouper_ArgsToInitializarApp.ShadowColor = Color.DarkGray;
            grouper_ArgsToInitializarApp.ShadowControl = false;
            grouper_ArgsToInitializarApp.ShadowThickness = 3;
            grouper_ArgsToInitializarApp.Size = new Size(1060, 240);
            grouper_ArgsToInitializarApp.TabIndex = 16;
            // 
            // label_DescriptionInfo
            // 
            label_DescriptionInfo.AutoSize = true;
            label_DescriptionInfo.Location = new Point(45, 200);
            label_DescriptionInfo.Margin = new Padding(16, 0, 16, 0);
            label_DescriptionInfo.Name = "label_DescriptionInfo";
            label_DescriptionInfo.Size = new Size(52, 21);
            label_DescriptionInfo.TabIndex = 29;
            label_DescriptionInfo.Text = "label5";
            // 
            // label_Description
            // 
            label_Description.AutoSize = true;
            label_Description.Location = new Point(45, 168);
            label_Description.Margin = new Padding(16, 0, 16, 0);
            label_Description.Name = "label_Description";
            label_Description.Size = new Size(89, 21);
            label_Description.TabIndex = 28;
            label_Description.Text = "Description";
            // 
            // label_CompanyInfo
            // 
            label_CompanyInfo.AutoSize = true;
            label_CompanyInfo.Location = new Point(179, 199);
            label_CompanyInfo.Margin = new Padding(16, 0, 16, 0);
            label_CompanyInfo.Name = "label_CompanyInfo";
            label_CompanyInfo.Size = new Size(52, 21);
            label_CompanyInfo.TabIndex = 27;
            label_CompanyInfo.Text = "label3";
            // 
            // label_company
            // 
            label_company.AutoSize = true;
            label_company.Location = new Point(179, 166);
            label_company.Margin = new Padding(16, 0, 16, 0);
            label_company.Name = "label_company";
            label_company.Size = new Size(77, 21);
            label_company.TabIndex = 26;
            label_company.Text = "Company";
            // 
            // CheckBox_CreateStartupFolderShortcut
            // 
            CheckBox_CreateStartupFolderShortcut.AutoSize = true;
            CheckBox_CreateStartupFolderShortcut.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            CheckBox_CreateStartupFolderShortcut.Location = new Point(338, 165);
            CheckBox_CreateStartupFolderShortcut.Margin = new Padding(16, 11, 16, 11);
            CheckBox_CreateStartupFolderShortcut.Name = "CheckBox_CreateStartupFolderShortcut";
            CheckBox_CreateStartupFolderShortcut.Size = new Size(169, 30);
            CheckBox_CreateStartupFolderShortcut.TabIndex = 25;
            CheckBox_CreateStartupFolderShortcut.Text = "Create Startup Folder Shortcut\r\n(Starts App When You Login)";
            CheckBox_CreateStartupFolderShortcut.UseVisualStyleBackColor = true;
            CheckBox_CreateStartupFolderShortcut.CheckedChanged += CheckBox_CreateStartupFolderShortcut_CheckedChanged;
            // 
            // CheckBox_ShowDesktopShortcut
            // 
            CheckBox_ShowDesktopShortcut.AutoSize = true;
            CheckBox_ShowDesktopShortcut.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            CheckBox_ShowDesktopShortcut.Location = new Point(566, 172);
            CheckBox_ShowDesktopShortcut.Margin = new Padding(16, 11, 16, 11);
            CheckBox_ShowDesktopShortcut.Name = "CheckBox_ShowDesktopShortcut";
            CheckBox_ShowDesktopShortcut.Size = new Size(139, 17);
            CheckBox_ShowDesktopShortcut.TabIndex = 24;
            CheckBox_ShowDesktopShortcut.Text = "Show Desktop Shortcut";
            CheckBox_ShowDesktopShortcut.UseVisualStyleBackColor = true;
            CheckBox_ShowDesktopShortcut.CheckedChanged += CheckBox_ShowDesktopShortcut_CheckedChanged;
            // 
            // checkBox_CheckInternetAccess
            // 
            checkBox_CheckInternetAccess.AutoSize = true;
            checkBox_CheckInternetAccess.Location = new Point(737, 165);
            checkBox_CheckInternetAccess.Margin = new Padding(16, 11, 16, 11);
            checkBox_CheckInternetAccess.Name = "checkBox_CheckInternetAccess";
            checkBox_CheckInternetAccess.Size = new Size(214, 24);
            checkBox_CheckInternetAccess.TabIndex = 23;
            checkBox_CheckInternetAccess.Text = "Check for Internet access.";
            checkBox_CheckInternetAccess.UseVisualStyleBackColor = true;
            checkBox_CheckInternetAccess.CheckedChanged += checkBox_CheckInternetAccess_CheckedChanged;
            // 
            // grouper_InfoArgsToInitializarApp
            // 
            grouper_InfoArgsToInitializarApp.BackgroundColor = Color.LightGoldenrodYellow;
            grouper_InfoArgsToInitializarApp.BackgroundGradientColor = Color.Gainsboro;
            grouper_InfoArgsToInitializarApp.BackgroundGradientMode = CodeVendor.Controls.Grouper.GroupBoxGradientMode.None;
            grouper_InfoArgsToInitializarApp.BorderColor = Color.DarkGoldenrod;
            grouper_InfoArgsToInitializarApp.BorderThickness = 1F;
            grouper_InfoArgsToInitializarApp.Controls.Add(richTextBox_InfoArgsToInitializarApp);
            grouper_InfoArgsToInitializarApp.CustomGroupBoxColor = Color.White;
            grouper_InfoArgsToInitializarApp.Dock = DockStyle.Top;
            grouper_InfoArgsToInitializarApp.GroupTitle = "";
            grouper_InfoArgsToInitializarApp.Location = new Point(25, 25);
            grouper_InfoArgsToInitializarApp.Margin = new Padding(1, 14, 1, 1);
            grouper_InfoArgsToInitializarApp.MaximumSize = new Size(0, 200);
            grouper_InfoArgsToInitializarApp.Name = "grouper_InfoArgsToInitializarApp";
            grouper_InfoArgsToInitializarApp.Padding = new Padding(20, 20, 20, 10);
            grouper_InfoArgsToInitializarApp.PaintGroupBox = false;
            grouper_InfoArgsToInitializarApp.RoundCorners = 10;
            grouper_InfoArgsToInitializarApp.ShadowColor = Color.DarkGray;
            grouper_InfoArgsToInitializarApp.ShadowControl = false;
            grouper_InfoArgsToInitializarApp.ShadowThickness = 3;
            grouper_InfoArgsToInitializarApp.Size = new Size(1010, 122);
            grouper_InfoArgsToInitializarApp.TabIndex = 22;
            // 
            // richTextBox_InfoArgsToInitializarApp
            // 
            richTextBox_InfoArgsToInitializarApp.BackColor = Color.LightGoldenrodYellow;
            richTextBox_InfoArgsToInitializarApp.BorderStyle = BorderStyle.None;
            richTextBox_InfoArgsToInitializarApp.DetectUrls = false;
            richTextBox_InfoArgsToInitializarApp.Dock = DockStyle.Fill;
            richTextBox_InfoArgsToInitializarApp.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            richTextBox_InfoArgsToInitializarApp.Location = new Point(20, 20);
            richTextBox_InfoArgsToInitializarApp.Margin = new Padding(16, 11, 16, 11);
            richTextBox_InfoArgsToInitializarApp.Name = "richTextBox_InfoArgsToInitializarApp";
            richTextBox_InfoArgsToInitializarApp.ReadOnly = true;
            richTextBox_InfoArgsToInitializarApp.ShortcutsEnabled = false;
            richTextBox_InfoArgsToInitializarApp.Size = new Size(970, 92);
            richTextBox_InfoArgsToInitializarApp.TabIndex = 1;
            richTextBox_InfoArgsToInitializarApp.Text = "";
            // 
            // grouper_DepartProperties
            // 
            grouper_DepartProperties.BackgroundColor = SystemColors.Control;
            grouper_DepartProperties.BackgroundGradientColor = Color.White;
            grouper_DepartProperties.BackgroundGradientMode = CodeVendor.Controls.Grouper.GroupBoxGradientMode.None;
            grouper_DepartProperties.BorderColor = Color.Black;
            grouper_DepartProperties.BorderThickness = 1F;
            grouper_DepartProperties.Controls.Add(textBox_DataBaseAddress);
            grouper_DepartProperties.Controls.Add(comboBox_ApplicationDepartmentName);
            grouper_DepartProperties.Controls.Add(label_DataBaseAddress);
            grouper_DepartProperties.Controls.Add(label_DepartmentName);
            grouper_DepartProperties.Controls.Add(textBoxApplicationHTMLtemples);
            grouper_DepartProperties.Controls.Add(button_BrowserDataBase);
            grouper_DepartProperties.Controls.Add(button_ApplicationHTMLtemples);
            grouper_DepartProperties.Controls.Add(labelApplicationHTMLtemples);
            grouper_DepartProperties.CustomGroupBoxColor = Color.White;
            grouper_DepartProperties.Dock = DockStyle.Top;
            grouper_DepartProperties.GroupTitle = "Department Name.";
            grouper_DepartProperties.Location = new Point(16, 11);
            grouper_DepartProperties.Margin = new Padding(1, 14, 1, 1);
            grouper_DepartProperties.Name = "grouper_DepartProperties";
            grouper_DepartProperties.Padding = new Padding(113, 86, 113, 71);
            grouper_DepartProperties.PaintGroupBox = false;
            grouper_DepartProperties.RoundCorners = 10;
            grouper_DepartProperties.ShadowColor = Color.DarkGray;
            grouper_DepartProperties.ShadowControl = false;
            grouper_DepartProperties.ShadowThickness = 3;
            grouper_DepartProperties.Size = new Size(1060, 205);
            grouper_DepartProperties.TabIndex = 15;
            // 
            // textBox_DataBaseAddress
            // 
            textBox_DataBaseAddress.Location = new Point(207, 95);
            textBox_DataBaseAddress.Margin = new Padding(16, 11, 16, 11);
            textBox_DataBaseAddress.Name = "textBox_DataBaseAddress";
            textBox_DataBaseAddress.Size = new Size(635, 29);
            textBox_DataBaseAddress.TabIndex = 3;
            textBox_DataBaseAddress.TextChanged += TextBox_DataBaseAddress_TextChanged;
            // 
            // comboBox_ApplicationDepartmentName
            // 
            comboBox_ApplicationDepartmentName.FormattingEnabled = true;
            comboBox_ApplicationDepartmentName.Location = new Point(207, 44);
            comboBox_ApplicationDepartmentName.Margin = new Padding(16, 11, 16, 11);
            comboBox_ApplicationDepartmentName.Name = "comboBox_ApplicationDepartmentName";
            comboBox_ApplicationDepartmentName.Size = new Size(766, 29);
            comboBox_ApplicationDepartmentName.TabIndex = 8;
            comboBox_ApplicationDepartmentName.SelectedIndexChanged += ComboBox_ApplicationDepartmentName_SelectedIndexChanged;
            comboBox_ApplicationDepartmentName.TextChanged += ComboBox_ApplicationDepartmentName_TextChanged;
            // 
            // label_DataBaseAddress
            // 
            label_DataBaseAddress.AutoSize = true;
            label_DataBaseAddress.Location = new Point(33, 103);
            label_DataBaseAddress.Margin = new Padding(16, 0, 16, 0);
            label_DataBaseAddress.Name = "label_DataBaseAddress";
            label_DataBaseAddress.Size = new Size(137, 21);
            label_DataBaseAddress.TabIndex = 2;
            label_DataBaseAddress.Text = "DataBase Address:";
            // 
            // label_DepartmentName
            // 
            label_DepartmentName.AutoSize = true;
            label_DepartmentName.Location = new Point(33, 47);
            label_DepartmentName.Margin = new Padding(16, 0, 16, 0);
            label_DepartmentName.Name = "label_DepartmentName";
            label_DepartmentName.Size = new Size(142, 21);
            label_DepartmentName.TabIndex = 0;
            label_DepartmentName.Text = "Department Name:";
            // 
            // textBoxApplicationHTMLtemples
            // 
            textBoxApplicationHTMLtemples.Location = new Point(207, 146);
            textBoxApplicationHTMLtemples.Margin = new Padding(16, 11, 16, 11);
            textBoxApplicationHTMLtemples.Name = "textBoxApplicationHTMLtemples";
            textBoxApplicationHTMLtemples.Size = new Size(635, 29);
            textBoxApplicationHTMLtemples.TabIndex = 6;
            // 
            // button_BrowserDataBase
            // 
            button_BrowserDataBase.Location = new Point(858, 93);
            button_BrowserDataBase.Margin = new Padding(0);
            button_BrowserDataBase.Name = "button_BrowserDataBase";
            button_BrowserDataBase.Size = new Size(115, 30);
            button_BrowserDataBase.TabIndex = 4;
            button_BrowserDataBase.Text = "Browser...";
            button_BrowserDataBase.UseVisualStyleBackColor = true;
            button_BrowserDataBase.Click += ButtonBrowserDataBaseFileClick;
            // 
            // button_ApplicationHTMLtemples
            // 
            button_ApplicationHTMLtemples.Location = new Point(858, 144);
            button_ApplicationHTMLtemples.Margin = new Padding(16, 11, 16, 11);
            button_ApplicationHTMLtemples.Name = "button_ApplicationHTMLtemples";
            button_ApplicationHTMLtemples.Size = new Size(115, 30);
            button_ApplicationHTMLtemples.TabIndex = 7;
            button_ApplicationHTMLtemples.Text = "Browser...";
            button_ApplicationHTMLtemples.UseVisualStyleBackColor = true;
            button_ApplicationHTMLtemples.Click += buttonApplicationHTMLtemples_Click;
            // 
            // labelApplicationHTMLtemples
            // 
            labelApplicationHTMLtemples.AutoSize = true;
            labelApplicationHTMLtemples.Location = new Point(33, 154);
            labelApplicationHTMLtemples.Margin = new Padding(16, 0, 16, 0);
            labelApplicationHTMLtemples.Name = "labelApplicationHTMLtemples";
            labelApplicationHTMLtemples.Size = new Size(145, 21);
            labelApplicationHTMLtemples.TabIndex = 5;
            labelApplicationHTMLtemples.Text = "App HTML temples:";
            // 
            // tabPageNotificationsOptions
            // 
            tabPageNotificationsOptions.Controls.Add(grouper2);
            tabPageNotificationsOptions.Location = new Point(4, 4);
            tabPageNotificationsOptions.Margin = new Padding(16, 11, 16, 11);
            tabPageNotificationsOptions.Name = "tabPageNotificationsOptions";
            tabPageNotificationsOptions.Padding = new Padding(16, 11, 16, 11);
            tabPageNotificationsOptions.Size = new Size(1092, 629);
            tabPageNotificationsOptions.TabIndex = 1;
            tabPageNotificationsOptions.Text = "   Notifycations Options";
            tabPageNotificationsOptions.UseVisualStyleBackColor = true;
            // 
            // grouper2
            // 
            grouper2.BackgroundColor = SystemColors.Control;
            grouper2.BackgroundGradientColor = Color.White;
            grouper2.BackgroundGradientMode = CodeVendor.Controls.Grouper.GroupBoxGradientMode.None;
            grouper2.BorderColor = Color.Black;
            grouper2.BorderThickness = 1F;
            grouper2.Controls.Add(panel7);
            grouper2.Controls.Add(panel6);
            grouper2.CustomGroupBoxColor = Color.White;
            grouper2.Dock = DockStyle.Fill;
            grouper2.GroupTitle = "";
            grouper2.Location = new Point(16, 11);
            grouper2.Margin = new Padding(16, 11, 16, 11);
            grouper2.Name = "grouper2";
            grouper2.Padding = new Padding(28, 50, 28, 17);
            grouper2.PaintGroupBox = false;
            grouper2.RoundCorners = 10;
            grouper2.ShadowColor = Color.DarkGray;
            grouper2.ShadowControl = false;
            grouper2.ShadowThickness = 3;
            grouper2.Size = new Size(1060, 607);
            grouper2.TabIndex = 9;
            // 
            // panel7
            // 
            panel7.Controls.Add(grouper_Notifycations);
            panel7.Controls.Add(grouper3);
            panel7.Controls.Add(grouper4);
            panel7.Dock = DockStyle.Fill;
            panel7.Location = new Point(343, 50);
            panel7.Margin = new Padding(16, 11, 16, 11);
            panel7.Name = "panel7";
            panel7.Size = new Size(689, 540);
            panel7.TabIndex = 18;
            // 
            // grouper_Notifycations
            // 
            grouper_Notifycations.BackgroundColor = SystemColors.Control;
            grouper_Notifycations.BackgroundGradientColor = Color.White;
            grouper_Notifycations.BackgroundGradientMode = CodeVendor.Controls.Grouper.GroupBoxGradientMode.None;
            grouper_Notifycations.BorderColor = Color.Black;
            grouper_Notifycations.BorderThickness = 1F;
            grouper_Notifycations.Controls.Add(checkBox_ShowEmailsNotifications);
            grouper_Notifycations.Controls.Add(checkBox_ShowDataBaseUpdateNotifications);
            grouper_Notifycations.Controls.Add(checkBox_ShowWarningsNotifications);
            grouper_Notifycations.CustomGroupBoxColor = Color.White;
            grouper_Notifycations.Dock = DockStyle.Fill;
            grouper_Notifycations.GroupTitle = "Received Notifications.";
            grouper_Notifycations.Location = new Point(0, 139);
            grouper_Notifycations.Margin = new Padding(1, 14, 1, 1);
            grouper_Notifycations.Name = "grouper_Notifycations";
            grouper_Notifycations.Padding = new Padding(113, 86, 113, 71);
            grouper_Notifycations.PaintGroupBox = false;
            grouper_Notifycations.RoundCorners = 10;
            grouper_Notifycations.ShadowColor = Color.DarkGray;
            grouper_Notifycations.ShadowControl = false;
            grouper_Notifycations.ShadowThickness = 3;
            grouper_Notifycations.Size = new Size(689, 201);
            grouper_Notifycations.TabIndex = 11;
            // 
            // checkBox_ShowEmailsNotifications
            // 
            checkBox_ShowEmailsNotifications.AutoSize = true;
            checkBox_ShowEmailsNotifications.Location = new Point(32, 150);
            checkBox_ShowEmailsNotifications.Margin = new Padding(16, 11, 16, 11);
            checkBox_ShowEmailsNotifications.Name = "checkBox_ShowEmailsNotifications";
            checkBox_ShowEmailsNotifications.Size = new Size(209, 25);
            checkBox_ShowEmailsNotifications.TabIndex = 14;
            checkBox_ShowEmailsNotifications.Text = "Show Emails notifications.";
            checkBox_ShowEmailsNotifications.UseVisualStyleBackColor = true;
            // 
            // checkBox_ShowDataBaseUpdateNotifications
            // 
            checkBox_ShowDataBaseUpdateNotifications.AutoSize = true;
            checkBox_ShowDataBaseUpdateNotifications.Location = new Point(32, 58);
            checkBox_ShowDataBaseUpdateNotifications.Margin = new Padding(16, 11, 16, 11);
            checkBox_ShowDataBaseUpdateNotifications.Name = "checkBox_ShowDataBaseUpdateNotifications";
            checkBox_ShowDataBaseUpdateNotifications.Size = new Size(280, 25);
            checkBox_ShowDataBaseUpdateNotifications.TabIndex = 13;
            checkBox_ShowDataBaseUpdateNotifications.Text = "Show DataBase update notifications.";
            checkBox_ShowDataBaseUpdateNotifications.UseVisualStyleBackColor = true;
            // 
            // checkBox_ShowWarningsNotifications
            // 
            checkBox_ShowWarningsNotifications.AutoSize = true;
            checkBox_ShowWarningsNotifications.Location = new Point(32, 104);
            checkBox_ShowWarningsNotifications.Margin = new Padding(16, 11, 16, 11);
            checkBox_ShowWarningsNotifications.Name = "checkBox_ShowWarningsNotifications";
            checkBox_ShowWarningsNotifications.Size = new Size(230, 25);
            checkBox_ShowWarningsNotifications.TabIndex = 12;
            checkBox_ShowWarningsNotifications.Text = "Show Warnings notifications.";
            checkBox_ShowWarningsNotifications.UseVisualStyleBackColor = true;
            // 
            // grouper3
            // 
            grouper3.BackgroundColor = SystemColors.Control;
            grouper3.BackgroundGradientColor = Color.White;
            grouper3.BackgroundGradientMode = CodeVendor.Controls.Grouper.GroupBoxGradientMode.None;
            grouper3.BorderColor = Color.Black;
            grouper3.BorderThickness = 1F;
            grouper3.Controls.Add(checkBox_ShowMyOwnNotifications);
            grouper3.Controls.Add(checkBox_SendMyOwnNotifications);
            grouper3.CustomGroupBoxColor = Color.White;
            grouper3.Dock = DockStyle.Top;
            grouper3.GroupTitle = "Send Notifications.";
            grouper3.Location = new Point(0, 0);
            grouper3.Margin = new Padding(1, 14, 1, 1);
            grouper3.Name = "grouper3";
            grouper3.Padding = new Padding(113, 86, 113, 71);
            grouper3.PaintGroupBox = false;
            grouper3.RoundCorners = 10;
            grouper3.ShadowColor = Color.DarkGray;
            grouper3.ShadowControl = false;
            grouper3.ShadowThickness = 3;
            grouper3.Size = new Size(689, 139);
            grouper3.TabIndex = 14;
            // 
            // checkBox_ShowMyOwnNotifications
            // 
            checkBox_ShowMyOwnNotifications.AutoSize = true;
            checkBox_ShowMyOwnNotifications.Location = new Point(32, 94);
            checkBox_ShowMyOwnNotifications.Margin = new Padding(16, 11, 16, 11);
            checkBox_ShowMyOwnNotifications.Name = "checkBox_ShowMyOwnNotifications";
            checkBox_ShowMyOwnNotifications.Size = new Size(246, 25);
            checkBox_ShowMyOwnNotifications.TabIndex = 11;
            checkBox_ShowMyOwnNotifications.Text = "Show me my own notifications.";
            checkBox_ShowMyOwnNotifications.UseVisualStyleBackColor = true;
            // 
            // checkBox_SendMyOwnNotifications
            // 
            checkBox_SendMyOwnNotifications.AutoSize = true;
            checkBox_SendMyOwnNotifications.Location = new Point(32, 48);
            checkBox_SendMyOwnNotifications.Margin = new Padding(16, 11, 16, 11);
            checkBox_SendMyOwnNotifications.Name = "checkBox_SendMyOwnNotifications";
            checkBox_SendMyOwnNotifications.Size = new Size(542, 25);
            checkBox_SendMyOwnNotifications.TabIndex = 14;
            checkBox_SendMyOwnNotifications.Text = "Send my own notifications. Check to send my notifications to others users.";
            checkBox_SendMyOwnNotifications.UseVisualStyleBackColor = true;
            // 
            // grouper4
            // 
            grouper4.BackgroundColor = SystemColors.Control;
            grouper4.BackgroundGradientColor = Color.White;
            grouper4.BackgroundGradientMode = CodeVendor.Controls.Grouper.GroupBoxGradientMode.None;
            grouper4.BorderColor = Color.Black;
            grouper4.BorderThickness = 1F;
            grouper4.Controls.Add(label_IntervalSetTo);
            grouper4.Controls.Add(trackBar_Interval);
            grouper4.Controls.Add(radioButton_Hours);
            grouper4.Controls.Add(radioButton_Minutes);
            grouper4.Controls.Add(radioButton_secund);
            grouper4.CustomGroupBoxColor = Color.White;
            grouper4.Dock = DockStyle.Bottom;
            grouper4.GroupTitle = "Interval between each reading of notifications.";
            grouper4.Location = new Point(0, 340);
            grouper4.Margin = new Padding(1, 14, 1, 1);
            grouper4.Name = "grouper4";
            grouper4.Padding = new Padding(48, 90, 48, 71);
            grouper4.PaintGroupBox = false;
            grouper4.RoundCorners = 10;
            grouper4.ShadowColor = Color.DarkGray;
            grouper4.ShadowControl = false;
            grouper4.ShadowThickness = 3;
            grouper4.Size = new Size(689, 200);
            grouper4.TabIndex = 16;
            // 
            // label_IntervalSetTo
            // 
            label_IntervalSetTo.AutoSize = true;
            label_IntervalSetTo.Location = new Point(60, 52);
            label_IntervalSetTo.Margin = new Padding(12, 0, 12, 0);
            label_IntervalSetTo.Name = "label_IntervalSetTo";
            label_IntervalSetTo.Size = new Size(487, 21);
            label_IntervalSetTo.TabIndex = 24;
            label_IntervalSetTo.Text = "The interval between each reading of notifications is set to 2 seconds.\r\n";
            // 
            // trackBar_Interval
            // 
            trackBar_Interval.Dock = DockStyle.Top;
            trackBar_Interval.Location = new Point(48, 90);
            trackBar_Interval.Margin = new Padding(12, 2, 12, 2);
            trackBar_Interval.Maximum = 100;
            trackBar_Interval.Minimum = 1;
            trackBar_Interval.Name = "trackBar_Interval";
            trackBar_Interval.Size = new Size(593, 45);
            trackBar_Interval.TabIndex = 23;
            trackBar_Interval.TickFrequency = 2;
            trackBar_Interval.TickStyle = TickStyle.Both;
            trackBar_Interval.Value = 2;
            trackBar_Interval.ValueChanged += TrackBar_Interval_ValueChanged;
            // 
            // radioButton_Hours
            // 
            radioButton_Hours.AutoSize = true;
            radioButton_Hours.Location = new Point(60, 148);
            radioButton_Hours.Margin = new Padding(12, 2, 12, 2);
            radioButton_Hours.Name = "radioButton_Hours";
            radioButton_Hours.Size = new Size(73, 25);
            radioButton_Hours.TabIndex = 21;
            radioButton_Hours.Text = "Hours.";
            radioButton_Hours.UseVisualStyleBackColor = true;
            radioButton_Hours.CheckedChanged += RadioButton_Hours_CheckedChanged;
            // 
            // radioButton_Minutes
            // 
            radioButton_Minutes.AutoSize = true;
            radioButton_Minutes.Location = new Point(177, 148);
            radioButton_Minutes.Margin = new Padding(12, 2, 12, 2);
            radioButton_Minutes.Name = "radioButton_Minutes";
            radioButton_Minutes.Size = new Size(87, 25);
            radioButton_Minutes.TabIndex = 20;
            radioButton_Minutes.Text = "Minutes.";
            radioButton_Minutes.UseVisualStyleBackColor = true;
            radioButton_Minutes.CheckedChanged += RadioButton_Minutes_CheckedChanged;
            // 
            // radioButton_secund
            // 
            radioButton_secund.AutoSize = true;
            radioButton_secund.Checked = true;
            radioButton_secund.Location = new Point(301, 148);
            radioButton_secund.Margin = new Padding(12, 2, 12, 2);
            radioButton_secund.Name = "radioButton_secund";
            radioButton_secund.Size = new Size(89, 25);
            radioButton_secund.TabIndex = 19;
            radioButton_secund.TabStop = true;
            radioButton_secund.Text = "Seconds.";
            radioButton_secund.UseVisualStyleBackColor = true;
            radioButton_secund.CheckedChanged += RadioButton_secund_CheckedChanged;
            // 
            // panel6
            // 
            panel6.Controls.Add(label1);
            panel6.Controls.Add(checkBox_EnableSendReceiveNotifycations);
            panel6.Controls.Add(checkBox_SetIntervalReadNotifications);
            panel6.Dock = DockStyle.Left;
            panel6.Location = new Point(28, 50);
            panel6.Margin = new Padding(16, 11, 16, 11);
            panel6.Name = "panel6";
            panel6.Size = new Size(315, 540);
            panel6.TabIndex = 17;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 12F);
            label1.Location = new Point(77, 17);
            label1.Margin = new Padding(16, 0, 16, 0);
            label1.Name = "label1";
            label1.Size = new Size(159, 20);
            label1.TabIndex = 9;
            label1.Text = "Notifications Options.";
            // 
            // checkBox_EnableSendReceiveNotifycations
            // 
            checkBox_EnableSendReceiveNotifycations.AutoSize = true;
            checkBox_EnableSendReceiveNotifycations.Location = new Point(16, 48);
            checkBox_EnableSendReceiveNotifycations.Margin = new Padding(16, 11, 16, 11);
            checkBox_EnableSendReceiveNotifycations.Name = "checkBox_EnableSendReceiveNotifycations";
            checkBox_EnableSendReceiveNotifycations.Size = new Size(272, 25);
            checkBox_EnableSendReceiveNotifycations.TabIndex = 13;
            checkBox_EnableSendReceiveNotifycations.Text = "Enable Receive/Send Notifycations.";
            checkBox_EnableSendReceiveNotifycations.UseVisualStyleBackColor = true;
            checkBox_EnableSendReceiveNotifycations.CheckedChanged += CheckBoxEnableSendReceiveNotifycationsCheckedChanged;
            // 
            // checkBox_SetIntervalReadNotifications
            // 
            checkBox_SetIntervalReadNotifications.AutoSize = true;
            checkBox_SetIntervalReadNotifications.Location = new Point(16, 94);
            checkBox_SetIntervalReadNotifications.Margin = new Padding(16, 11, 16, 11);
            checkBox_SetIntervalReadNotifications.Name = "checkBox_SetIntervalReadNotifications";
            checkBox_SetIntervalReadNotifications.Size = new Size(285, 25);
            checkBox_SetIntervalReadNotifications.TabIndex = 15;
            checkBox_SetIntervalReadNotifications.Text = "Set the interval reading Notifications.";
            checkBox_SetIntervalReadNotifications.UseVisualStyleBackColor = true;
            // 
            // tabPageUSB_DeviceUtility
            // 
            tabPageUSB_DeviceUtility.AutoScroll = true;
            tabPageUSB_DeviceUtility.Controls.Add(splitContainer1);
            tabPageUSB_DeviceUtility.Location = new Point(4, 4);
            tabPageUSB_DeviceUtility.Margin = new Padding(16, 11, 16, 11);
            tabPageUSB_DeviceUtility.Name = "tabPageUSB_DeviceUtility";
            tabPageUSB_DeviceUtility.Size = new Size(1092, 629);
            tabPageUSB_DeviceUtility.TabIndex = 2;
            tabPageUSB_DeviceUtility.Text = "   USB Device Utility";
            tabPageUSB_DeviceUtility.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            splitContainer1.BorderStyle = BorderStyle.Fixed3D;
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Margin = new Padding(16, 11, 16, 11);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Orientation = Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(richTextBox1);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(grouper_AddNewPrintHelpsButtons);
            splitContainer1.Panel2.Controls.Add(panel1);
            splitContainer1.Size = new Size(1092, 629);
            splitContainer1.SplitterDistance = 179;
            splitContainer1.SplitterWidth = 14;
            splitContainer1.TabIndex = 1;
            // 
            // richTextBox1
            // 
            richTextBox1.Dock = DockStyle.Fill;
            richTextBox1.Location = new Point(0, 0);
            richTextBox1.Margin = new Padding(12, 2, 12, 2);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(1088, 175);
            richTextBox1.TabIndex = 0;
            richTextBox1.Text = "";
            // 
            // grouper_AddNewPrintHelpsButtons
            // 
            grouper_AddNewPrintHelpsButtons.BackgroundColor = Color.LightGray;
            grouper_AddNewPrintHelpsButtons.BackgroundGradientColor = Color.DarkGray;
            grouper_AddNewPrintHelpsButtons.BackgroundGradientMode = CodeVendor.Controls.Grouper.GroupBoxGradientMode.Vertical;
            grouper_AddNewPrintHelpsButtons.BorderColor = Color.Black;
            grouper_AddNewPrintHelpsButtons.BorderThickness = 1F;
            grouper_AddNewPrintHelpsButtons.Controls.Add(flowLayoutPanel_AddNewPrintHelpsButton);
            grouper_AddNewPrintHelpsButtons.CustomGroupBoxColor = Color.White;
            grouper_AddNewPrintHelpsButtons.Dock = DockStyle.Fill;
            grouper_AddNewPrintHelpsButtons.GroupTitle = "";
            grouper_AddNewPrintHelpsButtons.Location = new Point(0, 0);
            grouper_AddNewPrintHelpsButtons.Margin = new Padding(12, 2, 12, 2);
            grouper_AddNewPrintHelpsButtons.Name = "grouper_AddNewPrintHelpsButtons";
            grouper_AddNewPrintHelpsButtons.Padding = new Padding(36, 21, 36, 21);
            grouper_AddNewPrintHelpsButtons.PaintGroupBox = false;
            grouper_AddNewPrintHelpsButtons.RoundCorners = 10;
            grouper_AddNewPrintHelpsButtons.ShadowColor = Color.DarkGray;
            grouper_AddNewPrintHelpsButtons.ShadowControl = false;
            grouper_AddNewPrintHelpsButtons.ShadowThickness = 3;
            grouper_AddNewPrintHelpsButtons.Size = new Size(1088, 165);
            grouper_AddNewPrintHelpsButtons.TabIndex = 17;
            // 
            // flowLayoutPanel_AddNewPrintHelpsButton
            // 
            flowLayoutPanel_AddNewPrintHelpsButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowLayoutPanel_AddNewPrintHelpsButton.Controls.Add(button_Adjustment);
            flowLayoutPanel_AddNewPrintHelpsButton.Controls.Add(button_RemoveScanner);
            flowLayoutPanel_AddNewPrintHelpsButton.Controls.Add(button_PrintHelps);
            flowLayoutPanel_AddNewPrintHelpsButton.Controls.Add(button_AddNew);
            flowLayoutPanel_AddNewPrintHelpsButton.Dock = DockStyle.Bottom;
            flowLayoutPanel_AddNewPrintHelpsButton.Location = new Point(36, 44);
            flowLayoutPanel_AddNewPrintHelpsButton.Margin = new Padding(0);
            flowLayoutPanel_AddNewPrintHelpsButton.Name = "flowLayoutPanel_AddNewPrintHelpsButton";
            flowLayoutPanel_AddNewPrintHelpsButton.Padding = new Padding(0, 2, 0, 0);
            flowLayoutPanel_AddNewPrintHelpsButton.Size = new Size(1016, 100);
            flowLayoutPanel_AddNewPrintHelpsButton.TabIndex = 13;
            // 
            // button_Adjustment
            // 
            button_Adjustment.Font = new Font("Arial", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button_Adjustment.Location = new Point(12, 2);
            button_Adjustment.Margin = new Padding(12, 0, 12, 0);
            button_Adjustment.Name = "button_Adjustment";
            button_Adjustment.Size = new Size(169, 41);
            button_Adjustment.TabIndex = 1;
            button_Adjustment.Text = "Adjustment";
            button_Adjustment.UseVisualStyleBackColor = true;
            // 
            // button_RemoveScanner
            // 
            button_RemoveScanner.Font = new Font("Arial", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button_RemoveScanner.Location = new Point(205, 2);
            button_RemoveScanner.Margin = new Padding(12, 0, 12, 0);
            button_RemoveScanner.Name = "button_RemoveScanner";
            button_RemoveScanner.Size = new Size(165, 41);
            button_RemoveScanner.TabIndex = 2;
            button_RemoveScanner.Text = "Remove Scanner";
            button_RemoveScanner.UseVisualStyleBackColor = true;
            // 
            // button_PrintHelps
            // 
            button_PrintHelps.Font = new Font("Arial", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button_PrintHelps.Location = new Point(394, 2);
            button_PrintHelps.Margin = new Padding(12, 0, 12, 0);
            button_PrintHelps.Name = "button_PrintHelps";
            button_PrintHelps.Size = new Size(189, 44);
            button_PrintHelps.TabIndex = 3;
            button_PrintHelps.Text = "Print Helps";
            button_PrintHelps.UseVisualStyleBackColor = true;
            // 
            // button_AddNew
            // 
            button_AddNew.Font = new Font("Arial", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button_AddNew.Location = new Point(607, 2);
            button_AddNew.Margin = new Padding(12, 0, 12, 0);
            button_AddNew.Name = "button_AddNew";
            button_AddNew.Size = new Size(153, 46);
            button_AddNew.TabIndex = 5;
            button_AddNew.Text = "Add New";
            button_AddNew.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            panel1.AutoScroll = true;
            panel1.AutoScrollMinSize = new Size(750, 200);
            panel1.Controls.Add(PicturesBox_Image);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 165);
            panel1.Margin = new Padding(16, 11, 16, 11);
            panel1.Name = "panel1";
            panel1.Size = new Size(1088, 267);
            panel1.TabIndex = 2;
            // 
            // PicturesBox_Image
            // 
            PicturesBox_Image.BackColor = Color.White;
            PicturesBox_Image.Dock = DockStyle.Fill;
            PicturesBox_Image.Image = Properties.Resources.USB1;
            PicturesBox_Image.Location = new Point(0, 0);
            PicturesBox_Image.Margin = new Padding(16, 11, 16, 11);
            PicturesBox_Image.Name = "PicturesBox_Image";
            PicturesBox_Image.Size = new Size(1088, 267);
            PicturesBox_Image.TabIndex = 1;
            PicturesBox_Image.TabStop = false;
            // 
            // tabPage_Documentation
            // 
            tabPage_Documentation.AutoScroll = true;
            tabPage_Documentation.Controls.Add(grouper_DocumentationBehavior);
            tabPage_Documentation.Location = new Point(4, 4);
            tabPage_Documentation.Margin = new Padding(16, 11, 16, 11);
            tabPage_Documentation.Name = "tabPage_Documentation";
            tabPage_Documentation.Padding = new Padding(21, 14, 21, 14);
            tabPage_Documentation.Size = new Size(1092, 625);
            tabPage_Documentation.TabIndex = 8;
            tabPage_Documentation.Text = "   Documentation";
            tabPage_Documentation.UseVisualStyleBackColor = true;
            // 
            // grouper_DocumentationBehavior
            // 
            grouper_DocumentationBehavior.AutoSize = true;
            grouper_DocumentationBehavior.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            grouper_DocumentationBehavior.BackgroundColor = SystemColors.Control;
            grouper_DocumentationBehavior.BackgroundGradientColor = Color.Gainsboro;
            grouper_DocumentationBehavior.BackgroundGradientMode = CodeVendor.Controls.Grouper.GroupBoxGradientMode.None;
            grouper_DocumentationBehavior.BorderColor = Color.Black;
            grouper_DocumentationBehavior.BorderThickness = 1F;
            grouper_DocumentationBehavior.Controls.Add(panel_NotDocumentToShow);
            grouper_DocumentationBehavior.Controls.Add(panel_LastTwoVersions);
            grouper_DocumentationBehavior.Controls.Add(panel_AllVersionsFound);
            grouper_DocumentationBehavior.Controls.Add(panel_TheLastRevision);
            grouper_DocumentationBehavior.Controls.Add(panel_SpecifiedDocument);
            grouper_DocumentationBehavior.Controls.Add(panel_DefaultDocument);
            grouper_DocumentationBehavior.Controls.Add(grouper_BrowserVersion);
            grouper_DocumentationBehavior.CustomGroupBoxColor = Color.White;
            grouper_DocumentationBehavior.Dock = DockStyle.Fill;
            grouper_DocumentationBehavior.GroupTitle = "Documentation Behavior";
            grouper_DocumentationBehavior.Location = new Point(21, 14);
            grouper_DocumentationBehavior.Margin = new Padding(1, 14, 1, 1);
            grouper_DocumentationBehavior.Name = "grouper_DocumentationBehavior";
            grouper_DocumentationBehavior.Padding = new Padding(8, 25, 8, 8);
            grouper_DocumentationBehavior.PaintGroupBox = false;
            grouper_DocumentationBehavior.RoundCorners = 10;
            grouper_DocumentationBehavior.ShadowColor = Color.DarkGray;
            grouper_DocumentationBehavior.ShadowControl = false;
            grouper_DocumentationBehavior.ShadowThickness = 3;
            grouper_DocumentationBehavior.Size = new Size(1050, 597);
            grouper_DocumentationBehavior.TabIndex = 20;
            // 
            // panel_NotDocumentToShow
            // 
            panel_NotDocumentToShow.Controls.Add(richTextBox_NotDocumentToShow);
            panel_NotDocumentToShow.Controls.Add(panel16);
            panel_NotDocumentToShow.Controls.Add(radioButton_NotDocumentToShow);
            panel_NotDocumentToShow.Dock = DockStyle.Top;
            panel_NotDocumentToShow.Location = new Point(8, 425);
            panel_NotDocumentToShow.Margin = new Padding(0);
            panel_NotDocumentToShow.MinimumSize = new Size(10, 10);
            panel_NotDocumentToShow.Name = "panel_NotDocumentToShow";
            panel_NotDocumentToShow.Padding = new Padding(5);
            panel_NotDocumentToShow.Size = new Size(1034, 60);
            panel_NotDocumentToShow.TabIndex = 32;
            // 
            // richTextBox_NotDocumentToShow
            // 
            richTextBox_NotDocumentToShow.BackColor = Color.LightGoldenrodYellow;
            richTextBox_NotDocumentToShow.BorderStyle = BorderStyle.None;
            richTextBox_NotDocumentToShow.Dock = DockStyle.Fill;
            richTextBox_NotDocumentToShow.Font = new Font("Microsoft Sans Serif", 12F);
            richTextBox_NotDocumentToShow.Location = new Point(230, 5);
            richTextBox_NotDocumentToShow.Margin = new Padding(16, 11, 16, 11);
            richTextBox_NotDocumentToShow.Name = "richTextBox_NotDocumentToShow";
            richTextBox_NotDocumentToShow.ReadOnly = true;
            richTextBox_NotDocumentToShow.Size = new Size(799, 50);
            richTextBox_NotDocumentToShow.TabIndex = 32;
            richTextBox_NotDocumentToShow.Text = "               On this options the system will not show any Document. It's the defaul and normal beahavior of the system.";
            // 
            // panel16
            // 
            panel16.BackColor = Color.LightGoldenrodYellow;
            panel16.Dock = DockStyle.Left;
            panel16.Location = new Point(205, 5);
            panel16.Margin = new Padding(0);
            panel16.MinimumSize = new Size(25, 10);
            panel16.Name = "panel16";
            panel16.Size = new Size(25, 50);
            panel16.TabIndex = 30;
            // 
            // radioButton_NotDocumentToShow
            // 
            radioButton_NotDocumentToShow.AutoSize = true;
            radioButton_NotDocumentToShow.Dock = DockStyle.Left;
            radioButton_NotDocumentToShow.Font = new Font("Microsoft Sans Serif", 12F);
            radioButton_NotDocumentToShow.Location = new Point(5, 5);
            radioButton_NotDocumentToShow.Margin = new Padding(16, 11, 16, 11);
            radioButton_NotDocumentToShow.MinimumSize = new Size(200, 0);
            radioButton_NotDocumentToShow.Name = "radioButton_NotDocumentToShow";
            radioButton_NotDocumentToShow.Size = new Size(200, 50);
            radioButton_NotDocumentToShow.TabIndex = 31;
            radioButton_NotDocumentToShow.Tag = "2";
            radioButton_NotDocumentToShow.Text = "Not Document to Show";
            radioButton_NotDocumentToShow.UseVisualStyleBackColor = true;
            // 
            // panel_LastTwoVersions
            // 
            panel_LastTwoVersions.Controls.Add(richTextBox_LastTwoVersions);
            panel_LastTwoVersions.Controls.Add(panel15);
            panel_LastTwoVersions.Controls.Add(radioButton_LastTwoVersions);
            panel_LastTwoVersions.Dock = DockStyle.Top;
            panel_LastTwoVersions.Location = new Point(8, 365);
            panel_LastTwoVersions.Margin = new Padding(0);
            panel_LastTwoVersions.MinimumSize = new Size(10, 10);
            panel_LastTwoVersions.Name = "panel_LastTwoVersions";
            panel_LastTwoVersions.Padding = new Padding(5);
            panel_LastTwoVersions.Size = new Size(1034, 60);
            panel_LastTwoVersions.TabIndex = 31;
            // 
            // richTextBox_LastTwoVersions
            // 
            richTextBox_LastTwoVersions.BackColor = Color.LightGoldenrodYellow;
            richTextBox_LastTwoVersions.BorderStyle = BorderStyle.None;
            richTextBox_LastTwoVersions.Dock = DockStyle.Fill;
            richTextBox_LastTwoVersions.Font = new Font("Microsoft Sans Serif", 12F);
            richTextBox_LastTwoVersions.Location = new Point(230, 5);
            richTextBox_LastTwoVersions.Margin = new Padding(16, 11, 16, 11);
            richTextBox_LastTwoVersions.Name = "richTextBox_LastTwoVersions";
            richTextBox_LastTwoVersions.ReadOnly = true;
            richTextBox_LastTwoVersions.Size = new Size(799, 50);
            richTextBox_LastTwoVersions.TabIndex = 32;
            richTextBox_LastTwoVersions.Text = "               On this options the system will not show any Document. It's the defaul and normal beahavior of the system.";
            // 
            // panel15
            // 
            panel15.BackColor = Color.LightGoldenrodYellow;
            panel15.Dock = DockStyle.Left;
            panel15.Location = new Point(205, 5);
            panel15.Margin = new Padding(0);
            panel15.MinimumSize = new Size(25, 10);
            panel15.Name = "panel15";
            panel15.Size = new Size(25, 50);
            panel15.TabIndex = 30;
            // 
            // radioButton_LastTwoVersions
            // 
            radioButton_LastTwoVersions.AutoSize = true;
            radioButton_LastTwoVersions.Dock = DockStyle.Left;
            radioButton_LastTwoVersions.Font = new Font("Microsoft Sans Serif", 12F);
            radioButton_LastTwoVersions.Location = new Point(5, 5);
            radioButton_LastTwoVersions.Margin = new Padding(16, 11, 16, 11);
            radioButton_LastTwoVersions.MinimumSize = new Size(200, 0);
            radioButton_LastTwoVersions.Name = "radioButton_LastTwoVersions";
            radioButton_LastTwoVersions.Size = new Size(200, 50);
            radioButton_LastTwoVersions.TabIndex = 31;
            radioButton_LastTwoVersions.Tag = "2";
            radioButton_LastTwoVersions.Text = "Last Two Versions";
            radioButton_LastTwoVersions.UseVisualStyleBackColor = true;
            // 
            // panel_AllVersionsFound
            // 
            panel_AllVersionsFound.Controls.Add(richTextBox_AllVersionsFound);
            panel_AllVersionsFound.Controls.Add(panel13);
            panel_AllVersionsFound.Controls.Add(radioButton_AllVersionsFound);
            panel_AllVersionsFound.Dock = DockStyle.Top;
            panel_AllVersionsFound.Location = new Point(8, 305);
            panel_AllVersionsFound.Margin = new Padding(0);
            panel_AllVersionsFound.MinimumSize = new Size(10, 10);
            panel_AllVersionsFound.Name = "panel_AllVersionsFound";
            panel_AllVersionsFound.Padding = new Padding(5);
            panel_AllVersionsFound.Size = new Size(1034, 60);
            panel_AllVersionsFound.TabIndex = 30;
            // 
            // richTextBox_AllVersionsFound
            // 
            richTextBox_AllVersionsFound.BackColor = Color.LightGoldenrodYellow;
            richTextBox_AllVersionsFound.BorderStyle = BorderStyle.None;
            richTextBox_AllVersionsFound.Dock = DockStyle.Fill;
            richTextBox_AllVersionsFound.Font = new Font("Microsoft Sans Serif", 12F);
            richTextBox_AllVersionsFound.Location = new Point(230, 5);
            richTextBox_AllVersionsFound.Margin = new Padding(16, 11, 16, 11);
            richTextBox_AllVersionsFound.Name = "richTextBox_AllVersionsFound";
            richTextBox_AllVersionsFound.ReadOnly = true;
            richTextBox_AllVersionsFound.Size = new Size(799, 50);
            richTextBox_AllVersionsFound.TabIndex = 32;
            richTextBox_AllVersionsFound.Text = "";
            // 
            // panel13
            // 
            panel13.BackColor = Color.LightGoldenrodYellow;
            panel13.Dock = DockStyle.Left;
            panel13.Location = new Point(205, 5);
            panel13.Margin = new Padding(0);
            panel13.MinimumSize = new Size(25, 10);
            panel13.Name = "panel13";
            panel13.Size = new Size(25, 50);
            panel13.TabIndex = 30;
            // 
            // radioButton_AllVersionsFound
            // 
            radioButton_AllVersionsFound.AutoSize = true;
            radioButton_AllVersionsFound.Dock = DockStyle.Left;
            radioButton_AllVersionsFound.Font = new Font("Microsoft Sans Serif", 12F);
            radioButton_AllVersionsFound.Location = new Point(5, 5);
            radioButton_AllVersionsFound.Margin = new Padding(16, 11, 16, 11);
            radioButton_AllVersionsFound.MinimumSize = new Size(200, 0);
            radioButton_AllVersionsFound.Name = "radioButton_AllVersionsFound";
            radioButton_AllVersionsFound.Size = new Size(200, 50);
            radioButton_AllVersionsFound.TabIndex = 31;
            radioButton_AllVersionsFound.Tag = "2";
            radioButton_AllVersionsFound.Text = "All Versions Found";
            radioButton_AllVersionsFound.UseVisualStyleBackColor = true;
            // 
            // panel_TheLastRevision
            // 
            panel_TheLastRevision.Controls.Add(richTextBox_TheLastRevision);
            panel_TheLastRevision.Controls.Add(panel12);
            panel_TheLastRevision.Controls.Add(radioButton_TheLastRevision);
            panel_TheLastRevision.Dock = DockStyle.Top;
            panel_TheLastRevision.Location = new Point(8, 245);
            panel_TheLastRevision.Margin = new Padding(0);
            panel_TheLastRevision.MinimumSize = new Size(10, 10);
            panel_TheLastRevision.Name = "panel_TheLastRevision";
            panel_TheLastRevision.Padding = new Padding(5);
            panel_TheLastRevision.Size = new Size(1034, 60);
            panel_TheLastRevision.TabIndex = 29;
            // 
            // richTextBox_TheLastRevision
            // 
            richTextBox_TheLastRevision.BackColor = Color.LightGoldenrodYellow;
            richTextBox_TheLastRevision.BorderStyle = BorderStyle.None;
            richTextBox_TheLastRevision.Dock = DockStyle.Fill;
            richTextBox_TheLastRevision.Font = new Font("Microsoft Sans Serif", 12F);
            richTextBox_TheLastRevision.Location = new Point(230, 5);
            richTextBox_TheLastRevision.Margin = new Padding(16, 11, 16, 11);
            richTextBox_TheLastRevision.Name = "richTextBox_TheLastRevision";
            richTextBox_TheLastRevision.ReadOnly = true;
            richTextBox_TheLastRevision.Size = new Size(799, 50);
            richTextBox_TheLastRevision.TabIndex = 32;
            richTextBox_TheLastRevision.Text = "";
            // 
            // panel12
            // 
            panel12.BackColor = Color.LightGoldenrodYellow;
            panel12.Dock = DockStyle.Left;
            panel12.Location = new Point(205, 5);
            panel12.Margin = new Padding(0);
            panel12.MinimumSize = new Size(25, 10);
            panel12.Name = "panel12";
            panel12.Size = new Size(25, 50);
            panel12.TabIndex = 30;
            // 
            // radioButton_TheLastRevision
            // 
            radioButton_TheLastRevision.AutoSize = true;
            radioButton_TheLastRevision.Dock = DockStyle.Left;
            radioButton_TheLastRevision.Font = new Font("Microsoft Sans Serif", 12F);
            radioButton_TheLastRevision.Location = new Point(5, 5);
            radioButton_TheLastRevision.Margin = new Padding(16, 11, 16, 11);
            radioButton_TheLastRevision.MinimumSize = new Size(200, 0);
            radioButton_TheLastRevision.Name = "radioButton_TheLastRevision";
            radioButton_TheLastRevision.Size = new Size(200, 50);
            radioButton_TheLastRevision.TabIndex = 31;
            radioButton_TheLastRevision.Tag = "2";
            radioButton_TheLastRevision.Text = "The Last Revision";
            radioButton_TheLastRevision.UseVisualStyleBackColor = true;
            // 
            // panel_SpecifiedDocument
            // 
            panel_SpecifiedDocument.Controls.Add(richTextBox_SpecifiedDocument);
            panel_SpecifiedDocument.Controls.Add(panel10);
            panel_SpecifiedDocument.Controls.Add(radioButton_SpecifiedDocument);
            panel_SpecifiedDocument.Dock = DockStyle.Top;
            panel_SpecifiedDocument.Location = new Point(8, 185);
            panel_SpecifiedDocument.Margin = new Padding(0);
            panel_SpecifiedDocument.MinimumSize = new Size(250, 0);
            panel_SpecifiedDocument.Name = "panel_SpecifiedDocument";
            panel_SpecifiedDocument.Padding = new Padding(5);
            panel_SpecifiedDocument.Size = new Size(1034, 60);
            panel_SpecifiedDocument.TabIndex = 27;
            // 
            // richTextBox_SpecifiedDocument
            // 
            richTextBox_SpecifiedDocument.BackColor = Color.LightGoldenrodYellow;
            richTextBox_SpecifiedDocument.BorderStyle = BorderStyle.None;
            richTextBox_SpecifiedDocument.Dock = DockStyle.Fill;
            richTextBox_SpecifiedDocument.Font = new Font("Microsoft Sans Serif", 12F);
            richTextBox_SpecifiedDocument.Location = new Point(230, 5);
            richTextBox_SpecifiedDocument.Margin = new Padding(0);
            richTextBox_SpecifiedDocument.Name = "richTextBox_SpecifiedDocument";
            richTextBox_SpecifiedDocument.ReadOnly = true;
            richTextBox_SpecifiedDocument.Size = new Size(799, 50);
            richTextBox_SpecifiedDocument.TabIndex = 3;
            richTextBox_SpecifiedDocument.Text = "\tOn this options the system will luck in column Data_Sheet if a specified document exist, if the document is found it's show into the tap Document.";
            // 
            // panel10
            // 
            panel10.BackColor = Color.LightGoldenrodYellow;
            panel10.Dock = DockStyle.Left;
            panel10.Location = new Point(205, 5);
            panel10.Margin = new Padding(0);
            panel10.MinimumSize = new Size(25, 10);
            panel10.Name = "panel10";
            panel10.Size = new Size(25, 50);
            panel10.TabIndex = 29;
            // 
            // radioButton_SpecifiedDocument
            // 
            radioButton_SpecifiedDocument.AutoSize = true;
            radioButton_SpecifiedDocument.Dock = DockStyle.Left;
            radioButton_SpecifiedDocument.Font = new Font("Microsoft Sans Serif", 12F);
            radioButton_SpecifiedDocument.Location = new Point(5, 5);
            radioButton_SpecifiedDocument.Margin = new Padding(0);
            radioButton_SpecifiedDocument.MinimumSize = new Size(200, 0);
            radioButton_SpecifiedDocument.Name = "radioButton_SpecifiedDocument";
            radioButton_SpecifiedDocument.Size = new Size(200, 50);
            radioButton_SpecifiedDocument.TabIndex = 2;
            radioButton_SpecifiedDocument.Tag = "1";
            radioButton_SpecifiedDocument.Text = "Specified Document";
            radioButton_SpecifiedDocument.UseVisualStyleBackColor = true;
            // 
            // panel_DefaultDocument
            // 
            panel_DefaultDocument.Controls.Add(richTextBox_DefaultDocument);
            panel_DefaultDocument.Controls.Add(panel18);
            panel_DefaultDocument.Controls.Add(radioButton_DefaultDocument);
            panel_DefaultDocument.Dock = DockStyle.Top;
            panel_DefaultDocument.Location = new Point(8, 125);
            panel_DefaultDocument.Margin = new Padding(0);
            panel_DefaultDocument.MinimumSize = new Size(10, 10);
            panel_DefaultDocument.Name = "panel_DefaultDocument";
            panel_DefaultDocument.Padding = new Padding(5);
            panel_DefaultDocument.Size = new Size(1034, 60);
            panel_DefaultDocument.TabIndex = 33;
            // 
            // richTextBox_DefaultDocument
            // 
            richTextBox_DefaultDocument.BackColor = Color.LightGoldenrodYellow;
            richTextBox_DefaultDocument.BorderStyle = BorderStyle.None;
            richTextBox_DefaultDocument.Dock = DockStyle.Fill;
            richTextBox_DefaultDocument.Font = new Font("Microsoft Sans Serif", 12F);
            richTextBox_DefaultDocument.Location = new Point(230, 5);
            richTextBox_DefaultDocument.Margin = new Padding(16, 11, 16, 11);
            richTextBox_DefaultDocument.Name = "richTextBox_DefaultDocument";
            richTextBox_DefaultDocument.ReadOnly = true;
            richTextBox_DefaultDocument.Size = new Size(799, 50);
            richTextBox_DefaultDocument.TabIndex = 32;
            richTextBox_DefaultDocument.Text = "               On this options the system will not show any Document. It's the defaul and normal beahavior of the system.";
            // 
            // panel18
            // 
            panel18.BackColor = Color.LightGoldenrodYellow;
            panel18.Dock = DockStyle.Left;
            panel18.Location = new Point(205, 5);
            panel18.Margin = new Padding(0);
            panel18.MinimumSize = new Size(25, 10);
            panel18.Name = "panel18";
            panel18.Size = new Size(25, 50);
            panel18.TabIndex = 30;
            // 
            // radioButton_DefaultDocument
            // 
            radioButton_DefaultDocument.AutoSize = true;
            radioButton_DefaultDocument.Dock = DockStyle.Left;
            radioButton_DefaultDocument.Font = new Font("Microsoft Sans Serif", 12F);
            radioButton_DefaultDocument.Location = new Point(5, 5);
            radioButton_DefaultDocument.Margin = new Padding(16, 11, 16, 11);
            radioButton_DefaultDocument.MinimumSize = new Size(200, 0);
            radioButton_DefaultDocument.Name = "radioButton_DefaultDocument";
            radioButton_DefaultDocument.Size = new Size(200, 50);
            radioButton_DefaultDocument.TabIndex = 31;
            radioButton_DefaultDocument.Tag = "2";
            radioButton_DefaultDocument.Text = "Default Document";
            radioButton_DefaultDocument.UseVisualStyleBackColor = true;
            // 
            // grouper_BrowserVersion
            // 
            grouper_BrowserVersion.BackgroundColor = SystemColors.ControlLight;
            grouper_BrowserVersion.BackgroundGradientColor = Color.LightGray;
            grouper_BrowserVersion.BackgroundGradientMode = CodeVendor.Controls.Grouper.GroupBoxGradientMode.Vertical;
            grouper_BrowserVersion.BorderColor = Color.Gainsboro;
            grouper_BrowserVersion.BorderThickness = 1F;
            grouper_BrowserVersion.Controls.Add(richTextBox5);
            grouper_BrowserVersion.CustomGroupBoxColor = Color.White;
            grouper_BrowserVersion.Dock = DockStyle.Top;
            grouper_BrowserVersion.GroupTitle = "";
            grouper_BrowserVersion.Location = new Point(8, 25);
            grouper_BrowserVersion.Margin = new Padding(1, 14, 1, 1);
            grouper_BrowserVersion.MaximumSize = new Size(0, 200);
            grouper_BrowserVersion.MinimumSize = new Size(0, 100);
            grouper_BrowserVersion.Name = "grouper_BrowserVersion";
            grouper_BrowserVersion.Padding = new Padding(8, 18, 8, 8);
            grouper_BrowserVersion.PaintGroupBox = false;
            grouper_BrowserVersion.RoundCorners = 10;
            grouper_BrowserVersion.ShadowColor = Color.DarkGray;
            grouper_BrowserVersion.ShadowControl = false;
            grouper_BrowserVersion.ShadowThickness = 3;
            grouper_BrowserVersion.Size = new Size(1034, 100);
            grouper_BrowserVersion.TabIndex = 25;
            // 
            // richTextBox5
            // 
            richTextBox5.BackColor = Color.LightGoldenrodYellow;
            richTextBox5.BorderStyle = BorderStyle.None;
            richTextBox5.DetectUrls = false;
            richTextBox5.Dock = DockStyle.Fill;
            richTextBox5.Font = new Font("Microsoft Sans Serif", 12F);
            richTextBox5.Location = new Point(8, 18);
            richTextBox5.Margin = new Padding(16, 11, 16, 11);
            richTextBox5.Name = "richTextBox5";
            richTextBox5.ReadOnly = true;
            richTextBox5.ShortcutsEnabled = false;
            richTextBox5.Size = new Size(1018, 74);
            richTextBox5.TabIndex = 2;
            richTextBox5.Text = "";
            // 
            // tabPage_SearchForPDFFileWithin
            // 
            tabPage_SearchForPDFFileWithin.Controls.Add(grouper_DefinedAddressDocumentation);
            tabPage_SearchForPDFFileWithin.Controls.Add(panel_Space2);
            tabPage_SearchForPDFFileWithin.Controls.Add(grouper_SearchForPDFfileWithin);
            tabPage_SearchForPDFFileWithin.Controls.Add(panel_Space_SearchForPDFfileWithin);
            tabPage_SearchForPDFFileWithin.Location = new Point(4, 4);
            tabPage_SearchForPDFFileWithin.Margin = new Padding(16, 11, 16, 11);
            tabPage_SearchForPDFFileWithin.Name = "tabPage_SearchForPDFFileWithin";
            tabPage_SearchForPDFFileWithin.Size = new Size(1092, 629);
            tabPage_SearchForPDFFileWithin.TabIndex = 9;
            tabPage_SearchForPDFFileWithin.Text = "   Search for PDF file within";
            tabPage_SearchForPDFFileWithin.UseVisualStyleBackColor = true;
            // 
            // grouper_DefinedAddressDocumentation
            // 
            grouper_DefinedAddressDocumentation.AutoScroll = true;
            grouper_DefinedAddressDocumentation.AutoSize = true;
            grouper_DefinedAddressDocumentation.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            grouper_DefinedAddressDocumentation.BackgroundColor = SystemColors.Control;
            grouper_DefinedAddressDocumentation.BackgroundGradientColor = Color.Gainsboro;
            grouper_DefinedAddressDocumentation.BackgroundGradientMode = CodeVendor.Controls.Grouper.GroupBoxGradientMode.Vertical;
            grouper_DefinedAddressDocumentation.BorderColor = Color.Black;
            grouper_DefinedAddressDocumentation.BorderThickness = 2F;
            grouper_DefinedAddressDocumentation.Controls.Add(documentsAddressGroup_SearchForPDFfileWithin);
            grouper_DefinedAddressDocumentation.CustomGroupBoxColor = Color.White;
            grouper_DefinedAddressDocumentation.Dock = DockStyle.Fill;
            grouper_DefinedAddressDocumentation.GroupTitle = "Search for PDF file within";
            grouper_DefinedAddressDocumentation.Location = new Point(0, 150);
            grouper_DefinedAddressDocumentation.Margin = new Padding(1, 14, 1, 14);
            grouper_DefinedAddressDocumentation.MinimumSize = new Size(250, 300);
            grouper_DefinedAddressDocumentation.Name = "grouper_DefinedAddressDocumentation";
            grouper_DefinedAddressDocumentation.Padding = new Padding(8, 14, 8, 8);
            grouper_DefinedAddressDocumentation.PaintGroupBox = false;
            grouper_DefinedAddressDocumentation.RoundCorners = 10;
            grouper_DefinedAddressDocumentation.ShadowColor = Color.DarkGray;
            grouper_DefinedAddressDocumentation.ShadowControl = false;
            grouper_DefinedAddressDocumentation.ShadowThickness = 3;
            grouper_DefinedAddressDocumentation.Size = new Size(1092, 479);
            grouper_DefinedAddressDocumentation.TabIndex = 26;
            // 
            // documentsAddressGroup_SearchForPDFfileWithin
            // 
            documentsAddressGroup_SearchForPDFfileWithin.AutoSize = true;
            documentsAddressGroup_SearchForPDFfileWithin.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            documentsAddressGroup_SearchForPDFfileWithin.Dock = DockStyle.Fill;
            documentsAddressGroup_SearchForPDFfileWithin.Location = new Point(8, 14);
            documentsAddressGroup_SearchForPDFfileWithin.Margin = new Padding(21, 17, 21, 17);
            documentsAddressGroup_SearchForPDFfileWithin.MinimumSize = new Size(250, 250);
            documentsAddressGroup_SearchForPDFfileWithin.Name = "documentsAddressGroup_SearchForPDFfileWithin";
            documentsAddressGroup_SearchForPDFfileWithin.Size = new Size(1076, 457);
            documentsAddressGroup_SearchForPDFfileWithin.TabIndex = 24;
            // 
            // panel_Space2
            // 
            panel_Space2.AutoSize = true;
            panel_Space2.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panel_Space2.BackColor = Color.Transparent;
            panel_Space2.Dock = DockStyle.Top;
            panel_Space2.Location = new Point(0, 138);
            panel_Space2.Margin = new Padding(16, 11, 16, 11);
            panel_Space2.MinimumSize = new Size(250, 12);
            panel_Space2.Name = "panel_Space2";
            panel_Space2.Size = new Size(1092, 12);
            panel_Space2.TabIndex = 27;
            // 
            // grouper_SearchForPDFfileWithin
            // 
            grouper_SearchForPDFfileWithin.BackgroundColor = SystemColors.Info;
            grouper_SearchForPDFfileWithin.BackgroundGradientColor = Color.DarkGray;
            grouper_SearchForPDFfileWithin.BackgroundGradientMode = CodeVendor.Controls.Grouper.GroupBoxGradientMode.None;
            grouper_SearchForPDFfileWithin.BorderColor = Color.Black;
            grouper_SearchForPDFfileWithin.BorderThickness = 1F;
            grouper_SearchForPDFfileWithin.Controls.Add(richTextBox_SearchForPDFfileWithin);
            grouper_SearchForPDFfileWithin.CustomGroupBoxColor = Color.White;
            grouper_SearchForPDFfileWithin.Dock = DockStyle.Top;
            grouper_SearchForPDFfileWithin.GroupTitle = "Information about Search for PDF file within";
            grouper_SearchForPDFfileWithin.Location = new Point(0, 12);
            grouper_SearchForPDFfileWithin.Margin = new Padding(1, 14, 1, 1);
            grouper_SearchForPDFfileWithin.Name = "grouper_SearchForPDFfileWithin";
            grouper_SearchForPDFfileWithin.Padding = new Padding(8, 28, 8, 8);
            grouper_SearchForPDFfileWithin.PaintGroupBox = false;
            grouper_SearchForPDFfileWithin.RoundCorners = 10;
            grouper_SearchForPDFfileWithin.ShadowColor = Color.DarkGray;
            grouper_SearchForPDFfileWithin.ShadowControl = false;
            grouper_SearchForPDFfileWithin.ShadowThickness = 3;
            grouper_SearchForPDFfileWithin.Size = new Size(1092, 126);
            grouper_SearchForPDFfileWithin.TabIndex = 29;
            // 
            // richTextBox_SearchForPDFfileWithin
            // 
            richTextBox_SearchForPDFfileWithin.BackColor = SystemColors.Info;
            richTextBox_SearchForPDFfileWithin.BorderStyle = BorderStyle.None;
            richTextBox_SearchForPDFfileWithin.Dock = DockStyle.Fill;
            richTextBox_SearchForPDFfileWithin.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            richTextBox_SearchForPDFfileWithin.Location = new Point(8, 28);
            richTextBox_SearchForPDFfileWithin.Margin = new Padding(16, 11, 16, 11);
            richTextBox_SearchForPDFfileWithin.Name = "richTextBox_SearchForPDFfileWithin";
            richTextBox_SearchForPDFfileWithin.Size = new Size(1076, 90);
            richTextBox_SearchForPDFfileWithin.TabIndex = 29;
            richTextBox_SearchForPDFfileWithin.Text = "\tSpecifies these folder where the system will search for PDF files containing in the name the PartNumber in question.";
            // 
            // panel_Space_SearchForPDFfileWithin
            // 
            panel_Space_SearchForPDFfileWithin.AutoSize = true;
            panel_Space_SearchForPDFfileWithin.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panel_Space_SearchForPDFfileWithin.BackColor = Color.Transparent;
            panel_Space_SearchForPDFfileWithin.Dock = DockStyle.Top;
            panel_Space_SearchForPDFfileWithin.Location = new Point(0, 0);
            panel_Space_SearchForPDFfileWithin.Margin = new Padding(16, 11, 16, 11);
            panel_Space_SearchForPDFfileWithin.MinimumSize = new Size(250, 12);
            panel_Space_SearchForPDFfileWithin.Name = "panel_Space_SearchForPDFfileWithin";
            panel_Space_SearchForPDFfileWithin.Size = new Size(1092, 12);
            panel_Space_SearchForPDFfileWithin.TabIndex = 30;
            // 
            // tabPage_ConvertFilesFrontThisLocation
            // 
            tabPage_ConvertFilesFrontThisLocation.Controls.Add(grouper_ConvertFilesFrontThisLocation);
            tabPage_ConvertFilesFrontThisLocation.Controls.Add(panel_ScanTheseFoltherFor);
            tabPage_ConvertFilesFrontThisLocation.Controls.Add(grouper_ConvertFilesFrontThisLocationInformation);
            tabPage_ConvertFilesFrontThisLocation.Controls.Add(panel_ScanTheseFoltherForInformation);
            tabPage_ConvertFilesFrontThisLocation.Location = new Point(4, 4);
            tabPage_ConvertFilesFrontThisLocation.Margin = new Padding(16, 11, 16, 11);
            tabPage_ConvertFilesFrontThisLocation.Name = "tabPage_ConvertFilesFrontThisLocation";
            tabPage_ConvertFilesFrontThisLocation.Size = new Size(1092, 629);
            tabPage_ConvertFilesFrontThisLocation.TabIndex = 10;
            tabPage_ConvertFilesFrontThisLocation.Text = "   Convert files front this location";
            tabPage_ConvertFilesFrontThisLocation.UseVisualStyleBackColor = true;
            // 
            // grouper_ConvertFilesFrontThisLocation
            // 
            grouper_ConvertFilesFrontThisLocation.AutoScroll = true;
            grouper_ConvertFilesFrontThisLocation.AutoSize = true;
            grouper_ConvertFilesFrontThisLocation.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            grouper_ConvertFilesFrontThisLocation.BackgroundColor = SystemColors.Control;
            grouper_ConvertFilesFrontThisLocation.BackgroundGradientColor = Color.Gainsboro;
            grouper_ConvertFilesFrontThisLocation.BackgroundGradientMode = CodeVendor.Controls.Grouper.GroupBoxGradientMode.Vertical;
            grouper_ConvertFilesFrontThisLocation.BorderColor = Color.Black;
            grouper_ConvertFilesFrontThisLocation.BorderThickness = 2F;
            grouper_ConvertFilesFrontThisLocation.Controls.Add(scanDocumentsAddressGroup_Default);
            grouper_ConvertFilesFrontThisLocation.CustomGroupBoxColor = Color.White;
            grouper_ConvertFilesFrontThisLocation.Dock = DockStyle.Top;
            grouper_ConvertFilesFrontThisLocation.GroupTitle = "Scan these folther for...";
            grouper_ConvertFilesFrontThisLocation.Location = new Point(0, 138);
            grouper_ConvertFilesFrontThisLocation.Margin = new Padding(1, 14, 1, 14);
            grouper_ConvertFilesFrontThisLocation.MinimumSize = new Size(250, 250);
            grouper_ConvertFilesFrontThisLocation.Name = "grouper_ConvertFilesFrontThisLocation";
            grouper_ConvertFilesFrontThisLocation.Padding = new Padding(10, 14, 10, 10);
            grouper_ConvertFilesFrontThisLocation.PaintGroupBox = false;
            grouper_ConvertFilesFrontThisLocation.RoundCorners = 10;
            grouper_ConvertFilesFrontThisLocation.ShadowColor = Color.DarkGray;
            grouper_ConvertFilesFrontThisLocation.ShadowControl = false;
            grouper_ConvertFilesFrontThisLocation.ShadowThickness = 3;
            grouper_ConvertFilesFrontThisLocation.Size = new Size(1092, 518);
            grouper_ConvertFilesFrontThisLocation.TabIndex = 31;
            // 
            // scanDocumentsAddressGroup_Default
            // 
            scanDocumentsAddressGroup_Default.AutoSize = true;
            scanDocumentsAddressGroup_Default.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            scanDocumentsAddressGroup_Default.Dock = DockStyle.Fill;
            scanDocumentsAddressGroup_Default.Location = new Point(10, 14);
            scanDocumentsAddressGroup_Default.Margin = new Padding(21, 17, 21, 17);
            scanDocumentsAddressGroup_Default.MinimumSize = new Size(250, 250);
            scanDocumentsAddressGroup_Default.Name = "scanDocumentsAddressGroup_Default";
            scanDocumentsAddressGroup_Default.Size = new Size(1072, 494);
            scanDocumentsAddressGroup_Default.TabIndex = 0;
            // 
            // panel_ScanTheseFoltherFor
            // 
            panel_ScanTheseFoltherFor.AutoSize = true;
            panel_ScanTheseFoltherFor.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panel_ScanTheseFoltherFor.BackColor = Color.Transparent;
            panel_ScanTheseFoltherFor.Dock = DockStyle.Top;
            panel_ScanTheseFoltherFor.Location = new Point(0, 118);
            panel_ScanTheseFoltherFor.Margin = new Padding(16, 11, 16, 11);
            panel_ScanTheseFoltherFor.MinimumSize = new Size(250, 20);
            panel_ScanTheseFoltherFor.Name = "panel_ScanTheseFoltherFor";
            panel_ScanTheseFoltherFor.Size = new Size(1092, 20);
            panel_ScanTheseFoltherFor.TabIndex = 32;
            // 
            // grouper_ConvertFilesFrontThisLocationInformation
            // 
            grouper_ConvertFilesFrontThisLocationInformation.BackgroundColor = SystemColors.Info;
            grouper_ConvertFilesFrontThisLocationInformation.BackgroundGradientColor = Color.DarkGray;
            grouper_ConvertFilesFrontThisLocationInformation.BackgroundGradientMode = CodeVendor.Controls.Grouper.GroupBoxGradientMode.None;
            grouper_ConvertFilesFrontThisLocationInformation.BorderColor = Color.Black;
            grouper_ConvertFilesFrontThisLocationInformation.BorderThickness = 1F;
            grouper_ConvertFilesFrontThisLocationInformation.Controls.Add(richTextBox7);
            grouper_ConvertFilesFrontThisLocationInformation.CustomGroupBoxColor = Color.White;
            grouper_ConvertFilesFrontThisLocationInformation.Dock = DockStyle.Top;
            grouper_ConvertFilesFrontThisLocationInformation.GroupTitle = "Convert files to PDF format";
            grouper_ConvertFilesFrontThisLocationInformation.Location = new Point(0, 33);
            grouper_ConvertFilesFrontThisLocationInformation.Margin = new Padding(1, 14, 1, 1);
            grouper_ConvertFilesFrontThisLocationInformation.Name = "grouper_ConvertFilesFrontThisLocationInformation";
            grouper_ConvertFilesFrontThisLocationInformation.Padding = new Padding(10, 25, 10, 10);
            grouper_ConvertFilesFrontThisLocationInformation.PaintGroupBox = false;
            grouper_ConvertFilesFrontThisLocationInformation.RoundCorners = 10;
            grouper_ConvertFilesFrontThisLocationInformation.ShadowColor = Color.DarkGray;
            grouper_ConvertFilesFrontThisLocationInformation.ShadowControl = false;
            grouper_ConvertFilesFrontThisLocationInformation.ShadowThickness = 3;
            grouper_ConvertFilesFrontThisLocationInformation.Size = new Size(1092, 85);
            grouper_ConvertFilesFrontThisLocationInformation.TabIndex = 33;
            // 
            // richTextBox7
            // 
            richTextBox7.BackColor = SystemColors.Info;
            richTextBox7.BorderStyle = BorderStyle.None;
            richTextBox7.Dock = DockStyle.Fill;
            richTextBox7.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            richTextBox7.Location = new Point(10, 25);
            richTextBox7.Margin = new Padding(16, 11, 16, 11);
            richTextBox7.Name = "richTextBox7";
            richTextBox7.Size = new Size(1072, 50);
            richTextBox7.TabIndex = 29;
            richTextBox7.Text = "";
            // 
            // panel_ScanTheseFoltherForInformation
            // 
            panel_ScanTheseFoltherForInformation.AutoSize = true;
            panel_ScanTheseFoltherForInformation.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panel_ScanTheseFoltherForInformation.BackColor = Color.Transparent;
            panel_ScanTheseFoltherForInformation.Dock = DockStyle.Top;
            panel_ScanTheseFoltherForInformation.Location = new Point(0, 0);
            panel_ScanTheseFoltherForInformation.Margin = new Padding(16, 11, 16, 11);
            panel_ScanTheseFoltherForInformation.MinimumSize = new Size(250, 33);
            panel_ScanTheseFoltherForInformation.Name = "panel_ScanTheseFoltherForInformation";
            panel_ScanTheseFoltherForInformation.Size = new Size(1092, 33);
            panel_ScanTheseFoltherForInformation.TabIndex = 34;
            // 
            // tabControlExtendBase
            // 
            tabControlExtendBase.AlignmentExtended = TabAlignment.Top;
            tabControlExtendBase.AppearanceExtended = TabAppearance.Normal;
            tabControlExtendBase.HotTrack = true;
            tabControlExtendBase.HotTrackExtended = true;
            tabControlExtendBase.Location = new Point(0, 0);
            tabControlExtendBase.MultilineExtended = false;
            tabControlExtendBase.Name = "tabControlExtendBase";
            tabControlExtendBase.PaddingExtended = new Point(6, 3);
            tabControlExtendBase.SelectedIndex = 0;
            tabControlExtendBase.Size = new Size(200, 100);
            tabControlExtendBase.TabIndex = 0;
            // 
            // grouper_ButtonSaveCancel
            // 
            grouper_ButtonSaveCancel.BackgroundColor = SystemColors.Control;
            grouper_ButtonSaveCancel.BackgroundGradientColor = Color.White;
            grouper_ButtonSaveCancel.BackgroundGradientMode = CodeVendor.Controls.Grouper.GroupBoxGradientMode.None;
            grouper_ButtonSaveCancel.BorderColor = Color.Black;
            grouper_ButtonSaveCancel.BorderThickness = 1F;
            grouper_ButtonSaveCancel.Controls.Add(button_Save_Exit);
            grouper_ButtonSaveCancel.Controls.Add(button_Cancel);
            grouper_ButtonSaveCancel.CustomGroupBoxColor = Color.White;
            grouper_ButtonSaveCancel.Dock = DockStyle.Bottom;
            grouper_ButtonSaveCancel.GroupTitle = "";
            grouper_ButtonSaveCancel.Location = new Point(10, 677);
            grouper_ButtonSaveCancel.Name = "grouper_ButtonSaveCancel";
            grouper_ButtonSaveCancel.Padding = new Padding(20);
            grouper_ButtonSaveCancel.PaintGroupBox = false;
            grouper_ButtonSaveCancel.RoundCorners = 10;
            grouper_ButtonSaveCancel.ShadowColor = Color.DarkGray;
            grouper_ButtonSaveCancel.ShadowControl = false;
            grouper_ButtonSaveCancel.ShadowThickness = 3;
            grouper_ButtonSaveCancel.Size = new Size(1487, 58);
            grouper_ButtonSaveCancel.TabIndex = 7;
            // 
            // button_Save_Exit
            // 
            button_Save_Exit.Enabled = false;
            button_Save_Exit.Font = new Font("Microsoft Sans Serif", 14F);
            button_Save_Exit.Location = new Point(450, 18);
            button_Save_Exit.Name = "button_Save_Exit";
            button_Save_Exit.Size = new Size(100, 35);
            button_Save_Exit.TabIndex = 5;
            button_Save_Exit.Text = "Save/Exit";
            button_Save_Exit.UseVisualStyleBackColor = true;
            button_Save_Exit.Click += ButtonSave_ExitClick;
            // 
            // button_Cancel
            // 
            button_Cancel.Font = new Font("Microsoft Sans Serif", 14F);
            button_Cancel.Location = new Point(642, 18);
            button_Cancel.Name = "button_Cancel";
            button_Cancel.Size = new Size(100, 35);
            button_Cancel.TabIndex = 6;
            button_Cancel.Text = "Cancel";
            button_Cancel.UseVisualStyleBackColor = true;
            button_Cancel.Click += ButtonCancelClick;
            // 
            // SolutionsProperties
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1507, 745);
            Controls.Add(splitContainerSetting);
            Controls.Add(grouper_ButtonSaveCancel);
            Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.SizableToolWindow;
            MinimizeBox = false;
            MinimumSize = new Size(487, 230);
            Name = "SolutionsProperties";
            Padding = new Padding(10);
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            FormClosing += SolutionsProperties_FormClosing;
            Load += SolutionsProperties_Load;
            Shown += SolutionsProperties_Shown;
            _contextMenuStrip.ResumeLayout(false);
            splitContainerSetting.Panel1.ResumeLayout(false);
            splitContainerSetting.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainerSetting).EndInit();
            splitContainerSetting.ResumeLayout(false);
            customTabControlSetting.ResumeLayout(false);
            tabPageApplicationSetting.ResumeLayout(false);
            grouper7.ResumeLayout(false);
            grouper7.PerformLayout();
            grouper_ArgsToInitializarApp.ResumeLayout(false);
            grouper_ArgsToInitializarApp.PerformLayout();
            grouper_InfoArgsToInitializarApp.ResumeLayout(false);
            grouper_DepartProperties.ResumeLayout(false);
            grouper_DepartProperties.PerformLayout();
            tabPageNotificationsOptions.ResumeLayout(false);
            grouper2.ResumeLayout(false);
            panel7.ResumeLayout(false);
            grouper_Notifycations.ResumeLayout(false);
            grouper_Notifycations.PerformLayout();
            grouper3.ResumeLayout(false);
            grouper3.PerformLayout();
            grouper4.ResumeLayout(false);
            grouper4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)trackBar_Interval).EndInit();
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            tabPageUSB_DeviceUtility.ResumeLayout(false);
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            grouper_AddNewPrintHelpsButtons.ResumeLayout(false);
            flowLayoutPanel_AddNewPrintHelpsButton.ResumeLayout(false);
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)PicturesBox_Image).EndInit();
            tabPage_Documentation.ResumeLayout(false);
            tabPage_Documentation.PerformLayout();
            grouper_DocumentationBehavior.ResumeLayout(false);
            panel_NotDocumentToShow.ResumeLayout(false);
            panel_NotDocumentToShow.PerformLayout();
            panel_LastTwoVersions.ResumeLayout(false);
            panel_LastTwoVersions.PerformLayout();
            panel_AllVersionsFound.ResumeLayout(false);
            panel_AllVersionsFound.PerformLayout();
            panel_TheLastRevision.ResumeLayout(false);
            panel_TheLastRevision.PerformLayout();
            panel_SpecifiedDocument.ResumeLayout(false);
            panel_SpecifiedDocument.PerformLayout();
            panel_DefaultDocument.ResumeLayout(false);
            panel_DefaultDocument.PerformLayout();
            grouper_BrowserVersion.ResumeLayout(false);
            tabPage_SearchForPDFFileWithin.ResumeLayout(false);
            tabPage_SearchForPDFFileWithin.PerformLayout();
            grouper_DefinedAddressDocumentation.ResumeLayout(false);
            grouper_DefinedAddressDocumentation.PerformLayout();
            grouper_SearchForPDFfileWithin.ResumeLayout(false);
            tabPage_ConvertFilesFrontThisLocation.ResumeLayout(false);
            tabPage_ConvertFilesFrontThisLocation.PerformLayout();
            grouper_ConvertFilesFrontThisLocation.ResumeLayout(false);
            grouper_ConvertFilesFrontThisLocation.PerformLayout();
            grouper_ConvertFilesFrontThisLocationInformation.ResumeLayout(false);
            grouper_ButtonSaveCancel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private CustomTabControl tabControlExtendBase = new CustomTabControl();
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.Button button_Save_Exit;
        private System.Windows.Forms.Button button_Cancel;
        private CodeVendor.Controls.Grouper grouper_ButtonSaveCancel;
        private System.Windows.Forms.SplitContainer splitContainerSetting;
        private System.Windows.Forms.TreeView treeViewApplicationsSetting;
        private System.Windows.Forms.ImageList imageListDrag;
        private System.Windows.Forms.ContextMenuStrip _contextMenuStrip;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_Deleted_USB;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_ClearDevices;
        private ImageList imageListTreeView;
        private CustomTabControl customTabControlSetting;
        private TabPage tabPageApplicationSetting;
        private CodeVendor.Controls.Grouper grouper7;
        private RadioButton radioButton2;
        private RadioButton radioButton1;
        private CodeVendor.Controls.Grouper grouper_ArgsToInitializarApp;
        private Label label_DescriptionInfo;
        private Label label_Description;
        private Label label_CompanyInfo;
        private Label label_company;
        private CheckBox CheckBox_CreateStartupFolderShortcut;
        private CheckBox CheckBox_ShowDesktopShortcut;
        private CheckBox checkBox_CheckInternetAccess;
        private CodeVendor.Controls.Grouper grouper_InfoArgsToInitializarApp;
        private RichTextBox richTextBox_InfoArgsToInitializarApp;
        private CodeVendor.Controls.Grouper grouper_DepartProperties;
        private TextBox textBox_DataBaseAddress;
        private ComboBox comboBox_ApplicationDepartmentName;
        private Label label_DataBaseAddress;
        private Label label_DepartmentName;
        private TextBox textBoxApplicationHTMLtemples;
        private Button button_BrowserDataBase;
        private Button button_ApplicationHTMLtemples;
        private Label labelApplicationHTMLtemples;
        private TabPage tabPageNotificationsOptions;
        private CodeVendor.Controls.Grouper grouper2;
        private Panel panel7;
        private CodeVendor.Controls.Grouper grouper_Notifycations;
        private CheckBox checkBox_ShowEmailsNotifications;
        private CheckBox checkBox_ShowDataBaseUpdateNotifications;
        private CheckBox checkBox_ShowWarningsNotifications;
        private CodeVendor.Controls.Grouper grouper3;
        private CheckBox checkBox_ShowMyOwnNotifications;
        private CheckBox checkBox_SendMyOwnNotifications;
        private CodeVendor.Controls.Grouper grouper4;
        private Label label_IntervalSetTo;
        private TrackBar trackBar_Interval;
        private RadioButton radioButton_Hours;
        private RadioButton radioButton_Minutes;
        private RadioButton radioButton_secund;
        private Panel panel6;
        private Label label1;
        private CheckBox checkBox_EnableSendReceiveNotifycations;
        private CheckBox checkBox_SetIntervalReadNotifications;
        private TabPage tabPageUSB_DeviceUtility;
        private SplitContainer splitContainer1;
        private RichTextBox richTextBox1;
        private CodeVendor.Controls.Grouper grouper_AddNewPrintHelpsButtons;
        private FlowLayoutPanel flowLayoutPanel_AddNewPrintHelpsButton;
        private Button button_Adjustment;
        private Button button_RemoveScanner;
        private Button button_PrintHelps;
        private Button button_AddNew;
        private Panel panel1;
        private PictureBox PicturesBox_Image;
        private TabPage tabPage_Documentation;
        private CodeVendor.Controls.Grouper grouper_DocumentationBehavior;
        private Panel panel_NotDocumentToShow;
        private RichTextBox richTextBox_NotDocumentToShow;
        private Panel panel16;
        private RadioButton radioButton_NotDocumentToShow;
        private Panel panel_LastTwoVersions;
        private RichTextBox richTextBox_LastTwoVersions;
        private Panel panel15;
        private RadioButton radioButton_LastTwoVersions;
        private Panel panel_AllVersionsFound;
        private RichTextBox richTextBox_AllVersionsFound;
        private Panel panel13;
        private RadioButton radioButton_AllVersionsFound;
        private Panel panel_TheLastRevision;
        private RichTextBox richTextBox_TheLastRevision;
        private Panel panel12;
        private RadioButton radioButton_TheLastRevision;
        private Panel panel_SpecifiedDocument;
        private RichTextBox richTextBox_SpecifiedDocument;
        private Panel panel10;
        private RadioButton radioButton_SpecifiedDocument;
        private Panel panel_DefaultDocument;
        private RichTextBox richTextBox_DefaultDocument;
        private Panel panel18;
        private RadioButton radioButton_DefaultDocument;
        private CodeVendor.Controls.Grouper grouper_BrowserVersion;
        private RichTextBox richTextBox5;
        private TabPage tabPage_SearchForPDFFileWithin;
        private CodeVendor.Controls.Grouper grouper_DefinedAddressDocumentation;
        private Controls.DocumentationBehavior.DocumentsAddressGroup documentsAddressGroup_SearchForPDFfileWithin;
        private CodeVendor.Controls.Grouper grouper_SearchForPDFfileWithin;
        private RichTextBox richTextBox_SearchForPDFfileWithin;
        private TabPage tabPage_ConvertFilesFrontThisLocation;
        private CodeVendor.Controls.Grouper grouper_ConvertFilesFrontThisLocation;
        private Controls.DocumentationBehavior.ScanDocumentsAddressGroup scanDocumentsAddressGroup_Default;
        private Panel panel_ScanTheseFoltherFor;
        private CodeVendor.Controls.Grouper grouper_ConvertFilesFrontThisLocationInformation;
        private RichTextBox richTextBox7;
        private Panel panel_ScanTheseFoltherForInformation;
        private Panel panel_Space2;
        private Panel panel_Space_SearchForPDFfileWithin;
    }
}