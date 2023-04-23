using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonWinFormsLibrary
{
    public class PointBall : RandomBall
    {
        public PointBall(Form form, int x, int y) : base(form)
        {
            this.centerX = x - 50;
            this.centerY = y - 50;
        }
    }
}
