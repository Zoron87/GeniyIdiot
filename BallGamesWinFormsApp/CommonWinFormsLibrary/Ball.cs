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
        protected Timer timer = new Timer();

        private Form form;
        private Brush brush;

        protected float centerX = 10;
        protected float centerY = 10;
        protected int radius = 25;

        protected float vx = 1;
        protected float vy = 1;

        public Ball(Form form)
        {
            this.form = form;
            timer.Start();
            timer.Tick += Timer_Tick;
        }


        public float GetCenterY()
        {
            return centerY;
        }

        public float GetCenterX()
        {
            return centerX;
        }

        public float GetRadius()
        {
            return radius;
        }

        public virtual void Move()
        {
            Clear();
            Go();
            Show();
        }

        public virtual void Show()
        {
            Init(Brushes.Aqua);
        }

        public bool IsMoveable()
        {
            return timer.Enabled;
        }

        public bool IsBallClick(float x, float y)
        {
            var clickInBall = Math.Pow(x - centerX, 2) + Math.Pow(y - centerY, 2) <= Math.Pow(radius, 2)*1.1;

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
            var rectangle = new RectangleF(centerX - radius, centerY - radius, 2 * radius, 2* radius);
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

        public void ChooseSide(string side)
        {
            switch (side)
            {
               case "Left":
                    centerX = random.Next(LeftSide(), form.ClientSize.Width /2 - radius);
                    brush = Brushes.Green;
                    break;

                case "Right":
                    centerX = random.Next(form.ClientSize.Width / 2 + radius, RightSide());
                    brush = Brushes.Blue;
                    break;
            }
        }

        protected virtual void Go()
        {
            centerX += vx;
            centerY += vy;
        }

        public void Clear()
        {
            Init(new SolidBrush(form.BackColor));
        }

        protected virtual void Timer_Tick(object? sender, EventArgs e)
        {
            Move();
        }
    }
}
