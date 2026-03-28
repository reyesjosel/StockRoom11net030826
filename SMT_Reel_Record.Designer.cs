using MyStuff11net;

namespace StockRoom11net
{
    partial class SMT_Reel_Record : BaseTemple
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
            this.components = new System.ComponentModel.Container();
            this.dataGridViewExtended_ReelRecord = new MyStuff11net.DataGridViewExtend.DataGridViewExtended();
            this._bindingSource_ReelRecord = new System.Windows.Forms.BindingSource(this.components);
         //   this.reelRecord_DataSet = new StockRoom11net.ReelRecord_DataSet();
            this.splitContainer_CompReelChange = new System.Windows.Forms.SplitContainer();
            this.progressBar_Test = new System.Windows.Forms.ProgressBar();
            this.textBox_ProgressBarData = new System.Windows.Forms.TextBox();
            this.tabControl_CompReelChange = new System.Windows.Forms.CustomTabControl();
            this.tabPage_IsNewProject = new System.Windows.Forms.TabPage();
            this.tabPage_CompReelChangeProcess = new System.Windows.Forms.TabPage();
            this.groupBox_CompSrNr = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label_CompSrNr = new System.Windows.Forms.Label();
            this.groupBox_feederSrNr = new System.Windows.Forms.GroupBox();
            this.label_FeederSrNr_Value = new System.Windows.Forms.Label();
            this.label_FeederSrNr = new System.Windows.Forms.Label();
            this.button_CompReelChange_Done = new System.Windows.Forms.Button();
            this.groupBox_Employee_ID = new System.Windows.Forms.GroupBox();
            this.label_EmployeeID_Value = new System.Windows.Forms.Label();
            this.label_NewRecord_Start_Panel = new System.Windows.Forms.Label();
            this.groupBox_NewRecord_ProjectName = new System.Windows.Forms.GroupBox();
            this.label_CompReelChangeProcess_Message = new System.Windows.Forms.Label();
            this.roundButton_CompReelChange_Cancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceTreeViewBase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._bindingSource_ReelRecord)).BeginInit();
      //      ((System.ComponentModel.ISupportInitialize)(this.reelRecord_DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_CompReelChange)).BeginInit();
            this.splitContainer_CompReelChange.Panel1.SuspendLayout();
            this.splitContainer_CompReelChange.Panel2.SuspendLayout();
            this.splitContainer_CompReelChange.SuspendLayout();
            this.tabControl_CompReelChange.SuspendLayout();
            this.tabPage_IsNewProject.SuspendLayout();
            this.tabPage_CompReelChangeProcess.SuspendLayout();
            this.groupBox_CompSrNr.SuspendLayout();
            this.groupBox_feederSrNr.SuspendLayout();
            this.groupBox_Employee_ID.SuspendLayout();
            this.groupBox_NewRecord_ProjectName.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewExtended_ReelRecord
            // 
            this.dataGridViewExtended_ReelRecord.BindingCompleted = false;
            this.dataGridViewExtended_ReelRecord.CurrentColumnActive = null;
            this.dataGridViewExtended_ReelRecord.CurrentDataGridViewRowMouseOver = null;
            this.dataGridViewExtended_ReelRecord.CurrentDataRowViewMouseOver = null;
            this.dataGridViewExtended_ReelRecord.CurrentEmployeesLogIn = null;
            this.dataGridViewExtended_ReelRecord.CurrentRowBackgroundColor = System.Drawing.Color.DeepSkyBlue;
            this.dataGridViewExtended_ReelRecord.CurrentRowBorderColor = System.Drawing.Color.DarkBlue;
            this.dataGridViewExtended_ReelRecord.CurrentRowMouseOverStatus = null;
            this.dataGridViewExtended_ReelRecord.CustomEdit = MyCode.EditMode.View;
            this.dataGridViewExtended_ReelRecord.CustomFilter = null;
            this.dataGridViewExtended_ReelRecord.DataGridViewDrawDoubleBuffering = false;
            this.dataGridViewExtended_ReelRecord.DataSource = this._bindingSource_ReelRecord;
            this.dataGridViewExtended_ReelRecord.DividerColor = System.Drawing.Color.Red;
            this.dataGridViewExtended_ReelRecord.DividerHeight = 0;
            this.dataGridViewExtended_ReelRecord.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewExtended_ReelRecord.FirstDisplayedRow = null;
            this.dataGridViewExtended_ReelRecord.IsMouseDrivenEvent = false;
            this.dataGridViewExtended_ReelRecord.Location = new Point(0, 0);
            this.dataGridViewExtended_ReelRecord.Margin = new System.Windows.Forms.Padding(5);
            this.dataGridViewExtended_ReelRecord.Name = "dataGridViewExtended_ReelRecord";
            this.dataGridViewExtended_ReelRecord.NeedSaveData = false;
            this.dataGridViewExtended_ReelRecord.SelectionBorderWidth = 3;
            this.dataGridViewExtended_ReelRecord.SelectionColor = System.Drawing.Color.DeepSkyBlue;
            this.dataGridViewExtended_ReelRecord.Size = new System.Drawing.Size(1440, 605);
            this.dataGridViewExtended_ReelRecord.TabIndex = 1;
            // 
            // _bindingSource_ReelRecord
            // 
            this._bindingSource_ReelRecord.DataMember = "ReelRecord_Table";
        //    this._bindingSource_ReelRecord.DataSource = this.reelRecord_DataSet;
            // 
            // reelRecord_DataSet
            // 
       //     this.reelRecord_DataSet.DataSetName = "ReelRecord_DataSet";
       //     this.reelRecord_DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // splitContainer_CompReelChange
            // 
            this.splitContainer_CompReelChange.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer_CompReelChange.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer_CompReelChange.Location = new Point(0, 0);
            this.splitContainer_CompReelChange.Margin = new System.Windows.Forms.Padding(4);
            this.splitContainer_CompReelChange.Name = "splitContainer_CompReelChange";
            this.splitContainer_CompReelChange.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer_CompReelChange.Panel1
            // 
            this.splitContainer_CompReelChange.Panel1.Controls.Add(this.dataGridViewExtended_ReelRecord);
            // 
            // splitContainer_CompReelChange.Panel2
            // 
            this.splitContainer_CompReelChange.Panel2.Controls.Add(this.tabControl_CompReelChange);
            this.splitContainer_CompReelChange.Panel2MinSize = 0;
            this.splitContainer_CompReelChange.Size = new System.Drawing.Size(1444, 863);
            this.splitContainer_CompReelChange.SplitterDistance = 609;
            this.splitContainer_CompReelChange.SplitterWidth = 5;
            this.splitContainer_CompReelChange.TabIndex = 2;
            // 
            // progressBar_Test
            // 
            this.progressBar_Test.Location = new Point(892, 65);
            this.progressBar_Test.Name = "progressBar_Test";
            this.progressBar_Test.Size = new System.Drawing.Size(339, 23);
            this.progressBar_Test.TabIndex = 3;
            // 
            // textBox_ProgressBarData
            // 
            this.textBox_ProgressBarData.Location = new Point(892, 100);
            this.textBox_ProgressBarData.Name = "textBox_ProgressBarData";
            this.textBox_ProgressBarData.Size = new System.Drawing.Size(100, 22);
            this.textBox_ProgressBarData.TabIndex = 2;
            this.textBox_ProgressBarData.TextChanged += new System.EventHandler(this.textBox_ProgressBarData_TextChanged);
            // 
            // tabControl_CompReelChange
            // 
            this.tabControl_CompReelChange.Controls.Add(this.tabPage_IsNewProject);
            this.tabControl_CompReelChange.Controls.Add(this.tabPage_CompReelChangeProcess);
            this.tabControl_CompReelChange.Cursor = System.Windows.Forms.Cursors.Default;
            this.tabControl_CompReelChange.DisplayStyle = System.Windows.Forms.TabStyle.VisualStudio;
            // 
            // 
            // 
            this.tabControl_CompReelChange.DisplayStyleProvider.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.tabControl_CompReelChange.DisplayStyleProvider.BorderColorHot = System.Drawing.SystemColors.ControlDark;
            this.tabControl_CompReelChange.DisplayStyleProvider.BorderColorSelected = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(130)))), ((int)(((byte)(132)))));
            this.tabControl_CompReelChange.DisplayStyleProvider.CloserColor = System.Drawing.Color.DarkGray;
            this.tabControl_CompReelChange.DisplayStyleProvider.FocusTrack = false;
            this.tabControl_CompReelChange.DisplayStyleProvider.HotTrack = true;
            this.tabControl_CompReelChange.DisplayStyleProvider.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tabControl_CompReelChange.DisplayStyleProvider.Opacity = 1F;
            this.tabControl_CompReelChange.DisplayStyleProvider.Overlap = 7;
            this.tabControl_CompReelChange.DisplayStyleProvider.Padding = new Point(14, 1);
            this.tabControl_CompReelChange.DisplayStyleProvider.ShowTabCloser = false;
            this.tabControl_CompReelChange.DisplayStyleProvider.TextColor = System.Drawing.SystemColors.ControlText;
            this.tabControl_CompReelChange.DisplayStyleProvider.TextColorDisabled = System.Drawing.SystemColors.ControlDark;
            this.tabControl_CompReelChange.DisplayStyleProvider.TextColorSelected = System.Drawing.SystemColors.ControlText;
            this.tabControl_CompReelChange.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl_CompReelChange.HotTrack = true;
            this.tabControl_CompReelChange.Location = new Point(0, 0);
            this.tabControl_CompReelChange.Margin = new System.Windows.Forms.Padding(0);
            this.tabControl_CompReelChange.Name = "tabControl_CompReelChange";
            this.tabControl_CompReelChange.SelectedIndex = 0;
            this.tabControl_CompReelChange.Size = new System.Drawing.Size(1440, 245);
            this.tabControl_CompReelChange.TabIndex = 9;
            // 
            // tabPage_IsNewProject
            // 
            this.tabPage_IsNewProject.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage_IsNewProject.Controls.Add(this.progressBar_Test);
            this.tabPage_IsNewProject.Controls.Add(this.textBox_ProgressBarData);
            this.tabPage_IsNewProject.Location = new Point(4, 24);
            this.tabPage_IsNewProject.Margin = new System.Windows.Forms.Padding(0);
            this.tabPage_IsNewProject.Name = "tabPage_IsNewProject";
            this.tabPage_IsNewProject.Size = new System.Drawing.Size(1432, 217);
            this.tabPage_IsNewProject.TabIndex = 0;
            this.tabPage_IsNewProject.Text = "New Project";
            // 
            // tabPage_CompReelChangeProcess
            // 
            this.tabPage_CompReelChangeProcess.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage_CompReelChangeProcess.Controls.Add(this.groupBox_CompSrNr);
            this.tabPage_CompReelChangeProcess.Controls.Add(this.groupBox_feederSrNr);
            this.tabPage_CompReelChangeProcess.Controls.Add(this.button_CompReelChange_Done);
            this.tabPage_CompReelChangeProcess.Controls.Add(this.groupBox_Employee_ID);
            this.tabPage_CompReelChangeProcess.Controls.Add(this.groupBox_NewRecord_ProjectName);
            this.tabPage_CompReelChangeProcess.Controls.Add(this.roundButton_CompReelChange_Cancel);
            this.tabPage_CompReelChangeProcess.Location = new Point(4, 24);
            this.tabPage_CompReelChangeProcess.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage_CompReelChangeProcess.Name = "tabPage_CompReelChangeProcess";
            this.tabPage_CompReelChangeProcess.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage_CompReelChangeProcess.Size = new System.Drawing.Size(1432, 217);
            this.tabPage_CompReelChangeProcess.TabIndex = 1;
            this.tabPage_CompReelChangeProcess.Text = "Component Reel Change Process";
            // 
            // groupBox_CompSrNr
            // 
            this.groupBox_CompSrNr.BackColor = System.Drawing.Color.Transparent;
            this.groupBox_CompSrNr.Controls.Add(this.label1);
            this.groupBox_CompSrNr.Controls.Add(this.label_CompSrNr);
            this.groupBox_CompSrNr.Location = new Point(607, 90);
            this.groupBox_CompSrNr.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox_CompSrNr.Name = "groupBox_CompSrNr";
            this.groupBox_CompSrNr.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox_CompSrNr.Size = new System.Drawing.Size(335, 78);
            this.groupBox_CompSrNr.TabIndex = 32;
            this.groupBox_CompSrNr.TabStop = false;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new Point(4, 46);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(327, 28);
            this.label1.TabIndex = 7;
            this.label1.Text = "Component Serial Number";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_CompSrNr
            // 
            this.label_CompSrNr.Dock = System.Windows.Forms.DockStyle.Top;
            this.label_CompSrNr.Location = new Point(4, 19);
            this.label_CompSrNr.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_CompSrNr.Name = "label_CompSrNr";
            this.label_CompSrNr.Size = new System.Drawing.Size(327, 16);
            this.label_CompSrNr.TabIndex = 5;
            this.label_CompSrNr.Text = "Component Serial Number";
            this.label_CompSrNr.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox_feederSrNr
            // 
            this.groupBox_feederSrNr.BackColor = System.Drawing.Color.Transparent;
            this.groupBox_feederSrNr.Controls.Add(this.label_FeederSrNr_Value);
            this.groupBox_feederSrNr.Controls.Add(this.label_FeederSrNr);
            this.groupBox_feederSrNr.Location = new Point(264, 90);
            this.groupBox_feederSrNr.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox_feederSrNr.Name = "groupBox_feederSrNr";
            this.groupBox_feederSrNr.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox_feederSrNr.Size = new System.Drawing.Size(335, 78);
            this.groupBox_feederSrNr.TabIndex = 31;
            this.groupBox_feederSrNr.TabStop = false;
            // 
            // label_FeederSrNr_Value
            // 
            this.label_FeederSrNr_Value.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label_FeederSrNr_Value.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_FeederSrNr_Value.Location = new Point(4, 46);
            this.label_FeederSrNr_Value.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_FeederSrNr_Value.Name = "label_FeederSrNr_Value";
            this.label_FeederSrNr_Value.Size = new System.Drawing.Size(327, 28);
            this.label_FeederSrNr_Value.TabIndex = 7;
            this.label_FeederSrNr_Value.Text = "Feeder Serial Number";
            this.label_FeederSrNr_Value.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_FeederSrNr
            // 
            this.label_FeederSrNr.Dock = System.Windows.Forms.DockStyle.Top;
            this.label_FeederSrNr.Location = new Point(4, 19);
            this.label_FeederSrNr.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_FeederSrNr.Name = "label_FeederSrNr";
            this.label_FeederSrNr.Size = new System.Drawing.Size(327, 16);
            this.label_FeederSrNr.TabIndex = 5;
            this.label_FeederSrNr.Text = "Feeder Serial Number";
            this.label_FeederSrNr.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button_CompReelChange_Done
            // 
            this.button_CompReelChange_Done.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button_CompReelChange_Done.Enabled = false;
            this.button_CompReelChange_Done.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_CompReelChange_Done.Location = new Point(1652, 121);
            this.button_CompReelChange_Done.Margin = new System.Windows.Forms.Padding(4);
            this.button_CompReelChange_Done.Name = "button_CompReelChange_Done";
            this.button_CompReelChange_Done.Size = new System.Drawing.Size(139, 74);
            this.button_CompReelChange_Done.TabIndex = 29;
            this.button_CompReelChange_Done.Text = "Done";
            this.button_CompReelChange_Done.UseVisualStyleBackColor = true;
            // 
            // groupBox_Employee_ID
            // 
            this.groupBox_Employee_ID.BackColor = System.Drawing.Color.Transparent;
            this.groupBox_Employee_ID.Controls.Add(this.label_EmployeeID_Value);
            this.groupBox_Employee_ID.Controls.Add(this.label_NewRecord_Start_Panel);
            this.groupBox_Employee_ID.Location = new Point(8, 90);
            this.groupBox_Employee_ID.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox_Employee_ID.Name = "groupBox_Employee_ID";
            this.groupBox_Employee_ID.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox_Employee_ID.Size = new System.Drawing.Size(248, 78);
            this.groupBox_Employee_ID.TabIndex = 27;
            this.groupBox_Employee_ID.TabStop = false;
            // 
            // label_EmployeeID_Value
            // 
            this.label_EmployeeID_Value.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label_EmployeeID_Value.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_EmployeeID_Value.Location = new Point(4, 46);
            this.label_EmployeeID_Value.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_EmployeeID_Value.Name = "label_EmployeeID_Value";
            this.label_EmployeeID_Value.Size = new System.Drawing.Size(240, 28);
            this.label_EmployeeID_Value.TabIndex = 7;
            this.label_EmployeeID_Value.Text = "Employee ID";
            this.label_EmployeeID_Value.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_NewRecord_Start_Panel
            // 
            this.label_NewRecord_Start_Panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.label_NewRecord_Start_Panel.Location = new Point(4, 19);
            this.label_NewRecord_Start_Panel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_NewRecord_Start_Panel.Name = "label_NewRecord_Start_Panel";
            this.label_NewRecord_Start_Panel.Size = new System.Drawing.Size(240, 16);
            this.label_NewRecord_Start_Panel.TabIndex = 5;
            this.label_NewRecord_Start_Panel.Text = "Employee ID";
            this.label_NewRecord_Start_Panel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox_NewRecord_ProjectName
            // 
            this.groupBox_NewRecord_ProjectName.BackColor = System.Drawing.Color.Transparent;
            this.groupBox_NewRecord_ProjectName.Controls.Add(this.label_CompReelChangeProcess_Message);
            this.groupBox_NewRecord_ProjectName.Location = new Point(8, 1);
            this.groupBox_NewRecord_ProjectName.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox_NewRecord_ProjectName.Name = "groupBox_NewRecord_ProjectName";
            this.groupBox_NewRecord_ProjectName.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox_NewRecord_ProjectName.Size = new System.Drawing.Size(1583, 81);
            this.groupBox_NewRecord_ProjectName.TabIndex = 26;
            this.groupBox_NewRecord_ProjectName.TabStop = false;
            // 
            // label_CompReelChangeProcess_Message
            // 
            this.label_CompReelChangeProcess_Message.Dock = System.Windows.Forms.DockStyle.Top;
            this.label_CompReelChangeProcess_Message.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_CompReelChangeProcess_Message.Location = new Point(4, 19);
            this.label_CompReelChangeProcess_Message.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_CompReelChangeProcess_Message.Name = "label_CompReelChangeProcess_Message";
            this.label_CompReelChangeProcess_Message.Size = new System.Drawing.Size(1575, 44);
            this.label_CompReelChangeProcess_Message.TabIndex = 1;
            this.label_CompReelChangeProcess_Message.Text = "Scand the employee ID card, please.";
            this.label_CompReelChangeProcess_Message.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // roundButton_CompReelChange_Cancel
            // 
            this.roundButton_CompReelChange_Cancel.AutoEllipsis = true;
            this.roundButton_CompReelChange_Cancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.roundButton_CompReelChange_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.roundButton_CompReelChange_Cancel.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.roundButton_CompReelChange_Cancel.FlatAppearance.BorderSize = 0;
            this.roundButton_CompReelChange_Cancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Yellow;
            this.roundButton_CompReelChange_Cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.roundButton_CompReelChange_Cancel.Location = new Point(1639, 21);
            this.roundButton_CompReelChange_Cancel.Margin = new System.Windows.Forms.Padding(4);
            this.roundButton_CompReelChange_Cancel.Name = "roundButton_CompReelChange_Cancel";
            this.roundButton_CompReelChange_Cancel.Size = new System.Drawing.Size(167, 74);
            this.roundButton_CompReelChange_Cancel.TabIndex = 30;
            this.roundButton_CompReelChange_Cancel.Text = "Cancel";
            this.roundButton_CompReelChange_Cancel.UseVisualStyleBackColor = false;
            // 
            // SMT_Reel_Record
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1444, 863);
            this.Controls.Add(this.splitContainer_CompReelChange);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "SMT_Reel_Record";
            this.Load += new System.EventHandler(this.SMT_Reel_Record_Load);
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceTreeViewBase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._bindingSource_ReelRecord)).EndInit();
       //     ((System.ComponentModel.ISupportInitialize)(this.reelRecord_DataSet)).EndInit();
            this.splitContainer_CompReelChange.Panel1.ResumeLayout(false);
            this.splitContainer_CompReelChange.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_CompReelChange)).EndInit();
            this.splitContainer_CompReelChange.ResumeLayout(false);
            this.tabControl_CompReelChange.ResumeLayout(false);
            this.tabPage_IsNewProject.ResumeLayout(false);
            this.tabPage_IsNewProject.PerformLayout();
            this.tabPage_CompReelChangeProcess.ResumeLayout(false);
            this.groupBox_CompSrNr.ResumeLayout(false);
            this.groupBox_feederSrNr.ResumeLayout(false);
            this.groupBox_Employee_ID.ResumeLayout(false);
            this.groupBox_NewRecord_ProjectName.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private MyStuff11net.DataGridViewExtend.DataGridViewExtended dataGridViewExtended_ReelRecord;
        private System.Windows.Forms.BindingSource _bindingSource_ReelRecord;
        private System.Windows.Forms.SplitContainer splitContainer_CompReelChange;
        private System.Windows.Forms.CustomTabControl tabControl_CompReelChange;
        private System.Windows.Forms.TabPage tabPage_IsNewProject;
        private System.Windows.Forms.TabPage tabPage_CompReelChangeProcess;
        private System.Windows.Forms.Button button_CompReelChange_Done;
        private System.Windows.Forms.GroupBox groupBox_Employee_ID;
        private System.Windows.Forms.Label label_EmployeeID_Value;
        private System.Windows.Forms.Label label_NewRecord_Start_Panel;
        private System.Windows.Forms.GroupBox groupBox_NewRecord_ProjectName;
        private System.Windows.Forms.Label label_CompReelChangeProcess_Message;
        private System.Windows.Forms.Button roundButton_CompReelChange_Cancel;
        private System.Windows.Forms.GroupBox groupBox_feederSrNr;
        private System.Windows.Forms.Label label_FeederSrNr_Value;
        private System.Windows.Forms.Label label_FeederSrNr;
        private System.Windows.Forms.GroupBox groupBox_CompSrNr;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label_CompSrNr;
        private System.Windows.Forms.ProgressBar progressBar_Test;
        private System.Windows.Forms.TextBox textBox_ProgressBarData;
    }
}