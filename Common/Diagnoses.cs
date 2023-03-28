using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeniyIdiot.Common
{
    public class Diagnose
    {
        private const string diagnosesAndPercentPath = "DiagnosesAndPercent.txt";

        public string UserDiagnose { get; set; }
        public float PercentCorrectAnswers { get; set; }

        public string Calc(User user)
        {
            var diagnosesAndPercent = GetAll().ToList();

            var result = diagnosesAndPercent.LastOrDefault(x => x.PercentCorrectAnswers <= user.PercentCorrectAnswers);

            if (result != null) return result.UserDiagnose.ToString();
            return diagnosesAndPercent[0].UserDiagnose;
        }

        private IEnumerable<Diagnose> GetAll()
        {
            return JsonConvert.DeserializeObject<IEnumerable<Diagnose>>(FileSystem.GetInfo(diagnosesAndPercentPath));
        }
    }
}
