using GeniyIdiot.Common;
using GeniyIdiotWinFormsApp;

namespace GeniyIdiotWinForm
{
    public partial class MainForm : Form
    {
        Game game;
        User user;
        IQuestionsStorage questionsStorage;
        IUserResultsStorage userResults;

        public MainForm()
        {
            InitializeComponent();
            this.questionsStorage = new QuestionsStorageInJson();
            this.userResults = new UserResultsStorageInJson();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            user = new User();
            game = new Game(user, questionsStorage);

            InputUsername inputUsername = new InputUsername();
            inputUsername.ShowDialog();

            user.Name = inputUsername.UserNameTextBox.Text;

            userAnswerNumericUpDown.Value = 0;
            questionsTextLabel.Text = game.GetNextQuestion().Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var userAnswer = userAnswerNumericUpDown.Value;

            game.AcceptAnswer(userAnswer);

            if (game.End())
            {
                user.PercentCorrectAnswers = game.CalculatePercentCorrectAnswers();
                var message = game.CalculateDiagnose(user);

                if (MessageBox.Show(message + "\r\n ∆елаете пройти викторину повторно ?", "¬аш диагноз", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    Application.Restart();
                } 
                else Close();

                return;
            }
            else
            {
                questionsTextLabel.Text = game.GetNextQuestion().Text;
                userAnswerNumericUpDown.Value = 0;
            }
        }

        private void результатыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GameStatistic gameStatistic = new GameStatistic(userResults);
            gameStatistic.ShowDialog();
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void оѕрограмеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutProgram aboutProgram = new AboutProgram();
            aboutProgram.ShowDialog();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            AddQuestion addquestion = new AddQuestion(questionsStorage);
            addquestion.ShowDialog();
        }

        private void удалить—уществующий¬опросToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteQuestion deleteQuestion = new DeleteQuestion(questionsStorage);
            deleteQuestion.ShowDialog();
        }
    }
}