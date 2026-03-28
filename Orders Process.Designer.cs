using MyStuff11net;

namespace StockRoom11net
{
    partial class Orders_Process
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
            this.dataGridViewExtended_GPS = new MyStuff11net.DataGridViewExtend.DataGridViewExtended();
            this._bindingSource_GPSDataSheet = new System.Windows.Forms.BindingSource(this.components);
       //     this._dataSet_GPSDataSheet = new StockRoom11net.GPS_DataSheetDataSet();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceTreeViewBase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._bindingSource_GPSDataSheet)).BeginInit();
      //      ((System.ComponentModel.ISupportInitialize)(this._dataSet_GPSDataSheet)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewExtended_GPS
            // 
            this.dataGridViewExtended_GPS.BindingCompleted = false;
            this.dataGridViewExtended_GPS.CurrentColumnActive = null;
            this.dataGridViewExtended_GPS.CurrentDataGridViewRowMouseOver = null;
            this.dataGridViewExtended_GPS.CurrentDataRowViewMouseOver = null;
            this.dataGridViewExtended_GPS.CurrentEmployeesLogIn = null;
            this.dataGridViewExtended_GPS.CurrentRowBackgroundColor = System.Drawing.Color.DeepSkyBlue;
            this.dataGridViewExtended_GPS.CurrentRowBorderColor = System.Drawing.Color.DarkBlue;
            this.dataGridViewExtended_GPS.CurrentRowMouseOverStatus = null;
            this.dataGridViewExtended_GPS.CustomEdit = MyCode.EditMode.View;
            this.dataGridViewExtended_GPS.CustomFilter = null;
            this.dataGridViewExtended_GPS.DataGridViewDrawDoubleBuffering = false;
            this.dataGridViewExtended_GPS.DataSource = this._bindingSource_GPSDataSheet;
            this.dataGridViewExtended_GPS.DividerColor = System.Drawing.Color.Red;
            this.dataGridViewExtended_GPS.DividerHeight = 0;
            this.dataGridViewExtended_GPS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewExtended_GPS.FirstDisplayedRow = null;
            this.dataGridViewExtended_GPS.IsMouseDrivenEvent = false;
            this.dataGridViewExtended_GPS.Location = new Point(0, 0);
            this.dataGridViewExtended_GPS.Name = "dataGridViewExtended_GPS";
            this.dataGridViewExtended_GPS.NeedSaveData = false;
            this.dataGridViewExtended_GPS.SelectionBorderWidth = 3;
            this.dataGridViewExtended_GPS.SelectionColor = System.Drawing.Color.DeepSkyBlue;
            this.dataGridViewExtended_GPS.Size = new System.Drawing.Size(1022, 525);
            this.dataGridViewExtended_GPS.TabIndex = 1;
            // 
            // _bindingSource_GPSDataSheet
            // 
            this._bindingSource_GPSDataSheet.DataMember = "GPS_DataSheet";
      //      this._bindingSource_GPSDataSheet.DataSource = this._dataSet_GPSDataSheet;
            // 
            // _dataSet_GPSDataSheet
            // 
      //      this._dataSet_GPSDataSheet.DataSetName = "GPS_DataSheetDataSet";
      //      this._dataSet_GPSDataSheet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // Orders_Process
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1022, 525);
            this.Controls.Add(this.dataGridViewExtended_GPS);
            this.Name = "Orders_Process";
            this.Text = "Microsoft® Visual Studio® 2015 - Microsoft® Visual Studio® 2015 - Microsoft® Visu" +
    "al Studio® 2015 - Orders_Process";
            this.Title = "Microsoft® Visual Studio® 2015 - Microsoft® Visual Studio® 2015 - Microsoft® Visu" +
    "al Studio® 2015 - Orders_Process";
            this.Load += new System.EventHandler(this.Orders_Process_Load);
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceTreeViewBase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._bindingSource_GPSDataSheet)).EndInit();
      //      ((System.ComponentModel.ISupportInitialize)(this._dataSet_GPSDataSheet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MyStuff11net.DataGridViewExtend.DataGridViewExtended dataGridViewExtended_GPS;
      //  private GPS_DataSheetDataSet _dataSet_GPSDataSheet;
        private System.Windows.Forms.BindingSource _bindingSource_GPSDataSheet;
    }
}