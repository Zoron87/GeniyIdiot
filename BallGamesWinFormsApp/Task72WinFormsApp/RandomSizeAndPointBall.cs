using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task72WinFormsApp
{
    public class RandomSizeAndPointBall : Ball
    {
        public RandomSizeAndPointBall(MainForm form) : base(form)
        {
            x = random.Next(0, form.ClientSize.Width);
            y = random.Next(0, form.ClientSize.Height);
            size = random.Next(30, 100);

            vx = random.Next(-10, 10);
            vy = random.Next(-10, 10);
        }
    }
}
