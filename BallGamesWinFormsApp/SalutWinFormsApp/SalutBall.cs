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
        float deltaLifeTime;
        Form form;

        float lifeTime;
        public SalutBall(Form form) : base(form)
        {
            this.form = form;
            centerY = form.ClientSize.Height;
            centerX = random.Next(8, 10);
            vy = -10;
            lifeTime = random.Next(5, 6);
            deltaLifeTime = (float)random.NextDouble();
        }

        protected override void Go()
        {
            base.Go();

            lifeTime -= deltaLifeTime;

            if (lifeTime <= 0)
            {
                for (int i=0; i<5; i++)
                {
                    var sparkBall = new SparkBall(form, this.centerX, this.centerY);
                }
            }
        }
    }
}
