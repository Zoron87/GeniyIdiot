using System.Drawing;

namespace FruitNinjaWinFormsApp
{
    public partial class MainForm : Form
    {
        static Random random = new Random();
        List<FruitNinjaBall> fruitNinjaBalls = new List<FruitNinjaBall>();
        bool activeGame = false;

        PointF pointStartLine, pointEndLine;
        PointF intersection1, intersection2;

        private int x;
        private int y;

        bool mouseMove = false;

        public MainForm()
        {
            InitializeComponent();
        }

        private void startGameButton_Click(object sender, EventArgs e)
        {
            if (activeGame)
                Application.Restart();

            var randomFruitNinjaBall = random.Next(10, 15);

            for (int i=0; i< randomFruitNinjaBall; i++)
            {
                var fruitNinjaBall = new FruitNinjaBall(this);
                fruitNinjaBalls.Add(fruitNinjaBall);
                fruitNinjaBall.Start();
            }

            activeGame = true;
            startGameButton.Text = "Перезапустить игру";
        }

        private void MainForm_MouseDown(object sender, MouseEventArgs e)
        {
            pointStartLine = new System.Drawing.Point(e.X, e.Y);
        }

        private void mouseMoveButton_Click(object sender, EventArgs e)
        {
            if (mouseMove) mouseMove = false;
            else mouseMove = true;
        }

        private void MainForm_MouseUp(object sender, MouseEventArgs e)
        {
            pointEndLine = new PointF(e.X, e.Y);

            PointF[] pointsArr = { pointStartLine, pointEndLine };
            Graphics g = this.CreateGraphics();
            g.DrawLines(new Pen(Color.Black), pointsArr);

            foreach (var fruitNinjaBall in fruitNinjaBalls)
            {
                int NumIntersections = FindLineCircleIntersections(fruitNinjaBall.GetCenterX(), fruitNinjaBall.GetCenterY(), fruitNinjaBall.GetRadius(), 
                    pointStartLine, pointEndLine, out intersection1, out intersection2);

                if (NumIntersections == 2)
                {
                    var lineVector = pointStartLine.X - pointEndLine.X;
                    var findVectorIntersection = intersection1.X - intersection2.X;

                    if (lineVector < 0)
                    {
                        if (findVectorIntersection > 0)
                        {
                            var temp = intersection1;
                            intersection1 = intersection2;
                            intersection2 = temp;
                        }
                    }
                    else
                    {
                        if (findVectorIntersection <= 0)
                        {
                            var temp = intersection1;
                            intersection1 = intersection2;
                            intersection2 = temp;
                        }
                    }

                    if ((intersection1.X >= pointStartLine.X && intersection2.X <= pointEndLine.X)
                        || (intersection1.X <= pointStartLine.X && intersection2.X >= pointEndLine.X))
                    {
                        fruitNinjaBall.Stop();
                        fruitNinjaBall.Clear();
                    }

                    scoreLabel.Text = (Convert.ToInt32(scoreLabel.Text) + 1).ToString();
                }
            }
            g.DrawLines(new Pen(this.BackColor), pointsArr);
        }

        public static int FindLineCircleIntersections(float cx, float cy, float radius,
            PointF point1, PointF point2, out PointF intersection1, out PointF intersection2)
        {
            float dx, dy, A, B, C, det, t;

            dx = point2.X - point1.X;
            dy = point2.Y - point1.Y;

            A = dx * dx + dy * dy;
            B = 2 * (dx * (point1.X - cx) + dy * (point1.Y - cy));
            C = (point1.X - cx) * (point1.X - cx) + (point1.Y - cy) * (point1.Y - cy) - radius * radius;

            det = B * B - 4 * A * C;
            if ((A <= 0.0000001) || (det < 0))
            {
                // No real solutions.
                intersection1 = new PointF(float.NaN, float.NaN);
                intersection2 = new PointF(float.NaN, float.NaN);
                return 0;
            }
            else if (det == 0)
            {
                // One solution.
                t = -B / (2 * A);
                intersection1 = new PointF(point1.X + t * dx, point1.Y + t * dy);
                intersection2 = new PointF(float.NaN, float.NaN);
                return 1;
            }
            else
            {
                // Two solutions.
                t = (float)((-B + Math.Sqrt(det)) / (2 * A));
                intersection1 = new PointF(point1.X + t * dx, point1.Y + t * dy);
                t = (float)((-B - Math.Sqrt(det)) / (2 * A));
                intersection2 = new PointF(point1.X + t * dx, point1.Y + t * dy);

                return 2;
            }
        }


    }
}