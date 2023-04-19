namespace Task72WinFormsApp
{
    public partial class MainForm : Form
    {
        int counterCatchBalls = 0;
        bool activeGame = false;

        Random random = new Random();
        List<MoveBall> moveBalls = new List<MoveBall>();

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
                moveBalls.Add(moveBall);
                moveBall.Show();
            }

            activeGame = true;
            startGameButton.Text = "Перезапустить";
        }

        private void MainForm_MouseClick(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < moveBalls.Count; i++)
            {
                if (moveBalls[i].isBallClick(moveBalls[i], e.X, e.Y))
                {
                    moveBalls[i].Stop();
                    moveBalls[i].Recolor();
                    counterCatchBalls++;

                    countBallsLabel.Text = counterCatchBalls.ToString();
                }
                   
            }
            
        }
    }
}