using System;
using System.Collections.Generic;
using System.Windows.Forms;

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

            ShowLoginDialog();
        }


        void dlgLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            dlgLogin.FormClosing -= dlgLogin_FormClosing;

            if (!dlgLogin.IsFilledOut)
            {
                person = new Person("unknown", "unknown");
                return;
            }

            person = new Person(dlgLogin.UserName, dlgLogin.Password);
            try
            {
                person.Load();
            }
            catch(System.Exception) 
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
            //SaveRecordsBinary("test.xml.bin");
            //SaveRecordsSoap("SoapTest.xml");

            if (person != null)
                person.Save();

            //if (person == null)
            //    return;
            //try
            //{

            //    using (FileStream fs = File.Open(person.FileName, FileMode.Create ))
            //    {
            //        XmlSerializer xml = new XmlSerializer(person.GetType());
            //        xml.Serialize(fs, person);
            //    }
            //}
            //catch(Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}
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
            float duration = task.Duration.Hours;
            duration += (task.Duration.Minutes / 60f);
            return duration.ToString("F2")
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

        private void treeViewRecords_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Parent == null)
            {
                DateTime date = DateTime.Parse(e.Node.Text);
                double totalHours = 0;
                foreach (var item in person.Records[date.ToString("d")])
                {
                    totalHours += Math.Abs(item.Duration.TotalHours);
                }

                List<float> data = new List<float>();
                List<string> tasks = new List<string>();
                foreach (var item in person.Records[date.ToString("d")])
                {
                    data.Add((float)(Math.Abs(item.Duration.TotalHours) / totalHours));
                    tasks.Add(item.Task);
                }

                pieChartControl1.SetData(data.ToArray(), tasks.ToArray());
            }
            else
            {
                // Copies the comment to the clipbard to post to timesheet.
                var split = e.Node.Text.Split('#');
                string comment = split[split.Length - 1];
                Clipboard.SetText(comment);
            }
        }

        private void timerSecondUpdate_Tick(object sender, EventArgs e)
        {
            if (currentTask != null)
            {
                textBox1.Text = currentTask.Task + " : " + Math.Abs((DateTime.Now - currentTask.Start).TotalHours).ToString("F2");
            }
        }
    }
}
