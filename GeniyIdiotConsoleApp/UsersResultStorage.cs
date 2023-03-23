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

        public static void SavesStatsInFile(string statOfGamesPath, User user)
        {
            string currentGameStat = JsonConvert.SerializeObject(user) + Environment.NewLine;
            FileSystem.SaveInfoInFile(statOfGamesPath, currentGameStat, true);
        }

        public static IEnumerable<User> GetStatsFromFile(string statOfGamesPath, bool IsOrderByDescending)
        {
            var statsFromFile = FileSystem.GetInfoFromFile(statOfGamesPath)
                .Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
           
            if (!IsOrderByDescending) return statsFromFile.Select(s => JsonConvert.DeserializeObject<User>(s));

            return statsFromFile.Select(s => JsonConvert.DeserializeObject<User>(s)).OrderByDescending(s => s.PercentCorrectAnswers);
            var test = statsFromFile.Select(s => JsonConvert.DeserializeObject<User>(s)).ToList();
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

