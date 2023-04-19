using CommonWinFormsLibrary;

namespace BallGamesWinFormsApp
{
    public partial class MainForm : Form
    {
        Random random = new Random();
        bool activeGame = false;

        List<MoveBall> moveBalls;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_MouseClick(object sender, MouseEventArgs e)
        {
            var pointBall = new PointBall(this, e.X, e.Y);
            pointBall.Show();
        }

        private void createBallsButton_Click(object sender, EventArgs e)
        {
            if (activeGame)
                Application.Restart();

            moveBalls = new List<MoveBall>();
            var numberBalls = random.Next(5, 10);

            for (int i = 0; i < numberBalls; i++)
            {
                var moveBall = new MoveBall(this);
                moveBalls.Add(moveBall);
                moveBall.Start();
            }

            createBallsButton.Text = "Перезагрузить";
            activeGame = true;
        }

        private void stopMoveButton_Click(object sender, EventArgs e)
        {
            if (activeGame)
            {
               moveBalls.ForEach(b => b.Stop());

               catchBallsNumberLabel.Text = moveBalls.Where(b => b.isCatchOnForm()).Count().ToString(); 
            }
            else MessageBox.Show("Сначала нажмите кнопку 'Создать'!");
        }
    }
}