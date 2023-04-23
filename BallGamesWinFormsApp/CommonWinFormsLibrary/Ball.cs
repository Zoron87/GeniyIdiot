using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timer = System.Windows.Forms.Timer;

namespace CommonWinFormsLibrary
{
    public class Ball
    {
        protected Random random = new Random();
        Timer timer = new Timer();

        private Form form;

        protected int centerX = 10;
        protected int centerY = 10;
        protected int radius = 25;

        protected int vx = 1;
        protected int vy = 1;

        public Ball(Form form)
        {
            this.form = form;
            timer.Start();
            timer.Tick += Timer_Tick;
        }

        public void Move()
        {
            Clear();
            Go();
            Show();
        }

        public void Show()
        {
            Init(Brushes.Aqua);
        }

        public bool IsMoveable()
        {
            return timer.Enabled;
        }

        public bool IsBallClick(int x, int y)
        {
            var clickInBall = Math.Pow(x - centerX, 2) + Math.Pow(y - centerY, 2) <= Math.Pow(radius, 2);

            return clickInBall;
        }

        public int RightSide()
        {
            return form.ClientSize.Width - radius;
        }

        public int TopSide()
        {
            return radius;
        }

        public int DownSide()
        {
            return form.ClientSize.Height - radius;
        }

        public int LeftSide()
        {
            return radius;
        }

        public bool IsCatchOnForm()
        {
            return centerX <= RightSide() && centerY <= DownSide() && centerX >= LeftSide() && centerY >= TopSide();
        }

        public void Init(Brush brush)
        {
            if (brush == null) brush = Brushes.Aqua;
            var graphics = form.CreateGraphics();
            Rectangle rectangle = new Rectangle(centerX - radius, centerY - radius, 2 * radius, 2* radius);
            graphics.FillEllipse(brush, rectangle);
        }

        public void Recolor()
        {
            Init(Brushes.Gray);
        }

        public void Start()
        {
            timer.Start();
        }

        public void Stop()
        {
            timer.Stop();
        }

        protected virtual void Go()
        {
            centerX += vx;
            centerY += vy;
        }

        private void Clear()
        {
            Init(new SolidBrush(form.BackColor));
        }

        private void Timer_Tick(object? sender, EventArgs e)
        {
            Move();
        }
    }
}
