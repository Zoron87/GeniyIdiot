using CommonWinFormsLibrary;

namespace BillyardBallsWinFormsApp
{
    public partial class MainForm : Form
    {
        private MainForm form;
        private Random random = new Random();
        bool isMove = false;
        bool activeGame = false;

        List<BillyardBall> balls = new List<BillyardBall>();

        public MainForm()
        {
            InitializeComponent();
        }

        private void Ball_OnHited(object? sender, HitEventArgs e)
        {
            switch (e.Side)
            {
                case Side.GreenLeft:
                    leftGreenLabel.Text = (Convert.ToInt32(leftGreenLabel.Text) + 1).ToString();
                    break;

                case Side.BlueLeft:
                    leftBlueLabel.Text = (Convert.ToInt32(leftBlueLabel.Text) + 1).ToString();
                    break;

                case Side.GreenRight:
                    rightGreenLabel.Text = (Convert.ToInt32(rightGreenLabel.Text) + 1).ToString();
                    break;

                case Side.BlueRight:
                    rightBlueLabel.Text = (Convert.ToInt32(rightBlueLabel.Text) + 1).ToString();
                    break;

                case Side.GreenTop:
                    topGreenLabel.Text = (Convert.ToInt32(topGreenLabel.Text) + 1).ToString();
                    break;

                case Side.BlueTop:
                    topBlueLabel.Text = (Convert.ToInt32(topBlueLabel.Text) + 1).ToString();
                    break;

                case Side.GreenDown:
                    downGreenLabel.Text = (Convert.ToInt32(downGreenLabel.Text) + 1).ToString();
                    break;

                case Side.BlueDown:
                    downBlueLabel.Text = (Convert.ToInt32(downBlueLabel.Text) + 1).ToString();
                    break;
            }
        }

        private void downLabel_Paint(object sender, PaintEventArgs e)
        {
            if (!activeGame)
            {
                var rndNumberBalls = random.Next(5, 10);

                for (int i = 0; i < 2 * rndNumberBalls; i++)
                {
                    var ball = new BillyardBall(this);
                    ball.OnHited += Ball_OnHited;

                    if (i % 2 == 0)
                    {
                        ball.ChooseSide("Left");
                        ball.brush = Brushes.Green;
                    }
                    else
                    {
                        ball.ChooseSide("Right");
                        ball.brush = Brushes.Blue;
                    }
                    ball.Show();
                    balls.Add(ball);
                }
            }

            var brush = Brushes.Black;
            var pen = new Pen(brush, 2);
            pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            var graphics = this.CreateGraphics();
            graphics.DrawLine(pen, this.ClientSize.Width / 2, 0, this.ClientSize.Width / 2, this.ClientSize.Height);

            activeGame = true;
        }

        private void MainForm_Click(object sender, EventArgs e)
        {
            if (!isMove)
            {
                balls.ForEach(b => b.Start());
                
                isMove = true;
            }
            else
            {
                balls.ForEach(b => b.Stop());

                isMove = false;
            }

            billyardTimer.Start();
        }

        public void CheckFullMixBalls()
        {
            var centerForm = this.ClientSize.Width / 2;
            var greenBallsLeftCount = 0;
            var blueBallsLeftCount = 0;
            var greenBallsRightCount = 0;
            var blueBallsRightCount = 0;

            foreach (var ball in balls)
            {
                if (ball.CenterX() < centerForm)
                {
                    if (ball.brush == Brushes.Green)
                        greenBallsLeftCount++;
                    if (ball.brush == Brushes.Blue)
                        blueBallsLeftCount++;
                }

                if (ball.CenterX() > centerForm)
                {
                    if (ball.brush == Brushes.Green)
                        greenBallsRightCount++;
                    if (ball.brush == Brushes.Blue)
                        blueBallsRightCount++;
                }
            }

            if (greenBallsLeftCount == blueBallsLeftCount && greenBallsRightCount == blueBallsRightCount)
            {
                balls.ForEach(b => b.Stop());

                billyardTimer.Stop();
                MessageBox.Show("Диффузия свершилась!");
            }
        }

        private void billyardTimer_Tick(object sender, EventArgs e)
        {
            CheckFullMixBalls();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }
    }
}