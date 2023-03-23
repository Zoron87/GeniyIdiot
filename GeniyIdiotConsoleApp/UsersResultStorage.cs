using System.Collections.Generic;
using System.IO;
using System;
using System.Linq;
using System.Timers;
using Newtonsoft.Json;

namespace GeniyIdiotConsoleApp
{
    public static class UsersResultStorage
    {
        public static string statOfGamesPath = "StatisticOfGames.txt";

        public static void SaveAll(User user)
        {
            var allStats = GetAll(false).ToList();
            allStats.Add(user);

            string currentGameStat = JsonConvert.SerializeObject(allStats) + Environment.NewLine;
            FileSystem.SaveInfo(statOfGamesPath, currentGameStat, false);
        }

        public static IEnumerable<User> GetAll(bool IsOrderByDescending = true)
        {
            var statsFromFile = JsonConvert.DeserializeObject<IEnumerable<User>>(FileSystem.GetInfo(statOfGamesPath));

            if (!IsOrderByDescending) return statsFromFile;

            return statsFromFile.OrderByDescending(s => s.PercentCorrectAnswers);
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

