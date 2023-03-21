using System.Collections.Generic;
using System.IO;
using System;
using System.Linq;
using System.Timers;


namespace GeniyIdiotConsoleApp
{
    public static class UsersResultStorage
    {
        public static string statOfGamesPath = "StatisticOfGames.txt";

        public static void SavesStatsInFile(string statOfGamesPath, User user)
        {
            string currentGameStat = String.Join(';', new[] { user.Diagnose, user.PercentCorrectAnswers.ToString("0.00"), user.Name }) + Environment.NewLine;
            FileSystem.SaveInfoInFile(statOfGamesPath, currentGameStat, true);
        }

        public static IEnumerable<string> GetStatsFromFile(string statOfGamesPath, bool IsOrderByDescending)
        {
            var statsFromFile = FileSystem.GetInfoFromFile(statOfGamesPath).Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
           
            if (!IsOrderByDescending) return statsFromFile;

            return statsFromFile.OrderByDescending(s => s, new StatsComparer()).Select(s => s);
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

        public static bool IsCurrentGameStatistic(string nameUserCheckGame, string statCheckGame, string nameUserCurGame, string statCurGame)
        {
            return nameUserCheckGame == nameUserCurGame && statCheckGame == statCurGame;
        }
    }
}

