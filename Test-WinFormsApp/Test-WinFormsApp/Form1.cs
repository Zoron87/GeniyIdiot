namespace Test_WinFormsApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var graphics = CreateGraphics();
            Brush brush = Brushes.Aqua;
            Rectangle rectangle = new Rectangle(100, 100, 150, 150);
            graphics.FillEllipse(brush, rectangle);
        }
    }
}