using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonWinFormsLibrary
{
    public class SparkBall : MoveBall
    {
        private float g = 0.2f;
        public Brush brush;

        public SparkBall(Form form, float centerX, float centerY) : base(form)
        {
            this.centerX = centerX;
            this.centerY = centerY;
            radius = random.Next(3, 10);
            brush = new SolidBrush(Color.FromArgb((byte)random.Next(1, 255), (byte)random.Next(1, 255), (byte)random.Next(1, 233)));

            vy = -Math.Abs(vy);
        }

        public SparkBall(Form form) : base(form)
        {
            radius = random.Next(3, 10);
            brush = new SolidBrush(Color.FromArgb((byte)random.Next(1, 255), (byte)random.Next(1, 255), (byte)random.Next(1, 233)));

            vy = -Math.Abs(vy);
        }

        protected override void Go()
        {
            base.Go();
            vy += g;
        }
        public override void Show()
        {
            Init(brush);
        }
    }
}
