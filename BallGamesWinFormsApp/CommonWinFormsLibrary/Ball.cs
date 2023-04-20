using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonWinFormsLibrary
{
    public class Ball
    {
        protected Random random = new Random();

        private Form form;

        protected int x = 50;
        protected int y = 50;
        protected int size = 100;

        protected int vx = 1;
        protected int vy = 1;

        public Ball(Form form)
        {
            this.form = form;
        }

        public void Move()
        {
            Clear();
            Go();
            Show();
        }

        public void Show()
        {
            Init(Brushes.Aqua);
        }

        public bool IsBallClick(int x, int y)
        {
            var centerX = this.x + size / 2;
            var centerY = this.y + size / 2;
            var radiusBall = size / 2;

            var clickInBall = Math.Pow(x - centerX, 2) + Math.Pow(y - centerY, 2) <= Math.Pow(radiusBall, 2);

            return clickInBall;
        }

        public bool IsCatchOnForm()
        {
            return x <= form.ClientSize.Width - size && y <= form.ClientSize.Height - size && x >= 0 && y >= 0;
        }

        public void Init(Brush brush)
        {
            if (brush == null) brush = Brushes.Aqua;
            var graphics = form.CreateGraphics();
            Rectangle rectangle = new Rectangle(x, y, size, size);
            graphics.FillEllipse(brush, rectangle);
        }

        public void Recolor()
        {
            Init(Brushes.Gray);
        }

        private void Go()
        {
            x += vx;
            y += vy;
        }

        private void Clear()
        {
            Init(Brushes.White);
        }
    }
}
