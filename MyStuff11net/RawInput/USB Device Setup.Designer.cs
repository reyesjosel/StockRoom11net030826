namespace RawInput_dll
{
    partial class USB_Device_Setup
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
            label_AnewUSBHassArrived = new System.Windows.Forms.Label();
            gbDetails = new System.Windows.Forms.GroupBox();
            labelSource = new System.Windows.Forms.Label();
            label_Source = new System.Windows.Forms.Label();
            label_VID = new System.Windows.Forms.Label();
            label_PID = new System.Windows.Forms.Label();
            labelsVID = new System.Windows.Forms.Label();
            label_DeviceDescription = new System.Windows.Forms.Label();
            label_Name = new System.Windows.Forms.Label();
            labelPID = new System.Windows.Forms.Label();
            textBox_Name = new System.Windows.Forms.TextBox();
            textBox_Description = new System.Windows.Forms.TextBox();
            button_AddDevice = new System.Windows.Forms.Button();
            button_Cancel = new System.Windows.Forms.Button();
            gbDetails.SuspendLayout();
            SuspendLayout();
            // 
            // label_AnewUSBHassArrived
            // 
            label_AnewUSBHassArrived.AutoSize = true;
            label_AnewUSBHassArrived.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label_AnewUSBHassArrived.Location = new System.Drawing.Point(181, 20);
            label_AnewUSBHassArrived.Name = "label_AnewUSBHassArrived";
            label_AnewUSBHassArrived.Size = new System.Drawing.Size(254, 20);
            label_AnewUSBHassArrived.TabIndex = 0;
            label_AnewUSBHassArrived.Text = "A new USB device has arrived.";
            // 
            // gbDetails
            // 
            gbDetails.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            gbDetails.Controls.Add(textBox_Description);
            gbDetails.Controls.Add(textBox_Name);
            gbDetails.Controls.Add(labelSource);
            gbDetails.Controls.Add(label_Source);
            gbDetails.Controls.Add(label_VID);
            gbDetails.Controls.Add(label_PID);
            gbDetails.Controls.Add(labelsVID);
            gbDetails.Controls.Add(label_DeviceDescription);
            gbDetails.Controls.Add(label_Name);
            gbDetails.Controls.Add(labelPID);
            gbDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            gbDetails.Location = new System.Drawing.Point(12, 52);
            gbDetails.Name = "gbDetails";
            gbDetails.Size = new System.Drawing.Size(619, 154);
            gbDetails.TabIndex = 26;
            gbDetails.TabStop = false;
            gbDetails.Text = "Device details";
            // 
            // labelSource
            // 
            labelSource.AutoSize = true;
            labelSource.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            labelSource.Location = new System.Drawing.Point(95, 117);
            labelSource.Name = "labelSource";
            labelSource.Size = new System.Drawing.Size(76, 13);
            labelSource.TabIndex = 24;
            labelSource.Text = "Source here";
            // 
            // label_Source
            // 
            label_Source.AutoSize = true;
            label_Source.Location = new System.Drawing.Point(10, 114);
            label_Source.Name = "label_Source";
            label_Source.Size = new System.Drawing.Size(57, 17);
            label_Source.TabIndex = 23;
            label_Source.Text = "Source:";
            // 
            // label_VID
            // 
            label_VID.AutoSize = true;
            label_VID.Location = new System.Drawing.Point(10, 35);
            label_VID.Name = "label_VID";
            label_VID.Size = new System.Drawing.Size(34, 17);
            label_VID.TabIndex = 0;
            label_VID.Text = "VID:";
            // 
            // label_PID
            // 
            label_PID.AutoSize = true;
            label_PID.Location = new System.Drawing.Point(246, 35);
            label_PID.Name = "label_PID";
            label_PID.Size = new System.Drawing.Size(34, 17);
            label_PID.TabIndex = 1;
            label_PID.Text = "PID:";
            // 
            // labelsVID
            // 
            labelsVID.AutoSize = true;
            labelsVID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            labelsVID.Location = new System.Drawing.Point(95, 39);
            labelsVID.Name = "labelsVID";
            labelsVID.Size = new System.Drawing.Size(57, 13);
            labelsVID.TabIndex = 17;
            labelsVID.Text = "VID here";
            // 
            // label_DeviceDescription
            // 
            label_DeviceDescription.AutoSize = true;
            label_DeviceDescription.Location = new System.Drawing.Point(10, 88);
            label_DeviceDescription.Name = "label_DeviceDescription";
            label_DeviceDescription.Size = new System.Drawing.Size(79, 17);
            label_DeviceDescription.TabIndex = 3;
            label_DeviceDescription.Text = "Description";
            // 
            // label_Name
            // 
            label_Name.AutoSize = true;
            label_Name.Location = new System.Drawing.Point(10, 62);
            label_Name.Name = "label_Name";
            label_Name.Size = new System.Drawing.Size(49, 17);
            label_Name.TabIndex = 2;
            label_Name.Text = "Name:";
            // 
            // labelPID
            // 
            labelPID.AutoSize = true;
            labelPID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            labelPID.Location = new System.Drawing.Point(301, 39);
            labelPID.Name = "labelPID";
            labelPID.Size = new System.Drawing.Size(57, 13);
            labelPID.TabIndex = 16;
            labelPID.Text = "PID here";
            // 
            // textBox_Name
            // 
            textBox_Name.Location = new System.Drawing.Point(98, 61);
            textBox_Name.Name = "textBox_Name";
            textBox_Name.Size = new System.Drawing.Size(139, 23);
            textBox_Name.TabIndex = 27;
            // 
            // textBox_Description
            // 
            textBox_Description.Location = new System.Drawing.Point(98, 87);
            textBox_Description.Name = "textBox_Description";
            textBox_Description.Size = new System.Drawing.Size(312, 23);
            textBox_Description.TabIndex = 28;
            // 
            // button_AddDevice
            // 
            button_AddDevice.Location = new System.Drawing.Point(187, 220);
            button_AddDevice.Name = "button_AddDevice";
            button_AddDevice.Size = new System.Drawing.Size(87, 30);
            button_AddDevice.TabIndex = 27;
            button_AddDevice.Text = "Add Device";
            button_AddDevice.UseVisualStyleBackColor = true;
            button_AddDevice.Click += new System.EventHandler(Button_AddDevice_Click);
            // 
            // button_Cancel
            // 
            button_Cancel.Location = new System.Drawing.Point(302, 220);
            button_Cancel.Name = "button_Cancel";
            button_Cancel.Size = new System.Drawing.Size(87, 30);
            button_Cancel.TabIndex = 28;
            button_Cancel.Text = "Cancel";
            button_Cancel.UseVisualStyleBackColor = true;
            button_Cancel.Click += new System.EventHandler(Button_Cancel_Click);
            // 
            // USB_Device_Setup
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(636, 262);
            Controls.Add(button_Cancel);
            Controls.Add(button_AddDevice);
            Controls.Add(gbDetails);
            Controls.Add(label_AnewUSBHassArrived);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            Name = "USB_Device_Setup";
            Text = "USB Device Setup";
            TopMost = true;
            Shown += new System.EventHandler(USB_Device_Setup_Shown);
            gbDetails.ResumeLayout(false);
            gbDetails.PerformLayout();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_AnewUSBHassArrived;
        private System.Windows.Forms.GroupBox gbDetails;
        private System.Windows.Forms.Label labelSource;
        private System.Windows.Forms.Label label_Source;
        private System.Windows.Forms.Label label_VID;
        private System.Windows.Forms.Label label_PID;
        private System.Windows.Forms.Label labelsVID;
        private System.Windows.Forms.Label label_DeviceDescription;
        private System.Windows.Forms.Label label_Name;
        private System.Windows.Forms.Label labelPID;
        private System.Windows.Forms.TextBox textBox_Description;
        private System.Windows.Forms.TextBox textBox_Name;
        private System.Windows.Forms.Button button_AddDevice;
        private System.Windows.Forms.Button button_Cancel;
    }
}