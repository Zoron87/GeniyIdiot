using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallGamesWinFormsApp
{
    public class RandomBall : Ball
    {
        static Random random = new Random();
        public RandomBall(MainForm form) : base(form)
        {
            x = random.Next(0, form.ClientSize.Width);
            y = random.Next(0, form.ClientSize.Height);
        }
    }
}
