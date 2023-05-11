using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;

namespace SnakeWinFormsApp
{
    public partial class MainForm : Form
    {
        public MainForm form;

        private int gameFieldHeight = 600, gameFieldWidth = 600;
        private int offsetX = 10, offsetY = 10;
        private int cellSize = 40;
        private int rowCount;
        private int colCount;

        private int moveX = 1;
        private int moveY = 0;

        private int score = 0;
        SnakeFood snakeFood;
        List<Cube> snake = new List<Cube>();
        Cube head;

        public MainForm()
        {
            InitializeComponent();
            this.KeyDown += MainForm_KeyPress;

            rowCount = (int)(gameFieldHeight / cellSize);
            colCount = (int)(gameFieldWidth / cellSize);
            
            snakeFood = new SnakeFood(this);
            snakeFood.Generate();

            head = new Cube(this, offsetX, offsetY, Color.DarkGreen);
            snake.Add(head);

            mainTimer.Tick += MainTimer_Tick;
            mainTimer.Interval = 500;
            mainTimer.Start();
        }

        private void MoveSnake()
        {
            for (int i = score; i >= 1; i--)
            {
                snake[i].X = snake[i - 1].X;
                snake[i].Y = snake[i - 1].Y;
                snake[i].Move();
            }

            head.X = head.X + cellSize * moveX;
            head.Y = head.Y + cellSize * moveY;
            head.Move();
        }

        private void EatFood()
        {
            if (snake[0].GetLocation().X == snakeFood.GetLocation().X && snake[0].GetLocation().Y == snakeFood.GetLocation().Y)
            {
                score++;

                CheckWinGame();

                Cube tail = new Cube(this, snake[score-1].X + moveX * cellSize, snake[score - 1].Y + moveY * cellSize, Color.Green);
                snake.Add(tail);

                scoreLabel.Text = "Score: " + score;
                snakeFood.Generate();
            }
        }

        private void EatYourSelf()
        {
            for (int i = 1; i < score; i++)
            {
                if (snake[0].GetLocation() == snake[i].GetLocation())
                {
                    mainTimer.Stop();
                    if (MessageBox.Show("Вы съели сами себя! \r\n Игра завершена. \r\n Попробовать еще раз?", "GameOver", MessageBoxButtons.OKCancel) == DialogResult.OK)
                        Application.Restart();

                }
            }
        }

        private void CheckWinGame()
        {
            if (score >= 200)
                if (MessageBox.Show("Вы победили! \r\n Игра завершена. \r\n Сыграть еще раз?", "GameOver", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    Application.Restart();
        }

        private void CheckGameBorder()
        {
            if (snake[0].GetLocation().X >= gameFieldWidth || snake[0].GetLocation().X <= 0
                || snake[0].GetLocation().Y >= gameFieldHeight || snake[0].GetLocation().Y <= 0)
            {
                mainTimer.Stop();
                if (MessageBox.Show("Вы вышли за границы поля! \r\n Игра завершена. \r\n Попробовать еще раз?", "GameOver", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    Application.Restart();

            }
        }

        private void MainTimer_Tick(object? sender, EventArgs e)
        {
            MoveSnake();
            EatFood();
            EatYourSelf();
            CheckGameBorder();
        }

        private void MainForm_KeyPress(object? sender, KeyEventArgs e)
        {
            switch (e.KeyCode.ToString())
            {
                case "Right":
                    moveX = 1;
                    moveY = 0;
                    break;

                case "Left":
                    moveX = -1;
                    moveY = 0;
                    break;

                case "Up":
                    moveY = -1;
                    moveX = 0;
                    break;

                case "Down":
                    moveY = 1;
                    moveX = 0;
                    break;
            }
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