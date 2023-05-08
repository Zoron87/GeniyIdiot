namespace AngryBirdsWinFormsApp
{
    public partial class MainForm : Form
    {
        BirdBall birdBall;
        PigBall pigBall;
        bool ballMove = false;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_MouseClick(object sender, MouseEventArgs e)
        {
            if (!ballMove)
            {
                ballMove = true;

                birdBall.SetSpeed(e.X / 20, (this.ClientSize.Height - e.Y) / 20);

                birdBall.Start();
                birdBall.Move();
            }
        }

        private void MainForm_Paint(object sender, PaintEventArgs e)
        {
            StartGame();

            gameTimer.Start();
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            if (pigBall.IsIntersect(birdBall) && pigBall.GetRadius() != 0)
            {
                pigBall.Clear();
                pigBall.Stop();
                pigBall.Destroy();

                scoreLabel.Text = (Convert.ToInt32(scoreLabel.Text) + 1).ToString();
            }

            if (pigBall.GetRadius() == 0 && (birdBall.IsStop() || birdBall.IsOutOverField()))
            {
                birdBall.Stop();
                birdBall.Clear();

                StartGame();
            }

            if (birdBall.IsOutOverField() || birdBall.IsStop())
            {
                birdBall.Clear();
                birdBall.BackToRoot();

                ballMove = false;
            }
        }

        public void StartGame()
        {
            birdBall = new BirdBall(this);
            pigBall = new PigBall(this);

            ballMove = false;
        }

    }
}