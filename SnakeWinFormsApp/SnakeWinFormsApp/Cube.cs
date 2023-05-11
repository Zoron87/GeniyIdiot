using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SnakeWinFormsApp
{
    public class Cube
    {
        PictureBox cube;

        private int cellSize = 40;

        public int X { get; set; }
        public int Y { get; set; }

        public Cube(Form form, int x, int y, Color color)
        {
            X = x;
            Y = y;
            cube = new PictureBox();
            cube.Size = new Size(cellSize - 1 , cellSize - 1);
            cube.BackColor = color;
            cube.Location = new Point(X + 2, Y + 2);
            form.Controls.Add(cube);
        }

        public Point GetLocation()
        {
            return cube.Location;
        }

        public void Move()
        {
            cube.Location = new Point(X + 1, Y + 1);
        }
    }
}
