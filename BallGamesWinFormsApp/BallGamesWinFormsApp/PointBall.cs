using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallGamesWinFormsApp
{
    public class PointBall : RandomBall
    {
        public PointBall(MainForm form, int x, int y) : base(form)
        {
            this.x = x - 50;
            this.y = y - 50;
        }
    }
}
