using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SnakeWinFormsApp
{
    public class SnakeFood
    {
        Random random = new Random();
        private const int cellSize = 40;
        Form form;
        PictureBox snakeFood;

        private int offsetX = 10, offsetY = 10;
        private int gameFieldHeight = 600, gameFieldWidth = 600;

        public int X { get; set; }
        public int Y { get; set; }

        public SnakeFood(Form form)
        {
            this.form = form;

            snakeFood = new PictureBox();
            snakeFood.BackColor = Color.Yellow;
            snakeFood.Size = new Size(cellSize - 1 , cellSize - 1);
            Generate();
        }

        public Point GetLocation()
        {
            return snakeFood.Location;
        }

        public void Generate()
        {
            var rnd = random.Next(cellSize, gameFieldHeight);
            var locationMultipleCellSizeX = rnd - rnd % cellSize;

            rnd = random.Next(cellSize, gameFieldWidth);
            var locationMultipleCellSizeY = rnd - rnd % cellSize;

            snakeFood.Location = new Point(offsetX + locationMultipleCellSizeX + 1, offsetY + locationMultipleCellSizeY + 1);

            form.Controls.Add(snakeFood);
        }
    }
}
