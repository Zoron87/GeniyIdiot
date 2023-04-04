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
    public partial class DeleteQuestion : Form
    {
        private List<Question> questions;
        IQuestionsStorage questionsStorage;

        public DeleteQuestion(IQuestionsStorage questionsStorage)
        {
            InitializeComponent();
            this.questionsStorage = questionsStorage;
        }

        private void DeleteQuestion_Load(object sender, EventArgs e)
        {
            questionGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            questionGridView.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            questions = questionsStorage.GetAll();

            questions.ToList().ForEach(q => questionGridView.Rows.Add(q.Text, q.Answer));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (questionGridView.SelectedRows.Count > 0)
            {
                var row = questionGridView.SelectedRows[0].Index;

                if (row < questions.Count)
                {
                    questionGridView.Rows.RemoveAt(row);

                    questionsStorage.Delete(questions[row]);

                    MessageBox.Show("Выбранный вопрос успешно удален!");
                }
                else MessageBox.Show("Выберите не пустую строку");
            }
            else MessageBox.Show("Выберите строку для удаления!");
        }
    }
}
