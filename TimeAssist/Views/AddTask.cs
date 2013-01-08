using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TimeAssist
{
    public partial class AddTask : Form
    {
        public Record RecordInfo { get; set; }

        public AddTask()
        {
            InitializeComponent();
            RecordInfo = new Record();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if( textBoxTask.Text.Length > 0)
                RecordInfo.Task = textBoxTask.Text;
            if( richTextBoxComment.Text.Length > 0)
                RecordInfo.Comment = richTextBoxComment.Text;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.CompareTo('\n') == 0)
            {
                button1_Click(this, new EventArgs());
            }
        }

        public string Task
        {
            get
            {
                return textBoxTask.Text;
            }
            set
            {
                RecordInfo.Task = value;
                textBoxTask.Text = RecordInfo.Task;
            }
        }

        public string Comment
        {
            get
            {
                return richTextBoxComment.Text;
            }
            set
            {
                RecordInfo.Comment = value;
                richTextBoxComment.Text = RecordInfo.Comment;
            }
        }

        public string ButtonText
        {
            get
            {
                return buttonOK.Text;
            }
            set
            {
                buttonOK.Text = value;
            }
        }
    }
}
