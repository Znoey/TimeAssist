using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TimeAssist.Views
{
    public partial class EditRecordForm : Form
    {
        public Record Record { get { return record; } set { record = value; } }

        public event EventHandler OnApplyClicked;

        public EditRecordForm(Record r)
        {
            record = r;
            InitializeComponent();
            dateTimePickerStart.Value = record.Start;
            dateTimePickerFinish.Value = record.Finish;
            textBoxTask.Text = record.Task;
            textBoxComment.Text = record.Comment;
            Invalidate();
        }

        private void buttonApply_Click(object sender, EventArgs e)
        {
            record.Start = dateTimePickerStart.Value;
            record.Finish = dateTimePickerFinish.Value;
            record.Task = textBoxTask.Text;
            record.Comment = textBoxComment.Text;

            if (OnApplyClicked != null) OnApplyClicked(sender, e);

            Close();
        }

        Record record;
    }
}
