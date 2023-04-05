using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeniyIdiot.Common
{
    public class UserResultsStorageInJson : IUserResultsStorage
    {
        public static string statOfGamesPath = "StatisticOfGames.txt";

        public void SaveAll(User user)
        {
            var allStats = GetAll(false).ToList();
            allStats.Add(user);

            string currentGameStat = JsonConvert.SerializeObject(allStats) + Environment.NewLine;
            FileSystem.SaveInfo(statOfGamesPath, currentGameStat, false);
        }

        public List<User> GetAll(bool IsOrderByDescending = true)
        {
            var statsFromFile = JsonConvert.DeserializeObject<List<User>>(FileSystem.GetInfo(statOfGamesPath));

            if (!IsOrderByDescending) return statsFromFile;

            return statsFromFile.OrderByDescending(s => s.PercentCorrectAnswers).ToList();
        }

        public bool IsCurrentGameStatistic(string nameUserCheckGame, string statCheckGame, string nameUserCurGame, string statCurGame)
        {
            return nameUserCheckGame == nameUserCurGame && statCheckGame == statCurGame;
        }
    }
}
