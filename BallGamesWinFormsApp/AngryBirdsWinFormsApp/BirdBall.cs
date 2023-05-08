using CommonWinFormsLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngryBirdsWinFormsApp
{
    public class BirdBall : MoveBall
    {
        Form form;
        private float g = 0.6f;

        public BirdBall(Form form) : base(form)
        {
            this.form = form;
            this.brush = Brushes.Green;
            this.radius = random.Next(25, 30);
            this.centerX = radius;
            this.centerY = form.ClientSize.Height - radius;

            Stop();
            Show();
        }

        public override void Show()
        {
            Init(brush);
        }

        public void BackToRoot()
        {
            this.centerX = radius;
            this.centerY = form.ClientSize.Height - radius;

            Show();
            Stop();
        }

        public void SetSpeed(float vx, float vy)
        {
            this.vx = vx;
            this.vy = -vy;
        }

        protected override void Go()
        {
            base.Go();

            vy += g;
        }

        protected override void Timer_Tick(object? sender, EventArgs e)
        {
            base.Move();
            
            if (this.centerY >= this.DownSide())
            {
                SlowDown();
            }
        }

        public void SlowDown()
        {
            vy = (float)(-vy / 1.6);
            vx = (float)(vx / 1.6);

            if (Math.Abs(vx) <= 1) vx = 0;
            if (Math.Abs(vy) <= 1) vy = 0;
        }

        public bool IsOutOverField()
        {
            return this.centerX > form.ClientSize.Width + 2 * radius;
        }

        public bool IsStop()
        {
            return vx == 0 && vy == 0;
        }
    }
}
