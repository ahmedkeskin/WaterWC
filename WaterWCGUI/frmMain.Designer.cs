namespace WaterWc.Gui
{
    partial class FrmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.lstWc = new System.Windows.Forms.ListBox();
            this.rightClickMenuWC = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.DeselectRightMenuWC = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.deleteRecordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnWC = new System.Windows.Forms.Button();
            this.btnWater = new System.Windows.Forms.Button();
            this.lstWater = new System.Windows.Forms.ListBox();
            this.rightClickMenuWater = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deselectWaterRecordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.deleteWaterRecordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblWater = new System.Windows.Forms.Label();
            this.lblWC = new System.Windows.Forms.Label();
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deselectListsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.deleteSelectedWaterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteSelectedWCToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.chkSoundEffects = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.clearDatabaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.goToWebsiteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.systemTrayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.systemTrayMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnShowMainForm = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.txtLastWater = new System.Windows.Forms.ToolStripTextBox();
            this.txtLastWC = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.waterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wCToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.btnQuit = new System.Windows.Forms.ToolStripMenuItem();
            this.rightClickMenuWC.SuspendLayout();
            this.rightClickMenuWater.SuspendLayout();
            this.mainMenu.SuspendLayout();
            this.systemTrayMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstWc
            // 
            this.lstWc.ContextMenuStrip = this.rightClickMenuWC;
            this.lstWc.FormattingEnabled = true;
            this.lstWc.Location = new System.Drawing.Point(138, 148);
            this.lstWc.Name = "lstWc";
            this.lstWc.Size = new System.Drawing.Size(120, 342);
            this.lstWc.TabIndex = 3;
            this.lstWc.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lstWc_MouseDown);
            // 
            // rightClickMenuWC
            // 
            this.rightClickMenuWC.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DeselectRightMenuWC,
            this.toolStripSeparator3,
            this.deleteRecordToolStripMenuItem});
            this.rightClickMenuWC.Name = "rightClickMenuWC";
            this.rightClickMenuWC.Size = new System.Drawing.Size(170, 54);
            // 
            // DeselectRightMenuWC
            // 
            this.DeselectRightMenuWC.Name = "DeselectRightMenuWC";
            this.DeselectRightMenuWC.Size = new System.Drawing.Size(169, 22);
            this.DeselectRightMenuWC.Text = "Deselect Record";
            this.DeselectRightMenuWC.Click += new System.EventHandler(this.DeselectRightMenuWC_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(166, 6);
            // 
            // deleteRecordToolStripMenuItem
            // 
            this.deleteRecordToolStripMenuItem.Image = global::WaterWc.Gui.Properties.Resources.rubbishBin;
            this.deleteRecordToolStripMenuItem.Name = "deleteRecordToolStripMenuItem";
            this.deleteRecordToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.deleteRecordToolStripMenuItem.Text = "Delete WC Record";
            this.deleteRecordToolStripMenuItem.Click += new System.EventHandler(this.deleteRecordToolStripMenuItem_Click);
            // 
            // btnWC
            // 
            this.btnWC.Location = new System.Drawing.Point(138, 106);
            this.btnWC.Name = "btnWC";
            this.btnWC.Size = new System.Drawing.Size(120, 37);
            this.btnWC.TabIndex = 5;
            this.btnWC.Text = "WC";
            this.btnWC.UseVisualStyleBackColor = true;
            this.btnWC.Click += new System.EventHandler(this.btnWC_Click);
            // 
            // btnWater
            // 
            this.btnWater.Location = new System.Drawing.Point(12, 106);
            this.btnWater.Name = "btnWater";
            this.btnWater.Size = new System.Drawing.Size(120, 37);
            this.btnWater.TabIndex = 7;
            this.btnWater.Text = "Water";
            this.btnWater.UseVisualStyleBackColor = true;
            this.btnWater.Click += new System.EventHandler(this.btnWater_Click);
            // 
            // lstWater
            // 
            this.lstWater.ContextMenuStrip = this.rightClickMenuWater;
            this.lstWater.FormattingEnabled = true;
            this.lstWater.Location = new System.Drawing.Point(12, 148);
            this.lstWater.Name = "lstWater";
            this.lstWater.Size = new System.Drawing.Size(120, 342);
            this.lstWater.TabIndex = 6;
            this.lstWater.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lstWater_MouseDown);
            // 
            // rightClickMenuWater
            // 
            this.rightClickMenuWater.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deselectWaterRecordToolStripMenuItem,
            this.toolStripSeparator4,
            this.deleteWaterRecordToolStripMenuItem});
            this.rightClickMenuWater.Name = "rightClickMenuWater";
            this.rightClickMenuWater.Size = new System.Drawing.Size(193, 54);
            // 
            // deselectWaterRecordToolStripMenuItem
            // 
            this.deselectWaterRecordToolStripMenuItem.Name = "deselectWaterRecordToolStripMenuItem";
            this.deselectWaterRecordToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.deselectWaterRecordToolStripMenuItem.Text = "Deselect Water Record";
            this.deselectWaterRecordToolStripMenuItem.Click += new System.EventHandler(this.deselectWaterRecordToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(189, 6);
            // 
            // deleteWaterRecordToolStripMenuItem
            // 
            this.deleteWaterRecordToolStripMenuItem.Image = global::WaterWc.Gui.Properties.Resources.rubbishBin;
            this.deleteWaterRecordToolStripMenuItem.Name = "deleteWaterRecordToolStripMenuItem";
            this.deleteWaterRecordToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.deleteWaterRecordToolStripMenuItem.Text = "Delete Water Record";
            this.deleteWaterRecordToolStripMenuItem.Click += new System.EventHandler(this.deleteWaterRecordToolStripMenuItem_Click);
            // 
            // lblWater
            // 
            this.lblWater.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblWater.Location = new System.Drawing.Point(12, 35);
            this.lblWater.Name = "lblWater";
            this.lblWater.Size = new System.Drawing.Size(120, 68);
            this.lblWater.TabIndex = 8;
            this.lblWater.Text = "0 lt.";
            this.lblWater.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblWC
            // 
            this.lblWC.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblWC.Location = new System.Drawing.Point(138, 35);
            this.lblWC.Name = "lblWC";
            this.lblWC.Size = new System.Drawing.Size(120, 68);
            this.lblWC.TabIndex = 9;
            this.lblWC.Text = "0 Time";
            this.lblWC.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mainMenu
            // 
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolsToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Size = new System.Drawing.Size(269, 24);
            this.mainMenu.TabIndex = 10;
            this.mainMenu.Text = "menuStrip1";
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deselectListsToolStripMenuItem,
            this.toolStripSeparator1,
            this.deleteSelectedWaterToolStripMenuItem,
            this.deleteSelectedWCToolStripMenuItem,
            this.toolStripSeparator2,
            this.chkSoundEffects,
            this.toolStripSeparator8,
            this.clearDatabaseToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
            this.toolsToolStripMenuItem.MouseDown += new System.Windows.Forms.MouseEventHandler(this.toolsToolStripMenuItem_MouseDown);
            // 
            // deselectListsToolStripMenuItem
            // 
            this.deselectListsToolStripMenuItem.Name = "deselectListsToolStripMenuItem";
            this.deselectListsToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.deselectListsToolStripMenuItem.Text = "Deselect Lists";
            this.deselectListsToolStripMenuItem.Click += new System.EventHandler(this.deselectListsToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(185, 6);
            // 
            // deleteSelectedWaterToolStripMenuItem
            // 
            this.deleteSelectedWaterToolStripMenuItem.Enabled = false;
            this.deleteSelectedWaterToolStripMenuItem.Image = global::WaterWc.Gui.Properties.Resources.rubbishBin;
            this.deleteSelectedWaterToolStripMenuItem.Name = "deleteSelectedWaterToolStripMenuItem";
            this.deleteSelectedWaterToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.deleteSelectedWaterToolStripMenuItem.Text = "Delete Selected Water";
            this.deleteSelectedWaterToolStripMenuItem.Click += new System.EventHandler(this.deleteSelectedWaterToolStripMenuItem_Click);
            // 
            // deleteSelectedWCToolStripMenuItem
            // 
            this.deleteSelectedWCToolStripMenuItem.Enabled = false;
            this.deleteSelectedWCToolStripMenuItem.Image = global::WaterWc.Gui.Properties.Resources.rubbishBin;
            this.deleteSelectedWCToolStripMenuItem.Name = "deleteSelectedWCToolStripMenuItem";
            this.deleteSelectedWCToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.deleteSelectedWCToolStripMenuItem.Text = "Delete Selected WC";
            this.deleteSelectedWCToolStripMenuItem.Click += new System.EventHandler(this.deleteSelectedWCToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(185, 6);
            // 
            // chkSoundEffects
            // 
            this.chkSoundEffects.Checked = true;
            this.chkSoundEffects.CheckOnClick = true;
            this.chkSoundEffects.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSoundEffects.Name = "chkSoundEffects";
            this.chkSoundEffects.Size = new System.Drawing.Size(188, 22);
            this.chkSoundEffects.Text = "Sound Effects";
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(185, 6);
            // 
            // clearDatabaseToolStripMenuItem
            // 
            this.clearDatabaseToolStripMenuItem.Image = global::WaterWc.Gui.Properties.Resources.database;
            this.clearDatabaseToolStripMenuItem.Name = "clearDatabaseToolStripMenuItem";
            this.clearDatabaseToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.clearDatabaseToolStripMenuItem.Text = "Clear Database";
            this.clearDatabaseToolStripMenuItem.Click += new System.EventHandler(this.clearDatabaseToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.goToWebsiteToolStripMenuItem});
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // goToWebsiteToolStripMenuItem
            // 
            this.goToWebsiteToolStripMenuItem.Name = "goToWebsiteToolStripMenuItem";
            this.goToWebsiteToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.goToWebsiteToolStripMenuItem.Text = "Go to GitHub Page";
            this.goToWebsiteToolStripMenuItem.Click += new System.EventHandler(this.goToWebsiteToolStripMenuItem_Click);
            // 
            // systemTrayIcon
            // 
            this.systemTrayIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.systemTrayIcon.BalloonTipText = "You could use here to add something. \\n To open the menu please click right butto" +
    "n.";
            this.systemTrayIcon.BalloonTipTitle = "Water&WC";
            this.systemTrayIcon.ContextMenuStrip = this.systemTrayMenu;
            this.systemTrayIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("systemTrayIcon.Icon")));
            this.systemTrayIcon.Text = "Water&WC";
            this.systemTrayIcon.DoubleClick += new System.EventHandler(this.systemTrayIcon_DoubleClick);
            // 
            // systemTrayMenu
            // 
            this.systemTrayMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnShowMainForm,
            this.toolStripSeparator7,
            this.txtLastWater,
            this.txtLastWC,
            this.toolStripSeparator5,
            this.waterToolStripMenuItem,
            this.wCToolStripMenuItem,
            this.toolStripSeparator6,
            this.btnQuit});
            this.systemTrayMenu.Name = "systemTrayMenu";
            this.systemTrayMenu.Size = new System.Drawing.Size(186, 182);
            this.systemTrayMenu.Opening += new System.ComponentModel.CancelEventHandler(this.systemTrayMenu_Opening);
            // 
            // btnShowMainForm
            // 
            this.btnShowMainForm.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShowMainForm.Name = "btnShowMainForm";
            this.btnShowMainForm.Size = new System.Drawing.Size(185, 22);
            this.btnShowMainForm.Text = "Show Water&WC";
            this.btnShowMainForm.Click += new System.EventHandler(this.btnShowMainForm_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(182, 6);
            // 
            // txtLastWater
            // 
            this.txtLastWater.Name = "txtLastWater";
            this.txtLastWater.ReadOnly = true;
            this.txtLastWater.Size = new System.Drawing.Size(125, 23);
            this.txtLastWater.Text = "Last Water:";
            // 
            // txtLastWC
            // 
            this.txtLastWC.Name = "txtLastWC";
            this.txtLastWC.ReadOnly = true;
            this.txtLastWC.Size = new System.Drawing.Size(125, 23);
            this.txtLastWC.Text = "Last WC:";
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(182, 6);
            // 
            // waterToolStripMenuItem
            // 
            this.waterToolStripMenuItem.Name = "waterToolStripMenuItem";
            this.waterToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.waterToolStripMenuItem.Text = "Drink Water";
            this.waterToolStripMenuItem.Click += new System.EventHandler(this.waterToolStripMenuItem_Click);
            // 
            // wCToolStripMenuItem
            // 
            this.wCToolStripMenuItem.Name = "wCToolStripMenuItem";
            this.wCToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.wCToolStripMenuItem.Text = "Go to the WC";
            this.wCToolStripMenuItem.Click += new System.EventHandler(this.wCToolStripMenuItem_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(182, 6);
            // 
            // btnQuit
            // 
            this.btnQuit.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuit.Image = global::WaterWc.Gui.Properties.Resources.logout;
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(185, 22);
            this.btnQuit.Text = "Quit";
            this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(269, 509);
            this.Controls.Add(this.lblWC);
            this.Controls.Add(this.lblWater);
            this.Controls.Add(this.btnWater);
            this.Controls.Add(this.lstWater);
            this.Controls.Add(this.btnWC);
            this.Controls.Add(this.lstWc);
            this.Controls.Add(this.mainMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mainMenu;
            this.MaximizeBox = false;
            this.Name = "FrmMain";
            this.Text = "Water&WC";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.Resize += new System.EventHandler(this.frmMain_Resize);
            this.rightClickMenuWC.ResumeLayout(false);
            this.rightClickMenuWater.ResumeLayout(false);
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            this.systemTrayMenu.ResumeLayout(false);
            this.systemTrayMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstWc;
        private System.Windows.Forms.Button btnWC;
        private System.Windows.Forms.Button btnWater;
        private System.Windows.Forms.ListBox lstWater;
        private System.Windows.Forms.Label lblWater;
        private System.Windows.Forms.Label lblWC;
        private System.Windows.Forms.MenuStrip mainMenu;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearDatabaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem goToWebsiteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteSelectedWaterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteSelectedWCToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deselectListsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ContextMenuStrip rightClickMenuWC;
        private System.Windows.Forms.ToolStripMenuItem DeselectRightMenuWC;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem deleteRecordToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip rightClickMenuWater;
        private System.Windows.Forms.ToolStripMenuItem deselectWaterRecordToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem deleteWaterRecordToolStripMenuItem;
        private System.Windows.Forms.NotifyIcon systemTrayIcon;
        private System.Windows.Forms.ContextMenuStrip systemTrayMenu;
        private System.Windows.Forms.ToolStripMenuItem waterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem wCToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox txtLastWater;
        private System.Windows.Forms.ToolStripTextBox txtLastWC;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem btnQuit;
        private System.Windows.Forms.ToolStripMenuItem btnShowMainForm;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripMenuItem chkSoundEffects;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
    }
}

