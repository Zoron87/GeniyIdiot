﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Geniyidiot;

namespace Geniyidiot
{
    public partial class mainForm : Form
    {
        public mainForm()
        {
            InitializeComponent();
        }

        private void userAnswerTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void questionNumberLabel_Click(object sender, EventArgs e)
        {

        }

        private void mainForm_Load(object sender, EventArgs e)
        {
            var questions = QuestionsStorage;
        }
    }
}