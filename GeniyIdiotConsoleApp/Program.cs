using System;
using System.Threading;


namespace GeniyIdiotConsoleApp
{
    internal partial class Program
    {
        const string questionsAnswersPath = "QuestionsAnswers.txt";
        const string statOfGamesPath = "StatisticOfGames.txt";
        const string diagnosesAndPercentPath = "DiagnosesAndPercent.txt";

        static System.Timers.Timer gameTimer = new System.Timers.Timer(1000);
        static int timeoutForAnswerOnQuestion = 10;
        static string testQuestion;

        static void Main(string[] args)
        {
            var user = new User();
 
            Game.InitializateStartMenu(user);

            gameTimer.Close();
            gameTimer.Dispose();
        }
    }
}