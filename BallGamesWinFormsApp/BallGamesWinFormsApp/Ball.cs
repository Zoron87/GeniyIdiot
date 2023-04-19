using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallGamesWinFormsApp
{
    public class Ball
    {
        private MainForm form;

        protected Random random = new Random();

        protected int x = 150;
        protected int y = 150;
        protected int size = 100;
        protected int vx = 1;
        protected int vy = 1;

        public Ball(MainForm form)
        {
            this.form = form;   
        }

        public void Show()
        {
            var graphics = form.CreateGraphics();
            Brush brush = Brushes.Aqua;
            Rectangle rectangle = new Rectangle(x, y, size, size);
            graphics.FillEllipse(brush, rectangle);
        }

        public void Move()
        {
            Clear();
            Go();
            Show();
        }

        public bool isCatch()
        {
            return ((x <= form.ClientSize.Width-size && y <= form.ClientSize.Height - size) && (x >= 0 && y >= 0));
        }

        private void Go()
        {
            x += vx;
            y += vy;
        }

        private void Clear() 
        {
            var graphics = form.CreateGraphics();
            Brush brush = Brushes.White;
            Rectangle rectangle = new Rectangle(x, y, size, size);
            graphics.FillEllipse(brush, rectangle);
        }
    }
}
