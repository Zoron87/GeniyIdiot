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
    public partial class GameStatistic : Form
    {
        public GameStatistic()
        {
            InitializeComponent();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void GameStatistic_Load(object sender, EventArgs e)
        {
            var gameStatistic = UsersResultStorage.GetAll() ;

            foreach (var stat in gameStatistic)
            {
                var formatResult = Game.OutputFormatConsole(stat.Diagnose, stat.PercentCorrectAnswers.ToString("0.00"), stat.Name);
                dataGridView1.Rows.Add(stat.Diagnose, stat.PercentCorrectAnswers.ToString(), stat.Name);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int deleteSelectedRow = dataGridView1.SelectedCells[0].RowIndex;
            dataGridView1.Rows.RemoveAt(deleteSelectedRow);
        }
    }
}
