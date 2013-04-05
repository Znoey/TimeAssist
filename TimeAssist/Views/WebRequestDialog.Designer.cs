namespace TimeAssist.Views
{
    partial class WebRequestDialog
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
            this.textboxRespose = new System.Windows.Forms.RichTextBox();
            this.buttonPost = new System.Windows.Forms.Button();
            this.textboxURI = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // textboxRespose
            // 
            this.textboxRespose.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textboxRespose.Location = new System.Drawing.Point(13, 84);
            this.textboxRespose.Name = "textboxRespose";
            this.textboxRespose.Size = new System.Drawing.Size(259, 166);
            this.textboxRespose.TabIndex = 0;
            this.textboxRespose.Text = "";
            // 
            // buttonPost
            // 
            this.buttonPost.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonPost.Location = new System.Drawing.Point(197, 55);
            this.buttonPost.Name = "buttonPost";
            this.buttonPost.Size = new System.Drawing.Size(75, 23);
            this.buttonPost.TabIndex = 1;
            this.buttonPost.Text = "Request";
            this.buttonPost.UseVisualStyleBackColor = true;
            this.buttonPost.Click += new System.EventHandler(this.button1_Click);
            // 
            // textboxURI
            // 
            this.textboxURI.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textboxURI.Location = new System.Drawing.Point(12, 12);
            this.textboxURI.Name = "textboxURI";
            this.textboxURI.Size = new System.Drawing.Size(260, 34);
            this.textboxURI.TabIndex = 0;
            this.textboxURI.Text = "http://192.168.40.116/timesheet";
            // 
            // WebRequestDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.buttonPost);
            this.Controls.Add(this.textboxURI);
            this.Controls.Add(this.textboxRespose);
            this.Name = "WebRequestDialog";
            this.Text = "WebRequestDialog";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox textboxRespose;
        private System.Windows.Forms.Button buttonPost;
        private System.Windows.Forms.RichTextBox textboxURI;
    }
}