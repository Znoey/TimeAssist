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
        public delegate void FinishRecord(Record r);
        public event FinishRecord OnRecordFinished;

        
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
            r.Start = DateTime.Now;
            panelListView.Controls.Add(RecordViewer(r));
            panelListView.AutoScroll = true;
        }

        private ShortRecordView RecordViewer(Record r)
        {
            ShortRecordView view = new ShortRecordView(r);
            view.Name = "RecordView_" + recordList.Count;
            view.Width = panelListView.Width;
            view.OnEndClicked += new ShortRecordView.CloseControl(view_OnEndClicked);
            view.Location = new Point(0, recordList.Count * view.Height);
            AddRecord(r);
            return view;
        }

        void view_OnEndClicked(object sender, EventArgs e)
        {
            ShortRecordView view = sender as ShortRecordView;
            int index = int.Parse(view.Name.Split('_')[1]);
            
            if( OnRecordFinished != null ) OnRecordFinished(recordList[index]);

            panelListView.Controls.RemoveAt(index);
            RemoveRecordAt(index);
            // TODO: Shift the other controls up.
            for (int i = 0, y = 0, c = 0; i < panelListView.Controls.Count; i++)
            {
                var control = panelListView.Controls[i] as ShortRecordView;
                if (control != null)
                {
                    control.Location = new Point(0, y);
                    control.Name = "RecordView_" + c.ToString();
                    y += control.Height;
                    c++;
                }
            }
        }


    }
}
