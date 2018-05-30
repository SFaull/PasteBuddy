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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.labelConnectionStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.panelButton = new System.Windows.Forms.GroupBox();
            this.btnErase = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.fpanelButtonID = new System.Windows.Forms.FlowLayoutPanel();
            this.fpanelButtonRelease = new System.Windows.Forms.FlowLayoutPanel();
            this.btnApply = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.fpanelButtonPress = new System.Windows.Forms.FlowLayoutPanel();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.boxConnection.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.panelButton.SuspendLayout();
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
            this.cmbSerialPorts.MouseClick += new System.Windows.Forms.MouseEventHandler(this.cmbSerialPorts_MouseClick);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.labelConnectionStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 670);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(861, 22);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // labelConnectionStatus
            // 
            this.labelConnectionStatus.Name = "labelConnectionStatus";
            this.labelConnectionStatus.Size = new System.Drawing.Size(129, 17);
            this.labelConnectionStatus.Text = "Status: Not Connected ";
            // 
            // panelButton
            // 
            this.panelButton.Controls.Add(this.progressBar);
            this.panelButton.Controls.Add(this.btnErase);
            this.panelButton.Controls.Add(this.label3);
            this.panelButton.Controls.Add(this.label2);
            this.panelButton.Controls.Add(this.label1);
            this.panelButton.Controls.Add(this.fpanelButtonID);
            this.panelButton.Controls.Add(this.fpanelButtonRelease);
            this.panelButton.Controls.Add(this.btnApply);
            this.panelButton.Controls.Add(this.btnRefresh);
            this.panelButton.Controls.Add(this.fpanelButtonPress);
            this.panelButton.Location = new System.Drawing.Point(18, 75);
            this.panelButton.Name = "panelButton";
            this.panelButton.Size = new System.Drawing.Size(831, 592);
            this.panelButton.TabIndex = 5;
            this.panelButton.TabStop = false;
            this.panelButton.Visible = false;
            // 
            // btnErase
            // 
            this.btnErase.Location = new System.Drawing.Point(10, 563);
            this.btnErase.Name = "btnErase";
            this.btnErase.Size = new System.Drawing.Size(75, 23);
            this.btnErase.TabIndex = 17;
            this.btnErase.Text = "Erase";
            this.btnErase.UseVisualStyleBackColor = true;
            this.btnErase.Click += new System.EventHandler(this.btnErase_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(599, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Button Release";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(247, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Button Press";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(20, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Button ID";
            // 
            // fpanelButtonID
            // 
            this.fpanelButtonID.Location = new System.Drawing.Point(10, 43);
            this.fpanelButtonID.Name = "fpanelButtonID";
            this.fpanelButtonID.Size = new System.Drawing.Size(81, 439);
            this.fpanelButtonID.TabIndex = 13;
            // 
            // fpanelButtonRelease
            // 
            this.fpanelButtonRelease.Location = new System.Drawing.Point(462, 43);
            this.fpanelButtonRelease.Name = "fpanelButtonRelease";
            this.fpanelButtonRelease.Size = new System.Drawing.Size(345, 439);
            this.fpanelButtonRelease.TabIndex = 14;
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(732, 563);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(75, 23);
            this.btnApply.TabIndex = 10;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(651, 563);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 11;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // fpanelButtonPress
            // 
            this.fpanelButtonPress.Location = new System.Drawing.Point(105, 43);
            this.fpanelButtonPress.Name = "fpanelButtonPress";
            this.fpanelButtonPress.Size = new System.Drawing.Size(345, 439);
            this.fpanelButtonPress.TabIndex = 12;
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(91, 563);
            this.progressBar.MarqueeAnimationSpeed = 10;
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(554, 23);
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar.TabIndex = 18;
            this.progressBar.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(861, 692);
            this.Controls.Add(this.panelButton);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.boxConnection);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Paste Buddy";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.boxConnection.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panelButton.ResumeLayout(false);
            this.panelButton.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox boxConnection;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.ComboBox cmbSerialPorts;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel labelConnectionStatus;
        private System.Windows.Forms.GroupBox panelButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel fpanelButtonID;
        private System.Windows.Forms.FlowLayoutPanel fpanelButtonRelease;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.FlowLayoutPanel fpanelButtonPress;
        private System.Windows.Forms.Button btnErase;
        private System.Windows.Forms.ProgressBar progressBar;
    }
}

