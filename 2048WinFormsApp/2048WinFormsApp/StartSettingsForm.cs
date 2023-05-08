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
        public int mapSize;
        public StartSettingsForm()
        {
            InitializeComponent();
        }

        private void userNameButton_Click(object sender, EventArgs e)
        {
            userName = userNameTextBox.Text;
            var size = mapSizeComboBox.Text;

            switch (size)
            {
                case "4x4":
                    mapSize = 4;
                    break;

                case "5x5":
                    mapSize = 5;
                    break;

                case "6x6":
                    mapSize=6;
                    break;
            }

            if (ValidateChildren(ValidationConstraints.Enabled))
            {
                Close();
            }
        }

        private void UserNameForm_Load(object sender, EventArgs e)
        {
            userNameTextBox.Focus();
        }

        private void userNameTextBox_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(userNameTextBox.Text))
            {
                e.Cancel = true;
                userNameTextBox.Focus();
                errorProvider.SetError(userNameTextBox, "Пожалуйста введите ваше имя!");
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(userNameTextBox, null);
            }
        }
    }
}
