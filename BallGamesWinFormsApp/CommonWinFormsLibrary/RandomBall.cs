using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonWinFormsLibrary
{
    public class RandomBall : Ball
    {
        static Random random = new Random();
        public RandomBall(Form form) : base(form)
        {
            centerX = random.Next(0, form.ClientSize.Width);
            centerY = random.Next(0, form.ClientSize.Height);
        }
    }
}
