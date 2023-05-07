using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace SnakeWinFormsApp
{
    public partial class MainForm : Form
    {
        private int height = 600;
        private int width = 600;
        private int cellSize = 40;
        private int offsetX = 10, offsetY = 10;
        private int rowCount;
        private int colCount;

        private int dirX = 1;
        private int dirY = 1;

        public MainForm()
        {
            InitializeComponent();
            this.KeyDown += MainForm_KeyPress;

            rowCount = (int)(height / cellSize);
            colCount = (int)(width / cellSize);

            mainTimer.Start();
        }

        private void MainForm_KeyPress(object? sender, KeyEventArgs e)
        {
            switch(e.KeyCode.ToString())
            {
                case "Right":
                    snakePictureBox.Location = new Point(snakePictureBox.Location.X + cellSize, snakePictureBox.Location.Y);
                    break;

                case "Left":
                    snakePictureBox.Location = new Point(snakePictureBox.Location.X - cellSize, snakePictureBox.Location.Y);
                    break;

                case "Up":
                    snakePictureBox.Location = new Point(snakePictureBox.Location.X, snakePictureBox.Location.Y - cellSize);
                    break;

                case "Down":
                    snakePictureBox.Location = new Point(snakePictureBox.Location.X, snakePictureBox.Location.Y + cellSize);
                    break;
            }
        }

        private void mainTimer_Tick(object sender, EventArgs e)
        {
            if (snakePictureBox.Location.X > height)
                snakePictureBox.Location = new Point(snakePictureBox.Location.X - cellSize, snakePictureBox.Location.Y);
        }

        private void MainForm_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawGrid(offsetX, offsetY, cellSize, rowCount, colCount, Pens.Black);
        }

    }

    public static class DrawingExtension
    {
        public static void DrawGrid(this Graphics g, int offsetX, int offsetY, int cellSize, int rowCount, int colCount, Pen pen)
        {
            for (int i = 0; i < colCount; i++)
            {
                for (int j = 0; j < rowCount; j++)
                {
                    g.DrawRectangle(pen, offsetX + i * cellSize, offsetY + j * cellSize, cellSize, cellSize);
                }
            }
        }
    }
}