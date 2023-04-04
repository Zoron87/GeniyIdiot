using GeniyIdiot.Common;
using System;
using System.Linq;
using System.Threading;
using System.Timers;

namespace GeniyIdiotConsoleApp
{
    internal partial class Program
    {
        public static string statOfGamesPath = "StatisticOfGames.txt";
       
        static System.Timers.Timer gameTimer = new System.Timers.Timer(1000);
        static int timeoutForAnswerOnQuestion = 10;

        static void Main(string[] args)
        {
             User user = new User();
             Diagnose diagnose = new Diagnose();

             IQuestionsStorage questionsStorageMethod = new QuestionsStorageInJson();

             Game game = new Game(user, questionsStorageMethod);

            InitializateStartMenu(game, user, diagnose, questionsStorageMethod);

            gameTimer.Close();
            gameTimer.Dispose();
        }

        public static void InitializateStartMenu(Game game, User user, Diagnose diagnose, IQuestionsStorage questionsStorageMethod)
        {
            Logs.OuputToConsole("Выберите подходящий пункт: \n 1. Пройти викторину \n 2. Добавить свой вопрос \n 3. Удалить вопрос из списка");

            var allowedMenuOption = new int[] { 1, 2, 3 };
            var answerMenuOption = GetAnswerOnQuestion(allowedMenuOption);

            switch (answerMenuOption)
            {
                case 1:
                    StartTest(game, user, diagnose, questionsStorageMethod);
                    break;
                case 2:
                    AddQuestionFromConsole(questionsStorageMethod);

                    break;
                case 3:

                    DeleteQuestionFromConsole(questionsStorageMethod);

                    break;
            }
        }

        private static void DeleteQuestionFromConsole(IQuestionsStorage questionStorageMethod)
        {
            do
            {
                var questions = questionStorageMethod.GetAll();

                var allowedNumbersForDeleteQuestion = FillArrayFromRange(1, questions.Count);

                Logs.OuputToConsole("Выводим список имеющихся вопросов:");

                int index = 0;
                questions.ForEach(s =>
                {
                    index++;
                    Logs.OuputToConsole($"{index}. Вопрос: {s.Text}. Ответ: {s.Answer}");
                });

                Logs.OuputToConsole("Укажите номер вопроса, который необходимо удалить?");

                int answer = GetAnswerOnQuestion(allowedNumbersForDeleteQuestion);

                var questionForDelete = questions[answer - 1];

                questionStorageMethod.Delete(questionForDelete);

                Logs.OuputToConsole($"Вопрос №{answer} был удален из файла вопросов. Желаете удалить еще один?");
            } while (GetAnswerFromUser());
        }

        private static void AddQuestionFromConsole(IQuestionsStorage questionStorageMethod)
        {
            do
            {
                Logs.OuputToConsole("Введите свой вопрос:");
                string textQuestionForAdd = Console.ReadLine();
                Logs.OuputToConsole("Введите ответ на него:");
                int answerQuestionForAdd = CheckIntRangeAnswerUser();

                questionStorageMethod.Add(new Question(textQuestionForAdd, answerQuestionForAdd));

                Logs.OuputToConsole("Вопрос успешно добавлен. Желаете добавить еще один?");
            } while (GetAnswerFromUser());
        }

        private static void StartTest(Game game, User user, Diagnose diagnose, IQuestionsStorage questionsStorageMethod)
        {
            BeepSounds.StartGame();

            Logs.OuputToConsole("Как вас зовут?");

            user.Name = Logs.InputFromConsole();

            bool retry = false;
            float percentRightAnswers;
            do
            {
                GetQuestions(user, questionsStorageMethod);
                var messageDiagnose = game.CalculateDiagnose(user);

                Logs.OuputToConsole(messageDiagnose);
                Logs.OuputToConsole("----------------------------------------------------");

                Logs.OuputToConsole("Есть желание пройти викторину повторно? Да / Нет");

                retry = GetAnswerFromUser();
                if (retry) Console.Clear();
            }
            while (retry);

            Logs.OuputToConsole("Вывести статистику игр? Да / Нет");

            if (GetAnswerFromUser()) OutputStats(user);

            var returnFontColorToDefault = ConsoleColor.White;
            Console.ForegroundColor = returnFontColorToDefault;
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
                tryParseAnswer = int.TryParse(Logs.InputFromConsole(), out answer);

                if (gameTimer.Enabled == false && timeoutForAnswerOnQuestion <= 0)
                {
                    timeoutForAnswerOnQuestion = 10;  // Reset timer for each question
                    gameTimer.Enabled = true;
                    return int.MinValue;
                }

                if (!tryParseAnswer)
                {
                    BeepSounds.WrongAnswer();
                    Logs.OuputToConsole($"!!! Ответ должен быть в виде числа в диапазоне от {int.MinValue} до {int.MaxValue}. Введите ответ еще раз !!!");
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
                    Logs.OuputToConsole($"!!! Указанного пункта меню не обнаружено. Выберите повторно !!!");
                    answer = CheckIntRangeAnswerUser();
                }
            }
            return answer;
        }

        private static int[] FillArrayFromRange(int startNumber, int count)
        {
            return Enumerable.Range(startNumber, count).ToArray();
        }

        public static void GetQuestions(User user, IQuestionsStorage questionsStorageMethod)
        {
            var game = new Game(user, questionsStorageMethod);
            int countRightAnswers = 0;

            var questionsAnswers = game.GetAllQuestions();

            gameTimer.AutoReset = true;
            gameTimer.Elapsed += timer_Elapsed;
            gameTimer.Start();

            while (!game.End())
            {
                var currentQuestion = game.GetNextQuestion();

                Console.Clear();
                Logs.OuputToConsole("=================================================");
                Logs.OuputToConsole("ВОПРОС - " + currentQuestion.Text);
                Logs.OuputToConsole("БЫСТРЕЕ ОТВЕЧАЙ НА ВОПРОС!");
                Logs.OuputToConsole("ВРЕМЕНИ НА ОТВЕТ:  10 СЕКУНД");
                Logs.OuputToConsole("=================================================");

                int userAnswer = GetAnswerOnQuestion();
                game.AcceptAnswer(userAnswer);
            }

            gameTimer.Stop();

            user.PercentCorrectAnswers = game.CalculatePercentCorrectAnswers();

            if (user.PercentCorrectAnswers >= 70) BeepSounds.GoodDiagnose();
            else BeepSounds.BadDiagnose();
        }

        public static bool GetAnswerFromUser(string message = "Укажите ДА / НЕТ", string agree = "да", string disagee = "нет")
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

        public static void OutputStats(User user)
        {
            Console.Clear();
            var userStats = UsersResultStorage.GetAll();

            string printHeaderGameStat = OutputViewFormat("Диагноз", "Результат", "ФИО");
            Logs.OuputToConsole(printHeaderGameStat);
            Logs.OuputToConsole();

            foreach (var userStat in userStats)
            {
                Console.ForegroundColor = UsersResultStorage.IsCurrentGameStatistic(userStat.Name, userStat.PercentCorrectAnswers.ToString("0.00"), user.Name, user.PercentCorrectAnswers.ToString("0.00")) ? ConsoleColor.Green : ConsoleColor.White;

                string printGameStat = OutputViewFormat(userStat.Diagnose, userStat.PercentCorrectAnswers.ToString(), userStat.Name);
                Logs.OuputToConsole(printGameStat);
            }
        }

        public static string OutputViewFormat(string param1, string param2, string param3)
        {
            return string.Format("{0,-10} {1, -9:0.00} {2, 10} ", param1, param2, param3);
        }

        public static void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            timeoutForAnswerOnQuestion -= 1;

            if (timeoutForAnswerOnQuestion == 0)
            {
                Console.Clear();
                Logs.OuputToConsole("==============================================");
                Logs.OuputToConsole("ВРЕМЯ НА ОТВЕТ ВЫШЛО!");
                Logs.OuputToConsole("НАЖМИТЕ ENTER ДЛЯ ПЕРЕХОДА К СЛЕДУЮЩЕМУ ВОПРОСУ!");
                Logs.OuputToConsole("==============================================");

                gameTimer.Stop();
            }
            GC.Collect();
        }

        public static class BeepSounds
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