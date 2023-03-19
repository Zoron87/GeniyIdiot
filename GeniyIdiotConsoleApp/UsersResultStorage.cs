using System.Collections.Generic;
using System.IO;
using System;
using System.Linq;
using System.Timers;


namespace GeniyIdiotConsoleApp
{
    internal partial class Program
    {
        public static class UsersResultStorage
        {
            public static void SavesStatsInFile(User user)
            {
                string currentGameStat = String.Join(';', new[] { user.Diagnose, user.PercentCorrectAnswers.ToString("0.00"), user.Name }) + Environment.NewLine;
                File.AppendAllText(statOfGamesPath, currentGameStat);
            }

            public static void OutputStatsFromFile(User user)
            {
                Console.Clear();
                var statsOfAllGames = SortGameStatByDesc(statOfGamesPath);

                string printHeaderGameStat = OutputFormatConsole("Диагноз", "Результат", "ФИО");
                Console.WriteLine(printHeaderGameStat);
                Console.WriteLine();

                foreach (var statOfOneGame in statsOfAllGames)
                {
                    var statOfOneGameArr = statOfOneGame.Split(";");
                    Console.ForegroundColor = (IsCurrentGameStatistic(statOfOneGameArr[2], statOfOneGameArr[1], user.Name, user.PercentCorrectAnswers.ToString("0.00"))) ? ConsoleColor.Green : ConsoleColor.White;

                    string printGameStat = OutputFormatConsole(statOfOneGameArr[0], statOfOneGameArr[1], statOfOneGameArr[2]);
                    Console.WriteLine(printGameStat);
                }
            }

            private static IEnumerable<string> SortGameStatByDesc(string pathToFileWithStatsOfGame)
            {
                return File.ReadAllText(pathToFileWithStatsOfGame).Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries)
                    .OrderByDescending(s => s, new StatsComparer()).Select(s => s);
            }

            private class StatsComparer : IComparer<string>
            {
                public int Compare(string stat1, string stat2)
                {
                    var statsGame1 = float.Parse(stat1.Split(";")[1].Trim());

                    var statsGame2 = float.Parse(stat2.Split(";")[1].Trim());

                    if (statsGame1 < statsGame2) return -1;
                    if (statsGame1 > statsGame2) return 1;
                    return 0;
                }
            }

            private static bool IsCurrentGameStatistic(string nameUserCheckGame, string statCheckGame, string nameUserCurGame, string statCurGame)
            {
                return nameUserCheckGame == nameUserCurGame && statCheckGame == statCurGame;
            }

            private static string OutputFormatConsole(string param1, string param2, string param3)
            {
                return String.Format("{0,-10} {1, -9:0.00} {2, 10} ", param1, param2, param3);
            }

            public static void timer_Elapsed(object sender, ElapsedEventArgs e)
            {
                timeoutForAnswerOnQuestion -= 1;

                if (timeoutForAnswerOnQuestion == 0)
                {
                    Console.Clear();
                    Console.WriteLine("==============================================");
                    Console.WriteLine("ВРЕМЯ НА ОТВЕТ ВЫШЛО!");
                    Console.WriteLine("НАЖМИТЕ ENTER ДЛЯ ПЕРЕХОДА К СЛЕДУЮЩЕМУ ВОПРОСУ!");
                    Console.WriteLine("==============================================");

                    gameTimer.Stop();
                }
                GC.Collect();
            }
        }
    }
}