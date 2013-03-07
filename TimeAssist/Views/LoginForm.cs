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
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            if (!IsFilledOut)
            {
                MessageBox.Show("Please fill out a name and password.", "Error!", MessageBoxButtons.OK);
                return;
            }

            this.Close();
        }

        public string UserName { get { return textBoxUserName.Text; } }
        public string Password { get { return textBoxPassword.Text; } }
        public bool IsFilledOut { get { return textBoxUserName.Text.Length > 0 && textBoxPassword.Text.Length > 0; } }
        public bool RememberMe { get { return checkBoxRememberMe.Checked; } }
    }
}
