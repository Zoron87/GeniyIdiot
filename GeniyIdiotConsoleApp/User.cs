using System.IO;
using System;
using System.Linq;


namespace GeniyIdiotConsoleApp
{
    internal partial class Program
    {
        public class User
        {
            private string name;
            private string diagnose;
            private float percentCorrectAnswers;

            public string Name {get; set; }

            public float PercentCorrectAnswers { get; private set; }

            public string Diagnose { get; private set; }

            public void GetPercentCorrectAnswers()
            {
                int countRightAnswers = 0;

                var questionsAnswers = File.ReadAllText(questionsAnswersPath).Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries).OrderBy(r => new Random().Next()).ToList();

                gameTimer.AutoReset = true;
                gameTimer.Elapsed += UsersResultStorage.timer_Elapsed;
                gameTimer.Start();

                foreach (var item in questionsAnswers)
                {
                    testQuestion = item.Split(";")[0];

                    Console.Clear();
                    Console.WriteLine("=================================================");
                    Console.WriteLine("ВОПРОС - " + testQuestion);
                    Console.WriteLine("БЫСТРЕЕ ОТВЕЧАЙ НА ВОПРОС!");
                    Console.WriteLine("ВРЕМЕНИ НА ОТВЕТ:  10 СЕКУНД");
                    Console.WriteLine("=================================================");

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
                var diagnosesAndPercent = File.ReadAllText(diagnosesAndPercentPath).Split(Environment.NewLine).ToList();

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
                    tryParseAnswer = int.TryParse(Console.ReadLine(), out answer);

                    if (gameTimer.Enabled == false && timeoutForAnswerOnQuestion <= 0)
                    {
                        timeoutForAnswerOnQuestion = 10;  // Reset timer for each question
                        gameTimer.Enabled = true;
                        return int.MinValue;
                    }

                    if (!tryParseAnswer)
                    {
                        Game.BeepSounds.WrongAnswer();
                        Console.WriteLine($"!!! Ответ должен быть в виде числа в диапазоне от {int.MinValue} до {int.MaxValue}. Введите ответ еще раз !!!");
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
                        Console.WriteLine($"!!! Указанного пункта меню не обнаружено. Выберите повторно !!!");
                        answer = CheckIntRangeAnswerUser();
                    }
                }
                return answer;
            }

            public bool GetAnswerFromUser(string message = "Укажите ДА / НЕТ", string agree = "да", string disagee = "нет")
            {
                string answer = Console.ReadLine().ToLower();
                do
                {
                    if (answer == agree.ToLower()) return true;
                    if (answer == disagee.ToLower()) return false;

                    Console.WriteLine(message);
                    answer = Console.ReadLine().ToLower();
                } while (true);

                return false;
            }

        }
    }
}