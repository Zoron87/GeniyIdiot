using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonWinFormsLibrary
{
    public class RandomSizeAndPointBall : Ball
    {
        public RandomSizeAndPointBall(Form form) : base(form)
        {
            centerX = random.Next(LeftSide(), RightSide());
            centerY = random.Next(TopSide(), DownSide());
            radius = random.Next(20, 40);

            vx = random.Next(-10, 10);
            vy = random.Next(-10, 10);
        }
    }
}
