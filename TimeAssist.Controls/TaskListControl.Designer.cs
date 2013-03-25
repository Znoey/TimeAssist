namespace TimeAssist.Controls
{
    partial class TaskListControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBoxTaskList = new System.Windows.Forms.GroupBox();
            this.buttonNewTask = new System.Windows.Forms.Button();
            this.panelListView = new System.Windows.Forms.Panel();
            this.groupBoxTaskList.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxTaskList
            // 
            this.groupBoxTaskList.Controls.Add(this.panelListView);
            this.groupBoxTaskList.Controls.Add(this.buttonNewTask);
            this.groupBoxTaskList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxTaskList.Location = new System.Drawing.Point(0, 0);
            this.groupBoxTaskList.Name = "groupBoxTaskList";
            this.groupBoxTaskList.Size = new System.Drawing.Size(229, 281);
            this.groupBoxTaskList.TabIndex = 0;
            this.groupBoxTaskList.TabStop = false;
            this.groupBoxTaskList.Text = "Task List";
            // 
            // buttonNewTask
            // 
            this.buttonNewTask.Location = new System.Drawing.Point(7, 20);
            this.buttonNewTask.Name = "buttonNewTask";
            this.buttonNewTask.Size = new System.Drawing.Size(75, 23);
            this.buttonNewTask.TabIndex = 0;
            this.buttonNewTask.Text = "New Task";
            this.buttonNewTask.UseVisualStyleBackColor = true;
            this.buttonNewTask.Click += new System.EventHandler(this.buttonNewTask_Click);
            // 
            // panelListView
            // 
            this.panelListView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelListView.Location = new System.Drawing.Point(7, 50);
            this.panelListView.Name = "panelListView";
            this.panelListView.Size = new System.Drawing.Size(216, 225);
            this.panelListView.TabIndex = 1;
            // 
            // TaskListControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBoxTaskList);
            this.Name = "TaskListControl";
            this.Size = new System.Drawing.Size(229, 281);
            this.groupBoxTaskList.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxTaskList;
        private System.Windows.Forms.Button buttonNewTask;
        private System.Windows.Forms.Panel panelListView;
    }
}
