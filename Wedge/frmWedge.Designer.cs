namespace Wedgies
{
    partial class frmWedge
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmWedge));
            this.cboPort = new System.Windows.Forms.ComboBox();
            this.cboBaudRate = new System.Windows.Forms.ComboBox();
            this.bgwInterceptWorker = new System.ComponentModel.BackgroundWorker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cboHandShake = new System.Windows.Forms.ComboBox();
            this.tabSerialSettings = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.chkBeepOnInput = new System.Windows.Forms.CheckBox();
            this.chkOnOff = new System.Windows.Forms.CheckBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.txtBoxLiveInput = new System.Windows.Forms.TextBox();
            this.tabDataFilter = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnNewLineDelim = new System.Windows.Forms.RadioButton();
            this.btnTabDelim = new System.Windows.Forms.RadioButton();
            this.chkGetYData = new System.Windows.Forms.CheckBox();
            this.chkGetXData = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtBoxPrefixStrip = new System.Windows.Forms.TextBox();
            this.checkBoxIgnorePrefix = new System.Windows.Forms.CheckBox();
            this.tabSerialSettings.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabDataFilter.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // cboPort
            // 
            this.cboPort.FormattingEnabled = true;
            this.cboPort.Location = new System.Drawing.Point(157, 34);
            this.cboPort.Name = "cboPort";
            this.cboPort.Size = new System.Drawing.Size(210, 21);
            this.cboPort.TabIndex = 0;
            // 
            // cboBaudRate
            // 
            this.cboBaudRate.FormattingEnabled = true;
            this.cboBaudRate.Location = new System.Drawing.Point(157, 124);
            this.cboBaudRate.Name = "cboBaudRate";
            this.cboBaudRate.Size = new System.Drawing.Size(210, 21);
            this.cboBaudRate.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(65, 35);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "Port Number";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(76, 126);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Baud Rate";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(72, 79);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "HandShake";
            // 
            // cboHandShake
            // 
            this.cboHandShake.FormattingEnabled = true;
            this.cboHandShake.Location = new System.Drawing.Point(157, 78);
            this.cboHandShake.Name = "cboHandShake";
            this.cboHandShake.Size = new System.Drawing.Size(210, 21);
            this.cboHandShake.TabIndex = 6;
            // 
            // tabSerialSettings
            // 
            this.tabSerialSettings.Controls.Add(this.tabPage1);
            this.tabSerialSettings.Controls.Add(this.tabPage2);
            this.tabSerialSettings.Controls.Add(this.tabDataFilter);
            this.tabSerialSettings.Controls.Add(this.tabPage3);
            this.tabSerialSettings.Location = new System.Drawing.Point(11, -1);
            this.tabSerialSettings.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabSerialSettings.Name = "tabSerialSettings";
            this.tabSerialSettings.SelectedIndex = 0;
            this.tabSerialSettings.Size = new System.Drawing.Size(477, 315);
            this.tabSerialSettings.TabIndex = 7;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.chkBeepOnInput);
            this.tabPage1.Controls.Add(this.cboPort);
            this.tabPage1.Controls.Add(this.chkOnOff);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.cboHandShake);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.cboBaudRate);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPage1.Size = new System.Drawing.Size(469, 289);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Serial Settings";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // chkBeepOnInput
            // 
            this.chkBeepOnInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkBeepOnInput.Location = new System.Drawing.Point(168, 155);
            this.chkBeepOnInput.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.chkBeepOnInput.Name = "chkBeepOnInput";
            this.chkBeepOnInput.Size = new System.Drawing.Size(174, 53);
            this.chkBeepOnInput.TabIndex = 8;
            this.chkBeepOnInput.Text = "Beep On Input";
            this.chkBeepOnInput.UseVisualStyleBackColor = true;
            this.chkBeepOnInput.CheckedChanged += new System.EventHandler(this.chkBeepOnInput_CheckedChanged);
            // 
            // chkOnOff
            // 
            this.chkOnOff.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkOnOff.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkOnOff.Location = new System.Drawing.Point(186, 217);
            this.chkOnOff.Name = "chkOnOff";
            this.chkOnOff.Size = new System.Drawing.Size(161, 47);
            this.chkOnOff.TabIndex = 2;
            this.chkOnOff.Text = "On/Off";
            this.chkOnOff.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkOnOff.UseVisualStyleBackColor = true;
            this.chkOnOff.CheckedChanged += new System.EventHandler(this.chkOnOff_CheckedChanged_1);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.txtBoxLiveInput);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPage2.Size = new System.Drawing.Size(469, 289);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Live Input";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // txtBoxLiveInput
            // 
            this.txtBoxLiveInput.Location = new System.Drawing.Point(0, 0);
            this.txtBoxLiveInput.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtBoxLiveInput.Multiline = true;
            this.txtBoxLiveInput.Name = "txtBoxLiveInput";
            this.txtBoxLiveInput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtBoxLiveInput.Size = new System.Drawing.Size(465, 287);
            this.txtBoxLiveInput.TabIndex = 0;
            // 
            // tabDataFilter
            // 
            this.tabDataFilter.Controls.Add(this.groupBox2);
            this.tabDataFilter.Controls.Add(this.chkGetYData);
            this.tabDataFilter.Controls.Add(this.chkGetXData);
            this.tabDataFilter.Controls.Add(this.groupBox1);
            this.tabDataFilter.Location = new System.Drawing.Point(4, 22);
            this.tabDataFilter.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabDataFilter.Name = "tabDataFilter";
            this.tabDataFilter.Size = new System.Drawing.Size(469, 289);
            this.tabDataFilter.TabIndex = 2;
            this.tabDataFilter.Text = "Data Filtering";
            this.tabDataFilter.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnNewLineDelim);
            this.groupBox2.Controls.Add(this.btnTabDelim);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(123, 151);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(228, 110);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Delimiter";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // btnNewLineDelim
            // 
            this.btnNewLineDelim.AutoSize = true;
            this.btnNewLineDelim.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewLineDelim.Location = new System.Drawing.Point(53, 65);
            this.btnNewLineDelim.Name = "btnNewLineDelim";
            this.btnNewLineDelim.Size = new System.Drawing.Size(92, 24);
            this.btnNewLineDelim.TabIndex = 1;
            this.btnNewLineDelim.TabStop = true;
            this.btnNewLineDelim.Text = "New Line";
            this.btnNewLineDelim.UseVisualStyleBackColor = true;
            // 
            // btnTabDelim
            // 
            this.btnTabDelim.AutoSize = true;
            this.btnTabDelim.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTabDelim.Location = new System.Drawing.Point(53, 23);
            this.btnTabDelim.Name = "btnTabDelim";
            this.btnTabDelim.Size = new System.Drawing.Size(54, 24);
            this.btnTabDelim.TabIndex = 0;
            this.btnTabDelim.TabStop = true;
            this.btnTabDelim.Text = "Tab";
            this.btnTabDelim.UseVisualStyleBackColor = true;
            // 
            // chkGetYData
            // 
            this.chkGetYData.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkGetYData.Location = new System.Drawing.Point(176, 73);
            this.chkGetYData.Name = "chkGetYData";
            this.chkGetYData.Size = new System.Drawing.Size(150, 50);
            this.chkGetYData.TabIndex = 1;
            this.chkGetYData.Text = "Get Y-Data";
            this.chkGetYData.UseVisualStyleBackColor = true;
            // 
            // chkGetXData
            // 
            this.chkGetXData.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkGetXData.Location = new System.Drawing.Point(176, 31);
            this.chkGetXData.Name = "chkGetXData";
            this.chkGetXData.Size = new System.Drawing.Size(150, 49);
            this.chkGetXData.TabIndex = 0;
            this.chkGetXData.Text = "Get X-Data";
            this.chkGetXData.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(123, 17);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(228, 112);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "MircoVu Data Output";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.groupBox3);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.tabPage3.Size = new System.Drawing.Size(469, 289);
            this.tabPage3.TabIndex = 3;
            this.tabPage3.Text = "Prefix ";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.txtBoxPrefixStrip);
            this.groupBox3.Controls.Add(this.checkBoxIgnorePrefix);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(67, 26);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(330, 235);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Prefix Data ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(51, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Prefix";
            // 
            // txtBoxPrefixStrip
            // 
            this.txtBoxPrefixStrip.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxPrefixStrip.Location = new System.Drawing.Point(105, 67);
            this.txtBoxPrefixStrip.Name = "txtBoxPrefixStrip";
            this.txtBoxPrefixStrip.Size = new System.Drawing.Size(170, 20);
            this.txtBoxPrefixStrip.TabIndex = 2;
            // 
            // checkBoxIgnorePrefix
            // 
            this.checkBoxIgnorePrefix.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxIgnorePrefix.Location = new System.Drawing.Point(55, 107);
            this.checkBoxIgnorePrefix.Name = "checkBoxIgnorePrefix";
            this.checkBoxIgnorePrefix.Size = new System.Drawing.Size(150, 49);
            this.checkBoxIgnorePrefix.TabIndex = 1;
            this.checkBoxIgnorePrefix.Text = "Ignore Prefix";
            this.checkBoxIgnorePrefix.UseVisualStyleBackColor = true;
            this.checkBoxIgnorePrefix.CheckedChanged += new System.EventHandler(this.checkBoxIgnorePrefix_CheckedChanged);
            // 
            // frmWedge
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(499, 330);
            this.Controls.Add(this.tabSerialSettings);
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmWedge";
            this.Text = "Wedge";
            this.tabSerialSettings.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabDataFilter.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cboPort;
        private System.Windows.Forms.ComboBox cboBaudRate;
        private System.ComponentModel.BackgroundWorker bgwInterceptWorker;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboHandShake;
        private System.Windows.Forms.TabControl tabSerialSettings;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox txtBoxLiveInput;
        private System.Windows.Forms.CheckBox chkOnOff;
        private System.Windows.Forms.CheckBox chkBeepOnInput;
        private System.Windows.Forms.TabPage tabDataFilter;
        public System.Windows.Forms.CheckBox chkGetYData;
        public System.Windows.Forms.CheckBox chkGetXData;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        public System.Windows.Forms.RadioButton btnTabDelim;
        public System.Windows.Forms.RadioButton btnNewLineDelim;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.GroupBox groupBox3;
        public System.Windows.Forms.CheckBox checkBoxIgnorePrefix;
        protected System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox txtBoxPrefixStrip;
    }
}

