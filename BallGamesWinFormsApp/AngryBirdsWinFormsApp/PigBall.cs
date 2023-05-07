using CommonWinFormsLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngryBirdsWinFormsApp
{
    public class PigBall : Ball
    {
        public PigBall(Form form) : base(form)
        {
            brush = Brushes.Red;
            radius = random.Next(10, 30);

            var scoreLabelWidth = 100;
            var scoreLabelHeight = 30;

            centerX = random.Next(radius + scoreLabelWidth, form.ClientSize.Width - radius - scoreLabelWidth);
            centerY = random.Next(radius + scoreLabelHeight, form.ClientSize.Height - radius - scoreLabelHeight);

            Init(brush);
            Stop();
        }

        public void Destroy()
        {
            radius = 0;
        }

        public bool IsIntersect(Ball other)
        {
            return Math.Pow(this.centerX - other.GetCenterX(), 2) + Math.Pow(this.centerY - other.GetCenterY(), 2) <= Math.Pow(this.radius + other.GetRadius(), 2);
        }
    }
}

