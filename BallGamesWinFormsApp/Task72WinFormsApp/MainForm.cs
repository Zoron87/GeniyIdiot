using CommonWinFormsLibrary;

namespace Task72WinFormsApp
{
    public partial class MainForm : Form
    {
        int counterCatchBalls = 0;
        bool activeGame = false;

        Random random = new Random();
        List<Ball> balls = new List<Ball>();

        public MainForm()
        {
            InitializeComponent();
        }

        private void startGameButton_Click(object sender, EventArgs e)
        {
            if (activeGame)
                Application.Restart();

            var numberBalls = random.Next(5, 10);

            for (int i = 0; i < numberBalls; i++)
            {
                var moveBall = new MoveBall(this);
                balls.Add(moveBall);
                moveBall.Show();
            }

            activeGame = true;
            startGameButton.Text = "Перезапустить";
        }

        private void MainForm_MouseClick(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < balls.Count; i++)
            {
                if (balls[i].IsBallClick(e.X, e.Y) && balls[i].IsCatchOnForm() && balls[i].IsMoveable())
                {
                    balls[i].Stop();
                    balls[i].Recolor();
                    counterCatchBalls++;

                    countBallsLabel.Text = counterCatchBalls.ToString();
                }
                   
            }
            
        }
    }
}