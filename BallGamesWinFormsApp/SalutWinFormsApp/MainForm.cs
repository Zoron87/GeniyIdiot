using Timer = System.Windows.Forms.Timer;

namespace SalutWinFormsApp
{
    public partial class MainForm : Form
    {
        Random random = new Random();
        SalutBall salutBall;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_MouseDown(object sender, MouseEventArgs e)
        {

            var rndSalutBalls = random.Next(6, 10);

            for (int i = 0; i < rndSalutBalls; i++)
            {
                salutBall = new SalutBall(this);
                salutBall.Start();
            }
        }
    }
}