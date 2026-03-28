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
            grouper7 = new CodeVendor.Controls.Grouper();
            radioButton2 = new RadioButton();
            radioButton1 = new RadioButton();
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
            grouper4 = new CodeVendor.Controls.Grouper();
            label_IntervalSetTo = new Label();
            trackBar_Interval = new TrackBar();
            radioButton_Hours = new RadioButton();
            radioButton_Minutes = new RadioButton();
            radioButton_secund = new RadioButton();
            grouper_Notifycations = new CodeVendor.Controls.Grouper();
            checkBox_ShowEmailsNotifications = new CheckBox();
            checkBox_ShowDataBaseUpdateNotifications = new CheckBox();
            checkBox_ShowWarningsNotifications = new CheckBox();
            grouper3 = new CodeVendor.Controls.Grouper();
            checkBox_ShowMyOwnNotifications = new CheckBox();
            checkBox_SendMyOwnNotifications = new CheckBox();
            panel6 = new Panel();
            label1 = new Label();
            checkBox_EnableSendReceiveNotifycations = new CheckBox();
            checkBox_SetIntervalReadNotifications = new CheckBox();
            tabPageUSB_DeviceUtility = new TabPage();
            splitContainer1 = new SplitContainer();
            richTextBox1 = new RichTextBox();
            panel1 = new Panel();
            PicturesBox_Image = new PictureBox();
            grouper_AddNewPrintHelpsButtons = new CodeVendor.Controls.Grouper();
            flowLayoutPanel_AddNewPrintHelpsButton = new FlowLayoutPanel();
            button_AddNew = new Button();
            button_Adjustment = new Button();
            button_RemoveScanner = new Button();
            button_PrintHelps = new Button();
            tabPageSave_Options = new TabPage();
            grouper6 = new CodeVendor.Controls.Grouper();
            richTextBox3 = new RichTextBox();
            checkBoxSaveTheInformationWhenTheUserSaves = new CheckBox();
            richTextBox2 = new RichTextBox();
            checkBoxSaveTheInformationByTime = new CheckBox();
            grouper5 = new CodeVendor.Controls.Grouper();
            radioButtonEvery30minutes = new RadioButton();
            radioButtonEvery15minutes = new RadioButton();
            radioButtonEvery5minutes = new RadioButton();
            checkBoxSaveEachTimeTheInformationIsChanged = new CheckBox();
            tabPage_InstallationLog = new TabPage();
            richTextBox_FirstInstalation = new RichTextBox();
            tabPage_SecurityLockFolder = new TabPage();
            grouper_SecurityLockFolder = new CodeVendor.Controls.Grouper();
            panel2 = new Panel();
            flowLayoutPanel1 = new FlowLayoutPanel();
            comboBox_SecurityLockFolder = new ComboBox();
            button_Browser = new Button();
            grouper_SecurityLockFolderButtons = new CodeVendor.Controls.Grouper();
            button_Lock = new Button();
            button_Delete = new Button();
            button_UnLock = new Button();
            grouper_Properties = new CodeVendor.Controls.Grouper();
            checkBox_Hidden = new CheckBox();
            checkBox_ReadOnly = new CheckBox();
            checkBox_System = new CheckBox();
            tabPage_RegisterDLL = new TabPage();
            grouper9 = new CodeVendor.Controls.Grouper();
            textBox_BrowsedDLL = new TextBox();
            button_BrowserDLL = new Button();
            button_UnregisterDLL = new Button();
            button_RegisterDLL = new Button();
            tabPage_SystemCompatibility = new TabPage();
            grouper10 = new CodeVendor.Controls.Grouper();
            checkBox_SupportDoubleBuffering = new CheckBox();
            label_SupportDoubleBuffering = new Label();
            tabPage_Documentation = new TabPage();
            grouper_DocumentationBehavior = new CodeVendor.Controls.Grouper();
            grouper_NoDocumentsToShow = new CodeVendor.Controls.Grouper();
            richTextBox_NoDocumentsToShow = new RichTextBox();
            panel_NoDocumentsToShow = new Panel();
            radioButton_NoDocumentsToShow = new RadioButton();
            grouper_Last2Versions = new CodeVendor.Controls.Grouper();
            richTextBox4 = new RichTextBox();
            panel3 = new Panel();
            numericUpDown1 = new NumericUpDown();
            radioButton_Last2Versions = new RadioButton();
            label_Versions = new Label();
            grouper_AllVersionsFound = new CodeVendor.Controls.Grouper();
            richTextBox_AllVersionsFound = new RichTextBox();
            panel_AllVersionsFound = new Panel();
            radioButton_AllVersionsFound = new RadioButton();
            grouper_LastRevision = new CodeVendor.Controls.Grouper();
            richTextBox_LastRevision = new RichTextBox();
            panel_LastRevision = new Panel();
            radioButton_LastRevision = new RadioButton();
            grouper_SpecifiedDocument = new CodeVendor.Controls.Grouper();
            richTextBox_SpecifiedDocument = new RichTextBox();
            panel_SpecifiedDocument = new Panel();
            radioButton_SpecifiedDocument = new RadioButton();
            grouper_BrowserVersion = new CodeVendor.Controls.Grouper();
            checkBox_PdfViewer = new CheckBox();
            richTextBox5 = new RichTextBox();
            tabPage_SearchForPDFFileWithin = new TabPage();
            grouper_DefinedAddressDocumentation = new CodeVendor.Controls.Grouper();
            documentsAddressGroup_SearchForPDFfileWithin = new MyStuff11net.DocumentsAddressGroup();
            panel_Space2 = new Panel();
            grouper_SearchForPDFfileWithin = new CodeVendor.Controls.Grouper();
            richTextBox_SearchForPDFfileWithin = new RichTextBox();
            panel_Space_SearchForPDFfileWithin = new Panel();
            tabPage_ConvertFilesFrontThisLocation = new TabPage();
            grouper_ConvertFilesFrontThisLocation = new CodeVendor.Controls.Grouper();
            scanDocumentsAddressGroup_Default = new MyStuff11net.ScanDocumentsAddressGroup();
            panel_ScanTheseFoltherFor = new Panel();
            grouper_ConvertFilesFrontThisLocationInformation = new CodeVendor.Controls.Grouper();
            richTextBox7 = new RichTextBox();
            panel_ScanTheseFoltherForInformation = new Panel();
            tabPage_PeerToPeerManagement = new TabPage();
            grouper_P2PsettingUtilityPath = new CodeVendor.Controls.Grouper();
            label_NgrokPath = new Label();
            checkBox_IsSuperPeer = new CheckBox();
            button_BrowserNgrokUtilityPath = new Button();
            textBox_NgrokUtilityPath = new TextBox();
            panel9 = new Panel();
            grouper_P2PManagement = new CodeVendor.Controls.Grouper();
            richTextBox_P2PInfomation = new RichTextBox();
            panel8 = new Panel();
            tabControlExtendBase = new CustomTabControl();
            grouper_ButtonSaveCancel = new CodeVendor.Controls.Grouper();
            button_Save = new Button();
            button_Cancel = new Button();
            _contextMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainerSetting).BeginInit();
            splitContainerSetting.Panel1.SuspendLayout();
            splitContainerSetting.Panel2.SuspendLayout();
            splitContainerSetting.SuspendLayout();
            customTabControlSetting.SuspendLayout();
            tabPageApplicationSetting.SuspendLayout();
            grouper_ArgsToInitializarApp.SuspendLayout();
            grouper_InfoArgsToInitializarApp.SuspendLayout();
            grouper7.SuspendLayout();
            grouper_DepartProperties.SuspendLayout();
            tabPageNotificationsOptions.SuspendLayout();
            grouper2.SuspendLayout();
            panel7.SuspendLayout();
            grouper4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)trackBar_Interval).BeginInit();
            grouper_Notifycations.SuspendLayout();
            grouper3.SuspendLayout();
            panel6.SuspendLayout();
            tabPageUSB_DeviceUtility.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)PicturesBox_Image).BeginInit();
            grouper_AddNewPrintHelpsButtons.SuspendLayout();
            flowLayoutPanel_AddNewPrintHelpsButton.SuspendLayout();
            tabPageSave_Options.SuspendLayout();
            grouper6.SuspendLayout();
            grouper5.SuspendLayout();
            tabPage_InstallationLog.SuspendLayout();
            tabPage_SecurityLockFolder.SuspendLayout();
            grouper_SecurityLockFolder.SuspendLayout();
            panel2.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            grouper_SecurityLockFolderButtons.SuspendLayout();
            grouper_Properties.SuspendLayout();
            tabPage_RegisterDLL.SuspendLayout();
            grouper9.SuspendLayout();
            tabPage_SystemCompatibility.SuspendLayout();
            grouper10.SuspendLayout();
            tabPage_Documentation.SuspendLayout();
            grouper_DocumentationBehavior.SuspendLayout();
            grouper_NoDocumentsToShow.SuspendLayout();
            panel_NoDocumentsToShow.SuspendLayout();
            grouper_Last2Versions.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            grouper_AllVersionsFound.SuspendLayout();
            panel_AllVersionsFound.SuspendLayout();
            grouper_LastRevision.SuspendLayout();
            panel_LastRevision.SuspendLayout();
            grouper_SpecifiedDocument.SuspendLayout();
            panel_SpecifiedDocument.SuspendLayout();
            grouper_BrowserVersion.SuspendLayout();
            tabPage_SearchForPDFFileWithin.SuspendLayout();
            grouper_DefinedAddressDocumentation.SuspendLayout();
            grouper_SearchForPDFfileWithin.SuspendLayout();
            tabPage_ConvertFilesFrontThisLocation.SuspendLayout();
            grouper_ConvertFilesFrontThisLocation.SuspendLayout();
            grouper_ConvertFilesFrontThisLocationInformation.SuspendLayout();
            tabPage_PeerToPeerManagement.SuspendLayout();
            grouper_P2PsettingUtilityPath.SuspendLayout();
            grouper_P2PManagement.SuspendLayout();
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
            splitContainerSetting.Size = new Size(1272, 701);
            splitContainerSetting.SplitterDistance = 325;
            splitContainerSetting.TabIndex = 11;
            // 
            // treeViewApplicationsSetting
            // 
            treeViewApplicationsSetting.AllowDrop = true;
            treeViewApplicationsSetting.ContextMenuStrip = _contextMenuStrip;
            treeViewApplicationsSetting.Dock = DockStyle.Fill;
            treeViewApplicationsSetting.HideSelection = false;
            treeViewApplicationsSetting.ImageIndex = 0;
            treeViewApplicationsSetting.ImageList = imageListTreeView;
            treeViewApplicationsSetting.Location = new Point(0, 0);
            treeViewApplicationsSetting.Margin = new Padding(5, 5, 5, 5);
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
            treeViewApplicationsSetting.Size = new Size(321, 697);
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
            customTabControlSetting.Controls.Add(tabPageApplicationSetting);
            customTabControlSetting.Controls.Add(tabPageNotificationsOptions);
            customTabControlSetting.Controls.Add(tabPageUSB_DeviceUtility);
            customTabControlSetting.Controls.Add(tabPageSave_Options);
            customTabControlSetting.Controls.Add(tabPage_InstallationLog);
            customTabControlSetting.Controls.Add(tabPage_SecurityLockFolder);
            customTabControlSetting.Controls.Add(tabPage_RegisterDLL);
            customTabControlSetting.Controls.Add(tabPage_SystemCompatibility);
            customTabControlSetting.Controls.Add(tabPage_Documentation);
            customTabControlSetting.Controls.Add(tabPage_SearchForPDFFileWithin);
            customTabControlSetting.Controls.Add(tabPage_ConvertFilesFrontThisLocation);
            customTabControlSetting.Controls.Add(tabPage_PeerToPeerManagement);
            customTabControlSetting.DisplayStyle = TabStyle.Chrome;
            // 
            // 
            // 
            customTabControlSetting.DisplayStyleProvider.BorderColor = SystemColors.ControlDark;
            customTabControlSetting.DisplayStyleProvider.BorderColorHot = SystemColors.ControlDark;
            customTabControlSetting.DisplayStyleProvider.BorderColorSelected = Color.FromArgb(132, 130, 132);
            customTabControlSetting.DisplayStyleProvider.CloserColor = Color.DarkGray;
            customTabControlSetting.DisplayStyleProvider.CloserColorActive = Color.White;
            customTabControlSetting.DisplayStyleProvider.Radius = 16;
            customTabControlSetting.DisplayStyleProvider.TextColor = SystemColors.ControlText;
            customTabControlSetting.DisplayStyleProvider.TextColorDisabled = SystemColors.ControlDark;
            customTabControlSetting.DisplayStyleProvider.TextColorSelected = SystemColors.ControlText;
            customTabControlSetting.Dock = DockStyle.Fill;
            customTabControlSetting.Location = new Point(0, 0);
            customTabControlSetting.Margin = new Padding(5, 5, 5, 5);
            customTabControlSetting.Name = "customTabControlSetting";
            customTabControlSetting.SelectedIndex = 0;
            customTabControlSetting.Size = new Size(939, 697);
            customTabControlSetting.TabIndex = 0;
            // 
            // tabPageApplicationSetting
            // 
            tabPageApplicationSetting.Controls.Add(grouper_ArgsToInitializarApp);
            tabPageApplicationSetting.Controls.Add(grouper7);
            tabPageApplicationSetting.Controls.Add(grouper_DepartProperties);
            tabPageApplicationSetting.Location = new Point(4, 4);
            tabPageApplicationSetting.Margin = new Padding(5, 5, 5, 5);
            tabPageApplicationSetting.Name = "tabPageApplicationSetting";
            tabPageApplicationSetting.Padding = new Padding(5, 5, 5, 5);
            tabPageApplicationSetting.Size = new Size(931, 666);
            tabPageApplicationSetting.TabIndex = 0;
            tabPageApplicationSetting.Text = "   Application Settings";
            tabPageApplicationSetting.UseVisualStyleBackColor = true;
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
            grouper_ArgsToInitializarApp.Dock = DockStyle.Top;
            grouper_ArgsToInitializarApp.GroupImage = null;
            grouper_ArgsToInitializarApp.GroupTitle = "Args to initializar the App.";
            grouper_ArgsToInitializarApp.Location = new Point(5, 362);
            grouper_ArgsToInitializarApp.Margin = new Padding(1, 6, 1, 1);
            grouper_ArgsToInitializarApp.Name = "grouper_ArgsToInitializarApp";
            grouper_ArgsToInitializarApp.Padding = new Padding(17, 31, 17, 15);
            grouper_ArgsToInitializarApp.PaintGroupBox = false;
            grouper_ArgsToInitializarApp.RoundCorners = 10;
            grouper_ArgsToInitializarApp.ShadowColor = Color.DarkGray;
            grouper_ArgsToInitializarApp.ShadowControl = false;
            grouper_ArgsToInitializarApp.ShadowThickness = 3;
            grouper_ArgsToInitializarApp.Size = new Size(921, 538);
            grouper_ArgsToInitializarApp.TabIndex = 16;
            // 
            // label_DescriptionInfo
            // 
            label_DescriptionInfo.AutoSize = true;
            label_DescriptionInfo.Location = new Point(665, 326);
            label_DescriptionInfo.Margin = new Padding(5, 0, 5, 0);
            label_DescriptionInfo.Name = "label_DescriptionInfo";
            label_DescriptionInfo.Size = new Size(52, 21);
            label_DescriptionInfo.TabIndex = 29;
            label_DescriptionInfo.Text = "label5";
            // 
            // label_Description
            // 
            label_Description.AutoSize = true;
            label_Description.Location = new Point(537, 326);
            label_Description.Margin = new Padding(5, 0, 5, 0);
            label_Description.Name = "label_Description";
            label_Description.Size = new Size(89, 21);
            label_Description.TabIndex = 28;
            label_Description.Text = "Description";
            // 
            // label_CompanyInfo
            // 
            label_CompanyInfo.AutoSize = true;
            label_CompanyInfo.Location = new Point(665, 276);
            label_CompanyInfo.Margin = new Padding(5, 0, 5, 0);
            label_CompanyInfo.Name = "label_CompanyInfo";
            label_CompanyInfo.Size = new Size(52, 21);
            label_CompanyInfo.TabIndex = 27;
            label_CompanyInfo.Text = "label3";
            // 
            // label_company
            // 
            label_company.AutoSize = true;
            label_company.Location = new Point(537, 276);
            label_company.Margin = new Padding(5, 0, 5, 0);
            label_company.Name = "label_company";
            label_company.Size = new Size(77, 21);
            label_company.TabIndex = 26;
            label_company.Text = "Company";
            // 
            // CheckBox_CreateStartupFolderShortcut
            // 
            CheckBox_CreateStartupFolderShortcut.AutoSize = true;
            CheckBox_CreateStartupFolderShortcut.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            CheckBox_CreateStartupFolderShortcut.Location = new Point(47, 380);
            CheckBox_CreateStartupFolderShortcut.Margin = new Padding(5, 5, 5, 5);
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
            CheckBox_ShowDesktopShortcut.Location = new Point(47, 326);
            CheckBox_ShowDesktopShortcut.Margin = new Padding(5, 5, 5, 5);
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
            checkBox_CheckInternetAccess.Location = new Point(47, 271);
            checkBox_CheckInternetAccess.Margin = new Padding(5, 5, 5, 5);
            checkBox_CheckInternetAccess.Name = "checkBox_CheckInternetAccess";
            checkBox_CheckInternetAccess.Size = new Size(151, 17);
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
            grouper_InfoArgsToInitializarApp.GroupImage = null;
            grouper_InfoArgsToInitializarApp.GroupTitle = "";
            grouper_InfoArgsToInitializarApp.Location = new Point(17, 31);
            grouper_InfoArgsToInitializarApp.Margin = new Padding(1, 6, 1, 1);
            grouper_InfoArgsToInitializarApp.Name = "grouper_InfoArgsToInitializarApp";
            grouper_InfoArgsToInitializarApp.Padding = new Padding(9, 22, 9, 7);
            grouper_InfoArgsToInitializarApp.PaintGroupBox = false;
            grouper_InfoArgsToInitializarApp.RoundCorners = 10;
            grouper_InfoArgsToInitializarApp.ShadowColor = Color.DarkGray;
            grouper_InfoArgsToInitializarApp.ShadowControl = false;
            grouper_InfoArgsToInitializarApp.ShadowThickness = 3;
            grouper_InfoArgsToInitializarApp.Size = new Size(887, 199);
            grouper_InfoArgsToInitializarApp.TabIndex = 22;
            // 
            // richTextBox_InfoArgsToInitializarApp
            // 
            richTextBox_InfoArgsToInitializarApp.BackColor = Color.LightGoldenrodYellow;
            richTextBox_InfoArgsToInitializarApp.BorderStyle = BorderStyle.None;
            richTextBox_InfoArgsToInitializarApp.DetectUrls = false;
            richTextBox_InfoArgsToInitializarApp.Dock = DockStyle.Fill;
            richTextBox_InfoArgsToInitializarApp.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            richTextBox_InfoArgsToInitializarApp.Location = new Point(9, 22);
            richTextBox_InfoArgsToInitializarApp.Margin = new Padding(5, 5, 5, 5);
            richTextBox_InfoArgsToInitializarApp.Name = "richTextBox_InfoArgsToInitializarApp";
            richTextBox_InfoArgsToInitializarApp.ReadOnly = true;
            richTextBox_InfoArgsToInitializarApp.ShortcutsEnabled = false;
            richTextBox_InfoArgsToInitializarApp.Size = new Size(869, 170);
            richTextBox_InfoArgsToInitializarApp.TabIndex = 1;
            richTextBox_InfoArgsToInitializarApp.Text = "";
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
            grouper7.Dock = DockStyle.Top;
            grouper7.GroupImage = null;
            grouper7.GroupTitle = "Pictures.";
            grouper7.Location = new Point(5, 202);
            grouper7.Margin = new Padding(1, 6, 1, 1);
            grouper7.Name = "grouper7";
            grouper7.Padding = new Padding(36, 37, 36, 31);
            grouper7.PaintGroupBox = false;
            grouper7.RoundCorners = 10;
            grouper7.ShadowColor = Color.DarkGray;
            grouper7.ShadowControl = false;
            grouper7.ShadowThickness = 3;
            grouper7.Size = new Size(921, 160);
            grouper7.TabIndex = 15;
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Location = new Point(39, 101);
            radioButton2.Margin = new Padding(4, 2, 4, 2);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(56, 17);
            radioButton2.TabIndex = 23;
            radioButton2.Text = "Hours.";
            radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Location = new Point(39, 54);
            radioButton1.Margin = new Padding(4, 2, 4, 2);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(56, 17);
            radioButton1.TabIndex = 22;
            radioButton1.Text = "Hours.";
            radioButton1.UseVisualStyleBackColor = true;
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
            grouper_DepartProperties.GroupImage = null;
            grouper_DepartProperties.GroupTitle = "Department Name.";
            grouper_DepartProperties.Location = new Point(5, 5);
            grouper_DepartProperties.Margin = new Padding(1, 6, 1, 1);
            grouper_DepartProperties.Name = "grouper_DepartProperties";
            grouper_DepartProperties.Padding = new Padding(36, 37, 36, 31);
            grouper_DepartProperties.PaintGroupBox = false;
            grouper_DepartProperties.RoundCorners = 10;
            grouper_DepartProperties.ShadowColor = Color.DarkGray;
            grouper_DepartProperties.ShadowControl = false;
            grouper_DepartProperties.ShadowThickness = 3;
            grouper_DepartProperties.Size = new Size(921, 197);
            grouper_DepartProperties.TabIndex = 15;
            // 
            // textBox_DataBaseAddress
            // 
            textBox_DataBaseAddress.Location = new Point(231, 90);
            textBox_DataBaseAddress.Margin = new Padding(5, 5, 5, 5);
            textBox_DataBaseAddress.Name = "textBox_DataBaseAddress";
            textBox_DataBaseAddress.Size = new Size(664, 29);
            textBox_DataBaseAddress.TabIndex = 3;
            // 
            // comboBox_ApplicationDepartmentName
            // 
            comboBox_ApplicationDepartmentName.FormattingEnabled = true;
            comboBox_ApplicationDepartmentName.Location = new Point(231, 39);
            comboBox_ApplicationDepartmentName.Margin = new Padding(5, 5, 5, 5);
            comboBox_ApplicationDepartmentName.Name = "comboBox_ApplicationDepartmentName";
            comboBox_ApplicationDepartmentName.Size = new Size(664, 29);
            comboBox_ApplicationDepartmentName.TabIndex = 8;
            // 
            // label_DataBaseAddress
            // 
            label_DataBaseAddress.AutoSize = true;
            label_DataBaseAddress.Location = new Point(41, 101);
            label_DataBaseAddress.Margin = new Padding(5, 0, 5, 0);
            label_DataBaseAddress.Name = "label_DataBaseAddress";
            label_DataBaseAddress.Size = new Size(137, 21);
            label_DataBaseAddress.TabIndex = 2;
            label_DataBaseAddress.Text = "DataBase Address:";
            // 
            // label_DepartmentName
            // 
            label_DepartmentName.AutoSize = true;
            label_DepartmentName.Location = new Point(41, 52);
            label_DepartmentName.Margin = new Padding(5, 0, 5, 0);
            label_DepartmentName.Name = "label_DepartmentName";
            label_DepartmentName.Size = new Size(142, 21);
            label_DepartmentName.TabIndex = 0;
            label_DepartmentName.Text = "Department Name:";
            // 
            // textBoxApplicationHTMLtemples
            // 
            textBoxApplicationHTMLtemples.Location = new Point(229, 138);
            textBoxApplicationHTMLtemples.Margin = new Padding(5, 5, 5, 5);
            textBoxApplicationHTMLtemples.Name = "textBoxApplicationHTMLtemples";
            textBoxApplicationHTMLtemples.Size = new Size(666, 29);
            textBoxApplicationHTMLtemples.TabIndex = 6;
            // 
            // button_BrowserDataBase
            // 
            button_BrowserDataBase.Location = new Point(1031, 98);
            button_BrowserDataBase.Margin = new Padding(5, 5, 5, 5);
            button_BrowserDataBase.Name = "button_BrowserDataBase";
            button_BrowserDataBase.Size = new Size(113, 34);
            button_BrowserDataBase.TabIndex = 4;
            button_BrowserDataBase.Text = "Browser...";
            button_BrowserDataBase.UseVisualStyleBackColor = true;
            button_BrowserDataBase.Click += ButtonBrowserDataBaseFileClick;
            // 
            // button_ApplicationHTMLtemples
            // 
            button_ApplicationHTMLtemples.Location = new Point(1031, 146);
            button_ApplicationHTMLtemples.Margin = new Padding(5, 5, 5, 5);
            button_ApplicationHTMLtemples.Name = "button_ApplicationHTMLtemples";
            button_ApplicationHTMLtemples.Size = new Size(113, 34);
            button_ApplicationHTMLtemples.TabIndex = 7;
            button_ApplicationHTMLtemples.Text = "Browser...";
            button_ApplicationHTMLtemples.UseVisualStyleBackColor = true;
            button_ApplicationHTMLtemples.Click += buttonApplicationHTMLtemples_Click;
            // 
            // labelApplicationHTMLtemples
            // 
            labelApplicationHTMLtemples.AutoSize = true;
            labelApplicationHTMLtemples.Location = new Point(39, 150);
            labelApplicationHTMLtemples.Margin = new Padding(5, 0, 5, 0);
            labelApplicationHTMLtemples.Name = "labelApplicationHTMLtemples";
            labelApplicationHTMLtemples.Size = new Size(145, 21);
            labelApplicationHTMLtemples.TabIndex = 5;
            labelApplicationHTMLtemples.Text = "App HTML temples:";
            // 
            // tabPageNotificationsOptions
            // 
            tabPageNotificationsOptions.Controls.Add(grouper2);
            tabPageNotificationsOptions.Location = new Point(4, 4);
            tabPageNotificationsOptions.Margin = new Padding(5, 5, 5, 5);
            tabPageNotificationsOptions.Name = "tabPageNotificationsOptions";
            tabPageNotificationsOptions.Padding = new Padding(5, 5, 5, 5);
            tabPageNotificationsOptions.Size = new Size(1244, 824);
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
            grouper2.GroupImage = null;
            grouper2.GroupTitle = "";
            grouper2.Location = new Point(5, 5);
            grouper2.Margin = new Padding(5, 5, 5, 5);
            grouper2.Name = "grouper2";
            grouper2.Padding = new Padding(9, 22, 9, 7);
            grouper2.PaintGroupBox = false;
            grouper2.RoundCorners = 10;
            grouper2.ShadowColor = Color.DarkGray;
            grouper2.ShadowControl = false;
            grouper2.ShadowThickness = 3;
            grouper2.Size = new Size(1234, 814);
            grouper2.TabIndex = 9;
            // 
            // panel7
            // 
            panel7.Controls.Add(grouper4);
            panel7.Controls.Add(grouper_Notifycations);
            panel7.Controls.Add(grouper3);
            panel7.Dock = DockStyle.Fill;
            panel7.Location = new Point(420, 22);
            panel7.Margin = new Padding(5, 5, 5, 5);
            panel7.Name = "panel7";
            panel7.Size = new Size(805, 785);
            panel7.TabIndex = 18;
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
            grouper4.Dock = DockStyle.Top;
            grouper4.GroupImage = null;
            grouper4.GroupTitle = "Interval between each reading of notifications.";
            grouper4.Location = new Point(0, 352);
            grouper4.Margin = new Padding(1, 6, 1, 1);
            grouper4.Name = "grouper4";
            grouper4.Padding = new Padding(15, 39, 15, 31);
            grouper4.PaintGroupBox = false;
            grouper4.RoundCorners = 10;
            grouper4.ShadowColor = Color.DarkGray;
            grouper4.ShadowControl = false;
            grouper4.ShadowThickness = 3;
            grouper4.Size = new Size(805, 196);
            grouper4.TabIndex = 16;
            // 
            // label_IntervalSetTo
            // 
            label_IntervalSetTo.AutoSize = true;
            label_IntervalSetTo.Location = new Point(37, 151);
            label_IntervalSetTo.Margin = new Padding(4, 0, 4, 0);
            label_IntervalSetTo.Name = "label_IntervalSetTo";
            label_IntervalSetTo.Size = new Size(487, 21);
            label_IntervalSetTo.TabIndex = 24;
            label_IntervalSetTo.Text = "The interval between each reading of notifications is set to 2 seconds.\r\n";
            // 
            // trackBar_Interval
            // 
            trackBar_Interval.Dock = DockStyle.Top;
            trackBar_Interval.Location = new Point(15, 39);
            trackBar_Interval.Margin = new Padding(4, 2, 4, 2);
            trackBar_Interval.Maximum = 100;
            trackBar_Interval.Minimum = 1;
            trackBar_Interval.Name = "trackBar_Interval";
            trackBar_Interval.Size = new Size(775, 45);
            trackBar_Interval.TabIndex = 23;
            trackBar_Interval.TickFrequency = 2;
            trackBar_Interval.TickStyle = TickStyle.Both;
            trackBar_Interval.Value = 2;
            trackBar_Interval.ValueChanged += TrackBar_Interval_ValueChanged;
            // 
            // radioButton_Hours
            // 
            radioButton_Hours.AutoSize = true;
            radioButton_Hours.Location = new Point(295, 116);
            radioButton_Hours.Margin = new Padding(4, 2, 4, 2);
            radioButton_Hours.Name = "radioButton_Hours";
            radioButton_Hours.Size = new Size(56, 17);
            radioButton_Hours.TabIndex = 21;
            radioButton_Hours.Text = "Hours.";
            radioButton_Hours.UseVisualStyleBackColor = true;
            radioButton_Hours.CheckedChanged += RadioButton_Hours_CheckedChanged;
            // 
            // radioButton_Minutes
            // 
            radioButton_Minutes.AutoSize = true;
            radioButton_Minutes.Location = new Point(175, 116);
            radioButton_Minutes.Margin = new Padding(4, 2, 4, 2);
            radioButton_Minutes.Name = "radioButton_Minutes";
            radioButton_Minutes.Size = new Size(65, 17);
            radioButton_Minutes.TabIndex = 20;
            radioButton_Minutes.Text = "Minutes.";
            radioButton_Minutes.UseVisualStyleBackColor = true;
            radioButton_Minutes.CheckedChanged += RadioButton_Minutes_CheckedChanged;
            // 
            // radioButton_secund
            // 
            radioButton_secund.AutoSize = true;
            radioButton_secund.Checked = true;
            radioButton_secund.Location = new Point(41, 116);
            radioButton_secund.Margin = new Padding(4, 2, 4, 2);
            radioButton_secund.Name = "radioButton_secund";
            radioButton_secund.Size = new Size(70, 17);
            radioButton_secund.TabIndex = 19;
            radioButton_secund.TabStop = true;
            radioButton_secund.Text = "Seconds.";
            radioButton_secund.UseVisualStyleBackColor = true;
            radioButton_secund.CheckedChanged += RadioButton_secund_CheckedChanged;
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
            grouper_Notifycations.Dock = DockStyle.Top;
            grouper_Notifycations.GroupImage = null;
            grouper_Notifycations.GroupTitle = "Received Notifications.";
            grouper_Notifycations.Location = new Point(0, 188);
            grouper_Notifycations.Margin = new Padding(1, 6, 1, 1);
            grouper_Notifycations.Name = "grouper_Notifycations";
            grouper_Notifycations.Padding = new Padding(36, 37, 36, 31);
            grouper_Notifycations.PaintGroupBox = false;
            grouper_Notifycations.RoundCorners = 10;
            grouper_Notifycations.ShadowColor = Color.DarkGray;
            grouper_Notifycations.ShadowControl = false;
            grouper_Notifycations.ShadowThickness = 3;
            grouper_Notifycations.Size = new Size(805, 164);
            grouper_Notifycations.TabIndex = 11;
            // 
            // checkBox_ShowEmailsNotifications
            // 
            checkBox_ShowEmailsNotifications.AutoSize = true;
            checkBox_ShowEmailsNotifications.Location = new Point(41, 113);
            checkBox_ShowEmailsNotifications.Margin = new Padding(5, 5, 5, 5);
            checkBox_ShowEmailsNotifications.Name = "checkBox_ShowEmailsNotifications";
            checkBox_ShowEmailsNotifications.Size = new Size(148, 17);
            checkBox_ShowEmailsNotifications.TabIndex = 14;
            checkBox_ShowEmailsNotifications.Text = "Show Emails notifications.";
            checkBox_ShowEmailsNotifications.UseVisualStyleBackColor = true;
            // 
            // checkBox_ShowDataBaseUpdateNotifications
            // 
            checkBox_ShowDataBaseUpdateNotifications.AutoSize = true;
            checkBox_ShowDataBaseUpdateNotifications.Location = new Point(41, 42);
            checkBox_ShowDataBaseUpdateNotifications.Margin = new Padding(5, 5, 5, 5);
            checkBox_ShowDataBaseUpdateNotifications.Name = "checkBox_ShowDataBaseUpdateNotifications";
            checkBox_ShowDataBaseUpdateNotifications.Size = new Size(201, 17);
            checkBox_ShowDataBaseUpdateNotifications.TabIndex = 13;
            checkBox_ShowDataBaseUpdateNotifications.Text = "Show DataBase update notifications.";
            checkBox_ShowDataBaseUpdateNotifications.UseVisualStyleBackColor = true;
            // 
            // checkBox_ShowWarningsNotifications
            // 
            checkBox_ShowWarningsNotifications.AutoSize = true;
            checkBox_ShowWarningsNotifications.Location = new Point(41, 78);
            checkBox_ShowWarningsNotifications.Margin = new Padding(5, 5, 5, 5);
            checkBox_ShowWarningsNotifications.Name = "checkBox_ShowWarningsNotifications";
            checkBox_ShowWarningsNotifications.Size = new Size(163, 17);
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
            grouper3.GroupImage = null;
            grouper3.GroupTitle = "Send Notifications.";
            grouper3.Location = new Point(0, 0);
            grouper3.Margin = new Padding(1, 6, 1, 1);
            grouper3.Name = "grouper3";
            grouper3.Padding = new Padding(36, 37, 36, 31);
            grouper3.PaintGroupBox = false;
            grouper3.RoundCorners = 10;
            grouper3.ShadowColor = Color.DarkGray;
            grouper3.ShadowControl = false;
            grouper3.ShadowThickness = 3;
            grouper3.Size = new Size(805, 188);
            grouper3.TabIndex = 14;
            // 
            // checkBox_ShowMyOwnNotifications
            // 
            checkBox_ShowMyOwnNotifications.AutoSize = true;
            checkBox_ShowMyOwnNotifications.Location = new Point(41, 119);
            checkBox_ShowMyOwnNotifications.Margin = new Padding(5, 5, 5, 5);
            checkBox_ShowMyOwnNotifications.Name = "checkBox_ShowMyOwnNotifications";
            checkBox_ShowMyOwnNotifications.Size = new Size(171, 17);
            checkBox_ShowMyOwnNotifications.TabIndex = 11;
            checkBox_ShowMyOwnNotifications.Text = "Show me my own notifications.";
            checkBox_ShowMyOwnNotifications.UseVisualStyleBackColor = true;
            // 
            // checkBox_SendMyOwnNotifications
            // 
            checkBox_SendMyOwnNotifications.AutoSize = true;
            checkBox_SendMyOwnNotifications.Location = new Point(41, 42);
            checkBox_SendMyOwnNotifications.Margin = new Padding(5, 5, 5, 5);
            checkBox_SendMyOwnNotifications.Name = "checkBox_SendMyOwnNotifications";
            checkBox_SendMyOwnNotifications.Size = new Size(374, 17);
            checkBox_SendMyOwnNotifications.TabIndex = 14;
            checkBox_SendMyOwnNotifications.Text = "Send my own notifications. Check to send my notifications to others users.";
            checkBox_SendMyOwnNotifications.UseVisualStyleBackColor = true;
            // 
            // panel6
            // 
            panel6.Controls.Add(label1);
            panel6.Controls.Add(checkBox_EnableSendReceiveNotifycations);
            panel6.Controls.Add(checkBox_SetIntervalReadNotifications);
            panel6.Dock = DockStyle.Left;
            panel6.Location = new Point(9, 22);
            panel6.Margin = new Padding(5, 5, 5, 5);
            panel6.Name = "panel6";
            panel6.Size = new Size(411, 785);
            panel6.TabIndex = 17;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(49, 15);
            label1.Margin = new Padding(5, 0, 5, 0);
            label1.Name = "label1";
            label1.Size = new Size(164, 17);
            label1.TabIndex = 9;
            label1.Text = "Notifications Options.";
            // 
            // checkBox_EnableSendReceiveNotifycations
            // 
            checkBox_EnableSendReceiveNotifycations.AutoSize = true;
            checkBox_EnableSendReceiveNotifycations.Location = new Point(25, 46);
            checkBox_EnableSendReceiveNotifycations.Margin = new Padding(5, 5, 5, 5);
            checkBox_EnableSendReceiveNotifycations.Name = "checkBox_EnableSendReceiveNotifycations";
            checkBox_EnableSendReceiveNotifycations.Size = new Size(199, 17);
            checkBox_EnableSendReceiveNotifycations.TabIndex = 13;
            checkBox_EnableSendReceiveNotifycations.Text = "Enable Receive/Send Notifycations.";
            checkBox_EnableSendReceiveNotifycations.UseVisualStyleBackColor = true;
            checkBox_EnableSendReceiveNotifycations.CheckedChanged += CheckBoxEnableSendReceiveNotifycationsCheckedChanged;
            // 
            // checkBox_SetIntervalReadNotifications
            // 
            checkBox_SetIntervalReadNotifications.AutoSize = true;
            checkBox_SetIntervalReadNotifications.Location = new Point(25, 391);
            checkBox_SetIntervalReadNotifications.Margin = new Padding(5, 5, 5, 5);
            checkBox_SetIntervalReadNotifications.Name = "checkBox_SetIntervalReadNotifications";
            checkBox_SetIntervalReadNotifications.Size = new Size(199, 17);
            checkBox_SetIntervalReadNotifications.TabIndex = 15;
            checkBox_SetIntervalReadNotifications.Text = "Set the interval reading Notifications.";
            checkBox_SetIntervalReadNotifications.UseVisualStyleBackColor = true;
            // 
            // tabPageUSB_DeviceUtility
            // 
            tabPageUSB_DeviceUtility.AutoScroll = true;
            tabPageUSB_DeviceUtility.Controls.Add(splitContainer1);
            tabPageUSB_DeviceUtility.Location = new Point(4, 4);
            tabPageUSB_DeviceUtility.Margin = new Padding(5, 5, 5, 5);
            tabPageUSB_DeviceUtility.Name = "tabPageUSB_DeviceUtility";
            tabPageUSB_DeviceUtility.Size = new Size(1244, 824);
            tabPageUSB_DeviceUtility.TabIndex = 2;
            tabPageUSB_DeviceUtility.Text = "   USB Device Utility";
            tabPageUSB_DeviceUtility.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            splitContainer1.BorderStyle = BorderStyle.Fixed3D;
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Margin = new Padding(5, 5, 5, 5);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Orientation = Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(richTextBox1);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(panel1);
            splitContainer1.Panel2.Controls.Add(grouper_AddNewPrintHelpsButtons);
            splitContainer1.Size = new Size(1244, 824);
            splitContainer1.SplitterDistance = 237;
            splitContainer1.SplitterWidth = 6;
            splitContainer1.TabIndex = 1;
            // 
            // richTextBox1
            // 
            richTextBox1.Dock = DockStyle.Fill;
            richTextBox1.Location = new Point(0, 0);
            richTextBox1.Margin = new Padding(4, 2, 4, 2);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(1240, 233);
            richTextBox1.TabIndex = 0;
            richTextBox1.Text = "";
            // 
            // panel1
            // 
            panel1.AutoScroll = true;
            panel1.AutoScrollMinSize = new Size(750, 500);
            panel1.Controls.Add(PicturesBox_Image);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 78);
            panel1.Margin = new Padding(5, 5, 5, 5);
            panel1.MinimumSize = new Size(623, 379);
            panel1.Name = "panel1";
            panel1.Size = new Size(1240, 499);
            panel1.TabIndex = 2;
            // 
            // PicturesBox_Image
            // 
            PicturesBox_Image.BackColor = Color.White;
            PicturesBox_Image.Dock = DockStyle.Top;
            PicturesBox_Image.Location = new Point(0, 0);
            PicturesBox_Image.Margin = new Padding(5, 5, 5, 5);
            PicturesBox_Image.Name = "PicturesBox_Image";
            PicturesBox_Image.Size = new Size(1223, 3567);
            PicturesBox_Image.TabIndex = 1;
            PicturesBox_Image.TabStop = false;
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
            grouper_AddNewPrintHelpsButtons.Dock = DockStyle.Top;
            grouper_AddNewPrintHelpsButtons.GroupImage = null;
            grouper_AddNewPrintHelpsButtons.GroupTitle = "";
            grouper_AddNewPrintHelpsButtons.Location = new Point(0, 0);
            grouper_AddNewPrintHelpsButtons.Margin = new Padding(4, 2, 4, 2);
            grouper_AddNewPrintHelpsButtons.Name = "grouper_AddNewPrintHelpsButtons";
            grouper_AddNewPrintHelpsButtons.Padding = new Padding(11, 9, 11, 9);
            grouper_AddNewPrintHelpsButtons.PaintGroupBox = false;
            grouper_AddNewPrintHelpsButtons.RoundCorners = 10;
            grouper_AddNewPrintHelpsButtons.ShadowColor = Color.DarkGray;
            grouper_AddNewPrintHelpsButtons.ShadowControl = false;
            grouper_AddNewPrintHelpsButtons.ShadowThickness = 3;
            grouper_AddNewPrintHelpsButtons.Size = new Size(1240, 78);
            grouper_AddNewPrintHelpsButtons.TabIndex = 17;
            // 
            // flowLayoutPanel_AddNewPrintHelpsButton
            // 
            flowLayoutPanel_AddNewPrintHelpsButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowLayoutPanel_AddNewPrintHelpsButton.Controls.Add(button_AddNew);
            flowLayoutPanel_AddNewPrintHelpsButton.Controls.Add(button_Adjustment);
            flowLayoutPanel_AddNewPrintHelpsButton.Controls.Add(button_RemoveScanner);
            flowLayoutPanel_AddNewPrintHelpsButton.Controls.Add(button_PrintHelps);
            flowLayoutPanel_AddNewPrintHelpsButton.Dock = DockStyle.Bottom;
            flowLayoutPanel_AddNewPrintHelpsButton.Location = new Point(11, 25);
            flowLayoutPanel_AddNewPrintHelpsButton.Margin = new Padding(0);
            flowLayoutPanel_AddNewPrintHelpsButton.Name = "flowLayoutPanel_AddNewPrintHelpsButton";
            flowLayoutPanel_AddNewPrintHelpsButton.Padding = new Padding(0, 2, 0, 0);
            flowLayoutPanel_AddNewPrintHelpsButton.Size = new Size(1218, 44);
            flowLayoutPanel_AddNewPrintHelpsButton.TabIndex = 13;
            // 
            // button_AddNew
            // 
            button_AddNew.Font = new Font("Arial", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button_AddNew.Location = new Point(4, 2);
            button_AddNew.Margin = new Padding(4, 0, 4, 0);
            button_AddNew.Name = "button_AddNew";
            button_AddNew.Size = new Size(249, 39);
            button_AddNew.TabIndex = 5;
            button_AddNew.Text = "Add New";
            button_AddNew.UseVisualStyleBackColor = true;
            // 
            // button_Adjustment
            // 
            button_Adjustment.Font = new Font("Arial", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button_Adjustment.Location = new Point(261, 2);
            button_Adjustment.Margin = new Padding(4, 0, 4, 0);
            button_Adjustment.Name = "button_Adjustment";
            button_Adjustment.Size = new Size(249, 39);
            button_Adjustment.TabIndex = 1;
            button_Adjustment.Text = "Adjustment";
            button_Adjustment.UseVisualStyleBackColor = true;
            // 
            // button_RemoveScanner
            // 
            button_RemoveScanner.Font = new Font("Arial", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button_RemoveScanner.Location = new Point(518, 2);
            button_RemoveScanner.Margin = new Padding(4, 0, 4, 0);
            button_RemoveScanner.Name = "button_RemoveScanner";
            button_RemoveScanner.Size = new Size(249, 39);
            button_RemoveScanner.TabIndex = 2;
            button_RemoveScanner.Text = "Remove Scanner";
            button_RemoveScanner.UseVisualStyleBackColor = true;
            // 
            // button_PrintHelps
            // 
            button_PrintHelps.Font = new Font("Arial", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button_PrintHelps.Location = new Point(775, 2);
            button_PrintHelps.Margin = new Padding(4, 0, 4, 0);
            button_PrintHelps.Name = "button_PrintHelps";
            button_PrintHelps.Size = new Size(249, 39);
            button_PrintHelps.TabIndex = 3;
            button_PrintHelps.Text = "Print Helps";
            button_PrintHelps.UseVisualStyleBackColor = true;
            // 
            // tabPageSave_Options
            // 
            tabPageSave_Options.Controls.Add(grouper6);
            tabPageSave_Options.Location = new Point(4, 4);
            tabPageSave_Options.Margin = new Padding(5, 5, 5, 5);
            tabPageSave_Options.Name = "tabPageSave_Options";
            tabPageSave_Options.Size = new Size(1244, 824);
            tabPageSave_Options.TabIndex = 3;
            tabPageSave_Options.Text = "   Save Options";
            tabPageSave_Options.UseVisualStyleBackColor = true;
            // 
            // grouper6
            // 
            grouper6.BackgroundColor = SystemColors.Control;
            grouper6.BackgroundGradientColor = Color.White;
            grouper6.BackgroundGradientMode = CodeVendor.Controls.Grouper.GroupBoxGradientMode.None;
            grouper6.BorderColor = Color.Black;
            grouper6.BorderThickness = 1F;
            grouper6.Controls.Add(richTextBox3);
            grouper6.Controls.Add(checkBoxSaveTheInformationWhenTheUserSaves);
            grouper6.Controls.Add(richTextBox2);
            grouper6.Controls.Add(checkBoxSaveTheInformationByTime);
            grouper6.Controls.Add(grouper5);
            grouper6.Controls.Add(checkBoxSaveEachTimeTheInformationIsChanged);
            grouper6.CustomGroupBoxColor = Color.White;
            grouper6.Dock = DockStyle.Fill;
            grouper6.GroupImage = null;
            grouper6.GroupTitle = "Save Options.";
            grouper6.Location = new Point(0, 0);
            grouper6.Margin = new Padding(9, 7, 9, 7);
            grouper6.Name = "grouper6";
            grouper6.Padding = new Padding(36, 38, 17, 31);
            grouper6.PaintGroupBox = false;
            grouper6.RoundCorners = 10;
            grouper6.ShadowColor = Color.DarkGray;
            grouper6.ShadowControl = false;
            grouper6.ShadowThickness = 3;
            grouper6.Size = new Size(1244, 824);
            grouper6.TabIndex = 17;
            // 
            // richTextBox3
            // 
            richTextBox3.Location = new Point(460, 334);
            richTextBox3.Margin = new Padding(5, 5, 5, 5);
            richTextBox3.Name = "richTextBox3";
            richTextBox3.ReadOnly = true;
            richTextBox3.Size = new Size(717, 70);
            richTextBox3.TabIndex = 19;
            richTextBox3.Text = "   The user is responsible for keeping the information, the system will alert if you have information to save on exit process.";
            // 
            // checkBoxSaveTheInformationWhenTheUserSaves
            // 
            checkBoxSaveTheInformationWhenTheUserSaves.AutoSize = true;
            checkBoxSaveTheInformationWhenTheUserSaves.Checked = true;
            checkBoxSaveTheInformationWhenTheUserSaves.CheckState = CheckState.Checked;
            checkBoxSaveTheInformationWhenTheUserSaves.Location = new Point(41, 334);
            checkBoxSaveTheInformationWhenTheUserSaves.Margin = new Padding(5, 5, 5, 5);
            checkBoxSaveTheInformationWhenTheUserSaves.Name = "checkBoxSaveTheInformationWhenTheUserSaves";
            checkBoxSaveTheInformationWhenTheUserSaves.Size = new Size(227, 17);
            checkBoxSaveTheInformationWhenTheUserSaves.TabIndex = 18;
            checkBoxSaveTheInformationWhenTheUserSaves.Text = "Save the information when the user saves.";
            checkBoxSaveTheInformationWhenTheUserSaves.UseVisualStyleBackColor = true;
            // 
            // richTextBox2
            // 
            richTextBox2.Location = new Point(460, 57);
            richTextBox2.Margin = new Padding(5, 5, 5, 5);
            richTextBox2.Name = "richTextBox2";
            richTextBox2.ReadOnly = true;
            richTextBox2.Size = new Size(717, 70);
            richTextBox2.TabIndex = 0;
            richTextBox2.Text = "   Whenever the information changes, the system will automatically save the information.";
            // 
            // checkBoxSaveTheInformationByTime
            // 
            checkBoxSaveTheInformationByTime.AutoSize = true;
            checkBoxSaveTheInformationByTime.Location = new Point(32, 165);
            checkBoxSaveTheInformationByTime.Margin = new Padding(5, 5, 5, 5);
            checkBoxSaveTheInformationByTime.Name = "checkBoxSaveTheInformationByTime";
            checkBoxSaveTheInformationByTime.Size = new Size(237, 17);
            checkBoxSaveTheInformationByTime.TabIndex = 17;
            checkBoxSaveTheInformationByTime.Text = "Save the information by time, set the interval.";
            checkBoxSaveTheInformationByTime.UseVisualStyleBackColor = true;
            // 
            // grouper5
            // 
            grouper5.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            grouper5.BackgroundColor = SystemColors.Control;
            grouper5.BackgroundGradientColor = Color.White;
            grouper5.BackgroundGradientMode = CodeVendor.Controls.Grouper.GroupBoxGradientMode.None;
            grouper5.BorderColor = Color.Black;
            grouper5.BorderThickness = 1F;
            grouper5.Controls.Add(radioButtonEvery30minutes);
            grouper5.Controls.Add(radioButtonEvery15minutes);
            grouper5.Controls.Add(radioButtonEvery5minutes);
            grouper5.CustomGroupBoxColor = Color.White;
            grouper5.GroupImage = null;
            grouper5.GroupTitle = "";
            grouper5.Location = new Point(460, 139);
            grouper5.Margin = new Padding(1, 6, 1, 1);
            grouper5.Name = "grouper5";
            grouper5.Padding = new Padding(9, 21, 9, 7);
            grouper5.PaintGroupBox = false;
            grouper5.RoundCorners = 10;
            grouper5.ShadowColor = Color.DarkGray;
            grouper5.ShadowControl = false;
            grouper5.ShadowThickness = 3;
            grouper5.Size = new Size(764, 4);
            grouper5.TabIndex = 16;
            // 
            // radioButtonEvery30minutes
            // 
            radioButtonEvery30minutes.AutoSize = true;
            radioButtonEvery30minutes.Location = new Point(27, 96);
            radioButtonEvery30minutes.Margin = new Padding(5, 5, 5, 5);
            radioButtonEvery30minutes.Name = "radioButtonEvery30minutes";
            radioButtonEvery30minutes.Size = new Size(109, 17);
            radioButtonEvery30minutes.TabIndex = 2;
            radioButtonEvery30minutes.Text = "Every 30 minutes.";
            radioButtonEvery30minutes.UseVisualStyleBackColor = true;
            // 
            // radioButtonEvery15minutes
            // 
            radioButtonEvery15minutes.AutoSize = true;
            radioButtonEvery15minutes.Location = new Point(27, 60);
            radioButtonEvery15minutes.Margin = new Padding(5, 5, 5, 5);
            radioButtonEvery15minutes.Name = "radioButtonEvery15minutes";
            radioButtonEvery15minutes.Size = new Size(109, 17);
            radioButtonEvery15minutes.TabIndex = 1;
            radioButtonEvery15minutes.Text = "Every 15 minutes.";
            radioButtonEvery15minutes.UseVisualStyleBackColor = true;
            // 
            // radioButtonEvery5minutes
            // 
            radioButtonEvery5minutes.AutoSize = true;
            radioButtonEvery5minutes.Location = new Point(27, 26);
            radioButtonEvery5minutes.Margin = new Padding(5, 5, 5, 5);
            radioButtonEvery5minutes.Name = "radioButtonEvery5minutes";
            radioButtonEvery5minutes.Size = new Size(103, 17);
            radioButtonEvery5minutes.TabIndex = 0;
            radioButtonEvery5minutes.Text = "Every 5 minutes.";
            radioButtonEvery5minutes.UseVisualStyleBackColor = true;
            // 
            // checkBoxSaveEachTimeTheInformationIsChanged
            // 
            checkBoxSaveEachTimeTheInformationIsChanged.AutoSize = true;
            checkBoxSaveEachTimeTheInformationIsChanged.Location = new Point(41, 57);
            checkBoxSaveEachTimeTheInformationIsChanged.Margin = new Padding(5, 5, 5, 5);
            checkBoxSaveEachTimeTheInformationIsChanged.Name = "checkBoxSaveEachTimeTheInformationIsChanged";
            checkBoxSaveEachTimeTheInformationIsChanged.Size = new Size(230, 17);
            checkBoxSaveEachTimeTheInformationIsChanged.TabIndex = 14;
            checkBoxSaveEachTimeTheInformationIsChanged.Text = "Save each time the information is changed.";
            checkBoxSaveEachTimeTheInformationIsChanged.UseVisualStyleBackColor = true;
            // 
            // tabPage_InstallationLog
            // 
            tabPage_InstallationLog.Controls.Add(richTextBox_FirstInstalation);
            tabPage_InstallationLog.Location = new Point(4, 4);
            tabPage_InstallationLog.Margin = new Padding(5, 5, 5, 5);
            tabPage_InstallationLog.Name = "tabPage_InstallationLog";
            tabPage_InstallationLog.Size = new Size(1244, 824);
            tabPage_InstallationLog.TabIndex = 4;
            tabPage_InstallationLog.Text = "   Installation Log";
            tabPage_InstallationLog.UseVisualStyleBackColor = true;
            // 
            // richTextBox_FirstInstalation
            // 
            richTextBox_FirstInstalation.Dock = DockStyle.Fill;
            richTextBox_FirstInstalation.Location = new Point(0, 0);
            richTextBox_FirstInstalation.Margin = new Padding(5, 5, 5, 5);
            richTextBox_FirstInstalation.Name = "richTextBox_FirstInstalation";
            richTextBox_FirstInstalation.Size = new Size(1244, 824);
            richTextBox_FirstInstalation.TabIndex = 0;
            richTextBox_FirstInstalation.Text = "";
            // 
            // tabPage_SecurityLockFolder
            // 
            tabPage_SecurityLockFolder.Controls.Add(grouper_SecurityLockFolder);
            tabPage_SecurityLockFolder.Location = new Point(4, 4);
            tabPage_SecurityLockFolder.Margin = new Padding(4, 2, 4, 2);
            tabPage_SecurityLockFolder.Name = "tabPage_SecurityLockFolder";
            tabPage_SecurityLockFolder.Size = new Size(1244, 824);
            tabPage_SecurityLockFolder.TabIndex = 5;
            tabPage_SecurityLockFolder.Text = "   Security & Lock System Folder";
            tabPage_SecurityLockFolder.UseVisualStyleBackColor = true;
            // 
            // grouper_SecurityLockFolder
            // 
            grouper_SecurityLockFolder.BackgroundColor = SystemColors.ButtonHighlight;
            grouper_SecurityLockFolder.BackgroundGradientColor = Color.DarkGray;
            grouper_SecurityLockFolder.BackgroundGradientMode = CodeVendor.Controls.Grouper.GroupBoxGradientMode.Vertical;
            grouper_SecurityLockFolder.BorderColor = Color.Black;
            grouper_SecurityLockFolder.BorderThickness = 1F;
            grouper_SecurityLockFolder.Controls.Add(panel2);
            grouper_SecurityLockFolder.Controls.Add(grouper_SecurityLockFolderButtons);
            grouper_SecurityLockFolder.Controls.Add(grouper_Properties);
            grouper_SecurityLockFolder.CustomGroupBoxColor = Color.White;
            grouper_SecurityLockFolder.Dock = DockStyle.Top;
            grouper_SecurityLockFolder.GroupImage = null;
            grouper_SecurityLockFolder.GroupTitle = "Security & Lock System Folder.";
            grouper_SecurityLockFolder.Location = new Point(0, 0);
            grouper_SecurityLockFolder.Margin = new Padding(1, 6, 1, 1);
            grouper_SecurityLockFolder.Name = "grouper_SecurityLockFolder";
            grouper_SecurityLockFolder.Padding = new Padding(36, 42, 36, 31);
            grouper_SecurityLockFolder.PaintGroupBox = false;
            grouper_SecurityLockFolder.RoundCorners = 10;
            grouper_SecurityLockFolder.ShadowColor = Color.DarkGray;
            grouper_SecurityLockFolder.ShadowControl = false;
            grouper_SecurityLockFolder.ShadowThickness = 3;
            grouper_SecurityLockFolder.Size = new Size(1244, 210);
            grouper_SecurityLockFolder.TabIndex = 15;
            // 
            // panel2
            // 
            panel2.Controls.Add(flowLayoutPanel1);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(36, 42);
            panel2.Margin = new Padding(0);
            panel2.Name = "panel2";
            panel2.Size = new Size(811, 37);
            panel2.TabIndex = 20;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(comboBox_SecurityLockFolder);
            flowLayoutPanel1.Controls.Add(button_Browser);
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.Location = new Point(0, 0);
            flowLayoutPanel1.Margin = new Padding(0);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(811, 37);
            flowLayoutPanel1.TabIndex = 0;
            // 
            // comboBox_SecurityLockFolder
            // 
            comboBox_SecurityLockFolder.FormattingEnabled = true;
            comboBox_SecurityLockFolder.Items.AddRange(new object[] { "Folder to be lock, hidde or readOnly properties changed." });
            comboBox_SecurityLockFolder.Location = new Point(4, 2);
            comboBox_SecurityLockFolder.Margin = new Padding(4, 2, 4, 2);
            comboBox_SecurityLockFolder.Name = "comboBox_SecurityLockFolder";
            comboBox_SecurityLockFolder.Size = new Size(624, 29);
            comboBox_SecurityLockFolder.TabIndex = 18;
            // 
            // button_Browser
            // 
            button_Browser.Location = new Point(636, 2);
            button_Browser.Margin = new Padding(4, 2, 4, 2);
            button_Browser.Name = "button_Browser";
            button_Browser.Size = new Size(137, 31);
            button_Browser.TabIndex = 19;
            button_Browser.Text = "Browser";
            button_Browser.UseVisualStyleBackColor = true;
            button_Browser.Click += button_Browser_Click;
            // 
            // grouper_SecurityLockFolderButtons
            // 
            grouper_SecurityLockFolderButtons.BackgroundColor = SystemColors.ButtonHighlight;
            grouper_SecurityLockFolderButtons.BackgroundGradientColor = Color.DarkGray;
            grouper_SecurityLockFolderButtons.BackgroundGradientMode = CodeVendor.Controls.Grouper.GroupBoxGradientMode.Vertical;
            grouper_SecurityLockFolderButtons.BorderColor = Color.Black;
            grouper_SecurityLockFolderButtons.BorderThickness = 1F;
            grouper_SecurityLockFolderButtons.Controls.Add(button_Lock);
            grouper_SecurityLockFolderButtons.Controls.Add(button_Delete);
            grouper_SecurityLockFolderButtons.Controls.Add(button_UnLock);
            grouper_SecurityLockFolderButtons.CustomGroupBoxColor = Color.White;
            grouper_SecurityLockFolderButtons.Dock = DockStyle.Bottom;
            grouper_SecurityLockFolderButtons.GroupImage = null;
            grouper_SecurityLockFolderButtons.GroupTitle = "";
            grouper_SecurityLockFolderButtons.Location = new Point(36, 100);
            grouper_SecurityLockFolderButtons.Margin = new Padding(1, 6, 1, 1);
            grouper_SecurityLockFolderButtons.Name = "grouper_SecurityLockFolderButtons";
            grouper_SecurityLockFolderButtons.Padding = new Padding(36, 31, 36, 31);
            grouper_SecurityLockFolderButtons.PaintGroupBox = false;
            grouper_SecurityLockFolderButtons.RoundCorners = 10;
            grouper_SecurityLockFolderButtons.ShadowColor = Color.DarkGray;
            grouper_SecurityLockFolderButtons.ShadowControl = false;
            grouper_SecurityLockFolderButtons.ShadowThickness = 3;
            grouper_SecurityLockFolderButtons.Size = new Size(811, 79);
            grouper_SecurityLockFolderButtons.TabIndex = 17;
            // 
            // button_Lock
            // 
            button_Lock.Location = new Point(17, 25);
            button_Lock.Margin = new Padding(4, 2, 4, 2);
            button_Lock.Name = "button_Lock";
            button_Lock.Size = new Size(100, 39);
            button_Lock.TabIndex = 17;
            button_Lock.Text = "Lock";
            button_Lock.UseVisualStyleBackColor = true;
            button_Lock.Click += button_Lock_Click;
            // 
            // button_Delete
            // 
            button_Delete.Location = new Point(235, 25);
            button_Delete.Margin = new Padding(4, 2, 4, 2);
            button_Delete.Name = "button_Delete";
            button_Delete.Size = new Size(100, 39);
            button_Delete.TabIndex = 19;
            button_Delete.Text = "Delete";
            button_Delete.UseVisualStyleBackColor = true;
            button_Delete.Click += button_Delete_Click;
            // 
            // button_UnLock
            // 
            button_UnLock.Location = new Point(127, 25);
            button_UnLock.Margin = new Padding(4, 2, 4, 2);
            button_UnLock.Name = "button_UnLock";
            button_UnLock.Size = new Size(100, 39);
            button_UnLock.TabIndex = 18;
            button_UnLock.Text = "UnLock";
            button_UnLock.UseVisualStyleBackColor = true;
            button_UnLock.Click += button_UnLock_Click;
            // 
            // grouper_Properties
            // 
            grouper_Properties.BackgroundColor = SystemColors.ButtonHighlight;
            grouper_Properties.BackgroundGradientColor = Color.DarkGray;
            grouper_Properties.BackgroundGradientMode = CodeVendor.Controls.Grouper.GroupBoxGradientMode.Vertical;
            grouper_Properties.BorderColor = Color.Black;
            grouper_Properties.BorderThickness = 1F;
            grouper_Properties.Controls.Add(checkBox_Hidden);
            grouper_Properties.Controls.Add(checkBox_ReadOnly);
            grouper_Properties.Controls.Add(checkBox_System);
            grouper_Properties.CustomGroupBoxColor = Color.White;
            grouper_Properties.Dock = DockStyle.Right;
            grouper_Properties.GroupImage = null;
            grouper_Properties.GroupTitle = "Folder Properties.";
            grouper_Properties.Location = new Point(847, 42);
            grouper_Properties.Margin = new Padding(1, 6, 1, 1);
            grouper_Properties.Name = "grouper_Properties";
            grouper_Properties.Padding = new Padding(36, 33, 36, 31);
            grouper_Properties.PaintGroupBox = false;
            grouper_Properties.RoundCorners = 10;
            grouper_Properties.ShadowColor = Color.DarkGray;
            grouper_Properties.ShadowControl = false;
            grouper_Properties.ShadowThickness = 3;
            grouper_Properties.Size = new Size(361, 137);
            grouper_Properties.TabIndex = 16;
            // 
            // checkBox_Hidden
            // 
            checkBox_Hidden.AutoSize = true;
            checkBox_Hidden.Location = new Point(41, 38);
            checkBox_Hidden.Margin = new Padding(5, 5, 5, 5);
            checkBox_Hidden.Name = "checkBox_Hidden";
            checkBox_Hidden.Size = new Size(123, 17);
            checkBox_Hidden.TabIndex = 15;
            checkBox_Hidden.Text = "FileAttributes.Hidden";
            checkBox_Hidden.UseVisualStyleBackColor = true;
            checkBox_Hidden.CheckedChanged += checkBox_Hidden_CheckedChanged;
            // 
            // checkBox_ReadOnly
            // 
            checkBox_ReadOnly.AutoSize = true;
            checkBox_ReadOnly.Location = new Point(41, 110);
            checkBox_ReadOnly.Margin = new Padding(5, 5, 5, 5);
            checkBox_ReadOnly.Name = "checkBox_ReadOnly";
            checkBox_ReadOnly.Size = new Size(136, 17);
            checkBox_ReadOnly.TabIndex = 14;
            checkBox_ReadOnly.Text = "FileAttributes.ReadOnly";
            checkBox_ReadOnly.UseVisualStyleBackColor = true;
            checkBox_ReadOnly.CheckedChanged += checkBox_ReadOnly_CheckedChanged;
            // 
            // checkBox_System
            // 
            checkBox_System.AutoSize = true;
            checkBox_System.Location = new Point(41, 74);
            checkBox_System.Margin = new Padding(5, 5, 5, 5);
            checkBox_System.Name = "checkBox_System";
            checkBox_System.Size = new Size(123, 17);
            checkBox_System.TabIndex = 11;
            checkBox_System.Text = "FileAttributes.System";
            checkBox_System.UseVisualStyleBackColor = true;
            checkBox_System.CheckedChanged += checkBox_System_CheckedChanged;
            // 
            // tabPage_RegisterDLL
            // 
            tabPage_RegisterDLL.Controls.Add(grouper9);
            tabPage_RegisterDLL.Location = new Point(4, 4);
            tabPage_RegisterDLL.Margin = new Padding(5, 5, 5, 5);
            tabPage_RegisterDLL.Name = "tabPage_RegisterDLL";
            tabPage_RegisterDLL.Size = new Size(1244, 824);
            tabPage_RegisterDLL.TabIndex = 6;
            tabPage_RegisterDLL.Text = "   Register a DLL";
            tabPage_RegisterDLL.UseVisualStyleBackColor = true;
            // 
            // grouper9
            // 
            grouper9.BackgroundColor = SystemColors.ButtonHighlight;
            grouper9.BackgroundGradientColor = Color.DarkGray;
            grouper9.BackgroundGradientMode = CodeVendor.Controls.Grouper.GroupBoxGradientMode.Vertical;
            grouper9.BorderColor = Color.Black;
            grouper9.BorderThickness = 1F;
            grouper9.Controls.Add(textBox_BrowsedDLL);
            grouper9.Controls.Add(button_BrowserDLL);
            grouper9.Controls.Add(button_UnregisterDLL);
            grouper9.Controls.Add(button_RegisterDLL);
            grouper9.CustomGroupBoxColor = Color.White;
            grouper9.Dock = DockStyle.Top;
            grouper9.GroupImage = null;
            grouper9.GroupTitle = "";
            grouper9.Location = new Point(0, 0);
            grouper9.Margin = new Padding(1, 6, 1, 1);
            grouper9.Name = "grouper9";
            grouper9.Padding = new Padding(36, 31, 36, 31);
            grouper9.PaintGroupBox = false;
            grouper9.RoundCorners = 10;
            grouper9.ShadowColor = Color.DarkGray;
            grouper9.ShadowControl = false;
            grouper9.ShadowThickness = 3;
            grouper9.Size = new Size(1244, 225);
            grouper9.TabIndex = 18;
            // 
            // textBox_BrowsedDLL
            // 
            textBox_BrowsedDLL.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox_BrowsedDLL.Location = new Point(41, 34);
            textBox_BrowsedDLL.Margin = new Padding(5, 5, 5, 5);
            textBox_BrowsedDLL.Name = "textBox_BrowsedDLL";
            textBox_BrowsedDLL.Size = new Size(944, 26);
            textBox_BrowsedDLL.TabIndex = 20;
            // 
            // button_BrowserDLL
            // 
            button_BrowserDLL.Location = new Point(997, 33);
            button_BrowserDLL.Margin = new Padding(4, 2, 4, 2);
            button_BrowserDLL.Name = "button_BrowserDLL";
            button_BrowserDLL.Size = new Size(176, 39);
            button_BrowserDLL.TabIndex = 17;
            button_BrowserDLL.Text = "Browser DLL";
            button_BrowserDLL.UseVisualStyleBackColor = true;
            button_BrowserDLL.Click += button_BrowserDLL_Click;
            // 
            // button_UnregisterDLL
            // 
            button_UnregisterDLL.Location = new Point(997, 153);
            button_UnregisterDLL.Margin = new Padding(4, 2, 4, 2);
            button_UnregisterDLL.Name = "button_UnregisterDLL";
            button_UnregisterDLL.Size = new Size(177, 39);
            button_UnregisterDLL.TabIndex = 19;
            button_UnregisterDLL.Text = "Unregister a DLL";
            button_UnregisterDLL.UseVisualStyleBackColor = true;
            // 
            // button_RegisterDLL
            // 
            button_RegisterDLL.Location = new Point(812, 153);
            button_RegisterDLL.Margin = new Padding(4, 2, 4, 2);
            button_RegisterDLL.Name = "button_RegisterDLL";
            button_RegisterDLL.Size = new Size(177, 39);
            button_RegisterDLL.TabIndex = 18;
            button_RegisterDLL.Text = "Register a DLL";
            button_RegisterDLL.UseVisualStyleBackColor = true;
            button_RegisterDLL.Click += button_RegisterDLL_Click;
            // 
            // tabPage_SystemCompatibility
            // 
            tabPage_SystemCompatibility.Controls.Add(grouper10);
            tabPage_SystemCompatibility.Location = new Point(4, 4);
            tabPage_SystemCompatibility.Margin = new Padding(5, 5, 5, 5);
            tabPage_SystemCompatibility.Name = "tabPage_SystemCompatibility";
            tabPage_SystemCompatibility.Size = new Size(1244, 824);
            tabPage_SystemCompatibility.TabIndex = 7;
            tabPage_SystemCompatibility.Text = "   System Compatibility";
            tabPage_SystemCompatibility.UseVisualStyleBackColor = true;
            // 
            // grouper10
            // 
            grouper10.BackgroundColor = SystemColors.ButtonHighlight;
            grouper10.BackgroundGradientColor = Color.DarkGray;
            grouper10.BackgroundGradientMode = CodeVendor.Controls.Grouper.GroupBoxGradientMode.Vertical;
            grouper10.BorderColor = Color.Black;
            grouper10.BorderThickness = 1F;
            grouper10.Controls.Add(checkBox_SupportDoubleBuffering);
            grouper10.Controls.Add(label_SupportDoubleBuffering);
            grouper10.CustomGroupBoxColor = Color.White;
            grouper10.Dock = DockStyle.Top;
            grouper10.GroupImage = null;
            grouper10.GroupTitle = "";
            grouper10.Location = new Point(0, 0);
            grouper10.Margin = new Padding(1, 6, 1, 1);
            grouper10.Name = "grouper10";
            grouper10.Padding = new Padding(36, 31, 36, 31);
            grouper10.PaintGroupBox = false;
            grouper10.RoundCorners = 10;
            grouper10.ShadowColor = Color.DarkGray;
            grouper10.ShadowControl = false;
            grouper10.ShadowThickness = 3;
            grouper10.Size = new Size(1244, 225);
            grouper10.TabIndex = 19;
            // 
            // checkBox_SupportDoubleBuffering
            // 
            checkBox_SupportDoubleBuffering.AutoSize = true;
            checkBox_SupportDoubleBuffering.Location = new Point(565, 42);
            checkBox_SupportDoubleBuffering.Margin = new Padding(5, 5, 5, 5);
            checkBox_SupportDoubleBuffering.Name = "checkBox_SupportDoubleBuffering";
            checkBox_SupportDoubleBuffering.Size = new Size(15, 14);
            checkBox_SupportDoubleBuffering.TabIndex = 1;
            checkBox_SupportDoubleBuffering.UseVisualStyleBackColor = true;
            checkBox_SupportDoubleBuffering.CheckedChanged += checkBox_SupportDoubleBuffering_CheckedChanged;
            // 
            // label_SupportDoubleBuffering
            // 
            label_SupportDoubleBuffering.AutoSize = true;
            label_SupportDoubleBuffering.Location = new Point(41, 44);
            label_SupportDoubleBuffering.Margin = new Padding(5, 0, 5, 0);
            label_SupportDoubleBuffering.Name = "label_SupportDoubleBuffering";
            label_SupportDoubleBuffering.Size = new Size(414, 21);
            label_SupportDoubleBuffering.TabIndex = 0;
            label_SupportDoubleBuffering.Text = "The system support DoubleBuffering on drawing controls?";
            // 
            // tabPage_Documentation
            // 
            tabPage_Documentation.AutoScroll = true;
            tabPage_Documentation.Controls.Add(grouper_DocumentationBehavior);
            tabPage_Documentation.Location = new Point(4, 4);
            tabPage_Documentation.Margin = new Padding(5, 5, 5, 5);
            tabPage_Documentation.Name = "tabPage_Documentation";
            tabPage_Documentation.Padding = new Padding(7, 6, 7, 6);
            tabPage_Documentation.Size = new Size(1244, 824);
            tabPage_Documentation.TabIndex = 8;
            tabPage_Documentation.Text = "   Documentation";
            tabPage_Documentation.UseVisualStyleBackColor = true;
            // 
            // grouper_DocumentationBehavior
            // 
            grouper_DocumentationBehavior.AutoScroll = true;
            grouper_DocumentationBehavior.AutoSize = true;
            grouper_DocumentationBehavior.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            grouper_DocumentationBehavior.BackgroundColor = SystemColors.Control;
            grouper_DocumentationBehavior.BackgroundGradientColor = Color.Gainsboro;
            grouper_DocumentationBehavior.BackgroundGradientMode = CodeVendor.Controls.Grouper.GroupBoxGradientMode.None;
            grouper_DocumentationBehavior.BorderColor = Color.Black;
            grouper_DocumentationBehavior.BorderThickness = 1F;
            grouper_DocumentationBehavior.Controls.Add(grouper_NoDocumentsToShow);
            grouper_DocumentationBehavior.Controls.Add(grouper_Last2Versions);
            grouper_DocumentationBehavior.Controls.Add(grouper_AllVersionsFound);
            grouper_DocumentationBehavior.Controls.Add(grouper_LastRevision);
            grouper_DocumentationBehavior.Controls.Add(grouper_SpecifiedDocument);
            grouper_DocumentationBehavior.Controls.Add(grouper_BrowserVersion);
            grouper_DocumentationBehavior.CustomGroupBoxColor = Color.White;
            grouper_DocumentationBehavior.Dock = DockStyle.Fill;
            grouper_DocumentationBehavior.GroupImage = null;
            grouper_DocumentationBehavior.GroupTitle = "Documentation Behavior";
            grouper_DocumentationBehavior.Location = new Point(7, 6);
            grouper_DocumentationBehavior.Margin = new Padding(1, 6, 1, 1);
            grouper_DocumentationBehavior.Name = "grouper_DocumentationBehavior";
            grouper_DocumentationBehavior.Padding = new Padding(36, 31, 36, 31);
            grouper_DocumentationBehavior.PaintGroupBox = false;
            grouper_DocumentationBehavior.RoundCorners = 10;
            grouper_DocumentationBehavior.ShadowColor = Color.DarkGray;
            grouper_DocumentationBehavior.ShadowControl = false;
            grouper_DocumentationBehavior.ShadowThickness = 3;
            grouper_DocumentationBehavior.Size = new Size(1230, 812);
            grouper_DocumentationBehavior.TabIndex = 20;
            // 
            // grouper_NoDocumentsToShow
            // 
            grouper_NoDocumentsToShow.BackgroundColor = SystemColors.Control;
            grouper_NoDocumentsToShow.BackgroundGradientColor = Color.Gainsboro;
            grouper_NoDocumentsToShow.BackgroundGradientMode = CodeVendor.Controls.Grouper.GroupBoxGradientMode.Vertical;
            grouper_NoDocumentsToShow.BorderColor = Color.Gainsboro;
            grouper_NoDocumentsToShow.BorderThickness = 1F;
            grouper_NoDocumentsToShow.Controls.Add(richTextBox_NoDocumentsToShow);
            grouper_NoDocumentsToShow.Controls.Add(panel_NoDocumentsToShow);
            grouper_NoDocumentsToShow.CustomGroupBoxColor = Color.White;
            grouper_NoDocumentsToShow.Dock = DockStyle.Top;
            grouper_NoDocumentsToShow.GroupImage = null;
            grouper_NoDocumentsToShow.GroupTitle = "";
            grouper_NoDocumentsToShow.Location = new Point(36, 809);
            grouper_NoDocumentsToShow.Margin = new Padding(1, 6, 1, 1);
            grouper_NoDocumentsToShow.Name = "grouper_NoDocumentsToShow";
            grouper_NoDocumentsToShow.Padding = new Padding(9, 22, 9, 7);
            grouper_NoDocumentsToShow.PaintGroupBox = false;
            grouper_NoDocumentsToShow.RoundCorners = 10;
            grouper_NoDocumentsToShow.ShadowColor = Color.DarkGray;
            grouper_NoDocumentsToShow.ShadowControl = false;
            grouper_NoDocumentsToShow.ShadowThickness = 3;
            grouper_NoDocumentsToShow.Size = new Size(1141, 124);
            grouper_NoDocumentsToShow.TabIndex = 26;
            // 
            // richTextBox_NoDocumentsToShow
            // 
            richTextBox_NoDocumentsToShow.BorderStyle = BorderStyle.None;
            richTextBox_NoDocumentsToShow.Dock = DockStyle.Fill;
            richTextBox_NoDocumentsToShow.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            richTextBox_NoDocumentsToShow.Location = new Point(308, 22);
            richTextBox_NoDocumentsToShow.Margin = new Padding(5, 5, 5, 5);
            richTextBox_NoDocumentsToShow.Name = "richTextBox_NoDocumentsToShow";
            richTextBox_NoDocumentsToShow.ReadOnly = true;
            richTextBox_NoDocumentsToShow.Size = new Size(824, 95);
            richTextBox_NoDocumentsToShow.TabIndex = 1;
            richTextBox_NoDocumentsToShow.Text = "\n               On this options the system will not show any Document. It's the defaul and normal beahavior of the system.";
            // 
            // panel_NoDocumentsToShow
            // 
            panel_NoDocumentsToShow.Controls.Add(radioButton_NoDocumentsToShow);
            panel_NoDocumentsToShow.Dock = DockStyle.Left;
            panel_NoDocumentsToShow.Location = new Point(9, 22);
            panel_NoDocumentsToShow.Margin = new Padding(5, 5, 5, 5);
            panel_NoDocumentsToShow.MinimumSize = new Size(276, 0);
            panel_NoDocumentsToShow.Name = "panel_NoDocumentsToShow";
            panel_NoDocumentsToShow.Size = new Size(299, 95);
            panel_NoDocumentsToShow.TabIndex = 2;
            // 
            // radioButton_NoDocumentsToShow
            // 
            radioButton_NoDocumentsToShow.AutoCheck = false;
            radioButton_NoDocumentsToShow.AutoSize = true;
            radioButton_NoDocumentsToShow.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            radioButton_NoDocumentsToShow.Location = new Point(5, 31);
            radioButton_NoDocumentsToShow.Margin = new Padding(5, 5, 5, 5);
            radioButton_NoDocumentsToShow.Name = "radioButton_NoDocumentsToShow";
            radioButton_NoDocumentsToShow.Size = new Size(160, 20);
            radioButton_NoDocumentsToShow.TabIndex = 0;
            radioButton_NoDocumentsToShow.Tag = "1";
            radioButton_NoDocumentsToShow.Text = "Not Document to Show";
            radioButton_NoDocumentsToShow.UseVisualStyleBackColor = true;
            // 
            // grouper_Last2Versions
            // 
            grouper_Last2Versions.BackgroundColor = SystemColors.Control;
            grouper_Last2Versions.BackgroundGradientColor = Color.Gainsboro;
            grouper_Last2Versions.BackgroundGradientMode = CodeVendor.Controls.Grouper.GroupBoxGradientMode.Vertical;
            grouper_Last2Versions.BorderColor = Color.Gainsboro;
            grouper_Last2Versions.BorderThickness = 1F;
            grouper_Last2Versions.Controls.Add(richTextBox4);
            grouper_Last2Versions.Controls.Add(panel3);
            grouper_Last2Versions.CustomGroupBoxColor = Color.White;
            grouper_Last2Versions.Dock = DockStyle.Top;
            grouper_Last2Versions.GroupImage = null;
            grouper_Last2Versions.GroupTitle = "";
            grouper_Last2Versions.Location = new Point(36, 643);
            grouper_Last2Versions.Margin = new Padding(1, 6, 1, 1);
            grouper_Last2Versions.Name = "grouper_Last2Versions";
            grouper_Last2Versions.Padding = new Padding(9, 22, 9, 7);
            grouper_Last2Versions.PaintGroupBox = false;
            grouper_Last2Versions.RoundCorners = 10;
            grouper_Last2Versions.ShadowColor = Color.DarkGray;
            grouper_Last2Versions.ShadowControl = false;
            grouper_Last2Versions.ShadowThickness = 3;
            grouper_Last2Versions.Size = new Size(1141, 166);
            grouper_Last2Versions.TabIndex = 24;
            // 
            // richTextBox4
            // 
            richTextBox4.BorderStyle = BorderStyle.None;
            richTextBox4.Dock = DockStyle.Fill;
            richTextBox4.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            richTextBox4.Location = new Point(308, 22);
            richTextBox4.Margin = new Padding(5, 5, 5, 5);
            richTextBox4.Name = "richTextBox4";
            richTextBox4.ReadOnly = true;
            richTextBox4.Size = new Size(824, 137);
            richTextBox4.TabIndex = 1;
            richTextBox4.Text = "";
            // 
            // panel3
            // 
            panel3.Controls.Add(numericUpDown1);
            panel3.Controls.Add(radioButton_Last2Versions);
            panel3.Controls.Add(label_Versions);
            panel3.Dock = DockStyle.Left;
            panel3.Location = new Point(9, 22);
            panel3.Margin = new Padding(5, 5, 5, 5);
            panel3.MinimumSize = new Size(276, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(299, 137);
            panel3.TabIndex = 2;
            // 
            // numericUpDown1
            // 
            numericUpDown1.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            numericUpDown1.Location = new Point(92, 52);
            numericUpDown1.Margin = new Padding(5, 5, 5, 5);
            numericUpDown1.Maximum = new decimal(new int[] { 99, 0, 0, 0 });
            numericUpDown1.Minimum = new decimal(new int[] { 2, 0, 0, 0 });
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(64, 22);
            numericUpDown1.TabIndex = 1;
            numericUpDown1.Value = new decimal(new int[] { 2, 0, 0, 0 });
            // 
            // radioButton_Last2Versions
            // 
            radioButton_Last2Versions.AutoCheck = false;
            radioButton_Last2Versions.AutoSize = true;
            radioButton_Last2Versions.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            radioButton_Last2Versions.Location = new Point(9, 52);
            radioButton_Last2Versions.Margin = new Padding(5, 5, 5, 5);
            radioButton_Last2Versions.Name = "radioButton_Last2Versions";
            radioButton_Last2Versions.Size = new Size(50, 20);
            radioButton_Last2Versions.TabIndex = 0;
            radioButton_Last2Versions.Tag = "4";
            radioButton_Last2Versions.Text = "Last";
            radioButton_Last2Versions.UseVisualStyleBackColor = true;
            // 
            // label_Versions
            // 
            label_Versions.AutoSize = true;
            label_Versions.Location = new Point(153, 58);
            label_Versions.Margin = new Padding(5, 0, 5, 0);
            label_Versions.Name = "label_Versions";
            label_Versions.Size = new Size(73, 21);
            label_Versions.TabIndex = 2;
            label_Versions.Text = " Versions";
            // 
            // grouper_AllVersionsFound
            // 
            grouper_AllVersionsFound.BackgroundColor = SystemColors.Control;
            grouper_AllVersionsFound.BackgroundGradientColor = Color.Gainsboro;
            grouper_AllVersionsFound.BackgroundGradientMode = CodeVendor.Controls.Grouper.GroupBoxGradientMode.Vertical;
            grouper_AllVersionsFound.BorderColor = Color.Gainsboro;
            grouper_AllVersionsFound.BorderThickness = 1F;
            grouper_AllVersionsFound.Controls.Add(richTextBox_AllVersionsFound);
            grouper_AllVersionsFound.Controls.Add(panel_AllVersionsFound);
            grouper_AllVersionsFound.CustomGroupBoxColor = Color.White;
            grouper_AllVersionsFound.Dock = DockStyle.Top;
            grouper_AllVersionsFound.GroupImage = null;
            grouper_AllVersionsFound.GroupTitle = "";
            grouper_AllVersionsFound.Location = new Point(36, 471);
            grouper_AllVersionsFound.Margin = new Padding(1, 6, 1, 1);
            grouper_AllVersionsFound.Name = "grouper_AllVersionsFound";
            grouper_AllVersionsFound.Padding = new Padding(9, 22, 9, 7);
            grouper_AllVersionsFound.PaintGroupBox = false;
            grouper_AllVersionsFound.RoundCorners = 10;
            grouper_AllVersionsFound.ShadowColor = Color.DarkGray;
            grouper_AllVersionsFound.ShadowControl = false;
            grouper_AllVersionsFound.ShadowThickness = 3;
            grouper_AllVersionsFound.Size = new Size(1141, 172);
            grouper_AllVersionsFound.TabIndex = 23;
            // 
            // richTextBox_AllVersionsFound
            // 
            richTextBox_AllVersionsFound.BorderStyle = BorderStyle.None;
            richTextBox_AllVersionsFound.Dock = DockStyle.Fill;
            richTextBox_AllVersionsFound.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            richTextBox_AllVersionsFound.Location = new Point(308, 22);
            richTextBox_AllVersionsFound.Margin = new Padding(5, 5, 5, 5);
            richTextBox_AllVersionsFound.Name = "richTextBox_AllVersionsFound";
            richTextBox_AllVersionsFound.ReadOnly = true;
            richTextBox_AllVersionsFound.Size = new Size(824, 143);
            richTextBox_AllVersionsFound.TabIndex = 1;
            richTextBox_AllVersionsFound.Text = "";
            // 
            // panel_AllVersionsFound
            // 
            panel_AllVersionsFound.Controls.Add(radioButton_AllVersionsFound);
            panel_AllVersionsFound.Dock = DockStyle.Left;
            panel_AllVersionsFound.Location = new Point(9, 22);
            panel_AllVersionsFound.Margin = new Padding(5, 5, 5, 5);
            panel_AllVersionsFound.MinimumSize = new Size(276, 0);
            panel_AllVersionsFound.Name = "panel_AllVersionsFound";
            panel_AllVersionsFound.Size = new Size(299, 143);
            panel_AllVersionsFound.TabIndex = 2;
            // 
            // radioButton_AllVersionsFound
            // 
            radioButton_AllVersionsFound.AutoCheck = false;
            radioButton_AllVersionsFound.AutoSize = true;
            radioButton_AllVersionsFound.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            radioButton_AllVersionsFound.Location = new Point(5, 54);
            radioButton_AllVersionsFound.Margin = new Padding(5, 5, 5, 5);
            radioButton_AllVersionsFound.Name = "radioButton_AllVersionsFound";
            radioButton_AllVersionsFound.Size = new Size(137, 20);
            radioButton_AllVersionsFound.TabIndex = 0;
            radioButton_AllVersionsFound.Tag = "3";
            radioButton_AllVersionsFound.Text = "All Versions Found";
            radioButton_AllVersionsFound.UseVisualStyleBackColor = true;
            // 
            // grouper_LastRevision
            // 
            grouper_LastRevision.BackgroundColor = SystemColors.Control;
            grouper_LastRevision.BackgroundGradientColor = Color.Gainsboro;
            grouper_LastRevision.BackgroundGradientMode = CodeVendor.Controls.Grouper.GroupBoxGradientMode.Vertical;
            grouper_LastRevision.BorderColor = Color.Gainsboro;
            grouper_LastRevision.BorderThickness = 1F;
            grouper_LastRevision.Controls.Add(richTextBox_LastRevision);
            grouper_LastRevision.Controls.Add(panel_LastRevision);
            grouper_LastRevision.CustomGroupBoxColor = Color.White;
            grouper_LastRevision.Dock = DockStyle.Top;
            grouper_LastRevision.GroupImage = null;
            grouper_LastRevision.GroupTitle = "";
            grouper_LastRevision.Location = new Point(36, 333);
            grouper_LastRevision.Margin = new Padding(1, 6, 1, 1);
            grouper_LastRevision.Name = "grouper_LastRevision";
            grouper_LastRevision.Padding = new Padding(9, 22, 9, 7);
            grouper_LastRevision.PaintGroupBox = false;
            grouper_LastRevision.RoundCorners = 10;
            grouper_LastRevision.ShadowColor = Color.DarkGray;
            grouper_LastRevision.ShadowControl = false;
            grouper_LastRevision.ShadowThickness = 3;
            grouper_LastRevision.Size = new Size(1141, 138);
            grouper_LastRevision.TabIndex = 22;
            // 
            // richTextBox_LastRevision
            // 
            richTextBox_LastRevision.BorderStyle = BorderStyle.None;
            richTextBox_LastRevision.Dock = DockStyle.Fill;
            richTextBox_LastRevision.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            richTextBox_LastRevision.Location = new Point(308, 22);
            richTextBox_LastRevision.Margin = new Padding(5, 5, 5, 5);
            richTextBox_LastRevision.Name = "richTextBox_LastRevision";
            richTextBox_LastRevision.ReadOnly = true;
            richTextBox_LastRevision.Size = new Size(824, 109);
            richTextBox_LastRevision.TabIndex = 1;
            richTextBox_LastRevision.Text = "";
            // 
            // panel_LastRevision
            // 
            panel_LastRevision.Controls.Add(radioButton_LastRevision);
            panel_LastRevision.Dock = DockStyle.Left;
            panel_LastRevision.Location = new Point(9, 22);
            panel_LastRevision.Margin = new Padding(5, 5, 5, 5);
            panel_LastRevision.MinimumSize = new Size(276, 0);
            panel_LastRevision.Name = "panel_LastRevision";
            panel_LastRevision.Size = new Size(299, 109);
            panel_LastRevision.TabIndex = 2;
            // 
            // radioButton_LastRevision
            // 
            radioButton_LastRevision.AutoCheck = false;
            radioButton_LastRevision.AutoSize = true;
            radioButton_LastRevision.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            radioButton_LastRevision.Location = new Point(5, 39);
            radioButton_LastRevision.Margin = new Padding(5, 5, 5, 5);
            radioButton_LastRevision.Name = "radioButton_LastRevision";
            radioButton_LastRevision.Size = new Size(133, 20);
            radioButton_LastRevision.TabIndex = 0;
            radioButton_LastRevision.Tag = "2";
            radioButton_LastRevision.Text = "The Last Revision";
            radioButton_LastRevision.UseVisualStyleBackColor = true;
            // 
            // grouper_SpecifiedDocument
            // 
            grouper_SpecifiedDocument.BackgroundColor = SystemColors.Control;
            grouper_SpecifiedDocument.BackgroundGradientColor = Color.Gainsboro;
            grouper_SpecifiedDocument.BackgroundGradientMode = CodeVendor.Controls.Grouper.GroupBoxGradientMode.Vertical;
            grouper_SpecifiedDocument.BorderColor = Color.Gainsboro;
            grouper_SpecifiedDocument.BorderThickness = 1F;
            grouper_SpecifiedDocument.Controls.Add(richTextBox_SpecifiedDocument);
            grouper_SpecifiedDocument.Controls.Add(panel_SpecifiedDocument);
            grouper_SpecifiedDocument.CustomGroupBoxColor = Color.White;
            grouper_SpecifiedDocument.Dock = DockStyle.Top;
            grouper_SpecifiedDocument.GroupImage = null;
            grouper_SpecifiedDocument.GroupTitle = "";
            grouper_SpecifiedDocument.Location = new Point(36, 222);
            grouper_SpecifiedDocument.Margin = new Padding(1, 6, 1, 1);
            grouper_SpecifiedDocument.Name = "grouper_SpecifiedDocument";
            grouper_SpecifiedDocument.Padding = new Padding(9, 22, 9, 7);
            grouper_SpecifiedDocument.PaintGroupBox = false;
            grouper_SpecifiedDocument.RoundCorners = 10;
            grouper_SpecifiedDocument.ShadowColor = Color.DarkGray;
            grouper_SpecifiedDocument.ShadowControl = false;
            grouper_SpecifiedDocument.ShadowThickness = 3;
            grouper_SpecifiedDocument.Size = new Size(1141, 111);
            grouper_SpecifiedDocument.TabIndex = 21;
            // 
            // richTextBox_SpecifiedDocument
            // 
            richTextBox_SpecifiedDocument.BorderStyle = BorderStyle.None;
            richTextBox_SpecifiedDocument.Dock = DockStyle.Fill;
            richTextBox_SpecifiedDocument.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            richTextBox_SpecifiedDocument.Location = new Point(308, 22);
            richTextBox_SpecifiedDocument.Margin = new Padding(5, 5, 5, 5);
            richTextBox_SpecifiedDocument.Name = "richTextBox_SpecifiedDocument";
            richTextBox_SpecifiedDocument.ReadOnly = true;
            richTextBox_SpecifiedDocument.Size = new Size(824, 82);
            richTextBox_SpecifiedDocument.TabIndex = 1;
            richTextBox_SpecifiedDocument.Text = "\tOn this options the system will luck in column Data_Sheet if a specified document exist, if the document is found it's show into the tap Document.";
            // 
            // panel_SpecifiedDocument
            // 
            panel_SpecifiedDocument.Controls.Add(radioButton_SpecifiedDocument);
            panel_SpecifiedDocument.Dock = DockStyle.Left;
            panel_SpecifiedDocument.Location = new Point(9, 22);
            panel_SpecifiedDocument.Margin = new Padding(5, 5, 5, 5);
            panel_SpecifiedDocument.MinimumSize = new Size(276, 0);
            panel_SpecifiedDocument.Name = "panel_SpecifiedDocument";
            panel_SpecifiedDocument.Size = new Size(299, 82);
            panel_SpecifiedDocument.TabIndex = 2;
            // 
            // radioButton_SpecifiedDocument
            // 
            radioButton_SpecifiedDocument.AutoCheck = false;
            radioButton_SpecifiedDocument.AutoSize = true;
            radioButton_SpecifiedDocument.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            radioButton_SpecifiedDocument.Location = new Point(5, 26);
            radioButton_SpecifiedDocument.Margin = new Padding(5, 5, 5, 5);
            radioButton_SpecifiedDocument.Name = "radioButton_SpecifiedDocument";
            radioButton_SpecifiedDocument.Size = new Size(146, 20);
            radioButton_SpecifiedDocument.TabIndex = 0;
            radioButton_SpecifiedDocument.Tag = "1";
            radioButton_SpecifiedDocument.Text = "Specified Document";
            radioButton_SpecifiedDocument.UseVisualStyleBackColor = true;
            // 
            // grouper_BrowserVersion
            // 
            grouper_BrowserVersion.BackgroundColor = SystemColors.Control;
            grouper_BrowserVersion.BackgroundGradientColor = Color.Gainsboro;
            grouper_BrowserVersion.BackgroundGradientMode = CodeVendor.Controls.Grouper.GroupBoxGradientMode.Vertical;
            grouper_BrowserVersion.BorderColor = Color.Gainsboro;
            grouper_BrowserVersion.BorderThickness = 1F;
            grouper_BrowserVersion.Controls.Add(checkBox_PdfViewer);
            grouper_BrowserVersion.Controls.Add(richTextBox5);
            grouper_BrowserVersion.CustomGroupBoxColor = Color.White;
            grouper_BrowserVersion.Dock = DockStyle.Top;
            grouper_BrowserVersion.GroupImage = null;
            grouper_BrowserVersion.GroupTitle = "";
            grouper_BrowserVersion.Location = new Point(36, 31);
            grouper_BrowserVersion.Margin = new Padding(1, 6, 1, 1);
            grouper_BrowserVersion.Name = "grouper_BrowserVersion";
            grouper_BrowserVersion.Padding = new Padding(9, 22, 9, 7);
            grouper_BrowserVersion.PaintGroupBox = false;
            grouper_BrowserVersion.RoundCorners = 10;
            grouper_BrowserVersion.ShadowColor = Color.DarkGray;
            grouper_BrowserVersion.ShadowControl = false;
            grouper_BrowserVersion.ShadowThickness = 3;
            grouper_BrowserVersion.Size = new Size(1141, 191);
            grouper_BrowserVersion.TabIndex = 25;
            // 
            // checkBox_PdfViewer
            // 
            checkBox_PdfViewer.AutoSize = true;
            checkBox_PdfViewer.Location = new Point(53, 85);
            checkBox_PdfViewer.Margin = new Padding(5, 5, 5, 5);
            checkBox_PdfViewer.Name = "checkBox_PdfViewer";
            checkBox_PdfViewer.Size = new Size(82, 17);
            checkBox_PdfViewer.TabIndex = 3;
            checkBox_PdfViewer.Text = "PDF Viewer";
            checkBox_PdfViewer.UseVisualStyleBackColor = true;
            checkBox_PdfViewer.CheckedChanged += CheckBox_PdfViewer_CheckedChanged;
            // 
            // richTextBox5
            // 
            richTextBox5.BackColor = Color.LightGoldenrodYellow;
            richTextBox5.BorderStyle = BorderStyle.None;
            richTextBox5.DetectUrls = false;
            richTextBox5.Dock = DockStyle.Right;
            richTextBox5.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            richTextBox5.Location = new Point(-132, 22);
            richTextBox5.Margin = new Padding(5, 5, 5, 5);
            richTextBox5.Name = "richTextBox5";
            richTextBox5.ReadOnly = true;
            richTextBox5.ShortcutsEnabled = false;
            richTextBox5.Size = new Size(1264, 162);
            richTextBox5.TabIndex = 2;
            richTextBox5.Text = "\tDo not check the checkbox, the application will use the internal PDF viewer.\nIf you check the checkbox, the application will use the default Windows PDF viewer";
            // 
            // tabPage_SearchForPDFFileWithin
            // 
            tabPage_SearchForPDFFileWithin.Controls.Add(grouper_DefinedAddressDocumentation);
            tabPage_SearchForPDFFileWithin.Controls.Add(panel_Space2);
            tabPage_SearchForPDFFileWithin.Controls.Add(grouper_SearchForPDFfileWithin);
            tabPage_SearchForPDFFileWithin.Controls.Add(panel_Space_SearchForPDFfileWithin);
            tabPage_SearchForPDFFileWithin.Location = new Point(4, 4);
            tabPage_SearchForPDFFileWithin.Margin = new Padding(5, 5, 5, 5);
            tabPage_SearchForPDFFileWithin.Name = "tabPage_SearchForPDFFileWithin";
            tabPage_SearchForPDFFileWithin.Size = new Size(1244, 824);
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
            grouper_DefinedAddressDocumentation.Dock = DockStyle.Top;
            grouper_DefinedAddressDocumentation.GroupImage = null;
            grouper_DefinedAddressDocumentation.GroupTitle = "Search for PDF file within";
            grouper_DefinedAddressDocumentation.Location = new Point(0, 173);
            grouper_DefinedAddressDocumentation.Margin = new Padding(1, 6, 1, 6);
            grouper_DefinedAddressDocumentation.MinimumSize = new Size(800, 129);
            grouper_DefinedAddressDocumentation.Name = "grouper_DefinedAddressDocumentation";
            grouper_DefinedAddressDocumentation.Padding = new Padding(9, 31, 9, 7);
            grouper_DefinedAddressDocumentation.PaintGroupBox = false;
            grouper_DefinedAddressDocumentation.RoundCorners = 10;
            grouper_DefinedAddressDocumentation.ShadowColor = Color.DarkGray;
            grouper_DefinedAddressDocumentation.ShadowControl = false;
            grouper_DefinedAddressDocumentation.ShadowThickness = 3;
            grouper_DefinedAddressDocumentation.Size = new Size(1244, 359);
            grouper_DefinedAddressDocumentation.TabIndex = 26;
            // 
            // documentsAddressGroup_SearchForPDFfileWithin
            // 
            documentsAddressGroup_SearchForPDFfileWithin.AutoSize = true;
            documentsAddressGroup_SearchForPDFfileWithin.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            documentsAddressGroup_SearchForPDFfileWithin.Dock = DockStyle.Fill;
            documentsAddressGroup_SearchForPDFfileWithin.Location = new Point(9, 31);
            documentsAddressGroup_SearchForPDFfileWithin.Margin = new Padding(7, 7, 7, 7);
            documentsAddressGroup_SearchForPDFfileWithin.MinimumSize = new Size(800, 175);
            documentsAddressGroup_SearchForPDFfileWithin.Name = "documentsAddressGroup_SearchForPDFfileWithin";
            documentsAddressGroup_SearchForPDFfileWithin.Size = new Size(1226, 321);
            documentsAddressGroup_SearchForPDFfileWithin.TabIndex = 24;
            // 
            // panel_Space2
            // 
            panel_Space2.AutoSize = true;
            panel_Space2.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panel_Space2.BackColor = Color.Transparent;
            panel_Space2.Dock = DockStyle.Top;
            panel_Space2.Location = new Point(0, 158);
            panel_Space2.Margin = new Padding(5, 5, 5, 5);
            panel_Space2.MinimumSize = new Size(533, 15);
            panel_Space2.Name = "panel_Space2";
            panel_Space2.Size = new Size(1244, 15);
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
            grouper_SearchForPDFfileWithin.GroupImage = null;
            grouper_SearchForPDFfileWithin.GroupTitle = "Information about Search for PDF file within";
            grouper_SearchForPDFfileWithin.Location = new Point(0, 15);
            grouper_SearchForPDFfileWithin.Margin = new Padding(1, 6, 1, 1);
            grouper_SearchForPDFfileWithin.Name = "grouper_SearchForPDFfileWithin";
            grouper_SearchForPDFfileWithin.Padding = new Padding(17, 42, 17, 15);
            grouper_SearchForPDFfileWithin.PaintGroupBox = false;
            grouper_SearchForPDFfileWithin.RoundCorners = 10;
            grouper_SearchForPDFfileWithin.ShadowColor = Color.DarkGray;
            grouper_SearchForPDFfileWithin.ShadowControl = false;
            grouper_SearchForPDFfileWithin.ShadowThickness = 3;
            grouper_SearchForPDFfileWithin.Size = new Size(1244, 143);
            grouper_SearchForPDFfileWithin.TabIndex = 29;
            // 
            // richTextBox_SearchForPDFfileWithin
            // 
            richTextBox_SearchForPDFfileWithin.BackColor = SystemColors.Info;
            richTextBox_SearchForPDFfileWithin.BorderStyle = BorderStyle.None;
            richTextBox_SearchForPDFfileWithin.Dock = DockStyle.Fill;
            richTextBox_SearchForPDFfileWithin.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            richTextBox_SearchForPDFfileWithin.Location = new Point(17, 42);
            richTextBox_SearchForPDFfileWithin.Margin = new Padding(5, 5, 5, 5);
            richTextBox_SearchForPDFfileWithin.Name = "richTextBox_SearchForPDFfileWithin";
            richTextBox_SearchForPDFfileWithin.Size = new Size(1210, 86);
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
            panel_Space_SearchForPDFfileWithin.Margin = new Padding(5, 5, 5, 5);
            panel_Space_SearchForPDFfileWithin.MinimumSize = new Size(533, 15);
            panel_Space_SearchForPDFfileWithin.Name = "panel_Space_SearchForPDFfileWithin";
            panel_Space_SearchForPDFfileWithin.Size = new Size(1244, 15);
            panel_Space_SearchForPDFfileWithin.TabIndex = 30;
            // 
            // tabPage_ConvertFilesFrontThisLocation
            // 
            tabPage_ConvertFilesFrontThisLocation.Controls.Add(grouper_ConvertFilesFrontThisLocation);
            tabPage_ConvertFilesFrontThisLocation.Controls.Add(panel_ScanTheseFoltherFor);
            tabPage_ConvertFilesFrontThisLocation.Controls.Add(grouper_ConvertFilesFrontThisLocationInformation);
            tabPage_ConvertFilesFrontThisLocation.Controls.Add(panel_ScanTheseFoltherForInformation);
            tabPage_ConvertFilesFrontThisLocation.Location = new Point(4, 4);
            tabPage_ConvertFilesFrontThisLocation.Margin = new Padding(5, 5, 5, 5);
            tabPage_ConvertFilesFrontThisLocation.Name = "tabPage_ConvertFilesFrontThisLocation";
            tabPage_ConvertFilesFrontThisLocation.Size = new Size(1244, 824);
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
            grouper_ConvertFilesFrontThisLocation.GroupImage = null;
            grouper_ConvertFilesFrontThisLocation.GroupTitle = "Scan these folther for...";
            grouper_ConvertFilesFrontThisLocation.Location = new Point(0, 173);
            grouper_ConvertFilesFrontThisLocation.Margin = new Padding(1, 6, 1, 6);
            grouper_ConvertFilesFrontThisLocation.MinimumSize = new Size(800, 363);
            grouper_ConvertFilesFrontThisLocation.Name = "grouper_ConvertFilesFrontThisLocation";
            grouper_ConvertFilesFrontThisLocation.Padding = new Padding(9, 31, 9, 7);
            grouper_ConvertFilesFrontThisLocation.PaintGroupBox = false;
            grouper_ConvertFilesFrontThisLocation.RoundCorners = 10;
            grouper_ConvertFilesFrontThisLocation.ShadowColor = Color.DarkGray;
            grouper_ConvertFilesFrontThisLocation.ShadowControl = false;
            grouper_ConvertFilesFrontThisLocation.ShadowThickness = 3;
            grouper_ConvertFilesFrontThisLocation.Size = new Size(1244, 532);
            grouper_ConvertFilesFrontThisLocation.TabIndex = 31;
            // 
            // scanDocumentsAddressGroup_Default
            // 
            scanDocumentsAddressGroup_Default.AutoSize = true;
            scanDocumentsAddressGroup_Default.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            scanDocumentsAddressGroup_Default.Dock = DockStyle.Top;
            scanDocumentsAddressGroup_Default.Location = new Point(9, 31);
            scanDocumentsAddressGroup_Default.Margin = new Padding(7, 7, 7, 7);
            scanDocumentsAddressGroup_Default.MinimumSize = new Size(800, 318);
            scanDocumentsAddressGroup_Default.Name = "scanDocumentsAddressGroup_Default";
            scanDocumentsAddressGroup_Default.Size = new Size(1226, 494);
            scanDocumentsAddressGroup_Default.TabIndex = 0;
            // 
            // panel_ScanTheseFoltherFor
            // 
            panel_ScanTheseFoltherFor.AutoSize = true;
            panel_ScanTheseFoltherFor.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panel_ScanTheseFoltherFor.BackColor = Color.Transparent;
            panel_ScanTheseFoltherFor.Dock = DockStyle.Top;
            panel_ScanTheseFoltherFor.Location = new Point(0, 158);
            panel_ScanTheseFoltherFor.Margin = new Padding(5, 5, 5, 5);
            panel_ScanTheseFoltherFor.MinimumSize = new Size(533, 15);
            panel_ScanTheseFoltherFor.Name = "panel_ScanTheseFoltherFor";
            panel_ScanTheseFoltherFor.Size = new Size(1244, 15);
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
            grouper_ConvertFilesFrontThisLocationInformation.GroupImage = null;
            grouper_ConvertFilesFrontThisLocationInformation.GroupTitle = "Convert files to PDF format";
            grouper_ConvertFilesFrontThisLocationInformation.Location = new Point(0, 15);
            grouper_ConvertFilesFrontThisLocationInformation.Margin = new Padding(1, 6, 1, 1);
            grouper_ConvertFilesFrontThisLocationInformation.Name = "grouper_ConvertFilesFrontThisLocationInformation";
            grouper_ConvertFilesFrontThisLocationInformation.Padding = new Padding(17, 42, 17, 15);
            grouper_ConvertFilesFrontThisLocationInformation.PaintGroupBox = false;
            grouper_ConvertFilesFrontThisLocationInformation.RoundCorners = 10;
            grouper_ConvertFilesFrontThisLocationInformation.ShadowColor = Color.DarkGray;
            grouper_ConvertFilesFrontThisLocationInformation.ShadowControl = false;
            grouper_ConvertFilesFrontThisLocationInformation.ShadowThickness = 3;
            grouper_ConvertFilesFrontThisLocationInformation.Size = new Size(1244, 143);
            grouper_ConvertFilesFrontThisLocationInformation.TabIndex = 33;
            // 
            // richTextBox7
            // 
            richTextBox7.BackColor = SystemColors.Info;
            richTextBox7.BorderStyle = BorderStyle.None;
            richTextBox7.Dock = DockStyle.Fill;
            richTextBox7.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            richTextBox7.Location = new Point(17, 42);
            richTextBox7.Margin = new Padding(5, 5, 5, 5);
            richTextBox7.Name = "richTextBox7";
            richTextBox7.Size = new Size(1210, 86);
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
            panel_ScanTheseFoltherForInformation.Margin = new Padding(5, 5, 5, 5);
            panel_ScanTheseFoltherForInformation.MinimumSize = new Size(533, 15);
            panel_ScanTheseFoltherForInformation.Name = "panel_ScanTheseFoltherForInformation";
            panel_ScanTheseFoltherForInformation.Size = new Size(1244, 15);
            panel_ScanTheseFoltherForInformation.TabIndex = 34;
            // 
            // tabPage_PeerToPeerManagement
            // 
            tabPage_PeerToPeerManagement.Controls.Add(grouper_P2PsettingUtilityPath);
            tabPage_PeerToPeerManagement.Controls.Add(panel9);
            tabPage_PeerToPeerManagement.Controls.Add(grouper_P2PManagement);
            tabPage_PeerToPeerManagement.Controls.Add(panel8);
            tabPage_PeerToPeerManagement.Location = new Point(4, 4);
            tabPage_PeerToPeerManagement.Margin = new Padding(5, 5, 5, 5);
            tabPage_PeerToPeerManagement.Name = "tabPage_PeerToPeerManagement";
            tabPage_PeerToPeerManagement.Size = new Size(1244, 824);
            tabPage_PeerToPeerManagement.TabIndex = 11;
            tabPage_PeerToPeerManagement.Text = "   Peer To Peer Management";
            tabPage_PeerToPeerManagement.UseVisualStyleBackColor = true;
            // 
            // grouper_P2PsettingUtilityPath
            // 
            grouper_P2PsettingUtilityPath.BackgroundColor = SystemColors.Control;
            grouper_P2PsettingUtilityPath.BackgroundGradientColor = Color.White;
            grouper_P2PsettingUtilityPath.BackgroundGradientMode = CodeVendor.Controls.Grouper.GroupBoxGradientMode.None;
            grouper_P2PsettingUtilityPath.BorderColor = Color.Black;
            grouper_P2PsettingUtilityPath.BorderThickness = 1F;
            grouper_P2PsettingUtilityPath.Controls.Add(label_NgrokPath);
            grouper_P2PsettingUtilityPath.Controls.Add(checkBox_IsSuperPeer);
            grouper_P2PsettingUtilityPath.Controls.Add(button_BrowserNgrokUtilityPath);
            grouper_P2PsettingUtilityPath.Controls.Add(textBox_NgrokUtilityPath);
            grouper_P2PsettingUtilityPath.CustomGroupBoxColor = Color.White;
            grouper_P2PsettingUtilityPath.Dock = DockStyle.Top;
            grouper_P2PsettingUtilityPath.GroupImage = null;
            grouper_P2PsettingUtilityPath.GroupTitle = "Department Name.";
            grouper_P2PsettingUtilityPath.Location = new Point(0, 205);
            grouper_P2PsettingUtilityPath.Margin = new Padding(1);
            grouper_P2PsettingUtilityPath.Name = "grouper_P2PsettingUtilityPath";
            grouper_P2PsettingUtilityPath.Padding = new Padding(36, 37, 36, 31);
            grouper_P2PsettingUtilityPath.PaintGroupBox = false;
            grouper_P2PsettingUtilityPath.RoundCorners = 10;
            grouper_P2PsettingUtilityPath.ShadowColor = Color.DarkGray;
            grouper_P2PsettingUtilityPath.ShadowControl = false;
            grouper_P2PsettingUtilityPath.ShadowThickness = 3;
            grouper_P2PsettingUtilityPath.Size = new Size(1244, 149);
            grouper_P2PsettingUtilityPath.TabIndex = 36;
            // 
            // label_NgrokPath
            // 
            label_NgrokPath.AutoSize = true;
            label_NgrokPath.Location = new Point(41, 85);
            label_NgrokPath.Margin = new Padding(5, 0, 5, 0);
            label_NgrokPath.Name = "label_NgrokPath";
            label_NgrokPath.Size = new Size(136, 21);
            label_NgrokPath.TabIndex = 2;
            label_NgrokPath.Text = "Ngrok Utility Path:";
            // 
            // checkBox_IsSuperPeer
            // 
            checkBox_IsSuperPeer.AutoSize = true;
            checkBox_IsSuperPeer.Location = new Point(231, 41);
            checkBox_IsSuperPeer.Margin = new Padding(5, 5, 5, 5);
            checkBox_IsSuperPeer.Name = "checkBox_IsSuperPeer";
            checkBox_IsSuperPeer.Size = new Size(84, 17);
            checkBox_IsSuperPeer.TabIndex = 35;
            checkBox_IsSuperPeer.Text = "IsSuperPeer";
            checkBox_IsSuperPeer.UseVisualStyleBackColor = true;
            checkBox_IsSuperPeer.CheckedChanged += checkBox_IsSuperPeer_CheckedChanged;
            // 
            // button_BrowserNgrokUtilityPath
            // 
            button_BrowserNgrokUtilityPath.Location = new Point(1031, 80);
            button_BrowserNgrokUtilityPath.Margin = new Padding(5, 5, 5, 5);
            button_BrowserNgrokUtilityPath.Name = "button_BrowserNgrokUtilityPath";
            button_BrowserNgrokUtilityPath.Size = new Size(113, 34);
            button_BrowserNgrokUtilityPath.TabIndex = 4;
            button_BrowserNgrokUtilityPath.Text = "Browser...";
            button_BrowserNgrokUtilityPath.UseVisualStyleBackColor = true;
            button_BrowserNgrokUtilityPath.Click += button_BrowserNgrokUtilityPath_Click;
            // 
            // textBox_NgrokUtilityPath
            // 
            textBox_NgrokUtilityPath.Location = new Point(231, 81);
            textBox_NgrokUtilityPath.Margin = new Padding(5, 5, 5, 5);
            textBox_NgrokUtilityPath.Name = "textBox_NgrokUtilityPath";
            textBox_NgrokUtilityPath.Size = new Size(787, 29);
            textBox_NgrokUtilityPath.TabIndex = 3;
            textBox_NgrokUtilityPath.Text = "  Not set to any";
            // 
            // panel9
            // 
            panel9.Dock = DockStyle.Top;
            panel9.Location = new Point(0, 190);
            panel9.Margin = new Padding(0);
            panel9.Name = "panel9";
            panel9.Size = new Size(1244, 15);
            panel9.TabIndex = 38;
            // 
            // grouper_P2PManagement
            // 
            grouper_P2PManagement.BackgroundColor = SystemColors.Info;
            grouper_P2PManagement.BackgroundGradientColor = Color.DarkGray;
            grouper_P2PManagement.BackgroundGradientMode = CodeVendor.Controls.Grouper.GroupBoxGradientMode.None;
            grouper_P2PManagement.BorderColor = Color.Black;
            grouper_P2PManagement.BorderThickness = 1F;
            grouper_P2PManagement.Controls.Add(richTextBox_P2PInfomation);
            grouper_P2PManagement.CustomGroupBoxColor = Color.White;
            grouper_P2PManagement.Dock = DockStyle.Top;
            grouper_P2PManagement.GroupImage = null;
            grouper_P2PManagement.GroupTitle = "Peer to Peer Management";
            grouper_P2PManagement.Location = new Point(0, 15);
            grouper_P2PManagement.Margin = new Padding(1);
            grouper_P2PManagement.Name = "grouper_P2PManagement";
            grouper_P2PManagement.Padding = new Padding(17, 42, 17, 15);
            grouper_P2PManagement.PaintGroupBox = false;
            grouper_P2PManagement.RoundCorners = 10;
            grouper_P2PManagement.ShadowColor = Color.DarkGray;
            grouper_P2PManagement.ShadowControl = false;
            grouper_P2PManagement.ShadowThickness = 3;
            grouper_P2PManagement.Size = new Size(1244, 175);
            grouper_P2PManagement.TabIndex = 34;
            // 
            // richTextBox_P2PInfomation
            // 
            richTextBox_P2PInfomation.BackColor = SystemColors.Info;
            richTextBox_P2PInfomation.BorderStyle = BorderStyle.None;
            richTextBox_P2PInfomation.Dock = DockStyle.Fill;
            richTextBox_P2PInfomation.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            richTextBox_P2PInfomation.Location = new Point(17, 42);
            richTextBox_P2PInfomation.Margin = new Padding(5, 5, 5, 5);
            richTextBox_P2PInfomation.Name = "richTextBox_P2PInfomation";
            richTextBox_P2PInfomation.Size = new Size(1210, 118);
            richTextBox_P2PInfomation.TabIndex = 29;
            richTextBox_P2PInfomation.Text = "";
            // 
            // panel8
            // 
            panel8.Dock = DockStyle.Top;
            panel8.Location = new Point(0, 0);
            panel8.Margin = new Padding(0);
            panel8.Name = "panel8";
            panel8.Size = new Size(1244, 15);
            panel8.TabIndex = 37;
            // 
            // tabControlExtendBase
            // 
            // 
            // 
            // 
            tabControlExtendBase.DisplayStyleProvider.BorderColor = SystemColors.ControlDark;
            tabControlExtendBase.DisplayStyleProvider.BorderColorHot = SystemColors.ControlDark;
            tabControlExtendBase.DisplayStyleProvider.BorderColorSelected = Color.FromArgb(127, 157, 185);
            tabControlExtendBase.DisplayStyleProvider.CloserColor = Color.DarkGray;
            tabControlExtendBase.DisplayStyleProvider.Radius = 2;
            tabControlExtendBase.DisplayStyleProvider.TextColor = SystemColors.ControlText;
            tabControlExtendBase.DisplayStyleProvider.TextColorDisabled = SystemColors.ControlDark;
            tabControlExtendBase.DisplayStyleProvider.TextColorSelected = SystemColors.ControlText;
            tabControlExtendBase.Location = new Point(0, 0);
            tabControlExtendBase.Name = "tabControlExtendBase";
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
            grouper_ButtonSaveCancel.Controls.Add(button_Save);
            grouper_ButtonSaveCancel.Controls.Add(button_Cancel);
            grouper_ButtonSaveCancel.CustomGroupBoxColor = Color.White;
            grouper_ButtonSaveCancel.Dock = DockStyle.Bottom;
            grouper_ButtonSaveCancel.GroupImage = null;
            grouper_ButtonSaveCancel.GroupTitle = "";
            grouper_ButtonSaveCancel.Location = new Point(10, 711);
            grouper_ButtonSaveCancel.Name = "grouper_ButtonSaveCancel";
            grouper_ButtonSaveCancel.Padding = new Padding(20);
            grouper_ButtonSaveCancel.PaintGroupBox = false;
            grouper_ButtonSaveCancel.RoundCorners = 10;
            grouper_ButtonSaveCancel.ShadowColor = Color.DarkGray;
            grouper_ButtonSaveCancel.ShadowControl = false;
            grouper_ButtonSaveCancel.ShadowThickness = 3;
            grouper_ButtonSaveCancel.Size = new Size(1272, 58);
            grouper_ButtonSaveCancel.TabIndex = 7;
            // 
            // button_Save
            // 
            button_Save.Location = new Point(442, 23);
            button_Save.Name = "button_Save";
            button_Save.Size = new Size(75, 23);
            button_Save.TabIndex = 5;
            button_Save.Text = "Save";
            button_Save.UseVisualStyleBackColor = true;
            button_Save.Click += ButtonSaveClick;
            // 
            // button_Cancel
            // 
            button_Cancel.Location = new Point(533, 23);
            button_Cancel.Name = "button_Cancel";
            button_Cancel.Size = new Size(75, 23);
            button_Cancel.TabIndex = 6;
            button_Cancel.Text = "Cancel";
            button_Cancel.UseVisualStyleBackColor = true;
            button_Cancel.Click += ButtonCancelClick;
            // 
            // SolutionsProperties
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1292, 779);
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
            grouper_ArgsToInitializarApp.ResumeLayout(false);
            grouper_ArgsToInitializarApp.PerformLayout();
            grouper_InfoArgsToInitializarApp.ResumeLayout(false);
            grouper7.ResumeLayout(false);
            grouper7.PerformLayout();
            grouper_DepartProperties.ResumeLayout(false);
            grouper_DepartProperties.PerformLayout();
            tabPageNotificationsOptions.ResumeLayout(false);
            grouper2.ResumeLayout(false);
            panel7.ResumeLayout(false);
            grouper4.ResumeLayout(false);
            grouper4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)trackBar_Interval).EndInit();
            grouper_Notifycations.ResumeLayout(false);
            grouper_Notifycations.PerformLayout();
            grouper3.ResumeLayout(false);
            grouper3.PerformLayout();
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            tabPageUSB_DeviceUtility.ResumeLayout(false);
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)PicturesBox_Image).EndInit();
            grouper_AddNewPrintHelpsButtons.ResumeLayout(false);
            flowLayoutPanel_AddNewPrintHelpsButton.ResumeLayout(false);
            tabPageSave_Options.ResumeLayout(false);
            grouper6.ResumeLayout(false);
            grouper6.PerformLayout();
            grouper5.ResumeLayout(false);
            grouper5.PerformLayout();
            tabPage_InstallationLog.ResumeLayout(false);
            tabPage_SecurityLockFolder.ResumeLayout(false);
            grouper_SecurityLockFolder.ResumeLayout(false);
            panel2.ResumeLayout(false);
            flowLayoutPanel1.ResumeLayout(false);
            grouper_SecurityLockFolderButtons.ResumeLayout(false);
            grouper_Properties.ResumeLayout(false);
            grouper_Properties.PerformLayout();
            tabPage_RegisterDLL.ResumeLayout(false);
            grouper9.ResumeLayout(false);
            grouper9.PerformLayout();
            tabPage_SystemCompatibility.ResumeLayout(false);
            grouper10.ResumeLayout(false);
            grouper10.PerformLayout();
            tabPage_Documentation.ResumeLayout(false);
            tabPage_Documentation.PerformLayout();
            grouper_DocumentationBehavior.ResumeLayout(false);
            grouper_NoDocumentsToShow.ResumeLayout(false);
            panel_NoDocumentsToShow.ResumeLayout(false);
            panel_NoDocumentsToShow.PerformLayout();
            grouper_Last2Versions.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            grouper_AllVersionsFound.ResumeLayout(false);
            panel_AllVersionsFound.ResumeLayout(false);
            panel_AllVersionsFound.PerformLayout();
            grouper_LastRevision.ResumeLayout(false);
            panel_LastRevision.ResumeLayout(false);
            panel_LastRevision.PerformLayout();
            grouper_SpecifiedDocument.ResumeLayout(false);
            panel_SpecifiedDocument.ResumeLayout(false);
            panel_SpecifiedDocument.PerformLayout();
            grouper_BrowserVersion.ResumeLayout(false);
            grouper_BrowserVersion.PerformLayout();
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
            tabPage_PeerToPeerManagement.ResumeLayout(false);
            grouper_P2PsettingUtilityPath.ResumeLayout(false);
            grouper_P2PsettingUtilityPath.PerformLayout();
            grouper_P2PManagement.ResumeLayout(false);
            grouper_ButtonSaveCancel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private CustomTabControl tabControlExtendBase = new CustomTabControl();
        private System.Windows.Forms.Label label_DepartmentName;
        private System.Windows.Forms.TextBox textBox_DataBaseAddress;
        private System.Windows.Forms.Label label_DataBaseAddress;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.Button button_BrowserDataBase;
        private System.Windows.Forms.Button button_Save;
        private System.Windows.Forms.Button button_Cancel;
        private CodeVendor.Controls.Grouper grouper_ButtonSaveCancel;
        private CodeVendor.Controls.Grouper grouper2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBox_ShowWarningsNotifications;
        private System.Windows.Forms.CheckBox checkBox_ShowMyOwnNotifications;
        private System.Windows.Forms.CheckBox checkBox_EnableSendReceiveNotifycations;
        private CodeVendor.Controls.Grouper grouper_Notifycations;
        private System.Windows.Forms.CheckBox checkBox_SendMyOwnNotifications;
        private System.Windows.Forms.SplitContainer splitContainerSetting;
        private System.Windows.Forms.CustomTabControl customTabControlSetting;
        private System.Windows.Forms.TabPage tabPageApplicationSetting;
        private System.Windows.Forms.TabPage tabPageNotificationsOptions;
        private System.Windows.Forms.TreeView treeViewApplicationsSetting;
        private System.Windows.Forms.TextBox textBoxApplicationHTMLtemples;
        private System.Windows.Forms.Button button_ApplicationHTMLtemples;
        private System.Windows.Forms.Label labelApplicationHTMLtemples;
        private System.Windows.Forms.TabPage tabPageUSB_DeviceUtility;
        private System.Windows.Forms.ImageList imageListDrag;
        private System.Windows.Forms.ContextMenuStrip _contextMenuStrip;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_Deleted_USB;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_ClearDevices;
        private System.Windows.Forms.PictureBox PicturesBox_Image;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel1;
        private CodeVendor.Controls.Grouper grouper3;
        private System.Windows.Forms.CheckBox checkBox_ShowEmailsNotifications;
        private System.Windows.Forms.CheckBox checkBox_ShowDataBaseUpdateNotifications;
        private System.Windows.Forms.TabPage tabPageSave_Options;
        private CodeVendor.Controls.Grouper grouper6;
        private System.Windows.Forms.CheckBox checkBoxSaveTheInformationByTime;
        private CodeVendor.Controls.Grouper grouper5;
        private System.Windows.Forms.CheckBox checkBoxSaveEachTimeTheInformationIsChanged;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.RadioButton radioButtonEvery30minutes;
        private System.Windows.Forms.RadioButton radioButtonEvery15minutes;
        private System.Windows.Forms.RadioButton radioButtonEvery5minutes;
        private System.Windows.Forms.RichTextBox richTextBox3;
        private System.Windows.Forms.CheckBox checkBoxSaveTheInformationWhenTheUserSaves;
        private CodeVendor.Controls.Grouper grouper_AddNewPrintHelpsButtons;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel_AddNewPrintHelpsButton;
        private System.Windows.Forms.Button button_AddNew;
        private System.Windows.Forms.Button button_Adjustment;
        private System.Windows.Forms.Button button_RemoveScanner;
        private System.Windows.Forms.Button button_PrintHelps;
        private System.Windows.Forms.TabPage tabPage_InstallationLog;
        private System.Windows.Forms.RichTextBox richTextBox_FirstInstalation;
        private System.Windows.Forms.TabPage tabPage_SecurityLockFolder;
        private CodeVendor.Controls.Grouper grouper_SecurityLockFolder;
        private CodeVendor.Controls.Grouper grouper_Properties;
        private System.Windows.Forms.CheckBox checkBox_ReadOnly;
        private System.Windows.Forms.CheckBox checkBox_System;
        private System.Windows.Forms.CheckBox checkBox_Hidden;
        private CodeVendor.Controls.Grouper grouper_SecurityLockFolderButtons;
        private System.Windows.Forms.Button button_Lock;
        private System.Windows.Forms.Button button_Delete;
        private System.Windows.Forms.Button button_UnLock;
        private System.Windows.Forms.ComboBox comboBox_SecurityLockFolder;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button button_Browser;
        private System.Windows.Forms.CheckBox checkBox_SetIntervalReadNotifications;
        private CodeVendor.Controls.Grouper grouper4;
        private System.Windows.Forms.Label label_IntervalSetTo;
        private System.Windows.Forms.TrackBar trackBar_Interval;
        private System.Windows.Forms.RadioButton radioButton_Hours;
        private System.Windows.Forms.RadioButton radioButton_Minutes;
        private System.Windows.Forms.RadioButton radioButton_secund;
        private CodeVendor.Controls.Grouper grouper_ArgsToInitializarApp;
        private CodeVendor.Controls.Grouper grouper7;
        private CodeVendor.Controls.Grouper grouper_DepartProperties;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.TabPage tabPage_RegisterDLL;
        private CodeVendor.Controls.Grouper grouper9;
        private System.Windows.Forms.TextBox textBox_BrowsedDLL;
        private System.Windows.Forms.Button button_BrowserDLL;
        private System.Windows.Forms.Button button_UnregisterDLL;
        private System.Windows.Forms.Button button_RegisterDLL;
        private System.Windows.Forms.TabPage tabPage_SystemCompatibility;
        private CodeVendor.Controls.Grouper grouper10;
        private System.Windows.Forms.CheckBox checkBox_SupportDoubleBuffering;
        private System.Windows.Forms.Label label_SupportDoubleBuffering;
        private System.Windows.Forms.ComboBox comboBox_ApplicationDepartmentName;
        private System.Windows.Forms.TabPage tabPage_Documentation;
        private CodeVendor.Controls.Grouper grouper_DocumentationBehavior;
        private CodeVendor.Controls.Grouper grouper_SpecifiedDocument;
        private System.Windows.Forms.Panel panel_SpecifiedDocument;
        private System.Windows.Forms.RadioButton radioButton_SpecifiedDocument;
        private System.Windows.Forms.RichTextBox richTextBox_SpecifiedDocument;
        private CodeVendor.Controls.Grouper grouper_LastRevision;
        private System.Windows.Forms.Panel panel_LastRevision;
        private System.Windows.Forms.RadioButton radioButton_LastRevision;
        private System.Windows.Forms.RichTextBox richTextBox_LastRevision;
        private CodeVendor.Controls.Grouper grouper_AllVersionsFound;
        private System.Windows.Forms.Panel panel_AllVersionsFound;
        private System.Windows.Forms.RadioButton radioButton_AllVersionsFound;
        private System.Windows.Forms.RichTextBox richTextBox_AllVersionsFound;
        private CodeVendor.Controls.Grouper grouper_Last2Versions;
        private System.Windows.Forms.RichTextBox richTextBox4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.RadioButton radioButton_Last2Versions;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label_Versions;
        private CodeVendor.Controls.Grouper grouper_BrowserVersion;
        private CodeVendor.Controls.Grouper grouper_DefinedAddressDocumentation;
        private MyStuff11net.DocumentsAddressGroup documentsAddressGroup_SearchForPDFfileWithin;
        private System.Windows.Forms.TabPage tabPage_SearchForPDFFileWithin;
        private System.Windows.Forms.Panel panel_Space2;
        private CodeVendor.Controls.Grouper grouper_SearchForPDFfileWithin;
        private System.Windows.Forms.RichTextBox richTextBox_SearchForPDFfileWithin;
        private System.Windows.Forms.Panel panel_Space_SearchForPDFfileWithin;
        private System.Windows.Forms.TabPage tabPage_ConvertFilesFrontThisLocation;
        private CodeVendor.Controls.Grouper grouper_ConvertFilesFrontThisLocation;
        private System.Windows.Forms.Panel panel_ScanTheseFoltherFor;
        private CodeVendor.Controls.Grouper grouper_ConvertFilesFrontThisLocationInformation;
        private System.Windows.Forms.RichTextBox richTextBox7;
        private System.Windows.Forms.Panel panel_ScanTheseFoltherForInformation;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel6;
        private CodeVendor.Controls.Grouper grouper_InfoArgsToInitializarApp;
        private System.Windows.Forms.RichTextBox richTextBox_InfoArgsToInitializarApp;
        private System.Windows.Forms.CheckBox checkBox_CheckInternetAccess;
        private System.Windows.Forms.CheckBox CheckBox_CreateStartupFolderShortcut;
        private System.Windows.Forms.CheckBox CheckBox_ShowDesktopShortcut;
        private System.Windows.Forms.Label label_DescriptionInfo;
        private System.Windows.Forms.Label label_Description;
        private System.Windows.Forms.Label label_CompanyInfo;
        private System.Windows.Forms.Label label_company;
        private System.Windows.Forms.TabPage tabPage_PeerToPeerManagement;
        private CodeVendor.Controls.Grouper grouper_P2PManagement;
        private System.Windows.Forms.RichTextBox richTextBox_P2PInfomation;
        private System.Windows.Forms.CheckBox checkBox_IsSuperPeer;
        private CodeVendor.Controls.Grouper grouper_P2PsettingUtilityPath;
        private System.Windows.Forms.Label label_NgrokPath;
        private System.Windows.Forms.Button button_BrowserNgrokUtilityPath;
        private System.Windows.Forms.TextBox textBox_NgrokUtilityPath;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Panel panel8;
        private CodeVendor.Controls.Grouper grouper_NoDocumentsToShow;
        private RichTextBox richTextBox_NoDocumentsToShow;
        private Panel panel_NoDocumentsToShow;
        private RadioButton radioButton_NoDocumentsToShow;
        private CheckBox checkBox_PdfViewer;
        private RichTextBox richTextBox5;
        private ImageList imageListTreeView;
    }
}