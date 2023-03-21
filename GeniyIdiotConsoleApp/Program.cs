using System;
using System.Threading;
using System.Timers;

namespace GeniyIdiotConsoleApp
{
    internal partial class Program
    {
        static System.Timers.Timer gameTimer = new System.Timers.Timer(1000);

        static void Main(string[] args)
        {
            var user = new User();

            Game.InitializateStartMenu(user);

            gameTimer.Close();
            gameTimer.Dispose();
        }
    }
}