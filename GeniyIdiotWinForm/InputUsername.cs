using GeniyIdiot.Common;
using GeniyIdiotWinForm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeniyIdiotWinFormsApp
{
    public partial class InputUsername : Form
    {
        public InputUsername()
        {
            InitializeComponent();
        }

        private void SaveUsernameButton_Click(object sender, EventArgs e)
        {
            Form1.user.Name  = UserNameTextBox.Text;
            Close();
        }
    }
}
