using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GeniyIdiotConsoleApp
{
    internal partial class Program
    {
        public static class Game
        {
            public static void InitializateStartMenu(User user)
            {
                Console.WriteLine("Выберите подходящий пункт: \n 1. Пройти викторину \n 2. Добавить свой вопрос \n 3. Удалить вопрос из списка");

                int[] allowedMenuOption = new int[] { 1, 2, 3 };
                int answerMenuOption = user.GetAnswerOnQuestion(allowedMenuOption);

                switch (answerMenuOption)
                {
                    case 1:
                        Game.StartTest(user);
                        break;
                    case 2:
                        QuestionsStorage.AddQuestionFromConsole(user);
                        break;
                    case 3:
                        QuestionsStorage.DeleteQuestionFromConsole(user);
                        break;
                }
            }

            private static void StartTest(User user)
            {
                BeepSounds.StartGame();

                Console.WriteLine("Как вас зовут?");

                user.Name = Console.ReadLine();

                string statOfGamesPath = "StatisticOfGames.txt";
                bool retry = false;
                float percentRightAnswers;
                do
                {
                    user.GetPercentCorrectAnswers();
                    user.CalcDiagnose(user);

                    Console.WriteLine($"{user.Name}, Ваш диагноз - {user.Diagnose}");
                    UsersResultStorage.SavesStatsInFile(user);
                    Console.WriteLine("----------------------------------------------------");

                    Console.WriteLine("Есть желание пройти викторину повторно? Да / Нет");

                    retry = user.GetAnswerFromUser();
                    if (retry) Console.Clear();
                }
                while (retry);

                Console.WriteLine("Вывести статистику игр? Да / Нет");

                if (user.GetAnswerFromUser()) UsersResultStorage.OutputStatsFromFile(user);

                var returnFontColorToDefault = ConsoleColor.White;
                Console.ForegroundColor = returnFontColorToDefault;
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
}
