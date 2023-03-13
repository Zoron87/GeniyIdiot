using System.Collections.Generic;
using System.IO;
using System;
using System.Linq;
using System.Threading;


namespace GeniyIdiotConsoleApp
{
    internal class Program
    {
        const string questionsAnswersPath = "QuestionsAnswers.txt";

        static void Main(string[] args)
        {
            InitializateStartMenu();
        }

        private static void InitializateStartMenu()
        {
            Console.WriteLine("Выберите подходящий пункт: \n 1. Пройти викторину \n 2. Добавить свой вопрос \n 3. Удалить вопрос из списка");

            int[] allowedMenuOption = new int[] { 1, 2, 3 };
            int answerMenuOption = GetAnswerOnQuestion(allowedMenuOption);

            switch (answerMenuOption)
            {
                case 1:
                    StartTest();
                    break;
                case 2:
                    AddQuestionFromConsole();
                    break;
                case 3:
                    DeleteQuestionFromConsole();
                    break;
            }
        }

        static int GetAnswerOnQuestion(int[] rangeAnswer = null)
        {
            int answer = CheckIntRangeAnswerUser();

            answer = CheckContainAnswerInAllowRange(rangeAnswer, answer);

            return answer;
        }

        static int CheckIntRangeAnswerUser()
        {
            bool tryParseAnswer;
            int answer = int.MinValue;
            do
            {
                tryParseAnswer = int.TryParse(Console.ReadLine(), out answer);
                if (!tryParseAnswer)
                {
                    BeepSounds.WrongAnswer();
                    Console.WriteLine($"!!! Ответ должен быть в виде числа в диапазоне от {int.MinValue} до {int.MaxValue}. Введите ответ еще раз !!!");
                }
            }
            while (!tryParseAnswer);

            return answer;
        }

        static int CheckContainAnswerInAllowRange(int[] rangeAnswer, int answer)
        {
            if (rangeAnswer != null)
            {
                while (!rangeAnswer.Contains(answer))
                {
                    BeepSounds.WrongAnswer();
                    Console.WriteLine($"!!! Указанного пункта меню не обнаружено. Выберите повторно !!!");
                    answer = CheckIntRangeAnswerUser();
                }
            }

            return answer;
        }

        private static void StartTest()
        {
            BeepSounds.StartGame();

            Console.WriteLine("Как вас зовут?");

            string name = Console.ReadLine();

            string statOfGamesPath = "StatisticOfGames.txt";
            bool retry = false;
            float percentRightAnswers;
            do
            {
                percentRightAnswers = GetPercentCorrectAnswers();
                string yourDiagnose = CalcDiagnose(percentRightAnswers);

                Console.WriteLine($"{name}, Ваш диагноз - {yourDiagnose}");
                SavesStatsInFile(statOfGamesPath, yourDiagnose, percentRightAnswers, name);
                Console.WriteLine("----------------------------------------------------");

                Console.WriteLine("Есть желание пройти викторину повторно? Да / Нет");

                retry = GetAnswerFromUser();
                if (retry) Console.Clear();
            }
            while (retry);

            Console.WriteLine("Вывести статистику игр? Да / Нет");

            if (GetAnswerFromUser()) OutputStatsFromFile(statOfGamesPath, name, percentRightAnswers);

            var returnFontColorToDefault = ConsoleColor.White;
            Console.ForegroundColor = returnFontColorToDefault;
        }

        static float GetPercentCorrectAnswers()
        {
            int countRightAnswers = 0;

            var questionsAnswers = File.ReadAllText(questionsAnswersPath).Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries).OrderBy(r => new Random().Next()).ToList();

            foreach (var item in questionsAnswers)
            {
                Console.WriteLine(item.Split(";")[0]);

                int answer = GetAnswerOnQuestion();
                if (int.Parse(item.Split(";")[1]) == answer) countRightAnswers++;
            }

            float percentRightAnswers = (float)countRightAnswers / questionsAnswers.Count * 100;

            if (percentRightAnswers >= 70) BeepSounds.GoodDiagnose();
            else BeepSounds.BadDiagnose();

            return percentRightAnswers;
        }

        static string CalcDiagnose(float percent)
        {
            string diagnosesAndPercentPath = "DiagnosesAndPercent.txt";

            var diagnosesAndPercent = File.ReadAllText(diagnosesAndPercentPath).Split(Environment.NewLine).ToList();

            var result = diagnosesAndPercent.Select(x => x.Split(";")).LastOrDefault(x => int.Parse(x[0]) <= percent);

            if (result != null) return result[1];
            else return diagnosesAndPercent[0].Split(";")[1];
        }

        static void SavesStatsInFile(string statsOfGamePath, string diagnose, float percentRightAnswers, string name)
        {
            string currentGameStat = String.Join(';', new[] { diagnose, percentRightAnswers.ToString("0.00"), name }) + Environment.NewLine;
            File.AppendAllText(statsOfGamePath, currentGameStat);
        }

        static bool GetAnswerFromUser(string message = "Укажите ДА / НЕТ", string agree = "да", string disagee = "нет")
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

        static void OutputStatsFromFile(string pathToFileWithStatsOfGame, string name, float percentRightAnswers)
        {
            Console.Clear();
            var statsOfAllGames = SortGameStatByDesc(pathToFileWithStatsOfGame);

            string printHeaderGameStat = OutputFormatConsole("Диагноз", "Результат", "ФИО");
            Console.WriteLine(printHeaderGameStat);
            Console.WriteLine();

            foreach (var statOfOneGame in statsOfAllGames)
            {
                var statOfOneGameArr = statOfOneGame.Split(";");
                Console.ForegroundColor = (IsCurrentGameStatistic(statOfOneGameArr[2], statOfOneGameArr[1], name, percentRightAnswers.ToString("0.00"))) ? ConsoleColor.Green : ConsoleColor.White;

                string printGameStat = OutputFormatConsole(statOfOneGameArr[0], statOfOneGameArr[1], statOfOneGameArr[2]);
                Console.WriteLine(printGameStat);
            }
        }

        static IEnumerable<string> SortGameStatByDesc(string pathToFileWithStatsOfGame)
        {
            return File.ReadAllText(pathToFileWithStatsOfGame).Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries)
                .OrderByDescending(s => s, new StatsComparer()).Select(s => s);
        }

        class StatsComparer : IComparer<string>
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

        static bool IsCurrentGameStatistic(string nameUserCheckGame, string statCheckGame, string nameUserCurGame, string statCurGame)
        {
            if (nameUserCheckGame == nameUserCurGame && statCheckGame == statCurGame)
                return true;
            return false;
        }

        static string OutputFormatConsole(string param1, string param2, string param3)
        {
            return String.Format("{0,-10} {1, -9:0.00} {2, 10} ", param1, param2, param3);
        }

        private static void AddQuestionFromConsole()
        {
            do
            {
                Console.WriteLine("Введите свой вопрос:");
                string questionForAdd = Console.ReadLine();
                Console.WriteLine("Введите ответ на него:");
                int answerOnQuestionForAdd = CheckIntRangeAnswerUser();

                File.AppendAllText(questionsAnswersPath, questionForAdd + ";" + answerOnQuestionForAdd + Environment.NewLine);

                Console.WriteLine("Вопрос успешно добавлен. Желаете добавить еще один?");
            } while (GetAnswerFromUser());
        }

        private static void DeleteQuestionFromConsole()
        {
            do
            {
                var questions = File.ReadAllLines(questionsAnswersPath).ToList();

                int[] allowedNumbersForDeleteQuestion = FillArrayFromRange(1, questions.Count);

                Console.WriteLine("Выводим список имеющихся вопросов:");

                int index = 0;
                questions.ForEach(s =>
                {
                    index++;
                    Console.WriteLine($"{index}. {s}");
                });

                Console.WriteLine("Укажите номер вопроса, который необходимо удалить?");

                int answer = GetAnswerOnQuestion(allowedNumbersForDeleteQuestion);

                questions.RemoveAt(answer - 1);

                File.WriteAllLines(questionsAnswersPath, questions);

                Console.WriteLine($"Вопрос №{answer} был удален из файла вопросов. Желаете удалить еще один?");
            } while (GetAnswerFromUser());
        }

        private static int[] FillArrayFromRange(int startNumber, int count)
        {
            return Enumerable.Range(startNumber, count).ToArray();
        }

        static class BeepSounds
        {
            public static void StartGame()
            {
                Console.Beep(500, 500);
                Console.Beep(500, 500);
                Console.Beep(660, 1500);
            }
            public static void WrongAnswer()
            {
                Console.Beep(700, 500);
            }
            public static void GoodDiagnose()
            {
                Console.Beep(659, 300);
                Console.Beep(783, 300);
                Console.Beep(523, 300);
                Console.Beep(587, 300);
                Console.Beep(659, 300);
            }
            public static void BadDiagnose()
            {
                Console.Beep(300, 500);
                Thread.Sleep(50);
                Console.Beep(300, 500);
                Thread.Sleep(50);
                Console.Beep(300, 500);
                Thread.Sleep(50);
                Console.Beep(250, 500);
            }
        }
    }
}