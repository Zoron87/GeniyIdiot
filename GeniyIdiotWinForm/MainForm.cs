using GeniyIdiot.Common;
using GeniyIdiotWinFormsApp;

namespace GeniyIdiotWinForm
{
    public partial class Form1 : Form
    {
        private List<Question> questions;
        private Question currentQuestion;
        public static User user;
        private Diagnose diagnose;
        private int countRightAnswers;
        private int questionsCounter = -1;
        private decimal userAnswer = -1;

        private readonly ErrorProvider _errorProvider1;

        public Form1()
        {
            InitializeComponent();

            _errorProvider1 = new ErrorProvider(this);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            user = new User();
            diagnose = new Diagnose();
            questions = QuestionsStorage.GetAll().ToList();

            InputUsername inputUsername = new InputUsername();
            inputUsername.ShowDialog();

            ShowNextQuestion();
        }

        private void ShowNextQuestion()
        {
            userAnswerNumericUpDown.Value = 0;
            questionsCounter++;
            questionsTextLabel.Text = questions[questionsCounter].Text;

            questionNumberLabel.Text = "Âîïğîñ ¹" + Convert.ToInt32(questionsCounter + 1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            userAnswer = userAnswerNumericUpDown.Value;

            if (userAnswer == questions[questionsCounter].Answer)
            {
                countRightAnswers++;
            }

            var endGame = questionsCounter == questions.Count-1;

            if (endGame)
            {
                user.PercentCorrectAnswers = (double)countRightAnswers / questions.Count * 100;

                user.Diagnose = diagnose.Calc(user);

                UsersResultStorage.SaveAll(user);

                MessageBox.Show(user.Name + ", Âàø äèàãíîç - " + user.Diagnose);

                Close();
                return;
            }

            ShowNextQuestion();
        }

        private void ğåçóëüòàòûToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GameStatistic gameStatistic = new GameStatistic();
            gameStatistic.ShowDialog();
        }

        private void âûõîäToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void îÏğîãğàìåToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutProgram aboutProgram = new AboutProgram();
            aboutProgram.ShowDialog();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            AddQuestion addquestion = new AddQuestion();
            addquestion.ShowDialog();
        }

        private void óäàëèòüÑóùåñòâóşùèéÂîïğîñToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteQuestion deleteQuestion = new DeleteQuestion();
            deleteQuestion.ShowDialog();
        }
    }
}