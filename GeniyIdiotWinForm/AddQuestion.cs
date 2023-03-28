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
            var questions = QuestionsStorage.GetAll().ToList();

            var questionText = questionTextBox.Text;
            var answerText = int.Parse(answerNumericUpDown.Text);

            questions.Add(new Question(questionText, answerText));

            QuestionsStorage.SaveAll(questions);

            MessageBox.Show("Ваш вопрос успешно добавлен!");

            Close();
        }
    }
}
