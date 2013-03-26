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
            this.seconds = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // textboxDuration
            // 
            this.textboxDuration.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.textboxDuration.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textboxDuration.Location = new System.Drawing.Point(3, 3);
            this.textboxDuration.MinimumSize = new System.Drawing.Size(43, 20);
            this.textboxDuration.Name = "textboxDuration";
            this.textboxDuration.Size = new System.Drawing.Size(43, 20);
            this.textboxDuration.TabIndex = 0;
            this.textboxDuration.Text = "";
            // 
            // textboxTask
            // 
            this.textboxTask.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textboxTask.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textboxTask.Location = new System.Drawing.Point(52, 3);
            this.textboxTask.Name = "textboxTask";
            this.textboxTask.Size = new System.Drawing.Size(112, 20);
            this.textboxTask.TabIndex = 0;
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
            this.buttonEnd.TabIndex = 1;
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
            this.textboxComment.Size = new System.Drawing.Size(200, 47);
            this.textboxComment.TabIndex = 2;
            this.textboxComment.Text = "";
            this.textboxComment.TextChanged += new System.EventHandler(this.textboxComment_TextChanged);
            // 
            // seconds
            // 
            this.seconds.Interval = 60000;
            this.seconds.Tick += new System.EventHandler(this.seconds_Tick);
            // 
            // ShortRecordView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.textboxComment);
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
        private System.Windows.Forms.Timer seconds;
    }
}
