using CommonWinFormsLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalutWinFormsApp
{
    public class SparkBall : MoveBall
    {
        private float g = 0.2f;

        public SparkBall(Form form, float centerX, float centerY) : base(form)
        {
            this.centerX = centerX;
            this.centerY = centerY;

            vy = -Math.Abs(vy);
            radius = 15;
        }

        protected override void Go()
        {
            base.Go();
            vy += g;
        }
    }
}
