using System;
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
        Record currentTask = null;

        /// <summary>
        /// Who are you?!  At least tell me your name and password...
        /// </summary>
        Person person = null;

        /// <summary>
        /// Our login form when we need to get a user name and password.
        /// </summary>
        LoginForm dlgLogin = null;

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

            // record control
            //recordControl.OnStartClicked += new Action(recordControl_OnStartClicked);
            //recordControl.OnFinishClicked += new Action(recordControl_OnFinishClicked);
        }

        void recordControl_OnFinishClicked()
        {
            //currentTask = recordControl.Record;
            //person.AddRecord(recordControl.Record);
            UpdateForm(person);
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
                person = new Person(AppSettings.Instance.loginName, AppSettings.Instance.loginPassword);
                try
                {
                    person.Load();
                }
                catch (System.Exception)
                {
                    person = new Person("unknown", "unknown");
                }

                this.Text = "Time Assist [" + person.Name + "]";

                UpdateForm(person);
            }
            else
            {
                ShowLoginDialog();
            }
        }


        void dlgLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            dlgLogin.FormClosing -= dlgLogin_FormClosing;

            if (!dlgLogin.IsFilledOut)
            {
                person = new Person("unknown", "unknown");
                return;
            }
            if (dlgLogin.RememberMe)
            {
                AppSettings.Instance.loginName = dlgLogin.UserName;
                AppSettings.Instance.loginPassword = dlgLogin.Password;
                AppSettings.Instance.rememberLastLogin = true;
            }
            person = new Person(dlgLogin.UserName, dlgLogin.Password);
            try
            {
                person.Load();
            }
            catch (System.Exception)
            {
                person = new Person("unknown", "unknown");
            }

            this.Text = "Time Assist [" + person.Name + "]";

            UpdateForm(person);
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
                        node.Nodes.Add(FormatTreeViewString(task));
                    }
                }
            }
        }

        /// <summary>
        /// Displays the login dialog to the user.
        /// </summary>
        private void ShowLoginDialog()
        {
            dlgLogin = new LoginForm();
            dlgLogin.Show(this);
            dlgLogin.FormClosing += new FormClosingEventHandler(dlgLogin_FormClosing);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                AppSettings.Instance.SaveFile();

                if (person != null)
                    person.Save();
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
                currentTask = dlgAddTask.RecordInfo;
                textBox1.Text = currentTask.Task;
            }
        }

        private void OnClickFinishTask(object sender, EventArgs e)
        {
            if (currentTask != null)
            {
                AddTask dlgAddTask = new AddTask();
                dlgAddTask.Text = "Finish Current Task.";
                dlgAddTask.RecordInfo = currentTask;
                dlgAddTask.Comment = currentTask.Comment;
                dlgAddTask.Task = currentTask.Task;
                dlgAddTask.ButtonText = "Finish Task";
                if (dlgAddTask.ShowDialog() == DialogResult.OK)
                {
                    currentTask.Task = dlgAddTask.Task;
                    currentTask.Comment = dlgAddTask.Comment;
                    currentTask.Finish = DateTime.Now;
                    person.AddRecord(currentTask);
                    UpdateForm(person);
                    currentTask = null;
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
        /// Adds the task to the tree view.
        /// </summary>
        /// <param name="task"></param>
        private string FormatTreeViewString(Record task)
        {
            return task.Duration.ToString("F2")
                + " @"
                + task.Task 
                + " #" 
                + task.Comment;
        }

        /// <summary>
        /// Sets the Finish time for the current record and stores it on our person.
        /// </summary>
        private void FinishOffCurrentTask()
        {
            if (currentTask != null)
            {
                // TODO: Finish off the current task first;
                currentTask.Finish = DateTime.Now;
                person.AddRecord(currentTask);
                currentTask = null;
            }
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            currentTask.Start = currentTask.Finish = DateTime.Now;
        }

        private void buttonFinish_Click(object sender, EventArgs e)
        {
            currentTask.Finish = DateTime.Now;
        }
        #region treeViewRecords Events

        private void treeViewRecords_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Parent == null)
            {
                DateTime date = DateTime.Parse(e.Node.Text);                
                pieChartControl1.SetData(person.Records[date.ToString("d")]);
            }
            else
            {
                // Copies the comment to the clipbard to post to timesheet.
                var split = e.Node.Text.Split('#');
                string comment = split[split.Length - 1];
                Clipboard.SetText(comment);
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
                treeViewContextMenu.Items.Add("Post to Time Sheet.");
                treeViewContextMenu.ItemClicked += new ToolStripItemClickedEventHandler(treeViewContextMenu_ItemClicked);
            }
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                if (e.Node.Parent == null)
                {
                    return;
                }

                treeViewContextMenu.Show( treeViewRecords.PointToScreen(e.Location) );
                treeViewRecords.SelectedNode = e.Node;
            }
        }

        void treeViewContextMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Text == "Copy Comment")
            {
                var split = treeViewRecords.SelectedNode.Text.Split('#');
                string comment = split[split.Length - 1];
                Clipboard.SetText(comment);
            }
            else if (e.ClickedItem.Text == "Edit")
            {
                var record = person.Records[treeViewRecords.SelectedNode.Parent.Text][treeViewRecords.SelectedNode.Index];
                EditRecordForm erf = new EditRecordForm(record);
                if (erf.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    person.Records[treeViewRecords.SelectedNode.Parent.Text][treeViewRecords.SelectedNode.Index] = erf.Record;
                    UpdateForm(person);
                }
            }
            else if (e.ClickedItem.Text == "Post to Time Sheet.")
            {

            }
            treeViewContextMenu.Hide();
        }

        #endregion

        private void timerSecondUpdate_Tick(object sender, EventArgs e)
        {
            if (currentTask != null)
            {
                textBox1.Text = currentTask.Task + " : " + Math.Abs((DateTime.Now - currentTask.Start).TotalHours).ToString("F2");
            }
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (person != null)
                person.Save();

            ShowLoginDialog();
        }
    }
}
