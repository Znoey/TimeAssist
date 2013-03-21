namespace TimeAssist
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.notifyContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuStartTask = new System.Windows.Forms.ToolStripMenuItem();
            this.finishTaskToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonStartTask = new System.Windows.Forms.Button();
            this.groupBoxCurrentTask = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.buttonFinishTask = new System.Windows.Forms.Button();
            this.treeViewRecords = new System.Windows.Forms.TreeView();
            this.userControl11 = new TimeAssist.Controls.PieChartControl();
            this.pieChartControl1 = new TimeAssist.Controls.PieChartControl();
            this.timerSecondUpdate = new System.Windows.Forms.Timer(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.logOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.notifyContextMenu.SuspendLayout();
            this.groupBoxCurrentTask.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // notifyIcon
            // 
            this.notifyIcon.ContextMenuStrip = this.notifyContextMenu;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "notifyIcon1";
            this.notifyIcon.Visible = true;
            // 
            // notifyContextMenu
            // 
            this.notifyContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuStartTask,
            this.finishTaskToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.notifyContextMenu.Name = "notifyContextMenu";
            this.notifyContextMenu.Size = new System.Drawing.Size(133, 70);
            // 
            // menuStartTask
            // 
            this.menuStartTask.Name = "menuStartTask";
            this.menuStartTask.Size = new System.Drawing.Size(132, 22);
            this.menuStartTask.Text = "Start &Task";
            this.menuStartTask.Click += new System.EventHandler(this.menuStartTask_Click);
            // 
            // finishTaskToolStripMenuItem
            // 
            this.finishTaskToolStripMenuItem.Name = "finishTaskToolStripMenuItem";
            this.finishTaskToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.finishTaskToolStripMenuItem.Text = "&Finish Task";
            this.finishTaskToolStripMenuItem.Click += new System.EventHandler(this.finishTaskToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // buttonStartTask
            // 
            this.buttonStartTask.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonStartTask.Location = new System.Drawing.Point(7, 50);
            this.buttonStartTask.Name = "buttonStartTask";
            this.buttonStartTask.Size = new System.Drawing.Size(121, 23);
            this.buttonStartTask.TabIndex = 1;
            this.buttonStartTask.Text = "Start Task";
            this.buttonStartTask.UseVisualStyleBackColor = true;
            this.buttonStartTask.Click += new System.EventHandler(this.OnClickAddTask);
            // 
            // groupBoxCurrentTask
            // 
            this.groupBoxCurrentTask.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxCurrentTask.Controls.Add(this.textBox1);
            this.groupBoxCurrentTask.Controls.Add(this.buttonFinishTask);
            this.groupBoxCurrentTask.Controls.Add(this.buttonStartTask);
            this.groupBoxCurrentTask.Location = new System.Drawing.Point(12, 12);
            this.groupBoxCurrentTask.Name = "groupBoxCurrentTask";
            this.groupBoxCurrentTask.Size = new System.Drawing.Size(268, 81);
            this.groupBoxCurrentTask.TabIndex = 3;
            this.groupBoxCurrentTask.TabStop = false;
            this.groupBoxCurrentTask.Text = "Current Task";
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(6, 19);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(254, 20);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = "none";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // buttonFinishTask
            // 
            this.buttonFinishTask.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonFinishTask.Location = new System.Drawing.Point(134, 50);
            this.buttonFinishTask.Name = "buttonFinishTask";
            this.buttonFinishTask.Size = new System.Drawing.Size(126, 23);
            this.buttonFinishTask.TabIndex = 0;
            this.buttonFinishTask.Text = "Finish Task";
            this.buttonFinishTask.UseVisualStyleBackColor = true;
            this.buttonFinishTask.Click += new System.EventHandler(this.OnClickFinishTask);
            // 
            // treeViewRecords
            // 
            this.treeViewRecords.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewRecords.Location = new System.Drawing.Point(3, 3);
            this.treeViewRecords.Name = "treeViewRecords";
            this.treeViewRecords.Size = new System.Drawing.Size(287, 311);
            this.treeViewRecords.TabIndex = 4;
            this.treeViewRecords.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewRecords_AfterSelect);
            this.treeViewRecords.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeViewRecords_NodeMouseClick);
            // 
            // userControl11
            // 
            this.userControl11.Location = new System.Drawing.Point(13, 99);
            this.userControl11.Name = "userControl11";
            this.userControl11.Size = new System.Drawing.Size(267, 238);
            this.userControl11.TabIndex = 6;
            // 
            // pieChartControl1
            // 
            this.pieChartControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pieChartControl1.Location = new System.Drawing.Point(12, 99);
            this.pieChartControl1.Name = "pieChartControl1";
            this.pieChartControl1.Size = new System.Drawing.Size(265, 257);
            this.pieChartControl1.TabIndex = 6;
            // 
            // timerSecondUpdate
            // 
            this.timerSecondUpdate.Enabled = true;
            this.timerSecondUpdate.Interval = 1000;
            this.timerSecondUpdate.Tick += new System.EventHandler(this.timerSecondUpdate_Tick);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 362);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(588, 22);
            this.statusStrip1.TabIndex = 7;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.logOutToolStripMenuItem});
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(29, 20);
            this.toolStripDropDownButton1.Text = "toolStripDropDownButton1";
            // 
            // logOutToolStripMenuItem
            // 
            this.logOutToolStripMenuItem.Name = "logOutToolStripMenuItem";
            this.logOutToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.logOutToolStripMenuItem.Text = "Log out";
            this.logOutToolStripMenuItem.Click += new System.EventHandler(this.logOutToolStripMenuItem_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(287, 13);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(301, 343);
            this.tabControl1.TabIndex = 8;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.treeViewRecords);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(293, 317);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "All Records";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(293, 317);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(588, 384);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.pieChartControl1);
            this.Controls.Add(this.groupBoxCurrentTask);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(604, 422);
            this.Name = "Main";
            this.Text = "Time Assist";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.notifyContextMenu.ResumeLayout(false);
            this.groupBoxCurrentTask.ResumeLayout(false);
            this.groupBoxCurrentTask.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ContextMenuStrip notifyContextMenu;
        private System.Windows.Forms.ToolStripMenuItem menuStartTask;
        private System.Windows.Forms.Button buttonStartTask;
        private System.Windows.Forms.GroupBox groupBoxCurrentTask;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button buttonFinishTask;
        private System.Windows.Forms.ToolStripMenuItem finishTaskToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.TreeView treeViewRecords;
        private TimeAssist.Controls.PieChartControl userControl11;
        private TimeAssist.Controls.PieChartControl pieChartControl1;
        private System.Windows.Forms.Timer timerSecondUpdate;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem logOutToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
    }
}

