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
            this.tabSerialSettings.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // cboPort
            // 
            this.cboPort.FormattingEnabled = true;
            this.cboPort.Location = new System.Drawing.Point(151, 36);
            this.cboPort.Name = "cboPort";
            this.cboPort.Size = new System.Drawing.Size(121, 21);
            this.cboPort.TabIndex = 0;
            // 
            // cboBaudRate
            // 
            this.cboBaudRate.FormattingEnabled = true;
            this.cboBaudRate.Location = new System.Drawing.Point(151, 126);
            this.cboBaudRate.Name = "cboBaudRate";
            this.cboBaudRate.Size = new System.Drawing.Size(121, 21);
            this.cboBaudRate.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(59, 37);
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
            this.label2.Location = new System.Drawing.Point(70, 128);
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
            this.label3.Location = new System.Drawing.Point(66, 81);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "HandShake";
            // 
            // cboHandShake
            // 
            this.cboHandShake.FormattingEnabled = true;
            this.cboHandShake.Location = new System.Drawing.Point(151, 80);
            this.cboHandShake.Name = "cboHandShake";
            this.cboHandShake.Size = new System.Drawing.Size(121, 21);
            this.cboHandShake.TabIndex = 6;
            // 
            // tabSerialSettings
            // 
            this.tabSerialSettings.Controls.Add(this.tabPage1);
            this.tabSerialSettings.Controls.Add(this.tabPage2);
            this.tabSerialSettings.Location = new System.Drawing.Point(0, -1);
            this.tabSerialSettings.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabSerialSettings.Name = "tabSerialSettings";
            this.tabSerialSettings.SelectedIndex = 0;
            this.tabSerialSettings.Size = new System.Drawing.Size(395, 307);
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
            this.tabPage1.Size = new System.Drawing.Size(387, 281);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Serial Settings";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // chkBeepOnInput
            // 
            this.chkBeepOnInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkBeepOnInput.Location = new System.Drawing.Point(141, 153);
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
            this.chkOnOff.Location = new System.Drawing.Point(114, 211);
            this.chkOnOff.Name = "chkOnOff";
            this.chkOnOff.Size = new System.Drawing.Size(161, 47);
            this.chkOnOff.TabIndex = 2;
            this.chkOnOff.Text = "On/Off";
            this.chkOnOff.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkOnOff.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.txtBoxLiveInput);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPage2.Size = new System.Drawing.Size(387, 281);
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
            this.txtBoxLiveInput.Size = new System.Drawing.Size(389, 287);
            this.txtBoxLiveInput.TabIndex = 0;
            // 
            // frmWedge
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(391, 304);
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
    }
}

