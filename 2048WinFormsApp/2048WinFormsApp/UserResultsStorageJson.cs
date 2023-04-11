using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2048WinFormsApp
{
    public class UserResultsStorageJson : IUserResultsStorage
    {
        private const string filePath = "GameStatistic.json";

        public List<User> GetAll()
        {
            return JsonConvert.DeserializeObject<List<User>>(FileSystem.GetData(filePath));
        }

        public void SaveAll(User user)
        {
            var allStatistics = GetAll();
            allStatistics.Add(user);

            string currentGameStatistic = JsonConvert.SerializeObject(allStatistics, Formatting.Indented);
            FileSystem.SaveData(filePath, currentGameStatistic);
        }
    }
}
