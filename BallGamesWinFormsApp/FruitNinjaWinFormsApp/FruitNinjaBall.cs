using CommonWinFormsLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace FruitNinjaWinFormsApp
{
    public class FruitNinjaBall : SparkBall
    {
        Brush[] brushesColor = new Brush[] { Brushes.Black, Brushes.Aqua, Brushes.Green, Brushes.Red, Brushes.Blue, Brushes.Magenta, Brushes.Brown, Brushes.Cyan };
        public FruitNinjaBall(Form form) : base(form)
        {
            radius = random.Next(20, 40);
            var startFromDown = centerY = form.ClientSize.Height;
            vy = -random.Next(10, 20);
            vx = random.Next(1,3);
            brush = brushesColor[random.Next(brushesColor.Length)];
        }

        public bool IsPointOnBorder(int x, int y)
        {
            return Math.Pow(x - this.centerX, 2) + Math.Pow(y - this.centerY, 2) <= Math.Pow(this.radius, 2);
        }
    }
}
