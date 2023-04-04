using GeniyIdiot.Common;
using GeniyIdiotWinFormsApp;

namespace GeniyIdiotWinForm
{
    public partial class MainForm : Form
    {
        Game game;
        User user;
        IQuestionsStorage questionsStorageMethod;

        public MainForm()
        {
            InitializeComponent();
            this.questionsStorageMethod = new QuestionsStorageInJson();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            user = new User();
            game = new Game(user);

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

                if (MessageBox.Show(message + "\r\n ������� ������ ��������� �������� ?", "��� �������", MessageBoxButtons.OKCancel) == DialogResult.OK)
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

        private void ����������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GameStatistic gameStatistic = new GameStatistic();
            gameStatistic.ShowDialog();
        }

        private void �����ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ���������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutProgram aboutProgram = new AboutProgram();
            aboutProgram.ShowDialog();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            AddQuestion addquestion = new AddQuestion(questionsStorageMethod);
            addquestion.ShowDialog();
        }

        private void �������������������������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteQuestion deleteQuestion = new DeleteQuestion(questionsStorageMethod);
            deleteQuestion.ShowDialog();
        }
    }
}