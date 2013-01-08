using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TimeAssist.Views
{
    public partial class RecordControl : UserControl
    {

        public RecordControl()
        {
            InitializeComponent();
            recordData = new Record();
        }

        public Record Record
        {
            get { return recordData; }
            set { recordData = value; UpdateControls(); }
        }

        public event System.Action OnStartClicked;
        public event System.Action OnFinishClicked;

        Record recordData;

        private void comboBox1_ValueMemberChanged(object sender, EventArgs e)
        {
            recordData.Task = comboBox1.Text;
        }

        private void richTextBoxComment_TextChanged(object sender, EventArgs e)
        {
            recordData.Comment = richTextBoxComment.Text;
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            recordData.Start = recordData.Finish = DateTime.Now;
            labelStart.Text = "S: " + recordData.Start.ToString();
            labelDuration.Text = "D: " + (recordData.Duration);
            if (OnStartClicked != null)
                OnStartClicked();
        }

        private void buttonFinish_Click(object sender, EventArgs e)
        {
            recordData.Finish = DateTime.Now;
            labelFinished.Text = "F: " + recordData.Finish.ToString();
            labelDuration.Text = "D: " + (recordData.Duration);
            if (OnFinishClicked != null)
                OnFinishClicked();
        }

        private void UpdateControls()
        {
            comboBox1.Text = recordData.Task;
            richTextBoxComment.Text = recordData.Comment;
            labelStart.Text = "S: " + recordData.Start.ToString();
            labelFinished.Text = "F: " + recordData.Finish.ToString();
            labelDuration.Text = "D: " + (recordData.Duration);
        }

        public void Reset()
        {
            recordData = new Record();
            UpdateControls();
        }
    }
}
