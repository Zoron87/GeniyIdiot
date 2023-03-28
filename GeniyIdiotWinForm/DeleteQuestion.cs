﻿using GeniyIdiot.Common;
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

        public DeleteQuestion()
        {
            InitializeComponent();
        }

        private void DeleteQuestion_Load(object sender, EventArgs e)
        {
            questionGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            questionGridView.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            questions = QuestionsStorage.GetAll().ToList();
            foreach (var question in questions)
            {
                questionGridView.Rows.Add(question.Text, question.Answer);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (questionGridView.SelectedRows.Count > 0)
            {
                var row = questionGridView.SelectedRows[0].Index;

                if (row < questions.Count)
                {
                    questionGridView.Rows.RemoveAt(row);

                    questions.RemoveAt(row);
                    QuestionsStorage.SaveAll(questions);

                    MessageBox.Show("Выбранный вопрос успешно удален!");
                }
                else MessageBox.Show("Выберите не пустую строку");
            }
            else MessageBox.Show("Выберите строку для удаления!");
        }
    }
}