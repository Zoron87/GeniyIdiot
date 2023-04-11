using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2048WinFormsApp
{
    public partial class StartSettingsForm : Form
    {
        public string userName;
        public StartSettingsForm()
        {
            InitializeComponent();
        }

        private void userNameButton_Click(object sender, EventArgs e)
        {
            userName = userNameTextBox.Text;
            Close();
        }

        private void UserNameForm_Load(object sender, EventArgs e)
        {
            userNameTextBox.Focus();
        }
    }
}
