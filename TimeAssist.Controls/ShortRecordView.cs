using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TimeAssist.Controls
{
    public partial class ShortRecordView : UserControl
    {
        public delegate void CloseControl(object sender, EventArgs e);

        public event CloseControl OnEndClicked;

        Record r = new Record();

        public ShortRecordView()
        {
            InitializeComponent();
        }

        public ShortRecordView(Record r)
        {
            InitializeComponent();
            this.r = r;
            var d = r.DurationTimeSpan;
            textboxDuration.Text = string.Format("{0}:{1}:{2}", d.Hours, d.Minutes, d.Seconds);
            updateTimer.Start();
        }

        private void textboxTask_TextChanged(object sender, EventArgs e)
        {
            r.Task = textboxTask.Text.Trim();
        }

        private void textboxComment_TextChanged(object sender, EventArgs e)
        {
            r.Comment = "";
            r.properties.RemoveAll(x => x.GetType() == typeof(TimeAssist.Data.Property.CommentProperty));
            r.Comment = textboxComment.Text.Trim();
        }

        private void buttonEnd_Click(object sender, EventArgs e)
        {
            r.Finish = DateTime.Now;
            if (string.IsNullOrEmpty(r.Task))
                r.Task = "not specified";
            if (string.IsNullOrEmpty(r.Comment))
                r.Comment = "no comments added.";
            if (OnEndClicked != null) OnEndClicked(this, new EventArgs());
        }

        private void buttonPause_Click(object sender, EventArgs e)
        {

        }

        private void Tick(object sender, EventArgs e)
        {
            var d = r.DurationTimeSpan;
            textboxDuration.Text = string.Format("{0}:{1}:{2}", d.Hours, d.Minutes, d.Seconds);
        }

    }
}
