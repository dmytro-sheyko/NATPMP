
namespace NATPMP
{
    partial class MainForm
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
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.groupGateway = new System.Windows.Forms.GroupBox();
            this.comboGateway = new System.Windows.Forms.ComboBox();
            this.groupLocalPort = new System.Windows.Forms.GroupBox();
            this.textLocalPort = new System.Windows.Forms.TextBox();
            this.groupExternalPort = new System.Windows.Forms.GroupBox();
            this.textExternalPort = new System.Windows.Forms.TextBox();
            this.groupLifetime = new System.Windows.Forms.GroupBox();
            this.textLifetime = new System.Windows.Forms.TextBox();
            this.buttonStart = new System.Windows.Forms.Button();
            this.buttonStop = new System.Windows.Forms.Button();
            this.groupExternalAddress = new System.Windows.Forms.GroupBox();
            this.groupStatus = new System.Windows.Forms.GroupBox();
            this.textExternalAddress = new System.Windows.Forms.TextBox();
            this.textStatus = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel.SuspendLayout();
            this.groupGateway.SuspendLayout();
            this.groupLocalPort.SuspendLayout();
            this.groupExternalPort.SuspendLayout();
            this.groupLifetime.SuspendLayout();
            this.groupExternalAddress.SuspendLayout();
            this.groupStatus.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 2;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.Controls.Add(this.groupGateway, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.groupLocalPort, 0, 1);
            this.tableLayoutPanel.Controls.Add(this.groupExternalPort, 1, 1);
            this.tableLayoutPanel.Controls.Add(this.groupLifetime, 0, 2);
            this.tableLayoutPanel.Controls.Add(this.buttonStart, 0, 3);
            this.tableLayoutPanel.Controls.Add(this.buttonStop, 1, 3);
            this.tableLayoutPanel.Controls.Add(this.groupExternalAddress, 0, 4);
            this.tableLayoutPanel.Controls.Add(this.groupStatus, 0, 5);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 7;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(289, 323);
            this.tableLayoutPanel.TabIndex = 0;
            // 
            // groupGateway
            // 
            this.tableLayoutPanel.SetColumnSpan(this.groupGateway, 2);
            this.groupGateway.Controls.Add(this.comboGateway);
            this.groupGateway.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupGateway.Location = new System.Drawing.Point(3, 3);
            this.groupGateway.Name = "groupGateway";
            this.groupGateway.Size = new System.Drawing.Size(283, 50);
            this.groupGateway.TabIndex = 7;
            this.groupGateway.TabStop = false;
            this.groupGateway.Text = "Gateway";
            // 
            // comboGateway
            // 
            this.comboGateway.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboGateway.FormattingEnabled = true;
            this.comboGateway.Location = new System.Drawing.Point(3, 16);
            this.comboGateway.Name = "comboGateway";
            this.comboGateway.Size = new System.Drawing.Size(277, 21);
            this.comboGateway.TabIndex = 0;
            // 
            // groupLocalPort
            // 
            this.groupLocalPort.Controls.Add(this.textLocalPort);
            this.groupLocalPort.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupLocalPort.Location = new System.Drawing.Point(3, 59);
            this.groupLocalPort.Name = "groupLocalPort";
            this.groupLocalPort.Size = new System.Drawing.Size(138, 50);
            this.groupLocalPort.TabIndex = 0;
            this.groupLocalPort.TabStop = false;
            this.groupLocalPort.Text = "Local Port";
            // 
            // textLocalPort
            // 
            this.textLocalPort.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textLocalPort.Location = new System.Drawing.Point(3, 16);
            this.textLocalPort.Name = "textLocalPort";
            this.textLocalPort.Size = new System.Drawing.Size(132, 20);
            this.textLocalPort.TabIndex = 0;
            // 
            // groupExternalPort
            // 
            this.groupExternalPort.Controls.Add(this.textExternalPort);
            this.groupExternalPort.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupExternalPort.Location = new System.Drawing.Point(147, 59);
            this.groupExternalPort.Name = "groupExternalPort";
            this.groupExternalPort.Size = new System.Drawing.Size(139, 50);
            this.groupExternalPort.TabIndex = 1;
            this.groupExternalPort.TabStop = false;
            this.groupExternalPort.Text = "Desired External Port";
            // 
            // textExternalPort
            // 
            this.textExternalPort.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textExternalPort.Location = new System.Drawing.Point(3, 16);
            this.textExternalPort.Name = "textExternalPort";
            this.textExternalPort.Size = new System.Drawing.Size(133, 20);
            this.textExternalPort.TabIndex = 0;
            // 
            // groupLifetime
            // 
            this.groupLifetime.Controls.Add(this.textLifetime);
            this.groupLifetime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupLifetime.Location = new System.Drawing.Point(3, 115);
            this.groupLifetime.Name = "groupLifetime";
            this.groupLifetime.Size = new System.Drawing.Size(138, 50);
            this.groupLifetime.TabIndex = 2;
            this.groupLifetime.TabStop = false;
            this.groupLifetime.Text = "Lifetime (in seconds)";
            // 
            // textLifetime
            // 
            this.textLifetime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textLifetime.Location = new System.Drawing.Point(3, 16);
            this.textLifetime.Name = "textLifetime";
            this.textLifetime.Size = new System.Drawing.Size(132, 20);
            this.textLifetime.TabIndex = 0;
            this.textLifetime.Text = "3600";
            // 
            // buttonStart
            // 
            this.buttonStart.Dock = System.Windows.Forms.DockStyle.Left;
            this.buttonStart.Location = new System.Drawing.Point(3, 171);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(75, 23);
            this.buttonStart.TabIndex = 3;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // buttonStop
            // 
            this.buttonStop.Dock = System.Windows.Forms.DockStyle.Left;
            this.buttonStop.Enabled = false;
            this.buttonStop.Location = new System.Drawing.Point(147, 171);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(75, 23);
            this.buttonStop.TabIndex = 4;
            this.buttonStop.Text = "Stop";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // groupExternalAddress
            // 
            this.tableLayoutPanel.SetColumnSpan(this.groupExternalAddress, 2);
            this.groupExternalAddress.Controls.Add(this.textExternalAddress);
            this.groupExternalAddress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupExternalAddress.Location = new System.Drawing.Point(3, 200);
            this.groupExternalAddress.Name = "groupExternalAddress";
            this.groupExternalAddress.Size = new System.Drawing.Size(283, 50);
            this.groupExternalAddress.TabIndex = 5;
            this.groupExternalAddress.TabStop = false;
            this.groupExternalAddress.Text = "External Address";
            // 
            // groupStatus
            // 
            this.tableLayoutPanel.SetColumnSpan(this.groupStatus, 2);
            this.groupStatus.Controls.Add(this.textStatus);
            this.groupStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupStatus.Location = new System.Drawing.Point(3, 256);
            this.groupStatus.Name = "groupStatus";
            this.groupStatus.Size = new System.Drawing.Size(283, 50);
            this.groupStatus.TabIndex = 6;
            this.groupStatus.TabStop = false;
            this.groupStatus.Text = "Status";
            // 
            // textExternalAddress
            // 
            this.textExternalAddress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textExternalAddress.Location = new System.Drawing.Point(3, 16);
            this.textExternalAddress.Name = "textExternalAddress";
            this.textExternalAddress.ReadOnly = true;
            this.textExternalAddress.Size = new System.Drawing.Size(277, 20);
            this.textExternalAddress.TabIndex = 0;
            // 
            // textStatus
            // 
            this.textStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textStatus.Location = new System.Drawing.Point(3, 16);
            this.textStatus.Name = "textStatus";
            this.textStatus.ReadOnly = true;
            this.textStatus.Size = new System.Drawing.Size(277, 20);
            this.textStatus.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AcceptButton = this.buttonStart;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(289, 323);
            this.Controls.Add(this.tableLayoutPanel);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NAT-PMP";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.tableLayoutPanel.ResumeLayout(false);
            this.groupGateway.ResumeLayout(false);
            this.groupLocalPort.ResumeLayout(false);
            this.groupLocalPort.PerformLayout();
            this.groupExternalPort.ResumeLayout(false);
            this.groupExternalPort.PerformLayout();
            this.groupLifetime.ResumeLayout(false);
            this.groupLifetime.PerformLayout();
            this.groupExternalAddress.ResumeLayout(false);
            this.groupExternalAddress.PerformLayout();
            this.groupStatus.ResumeLayout(false);
            this.groupStatus.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.GroupBox groupGateway;
        private System.Windows.Forms.ComboBox comboGateway;
        private System.Windows.Forms.GroupBox groupLocalPort;
        private System.Windows.Forms.TextBox textLocalPort;
        private System.Windows.Forms.GroupBox groupExternalPort;
        private System.Windows.Forms.TextBox textExternalPort;
        private System.Windows.Forms.GroupBox groupLifetime;
        private System.Windows.Forms.TextBox textLifetime;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.GroupBox groupExternalAddress;
        private System.Windows.Forms.GroupBox groupStatus;
        private System.Windows.Forms.TextBox textExternalAddress;
        private System.Windows.Forms.TextBox textStatus;
    }
}

