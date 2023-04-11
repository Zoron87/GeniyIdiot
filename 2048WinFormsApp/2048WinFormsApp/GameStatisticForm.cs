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
    public partial class GameStatisticForm : Form
    {
        private IUserResultsStorage userResults = new UserResultsStorageJson();
        public GameStatisticForm()
        {
            InitializeComponent();
        }

        private void GameStatisticForm1_Load(object sender, EventArgs e)
        {
            var allStatistics = userResults.GetAll();

            foreach (var stat in allStatistics)
            {
                userResultsDataGridView.Rows.Add(stat.Name, stat.Score);
            }
        }
    }
}
