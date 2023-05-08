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
        public float vy;
        Brush[] brushesColor = new Brush[] { Brushes.Black, Brushes.Aqua, Brushes.Green, Brushes.Red, Brushes.Blue, Brushes.Magenta, Brushes.Brown, Brushes.Cyan, Brushes.Yellow };
        public FruitNinjaBall(Form form) : base(form)
        {
            radius = random.Next(20, 40);
            var startFromDown = centerY = form.ClientSize.Height;
            this.vy = -random.Next(150, 200);
            vx = random.Next(1,3);
            brush = brushesColor[random.Next(brushesColor.Length)];
        }

        public void SetDefaultSpeed()
        {
            this.vy = -random.Next(80, 90);
        }

        public void SetSlowSpeed()
        {
            this.vy = -random.Next(30, 50);
        }
    }
}
