namespace TimeAssist.Controls
{
    partial class ShortRecordView
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
            this.components = new System.ComponentModel.Container();
            this.textboxDuration = new System.Windows.Forms.RichTextBox();
            this.textboxTask = new System.Windows.Forms.RichTextBox();
            this.buttonEnd = new System.Windows.Forms.Button();
            this.textboxComment = new System.Windows.Forms.RichTextBox();
            this.updateTimer = new System.Windows.Forms.Timer(this.components);
            this.buttonPause = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textboxDuration
            // 
            this.textboxDuration.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.textboxDuration.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textboxDuration.Location = new System.Drawing.Point(3, 3);
            this.textboxDuration.Multiline = false;
            this.textboxDuration.Name = "textboxDuration";
            this.textboxDuration.ReadOnly = true;
            this.textboxDuration.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.textboxDuration.Size = new System.Drawing.Size(35, 20);
            this.textboxDuration.TabIndex = 0;
            this.textboxDuration.TabStop = false;
            this.textboxDuration.Text = "00:00";
            // 
            // textboxTask
            // 
            this.textboxTask.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textboxTask.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textboxTask.Location = new System.Drawing.Point(44, 3);
            this.textboxTask.Name = "textboxTask";
            this.textboxTask.Size = new System.Drawing.Size(120, 20);
            this.textboxTask.TabIndex = 1;
            this.textboxTask.Text = "";
            this.textboxTask.TextChanged += new System.EventHandler(this.textboxTask_TextChanged);
            // 
            // buttonEnd
            // 
            this.buttonEnd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonEnd.BackColor = System.Drawing.Color.Red;
            this.buttonEnd.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonEnd.Location = new System.Drawing.Point(170, 3);
            this.buttonEnd.MinimumSize = new System.Drawing.Size(34, 20);
            this.buttonEnd.Name = "buttonEnd";
            this.buttonEnd.Size = new System.Drawing.Size(34, 20);
            this.buttonEnd.TabIndex = 0;
            this.buttonEnd.TabStop = false;
            this.buttonEnd.Text = "End";
            this.buttonEnd.UseVisualStyleBackColor = false;
            this.buttonEnd.Click += new System.EventHandler(this.buttonEnd_Click);
            // 
            // textboxComment
            // 
            this.textboxComment.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textboxComment.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textboxComment.Location = new System.Drawing.Point(4, 30);
            this.textboxComment.Name = "textboxComment";
            this.textboxComment.Size = new System.Drawing.Size(160, 47);
            this.textboxComment.TabIndex = 2;
            this.textboxComment.Text = "";
            this.textboxComment.TextChanged += new System.EventHandler(this.textboxComment_TextChanged);
            // 
            // updateTimer
            // 
            this.updateTimer.Interval = 1000;
            this.updateTimer.Tick += new System.EventHandler(this.Tick);
            // 
            // buttonPause
            // 
            this.buttonPause.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonPause.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.buttonPause.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonPause.Location = new System.Drawing.Point(170, 26);
            this.buttonPause.MinimumSize = new System.Drawing.Size(34, 20);
            this.buttonPause.Name = "buttonPause";
            this.buttonPause.Size = new System.Drawing.Size(34, 20);
            this.buttonPause.TabIndex = 0;
            this.buttonPause.TabStop = false;
            this.buttonPause.Text = "Pause";
            this.buttonPause.UseVisualStyleBackColor = false;
            this.buttonPause.Click += new System.EventHandler(this.buttonPause_Click);
            // 
            // ShortRecordView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.Controls.Add(this.textboxComment);
            this.Controls.Add(this.buttonPause);
            this.Controls.Add(this.buttonEnd);
            this.Controls.Add(this.textboxTask);
            this.Controls.Add(this.textboxDuration);
            this.Name = "ShortRecordView";
            this.Size = new System.Drawing.Size(207, 80);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox textboxDuration;
        private System.Windows.Forms.RichTextBox textboxTask;
        private System.Windows.Forms.Button buttonEnd;
        private System.Windows.Forms.RichTextBox textboxComment;
        private System.Windows.Forms.Timer updateTimer;
        private System.Windows.Forms.Button buttonPause;
    }
}
