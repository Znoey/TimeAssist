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
            this.groupBoxRecords = new System.Windows.Forms.GroupBox();
            this.treeViewRecords = new System.Windows.Forms.TreeView();
            this.userControl11 = new WindowsFormsControlLibrary1.PieChartControl();
            this.pieChartControl1 = new WindowsFormsControlLibrary1.PieChartControl();
            this.notifyContextMenu.SuspendLayout();
            this.groupBoxCurrentTask.SuspendLayout();
            this.groupBoxRecords.SuspendLayout();
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
            this.groupBoxCurrentTask.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBoxCurrentTask.Controls.Add(this.textBox1);
            this.groupBoxCurrentTask.Controls.Add(this.buttonFinishTask);
            this.groupBoxCurrentTask.Controls.Add(this.buttonStartTask);
            this.groupBoxCurrentTask.Location = new System.Drawing.Point(12, 12);
            this.groupBoxCurrentTask.Name = "groupBoxCurrentTask";
            this.groupBoxCurrentTask.Size = new System.Drawing.Size(268, 80);
            this.groupBoxCurrentTask.TabIndex = 3;
            this.groupBoxCurrentTask.TabStop = false;
            this.groupBoxCurrentTask.Text = "Current Task";
            // 
            // textBox1
            // 
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
            this.buttonFinishTask.Location = new System.Drawing.Point(134, 50);
            this.buttonFinishTask.Name = "buttonFinishTask";
            this.buttonFinishTask.Size = new System.Drawing.Size(126, 23);
            this.buttonFinishTask.TabIndex = 0;
            this.buttonFinishTask.Text = "Finish Task";
            this.buttonFinishTask.UseVisualStyleBackColor = true;
            this.buttonFinishTask.Click += new System.EventHandler(this.OnClickFinishTask);
            // 
            // groupBoxRecords
            // 
            this.groupBoxRecords.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxRecords.Controls.Add(this.treeViewRecords);
            this.groupBoxRecords.Location = new System.Drawing.Point(286, 12);
            this.groupBoxRecords.Name = "groupBoxRecords";
            this.groupBoxRecords.Size = new System.Drawing.Size(293, 328);
            this.groupBoxRecords.TabIndex = 5;
            this.groupBoxRecords.TabStop = false;
            this.groupBoxRecords.Text = "All Records";
            // 
            // treeViewRecords
            // 
            this.treeViewRecords.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewRecords.Location = new System.Drawing.Point(3, 16);
            this.treeViewRecords.Name = "treeViewRecords";
            this.treeViewRecords.Size = new System.Drawing.Size(287, 309);
            this.treeViewRecords.TabIndex = 4;
            this.treeViewRecords.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewRecords_AfterSelect);
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
            this.pieChartControl1.Location = new System.Drawing.Point(12, 99);
            this.pieChartControl1.Name = "pieChartControl1";
            this.pieChartControl1.Size = new System.Drawing.Size(240, 249);
            this.pieChartControl1.TabIndex = 6;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(591, 352);
            this.Controls.Add(this.pieChartControl1);
            this.Controls.Add(this.groupBoxRecords);
            this.Controls.Add(this.groupBoxCurrentTask);
            this.MaximizeBox = false;
            this.Name = "Main";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Time Assist";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.notifyContextMenu.ResumeLayout(false);
            this.groupBoxCurrentTask.ResumeLayout(false);
            this.groupBoxCurrentTask.PerformLayout();
            this.groupBoxRecords.ResumeLayout(false);
            this.ResumeLayout(false);

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
        private System.Windows.Forms.GroupBox groupBoxRecords;
        private System.Windows.Forms.TreeView treeViewRecords;
        private WindowsFormsControlLibrary1.PieChartControl userControl11;
        private WindowsFormsControlLibrary1.PieChartControl pieChartControl1;
    }
}

