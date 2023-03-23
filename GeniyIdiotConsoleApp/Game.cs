using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace GeniyIdiotConsoleApp
{
    public static class Game
    {
        public static string statOfGamesPath = "StatisticOfGames.txt";

        static System.Timers.Timer gameTimer = new System.Timers.Timer(1000);
        static int timeoutForAnswerOnQuestion = 10;

        public static void InitializateStartMenu(User user, Diagnose diagnose)
        {
            Logs.OuputToConsole("Выберите подходящий пункт: \n 1. Пройти викторину \n 2. Добавить свой вопрос \n 3. Удалить вопрос из списка");

            var allowedMenuOption = new int[] { 1, 2, 3 };
            var answerMenuOption = user.GetAnswerOnQuestion(allowedMenuOption);

            switch (answerMenuOption)
            {
                case 1:
                    Game.StartTest(user,diagnose);
                    break;
                case 2:
                    QuestionsStorage.AddQuestionFromConsole(user);
                    break;
                case 3:
                    QuestionsStorage.DeleteQuestionFromConsole(user);
                    break;
            }
        }

        private static void StartTest(User user, Diagnose diagnose)
        {
            BeepSounds.StartGame();

            Logs.OuputToConsole("Как вас зовут?");

            user.Name = Logs.InputFromConsole();

            bool retry = false;
            float percentRightAnswers;
            do
            {
                user.GetPercentCorrectAnswers();
                user.Diagnose = diagnose.CalcDiagnose(user);

                Logs.OuputToConsole($"{user.Name}, Ваш диагноз - {user.Diagnose}");
                UsersResultStorage.SavesStatsInFile(statOfGamesPath, user);
                Logs.OuputToConsole("----------------------------------------------------");

                Logs.OuputToConsole("Есть желание пройти викторину повторно? Да / Нет");

                retry = user.GetAnswerFromUser();
                if (retry) Console.Clear();
            }
            while (retry);

            Logs.OuputToConsole("Вывести статистику игр? Да / Нет");

            if (user.GetAnswerFromUser()) Game.OutputStatsToConsole(user);

            var returnFontColorToDefault = ConsoleColor.White;
            Console.ForegroundColor = returnFontColorToDefault;
        }

        public static void OutputStatsToConsole(User user)
        {
            Console.Clear();
            var statsOfAllGamesByDesc = UsersResultStorage.GetStatsFromFile(statOfGamesPath, true);

            string printHeaderGameStat = OutputFormatConsole("Диагноз", "Результат", "ФИО");
            Logs.OuputToConsole(printHeaderGameStat);
            Logs.OuputToConsole();

            foreach (var statOfOneGame in statsOfAllGamesByDesc)
            {
                Console.ForegroundColor = (UsersResultStorage.IsCurrentGameStatistic(statOfOneGame.Name, statOfOneGame.PercentCorrectAnswers.ToString("0.00"), user.Name, user.PercentCorrectAnswers.ToString("0.00"))) ? ConsoleColor.Green : ConsoleColor.White;

                string printGameStat = OutputFormatConsole(statOfOneGame.Diagnose, statOfOneGame.PercentCorrectAnswers.ToString(), statOfOneGame.Name);
                Logs.OuputToConsole(printGameStat);
            }
        }

        private static string OutputFormatConsole(string param1, string param2, string param3)
        {
            return String.Format("{0,-10} {1, -9:0.00} {2, 10} ", param1, param2, param3);
        }

        public static class BeepSounds
        {
            public static void StartGame()
            {
                Console.Beep(500, 500);
                Console.Beep(500, 500);
                Console.Beep(660, 1500);
            }
            public static void WrongAnswer()
            {
                Console.Beep(700, 500);
            }
            public static void GoodDiagnose()
            {
                Console.Beep(659, 300);
                Console.Beep(783, 300);
                Console.Beep(523, 300);
                Console.Beep(587, 300);
                Console.Beep(659, 300);
            }
            public static void BadDiagnose()
            {
                Console.Beep(300, 500);
                Thread.Sleep(50);
                Console.Beep(300, 500);
                Thread.Sleep(50);
                Console.Beep(300, 500);
                Thread.Sleep(50);
                Console.Beep(250, 500);
            }
        }

        public static void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            timeoutForAnswerOnQuestion -= 1;

            if (timeoutForAnswerOnQuestion == 0)
            {
                Console.Clear();
                Logs.OuputToConsole("==============================================");
                Logs.OuputToConsole("ВРЕМЯ НА ОТВЕТ ВЫШЛО!");
                Logs.OuputToConsole("НАЖМИТЕ ENTER ДЛЯ ПЕРЕХОДА К СЛЕДУЮЩЕМУ ВОПРОСУ!");
                Logs.OuputToConsole("==============================================");

                gameTimer.Stop();
            }
            GC.Collect();
        }
    }
}
