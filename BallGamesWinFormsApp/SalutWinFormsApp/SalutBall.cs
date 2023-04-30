using CommonWinFormsLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalutWinFormsApp
{
    public class SalutBall : MoveBall
    {
        static Random random = new Random();
        Form form;

        public SalutBall(Form form) : base(form)
        {
            this.form = form;
            var startFromDown = centerY = form.ClientSize.Height;

            vy = -random.Next(5,15);
            vx = 1;

            radius = 18;
        }

        public float GetCenterY()
        {
            return centerY;
        }

        public float GetCenterX()
        {
            return centerX;
        }

        protected override void Timer_Tick(object? sender, EventArgs e)
        {
            base.Move();

            var randomMaxHeight = random.Next((int)(form.ClientSize.Height * 0.1), (int)(form.ClientSize.Height * 0.3));

            if (centerY <= randomMaxHeight)
            {
                Clear();
                Stop();

                var randomSparkBall = random.Next(20, 30);

                for (int i = 0; i < randomSparkBall; i++)
                {
                    var sparkBall = new SparkBall(form, this.centerX, this.centerY);
                }
            }
        }
    }
}
