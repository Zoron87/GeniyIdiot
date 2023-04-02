using GeniyIdiot.Common;
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

    public partial class AddQuestion : Form
    {
        public AddQuestion()
        {
            InitializeComponent();
        }

        private void addQuestionButton_Click(object sender, EventArgs e)
        {
            var questionText = questionTextBox.Text;
            var answerText = int.Parse(answerNumericUpDown.Text);

            QuestionsStorage.AddQuestion(new Question(questionText, answerText));

            MessageBox.Show("Ваш вопрос успешно добавлен!");

            Close();
        }
    }
}
