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
            var diagnosesAndPercent = GetAll().ToList();

            var result = diagnosesAndPercent.LastOrDefault(x => x.PercentCorrectAnswers <= user.PercentCorrectAnswers);

            if (result != null) return result.UserDiagnose.ToString();
            else return diagnosesAndPercent[0].UserDiagnose;
        }

        private IEnumerable<Diagnose> GetAll()
        {
            return JsonConvert.DeserializeObject<IEnumerable<Diagnose>>(FileSystem.GetInfo(diagnosesAndPercentPath));
        }
    }
}
