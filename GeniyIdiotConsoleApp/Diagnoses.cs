using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeniyIdiotConsoleApp
{
    public class Diagnose
    {
        private const string diagnosesAndPercentPath = "DiagnosesAndPercent.txt";

        public string UserDiagnose{ get; set; }
        public float PercentCorrectAnswers { get; set; }

        public string CalcDiagnose(User user)
        {
            var diagnosesAndPercent = FileSystem.GetInfoFromFile(diagnosesAndPercentPath)
                .Split(Environment.NewLine).Select(s=>JsonConvert.DeserializeObject<Diagnose>(s)).ToList();

            var result = diagnosesAndPercent.LastOrDefault(x => x.PercentCorrectAnswers <= user.PercentCorrectAnswers);

            if (result != null) return result.UserDiagnose.ToString();
            else return diagnosesAndPercent[0].UserDiagnose;
        }
    }
}
