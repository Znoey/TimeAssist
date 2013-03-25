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
    public partial class TaskListControl : UserControl
    {
        public const int RecordPanelHeight = 32;

        List<Record> recordList = new List<Record>();

        public TaskListControl()
        {
            InitializeComponent();
        }

        #region Record List Controls

        public void AddRecord(Record r)
        {
            recordList.Add(r);
        }

        public void RemoveRecordAt(int index)
        {
            recordList.RemoveAt(index);
        }

        #endregion

        private void buttonNewTask_Click(object sender, EventArgs e)
        {
            var r = new Record();
            AddRecord(r);
            panelListView.Controls.Add(RecordViewer(r));
        }

        private Control RecordViewer(Record r)
        {
            Panel p = new Panel();
            p.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            p.Size = new System.Drawing.Size(panelListView.Width, RecordPanelHeight);
            p.Location = new Point(0, recordList.Count * RecordPanelHeight);
            TextBox duration = new TextBox();
            TextBox task = new TextBox();
            Button addComment = new Button();
            Button end = new Button();

            p.Controls.Add(duration);
            p.Controls.Add(task);
            p.Controls.Add(addComment);
            p.Controls.Add(end);

            return p;
        }


    }
}
