using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;
using System.Timers;

namespace GeniyIdiotConsoleApp
{
    public class User
    {
        private const string questionsAnswersPath = "QuestionsAnswers.txt";

        static System.Timers.Timer gameTimer = new System.Timers.Timer(1000);
        static int timeoutForAnswerOnQuestion = 10;
        static string testQuestion;

        public string Name { get; set; }

        public double PercentCorrectAnswers { get; set; }

        public string Diagnose { get; set; }

        public void GetPercentCorrectAnswers()
        {
            int countRightAnswers = 0;

            //var questionsAnswers = FileSystem.GetInfo(questionsAnswersPath)
            //    .Split("\n", StringSplitOptions.RemoveEmptyEntries).OrderBy(r => new Random().Next())
            //    .Select(s=>JsonConvert.DeserializeObject<Question>(s)).ToList();
            var questionsAnswers = QuestionsStorage.GetAll().ToList();

            gameTimer.AutoReset = true;
            gameTimer.Elapsed += Game.timer_Elapsed;
            gameTimer.Start();

            foreach (var item in questionsAnswers)
            {
                testQuestion = item.Text;

                Console.Clear();
                Logs.OuputToConsole("=================================================");
                Logs.OuputToConsole("ВОПРОС - " + testQuestion);
                Logs.OuputToConsole("БЫСТРЕЕ ОТВЕЧАЙ НА ВОПРОС!");
                Logs.OuputToConsole("ВРЕМЕНИ НА ОТВЕТ:  10 СЕКУНД");
                Logs.OuputToConsole("=================================================");

                int answer = GetAnswerOnQuestion();
                if (item.Answer == answer) countRightAnswers++;
            }

            gameTimer.Stop();

            float percentRightAnswers = (float)countRightAnswers / questionsAnswers.Count * 100;

            if (percentRightAnswers >= 70) Game.BeepSounds.GoodDiagnose();
            else Game.BeepSounds.BadDiagnose();

            PercentCorrectAnswers = Math.Round(percentRightAnswers, 2);
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