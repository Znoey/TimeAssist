﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TimeAssist.Views;

namespace TimeAssist
{
    public partial class Main : Form
    {
        /// <summary>
        /// The current task the user is working on.
        /// </summary>
        Record m_rCurrentRecord = null;

        List<Record> m_lCurrent = null;

        /// <summary>
        /// Who are you?!  At least tell me your name and password...
        /// </summary>
        Person m_pPerson = null;

        /// <summary>
        /// Our login form when we need to get a user name and password.
        /// </summary>
        LoginForm m_dlgLogin = null;

        public Main()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            // Initialize the notification Icon in the system tray.
            notifyIcon.Text = "Time Assistant v1.0";
            notifyIcon.Visible = true;
            notifyIcon.MouseDoubleClick += new MouseEventHandler(notifyIcon_MouseDoubleClick);

            m_lCurrent = new List<Record>();
            // record control
            //recordControl.OnStartClicked += new Action(recordControl_OnStartClicked);
            //recordControl.OnFinishClicked += new Action(recordControl_OnFinishClicked);
        }

        void recordControl_OnFinishClicked()
        {
            //currentTask = recordControl.Record;
            //person.AddRecord(recordControl.Record);
            UpdateForm(m_pPerson);
        }

        void recordControl_OnStartClicked()
        {
            //throw new NotImplementedException();
        }

        void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
                this.WindowState = FormWindowState.Normal;

            this.Activate();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //LoadRecordsBinary("test.xml.bin");
            //LoadRecordsSoap("SoapTest.xml");
            if (AppSettings.Instance.rememberLastLogin)
            {
                m_pPerson = new Person(AppSettings.Instance.loginName, AppSettings.Instance.loginPassword);
                try
                {
                    m_pPerson.Load();
                }
                catch (System.Exception)
                {
                    m_pPerson = new Person("unknown", "unknown");
                }

                this.Text = "Time Assist [" + m_pPerson.Name + "]";

                UpdateForm(m_pPerson);
            }
            else
            {
                ShowLoginDialog();
            }
        }


        void dlgLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            m_dlgLogin.FormClosing -= dlgLogin_FormClosing;

            if (!m_dlgLogin.IsFilledOut)
            {
                m_pPerson = new Person("unknown", "unknown");
                return;
            }
            if (m_dlgLogin.RememberMe)
            {
                AppSettings.Instance.loginName = m_dlgLogin.UserName;
                AppSettings.Instance.loginPassword = m_dlgLogin.Password;
                AppSettings.Instance.rememberLastLogin = true;
            }
            m_pPerson = new Person(m_dlgLogin.UserName, m_dlgLogin.Password);
            try
            {
                m_pPerson.Load();
            }
            catch (System.Exception)
            {
                m_pPerson = new Person("unknown", "unknown");
            }

            this.Text = "Time Assist [" + m_pPerson.Name + "]";

            UpdateForm(m_pPerson);
        }

        private void UpdateForm(Person p)
        {
            // TODO: Add the ability to update both the today element and 
            //      the record stack of elements.

            if (p.Records.Count > 0)
            {
                // Handle all records.
                treeViewRecords.Nodes.Clear();
                foreach (var key in p.Records.Keys)
                {
                    var node = treeViewRecords.Nodes.Add(key.ToString());
                    List<Record> sorted = new List<Record>(p.Records[key].ToArray());
                    sorted.Sort((Record a, Record b) =>
                        {
                            return a.Start.CompareTo(b.Start);
                        });
                    foreach (var task in sorted)
                    {
                        TreeNode record = new TreeNode();
                        record.Text = task.Duration.ToString("F2") + " - " + task.Task;
                        foreach (var item in task.properties)
                        {
                            record.Nodes.Add(item.GetType().Name + " - " + item.Data.ToString());
                        }
                        node.Nodes.Add(record);
                    }
                }
            }
        }

        /// <summary>
        /// Displays the login dialog to the user.
        /// </summary>
        private void ShowLoginDialog()
        {
            m_dlgLogin = new LoginForm();
            m_dlgLogin.Show(this);
            m_dlgLogin.FormClosing += new FormClosingEventHandler(dlgLogin_FormClosing);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                AppSettings.Instance.SaveFile();

                if (m_pPerson != null)
                    m_pPerson.Save();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something went wrong when closing. " + ex.Message);
            }
        }


        private void OnClickAddTask(object sender, EventArgs e)
        {
            AddTask dlgAddTask = new AddTask();
            dlgAddTask.Text = "Start a New Task.";
            if (dlgAddTask.ShowDialog() == DialogResult.OK)
            {
                m_rCurrentRecord = new Record();
                m_rCurrentRecord.Start = dlgAddTask.RecordInfo.Start;
                m_rCurrentRecord.Finish = dlgAddTask.RecordInfo.Finish;
                m_rCurrentRecord.Task = dlgAddTask.RecordInfo.Task;
                m_rCurrentRecord.Comment = dlgAddTask.RecordInfo.Comment;
                textBox1.Text = m_rCurrentRecord.Task;
            }
        }

        private void OnClickFinishTask(object sender, EventArgs e)
        {
            if (m_rCurrentRecord != null)
            {
                AddTask dlgAddTask = new AddTask();
                dlgAddTask.Text = "Finish Current Task.";
                dlgAddTask.RecordInfo = m_rCurrentRecord;
                dlgAddTask.Comment = m_rCurrentRecord.Comment;
                dlgAddTask.Task = m_rCurrentRecord.Task;
                dlgAddTask.ButtonText = "Finish Task";
                if (dlgAddTask.ShowDialog() == DialogResult.OK)
                {
                    m_rCurrentRecord.Task = dlgAddTask.Task;
                    m_rCurrentRecord.Comment = dlgAddTask.Comment;
                    m_rCurrentRecord.Finish = DateTime.Now;
                    m_pPerson.AddRecord(m_rCurrentRecord);
                    UpdateForm(m_pPerson);
                    m_rCurrentRecord = null;
                    textBox1.Text = "No Current Task.";
                    return;
                }
            }
            else
            {
                OnClickAddTask(this, new EventArgs());
            }
        }



        #region Context Menu hooks 

        private void menuStartTask_Click(object sender, EventArgs e)
        {
            OnClickAddTask(sender, e);
        }

        private void finishTaskToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OnClickFinishTask(sender, e);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        /// <summary>
        /// Sets the Finish time for the current record and stores it on our person.
        /// </summary>
        private void FinishOffCurrentTask()
        {
            if (m_rCurrentRecord != null)
            {
                // TODO: Finish off the current task first;
                m_rCurrentRecord.Finish = DateTime.Now;
                m_pPerson.AddRecord(m_rCurrentRecord);
                m_rCurrentRecord = null;
            }
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            m_rCurrentRecord.Start = m_rCurrentRecord.Finish = DateTime.Now;
        }

        private void buttonFinish_Click(object sender, EventArgs e)
        {
            m_rCurrentRecord.Finish = DateTime.Now;
        }
        #region treeViewRecords Events

        private void treeViewRecords_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Parent == null)
            {
                DateTime date = DateTime.Parse(e.Node.Text);                
                pieChartControl1.SetData(m_pPerson.Records[date.ToString("d")]);
            }
            else
            {
                var n = e.Node;
                if (e.Node.Parent.Parent == null)
                {
                    DateTime dat = DateTime.Parse(e.Node.Parent.Text);
                    pieChartControl1.SetData(m_pPerson.Records[dat.ToString("d")]);
                }
                else if (e.Node.Parent.Parent.Parent == null)
                {
                    DateTime dat = DateTime.Parse(e.Node.Parent.Parent.Text);
                    pieChartControl1.SetData(m_pPerson.Records[dat.ToString("d")]);
                    n = e.Node.Parent;
                }
                var record = m_pPerson.Records[n.Parent.Text][n.Index];
                Clipboard.SetText(record.Comment);
            }
        }

        ContextMenuStrip treeViewContextMenu = null;
        private void treeViewRecords_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (treeViewContextMenu == null)
            {
                treeViewContextMenu = new ContextMenuStrip();
                treeViewContextMenu.Items.Add("Copy Comment");
                treeViewContextMenu.Items.Add("Edit");
                treeViewContextMenu.Items.Add("Delete");
                treeViewContextMenu.Items.Add("Post to Time Sheet.");
                treeViewContextMenu.ItemClicked += new ToolStripItemClickedEventHandler(treeViewContextMenu_ItemClicked);
            }
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                if (e.Node.Parent == null)
                {
                    return;
                }
                else if (e.Node.Parent.Parent != null)
                {
                    treeViewContextMenu.Show(treeViewRecords.PointToScreen(e.Location));
                    treeViewRecords.SelectedNode = e.Node.Parent;
                    return;
                }
                else
                {
                    treeViewContextMenu.Show(treeViewRecords.PointToScreen(e.Location));
                    treeViewRecords.SelectedNode = e.Node;
                }
            }
        }

        void treeViewContextMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Text == "Copy Comment")
            {
                var record = m_pPerson.Records[treeViewRecords.SelectedNode.Parent.Text][treeViewRecords.SelectedNode.Index];
                Clipboard.SetText(record.Comment);
            }
            else if (e.ClickedItem.Text == "Edit")
            {
                var record = m_pPerson.Records[treeViewRecords.SelectedNode.Parent.Text][treeViewRecords.SelectedNode.Index];
                EditRecordForm erf = new EditRecordForm(record);
                if (erf.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    m_pPerson.Records[treeViewRecords.SelectedNode.Parent.Text].RemoveAt(treeViewRecords.SelectedNode.Index);
                    m_pPerson.AddRecord(record);
                    //person.Records[record.Start.ToString("d")].Add(record);
                    UpdateForm(m_pPerson);
                }
            }
            else if (e.ClickedItem.Text == "Delete")
            {
                m_pPerson.Records[treeViewRecords.SelectedNode.Parent.Text].RemoveAt(treeViewRecords.SelectedNode.Index);
                UpdateForm(m_pPerson);
            }
            else if (e.ClickedItem.Text == "Post to Time Sheet.")
            {

            }
            treeViewContextMenu.Hide();
        }

        #endregion

        private void timerSecondUpdate_Tick(object sender, EventArgs e)
        {
            if (m_rCurrentRecord != null)
            {
                var d = DateTime.Now - m_rCurrentRecord.Start;
                textBox1.Text = string.Format("{0} [{1}:{2}:{3}]", m_rCurrentRecord.Task.Length < 40 ? m_rCurrentRecord.Task : m_rCurrentRecord.Task.Substring(0, 40), d.Hours, d.Minutes, d.Seconds);
            }
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (m_pPerson != null)
                m_pPerson.Save();

            ShowLoginDialog();
        }
    }
}
