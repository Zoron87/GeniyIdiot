using System.Collections.Generic;
using System.IO;
using System;
using System.Linq;
using System.Threading;
using System.Timers;


namespace GeniyIdiotConsoleApp
{
    internal class Program
    {
        const string questionsAnswersPath = "QuestionsAnswers.txt";

        static System.Timers.Timer gameTimer = new System.Timers.Timer(1000);
        static int timeoutForAnswerOnQuestion = 10;
        static string testQuestion;

        static void Main(string[] args)
        {
            Tools.InitializateStartMenu();

            gameTimer.Close();
            gameTimer.Dispose();
        }

        public static class User
        {
            private static string name;
            private static string diagnose;
            private static float percentCorrectAnswers;

            public static string Name
            {
                get { return name; }
                set { name = value; }
            }

            public static float PercentCorrectAnswers
            {
                get { return percentCorrectAnswers; }
                private set { percentCorrectAnswers = value; }
            }

            public static string Diagnose
            {
                get { return diagnose; }
                private set { diagnose = value; }
            }

            public static void GetPercentCorrectAnswers()
            {
                int countRightAnswers = 0;

                var questionsAnswers = File.ReadAllText(questionsAnswersPath).Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries).OrderBy(r => new Random().Next()).ToList();

                gameTimer.AutoReset = true;
                gameTimer.Elapsed += Game.timer_Elapsed;
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

                if (percentRightAnswers >= 70) BeepSounds.GoodDiagnose();
                else BeepSounds.BadDiagnose();


                PercentCorrectAnswers = percentRightAnswers;
            }

            public static void CalcDiagnose(float percent)
            {
                string diagnosesAndPercentPath = "DiagnosesAndPercent.txt";

                var diagnosesAndPercent = File.ReadAllText(diagnosesAndPercentPath).Split(Environment.NewLine).ToList();

                var result = diagnosesAndPercent.Select(x => x.Split(";")).LastOrDefault(x => int.Parse(x[0]) <= percent);

                if (result != null) diagnose = result[1];
                else diagnose = diagnosesAndPercent[0].Split(";")[1];
            }

            public static int GetAnswerOnQuestion(int[] rangeAnswer = null)
            {
                int answer = CheckIntRangeAnswerUser();

                answer = CheckContainAnswerInAllowRange(rangeAnswer, answer);

                return answer;
            }

            public static int CheckIntRangeAnswerUser()
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
                        BeepSounds.WrongAnswer();
                        Console.WriteLine($"!!! Ответ должен быть в виде числа в диапазоне от {int.MinValue} до {int.MaxValue}. Введите ответ еще раз !!!");
                    }
                }
                while (!tryParseAnswer);

                return answer;
            }

            private static int CheckContainAnswerInAllowRange(int[] rangeAnswer, int answer)
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

            public static bool GetAnswerFromUser(string message = "Укажите ДА / НЕТ", string agree = "да", string disagee = "нет")
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

        public static class Game
        {
            public static string statOfGamesPath = "StatisticOfGames.txt";

            public static void SavesStatsInFile(string statsOfGamePath, string diagnose, float percentRightAnswers, string name)
            {
                string currentGameStat = String.Join(';', new[] { User.Diagnose, User.PercentCorrectAnswers.ToString("0.00"), User.Name }) + Environment.NewLine;
                File.AppendAllText(statsOfGamePath, currentGameStat);
            }

            public static void OutputStatsFromFile(string pathToFileWithStatsOfGame, string name, float percentRightAnswers)
            {
                Console.Clear();
                var statsOfAllGames = SortGameStatByDesc(pathToFileWithStatsOfGame);

                string printHeaderGameStat = OutputFormatConsole("Диагноз", "Результат", "ФИО");
                Console.WriteLine(printHeaderGameStat);
                Console.WriteLine();

                foreach (var statOfOneGame in statsOfAllGames)
                {
                    var statOfOneGameArr = statOfOneGame.Split(";");
                    Console.ForegroundColor = (IsCurrentGameStatistic(statOfOneGameArr[2], statOfOneGameArr[1], User.Name, percentRightAnswers.ToString("0.00"))) ? ConsoleColor.Green : ConsoleColor.White;

                    string printGameStat = OutputFormatConsole(statOfOneGameArr[0], statOfOneGameArr[1], statOfOneGameArr[2]);
                    Console.WriteLine(printGameStat);
                }
            }

            private static IEnumerable<string> SortGameStatByDesc(string pathToFileWithStatsOfGame)
            {
                return File.ReadAllText(pathToFileWithStatsOfGame).Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries)
                    .OrderByDescending(s => s, new StatsComparer()).Select(s => s);
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

            private static bool IsCurrentGameStatistic(string nameUserCheckGame, string statCheckGame, string nameUserCurGame, string statCurGame)
            {
                return nameUserCheckGame == nameUserCurGame && statCheckGame == statCurGame;
            }

            private static string OutputFormatConsole(string param1, string param2, string param3)
            {
                return String.Format("{0,-10} {1, -9:0.00} {2, 10} ", param1, param2, param3);
            }

            public static void timer_Elapsed(object sender, ElapsedEventArgs e)
            {
                timeoutForAnswerOnQuestion -= 1;

                if (timeoutForAnswerOnQuestion == 0)
                {
                    Console.Clear();
                    Console.WriteLine("==============================================");
                    Console.WriteLine("ВРЕМЯ НА ОТВЕТ ВЫШЛО!");
                    Console.WriteLine("НАЖМИТЕ ENTER ДЛЯ ПЕРЕХОДА К СЛЕДУЮЩЕМУ ВОПРОСУ!");
                    Console.WriteLine("==============================================");

                    gameTimer.Stop();
                }
                GC.Collect();
            }
        }

        public static class Tools
        {
            public static void InitializateStartMenu()
            {
                Console.WriteLine("Выберите подходящий пункт: \n 1. Пройти викторину \n 2. Добавить свой вопрос \n 3. Удалить вопрос из списка");

                int[] allowedMenuOption = new int[] { 1, 2, 3 };
                int answerMenuOption = User.GetAnswerOnQuestion(allowedMenuOption);

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

            private static void StartTest()
            {
                BeepSounds.StartGame();

                Console.WriteLine("Как вас зовут?");

                User.Name = Console.ReadLine();

                string statOfGamesPath = "StatisticOfGames.txt";
                bool retry = false;
                float percentRightAnswers;
                do
                {
                    User.GetPercentCorrectAnswers();
                    User.CalcDiagnose(User.PercentCorrectAnswers);

                    Console.WriteLine($"{User.Name}, Ваш диагноз - {User.Diagnose}");
                    Game.SavesStatsInFile(Game.statOfGamesPath, User.Diagnose, User.PercentCorrectAnswers, User.Name);
                    Console.WriteLine("----------------------------------------------------");

                    Console.WriteLine("Есть желание пройти викторину повторно? Да / Нет");

                    retry = User.GetAnswerFromUser();
                    if (retry) Console.Clear();
                }
                while (retry);

                Console.WriteLine("Вывести статистику игр? Да / Нет");

                if (User.GetAnswerFromUser()) Game.OutputStatsFromFile(statOfGamesPath, User.Name, User.PercentCorrectAnswers);

                var returnFontColorToDefault = ConsoleColor.White;
                Console.ForegroundColor = returnFontColorToDefault;
            }

            private static void AddQuestionFromConsole()
            {
                do
                {
                    Console.WriteLine("Введите свой вопрос:");
                    string questionForAdd = Console.ReadLine();
                    Console.WriteLine("Введите ответ на него:");
                    int answerOnQuestionForAdd = User.CheckIntRangeAnswerUser();

                    File.AppendAllText(questionsAnswersPath, questionForAdd + ";" + answerOnQuestionForAdd + Environment.NewLine);

                    Console.WriteLine("Вопрос успешно добавлен. Желаете добавить еще один?");
                } while (User.GetAnswerFromUser());
            }

            private static void DeleteQuestionFromConsole()
            {
                do
                {
                    var questions = File.ReadAllLines(questionsAnswersPath).ToList();

                    var allowedNumbersForDeleteQuestion = FillArrayFromRange(1, questions.Count);

                    Console.WriteLine("Выводим список имеющихся вопросов:");

                    int index = 0;
                    questions.ForEach(s =>
                    {
                        index++;
                        Console.WriteLine($"{index}. {s}");
                    });

                    Console.WriteLine("Укажите номер вопроса, который необходимо удалить?");

                    int answer = User.GetAnswerOnQuestion(allowedNumbersForDeleteQuestion);

                    questions.RemoveAt(answer - 1);

                    File.WriteAllLines(questionsAnswersPath, questions);

                    Console.WriteLine($"Вопрос №{answer} был удален из файла вопросов. Желаете удалить еще один?");
                } while (User.GetAnswerFromUser());
            }

            private static int[] FillArrayFromRange(int startNumber, int count)
            {
                return Enumerable.Range(startNumber, count).ToArray();
            }
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