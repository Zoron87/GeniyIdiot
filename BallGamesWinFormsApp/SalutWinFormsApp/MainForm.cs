namespace SalutWinFormsApp
{
    public partial class MainForm : Form
    {
        Random random = new Random();
        SparkBall sparkBall;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_MouseDown(object sender, MouseEventArgs e)
        {
            var rndSparkBalls = random.Next(5, 10);

            for (int i = 0; i < rndSparkBalls; i++)
            {
                sparkBall = new SparkBall(this, e.X, e.Y);
                sparkBall.Start();
            }
        }
    }
}