using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task72WinFormsApp
{
    public class Ball
    {
        protected Random random = new Random();  
        
        private MainForm form;

        protected int x = 50;
        protected int y = 50;
        protected int size = 100;

        protected int vx = 1;
        protected int vy = 1;

        public Ball(MainForm form)
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
            var graphics = form.CreateGraphics();
            Brush brush = Brushes.Aqua;
            Rectangle rectangle = new Rectangle(x, y, size, size);
            graphics.FillEllipse(brush, rectangle);
        }

        public bool isBallClick(Ball ball, int x, int y)
        {
            var centerX = ball.x + size / 2;
            var centerY = ball.y + size / 2;
            var radiusBall = size / 2;

            var clickInBall = Math.Pow(x - centerX, 2) + Math.Pow(y - centerY, 2) <= Math.Pow(radiusBall, 2);
            var ballOnForm = (ball.x <= form.ClientSize.Width-size && ball.y <= form.ClientSize.Height - size) && (ball.x > 0 && ball.y > 0);

            return clickInBall && ballOnForm;
        }

        public void Recolor()
        {
            var graphics = form.CreateGraphics();
            Brush brush = Brushes.Gray;
            Rectangle rectangle = new Rectangle(x, y, size, size);
            graphics.FillEllipse(brush, rectangle);
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
