using CommonWinFormsLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillyardBallsWinFormsApp
{
    public class BillyardBall : MoveBall
    {
        public Brush brush;
        public event EventHandler<HitEventArgs> OnHited;

    public BillyardBall(Form form) : base(form)
        {
            timer.Enabled = false;

            radius = random.Next(10, 20);

            vx = random.Next(-15, 15);
            vy = random.Next(-15, 15);
        }

        protected override void Go()
        {
            base.Go();

            if (brush == Brushes.Green)
            {
                if (centerX <= LeftSide())
                {
                    vx = -vx;
                    OnHited.Invoke(this, new HitEventArgs(Side.GreenLeft));
                }

                if (centerX >= RightSide())
                {
                    vx = -vx;
                    OnHited.Invoke(this, new HitEventArgs(Side.GreenRight));
                }

                if (centerY <= TopSide())
                {
                    vy = -vy;
                    OnHited.Invoke(this, new HitEventArgs(Side.GreenTop));
                }

                if (centerY >= DownSide())
                {
                    vy = -vy;
                    OnHited.Invoke(this, new HitEventArgs(Side.GreenDown));
                }
            }

            if (brush == Brushes.Blue)
            {
                if (centerX <= LeftSide())
                {
                    vx = -vx;
                    OnHited.Invoke(this, new HitEventArgs(Side.BlueLeft));
                }

                if (centerX >= RightSide())
                {
                    vx = -vx;
                    OnHited.Invoke(this, new HitEventArgs(Side.BlueRight));
                }

                if (centerY <= TopSide())
                {
                    vy = -vy;
                    OnHited.Invoke(this, new HitEventArgs(Side.BlueTop));
                }

                if (centerY >= DownSide())
                {
                    vy = -vy;
                    OnHited.Invoke(this, new HitEventArgs(Side.BlueDown));
                }
            }
        }

        public override void Show()
        {
            Init(brush);
        }

        public int CenterX()
        {
            return centerX;
        }

        public int CenterY()
        {
            return centerY;
        }


        protected virtual void Timer_Tick(object? sender, EventArgs e)
        {
            Move();
        }
    }
}
