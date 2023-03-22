using System;
using System.IO;
using System.Linq;
using System.Timers;

namespace GeniyIdiotConsoleApp
{
    public class User
    {
        private const string questionsAnswersPath = "QuestionsAnswers.txt";
        private const string diagnosesAndPercentPath = "DiagnosesAndPercent.txt";

        static System.Timers.Timer gameTimer = new System.Timers.Timer(1000);
        static int timeoutForAnswerOnQuestion = 10;
        static string testQuestion;

        private string name;
        private string diagnose;
        private float percentCorrectAnswers;

        public string Name { get; set; }

        public float PercentCorrectAnswers { get; private set; }

        public string Diagnose { get; private set; }

        public void GetPercentCorrectAnswers()
        {
            int countRightAnswers = 0;

            var questionsAnswers = FileSystem.GetInfoFromFile(questionsAnswersPath).Split("\n", StringSplitOptions.RemoveEmptyEntries).OrderBy(r => new Random().Next()).ToList();

            gameTimer.AutoReset = true;
            gameTimer.Elapsed += Game.timer_Elapsed;
            gameTimer.Start();

            foreach (var item in questionsAnswers)
            {
                testQuestion = item.Split(";")[0];

                Console.Clear();
                Logs.OuputToConsole("=================================================");
                Logs.OuputToConsole("ВОПРОС - " + testQuestion);
                Logs.OuputToConsole("БЫСТРЕЕ ОТВЕЧАЙ НА ВОПРОС!");
                Logs.OuputToConsole("ВРЕМЕНИ НА ОТВЕТ:  10 СЕКУНД");
                Logs.OuputToConsole("=================================================");

                int answer = GetAnswerOnQuestion();
                if (int.Parse(item.Split(";")[1]) == answer) countRightAnswers++;
            }

            gameTimer.Stop();

            float percentRightAnswers = (float)countRightAnswers / questionsAnswers.Count * 100;

            if (percentRightAnswers >= 70) Game.BeepSounds.GoodDiagnose();
            else Game.BeepSounds.BadDiagnose();

            PercentCorrectAnswers = percentRightAnswers;
        }

        public void CalcDiagnose(User user)
        {
            var diagnosesAndPercent = FileSystem.GetInfoFromFile(diagnosesAndPercentPath).Split(Environment.NewLine).ToList();

            var result = diagnosesAndPercent.Select(x => x.Split(";")).LastOrDefault(x => int.Parse(x[0]) <= user.PercentCorrectAnswers);

            if (result != null) user.Diagnose = result[1];
            else user.Diagnose = diagnosesAndPercent[0].Split(";")[1];
        }

        public int GetAnswerOnQuestion(int[] rangeAnswer = null)
        {
            int answer = CheckIntRangeAnswerUser();

            answer = CheckContainAnswerInAllowRange(rangeAnswer, answer);

            return answer;
        }

        public int CheckIntRangeAnswerUser()
        {
            bool tryParseAnswer = false;
            int answer = int.MinValue;
            do
            {
                tryParseAnswer = int.TryParse(Logs.InputFromConsole(), out answer);

                if (gameTimer.Enabled == false && timeoutForAnswerOnQuestion <= 0)
                {
                    timeoutForAnswerOnQuestion = 10;  // Reset timer for each question
                    gameTimer.Enabled = true;
                    return int.MinValue;
                }

                if (!tryParseAnswer)
                {
                    Game.BeepSounds.WrongAnswer();
                    Logs.OuputToConsole($"!!! Ответ должен быть в виде числа в диапазоне от {int.MinValue} до {int.MaxValue}. Введите ответ еще раз !!!");
                }
            }
            while (!tryParseAnswer);

            return answer;
        }

        private int CheckContainAnswerInAllowRange(int[] rangeAnswer, int answer)
        {
            if (rangeAnswer != null)
            {
                while (!rangeAnswer.Contains(answer))
                {
                    Game.BeepSounds.WrongAnswer();
                    Logs.OuputToConsole($"!!! Указанного пункта меню не обнаружено. Выберите повторно !!!");
                    answer = CheckIntRangeAnswerUser();
                }
            }
            return answer;
        }

        public bool GetAnswerFromUser(string message = "Укажите ДА / НЕТ", string agree = "да", string disagee = "нет")
        {
            string answer = Logs.InputFromConsole().ToLower();
            do
            {
                if (answer == agree.ToLower()) return true;
                if (answer == disagee.ToLower()) return false;

                Logs.OuputToConsole(message);
                answer = Logs.InputFromConsole().ToLower();
            } while (true);

            return false;
        }
    }
}