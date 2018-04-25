namespace PasteBuddy
{
    partial class Form1
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
            this.boxConnection = new System.Windows.Forms.GroupBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.cmbSerialPorts = new System.Windows.Forms.ComboBox();
            this.boxButton1 = new System.Windows.Forms.GroupBox();
            this.txtButtonRelease1 = new System.Windows.Forms.TextBox();
            this.txtButtonPress1 = new System.Windows.Forms.TextBox();
            this.btnApply = new System.Windows.Forms.Button();
            this.panelButton = new System.Windows.Forms.Panel();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtButtonRelease3 = new System.Windows.Forms.TextBox();
            this.txtButtonPress3 = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtButtonRelease2 = new System.Windows.Forms.TextBox();
            this.txtButtonPress2 = new System.Windows.Forms.TextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.labelConnectionStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.boxConnection.SuspendLayout();
            this.boxButton1.SuspendLayout();
            this.panelButton.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // boxConnection
            // 
            this.boxConnection.Controls.Add(this.btnConnect);
            this.boxConnection.Controls.Add(this.cmbSerialPorts);
            this.boxConnection.Location = new System.Drawing.Point(18, 12);
            this.boxConnection.Name = "boxConnection";
            this.boxConnection.Size = new System.Drawing.Size(227, 57);
            this.boxConnection.TabIndex = 0;
            this.boxConnection.TabStop = false;
            this.boxConnection.Text = "Connect to Device";
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(134, 19);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 23);
            this.btnConnect.TabIndex = 1;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // cmbSerialPorts
            // 
            this.cmbSerialPorts.FormattingEnabled = true;
            this.cmbSerialPorts.Location = new System.Drawing.Point(6, 19);
            this.cmbSerialPorts.Name = "cmbSerialPorts";
            this.cmbSerialPorts.Size = new System.Drawing.Size(121, 21);
            this.cmbSerialPorts.TabIndex = 0;
            // 
            // boxButton1
            // 
            this.boxButton1.Controls.Add(this.txtButtonRelease1);
            this.boxButton1.Controls.Add(this.txtButtonPress1);
            this.boxButton1.Location = new System.Drawing.Point(6, 3);
            this.boxButton1.Name = "boxButton1";
            this.boxButton1.Size = new System.Drawing.Size(670, 54);
            this.boxButton1.TabIndex = 1;
            this.boxButton1.TabStop = false;
            this.boxButton1.Text = "Button 1";
            // 
            // txtButtonRelease1
            // 
            this.txtButtonRelease1.Location = new System.Drawing.Point(356, 19);
            this.txtButtonRelease1.Name = "txtButtonRelease1";
            this.txtButtonRelease1.Size = new System.Drawing.Size(308, 20);
            this.txtButtonRelease1.TabIndex = 1;
            // 
            // txtButtonPress1
            // 
            this.txtButtonPress1.Location = new System.Drawing.Point(7, 19);
            this.txtButtonPress1.Name = "txtButtonPress1";
            this.txtButtonPress1.Size = new System.Drawing.Size(308, 20);
            this.txtButtonPress1.TabIndex = 0;
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(595, 222);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(75, 23);
            this.btnApply.TabIndex = 2;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // panelButton
            // 
            this.panelButton.Controls.Add(this.btnRefresh);
            this.panelButton.Controls.Add(this.groupBox2);
            this.panelButton.Controls.Add(this.groupBox1);
            this.panelButton.Controls.Add(this.boxButton1);
            this.panelButton.Controls.Add(this.btnApply);
            this.panelButton.Location = new System.Drawing.Point(18, 86);
            this.panelButton.Name = "panelButton";
            this.panelButton.Size = new System.Drawing.Size(679, 248);
            this.panelButton.TabIndex = 3;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(514, 222);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 3;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtButtonRelease3);
            this.groupBox2.Controls.Add(this.txtButtonPress3);
            this.groupBox2.Location = new System.Drawing.Point(6, 123);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(670, 54);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Button 3";
            // 
            // txtButtonRelease3
            // 
            this.txtButtonRelease3.Location = new System.Drawing.Point(356, 19);
            this.txtButtonRelease3.Name = "txtButtonRelease3";
            this.txtButtonRelease3.Size = new System.Drawing.Size(308, 20);
            this.txtButtonRelease3.TabIndex = 1;
            // 
            // txtButtonPress3
            // 
            this.txtButtonPress3.Location = new System.Drawing.Point(7, 19);
            this.txtButtonPress3.Name = "txtButtonPress3";
            this.txtButtonPress3.Size = new System.Drawing.Size(308, 20);
            this.txtButtonPress3.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtButtonRelease2);
            this.groupBox1.Controls.Add(this.txtButtonPress2);
            this.groupBox1.Location = new System.Drawing.Point(6, 63);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(670, 54);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Button 2";
            // 
            // txtButtonRelease2
            // 
            this.txtButtonRelease2.Location = new System.Drawing.Point(356, 19);
            this.txtButtonRelease2.Name = "txtButtonRelease2";
            this.txtButtonRelease2.Size = new System.Drawing.Size(308, 20);
            this.txtButtonRelease2.TabIndex = 1;
            // 
            // txtButtonPress2
            // 
            this.txtButtonPress2.Location = new System.Drawing.Point(7, 19);
            this.txtButtonPress2.Name = "txtButtonPress2";
            this.txtButtonPress2.Size = new System.Drawing.Size(308, 20);
            this.txtButtonPress2.TabIndex = 0;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.labelConnectionStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 448);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(709, 22);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // labelConnectionStatus
            // 
            this.labelConnectionStatus.Name = "labelConnectionStatus";
            this.labelConnectionStatus.Size = new System.Drawing.Size(129, 17);
            this.labelConnectionStatus.Text = "Status: Not Connected ";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(709, 470);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.panelButton);
            this.Controls.Add(this.boxConnection);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Paste Buddy";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.boxConnection.ResumeLayout(false);
            this.boxButton1.ResumeLayout(false);
            this.boxButton1.PerformLayout();
            this.panelButton.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox boxConnection;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.ComboBox cmbSerialPorts;
        private System.Windows.Forms.GroupBox boxButton1;
        private System.Windows.Forms.TextBox txtButtonPress1;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Panel panelButton;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel labelConnectionStatus;
        private System.Windows.Forms.TextBox txtButtonRelease1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtButtonRelease3;
        private System.Windows.Forms.TextBox txtButtonPress3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtButtonRelease2;
        private System.Windows.Forms.TextBox txtButtonPress2;
        private System.Windows.Forms.Button btnRefresh;
    }
}

