﻿using System.Collections.Generic;
using System.IO;
using System;
using System.Linq;
using System.Threading;


namespace GeniyIdiotConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
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

        static int GetAnswerOnQuestion()
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

        static string CalcDiagnose(float percent)
        {
            string diagnosesAndPercentPath = "DiagnosesAndPercent.txt";

            var diagnosesAndPercent = File.ReadAllText(diagnosesAndPercentPath).Split(Environment.NewLine).ToList();

            var result = diagnosesAndPercent.Select(x => x.Split(";")).LastOrDefault(x => int.Parse(x[0]) <= percent);

            if (result != null) return result[1];
            else return diagnosesAndPercent[0].Split(";")[1];
        }

        static float GetPercentCorrectAnswers()
        {
            int countRightAnswers = 0;

            string questionsAnswersPath = "QuestionsAnswers.txt";
            var questionsAnswers = File.ReadAllText(questionsAnswersPath).Split(Environment.NewLine).OrderBy(r => new Random().Next()).ToList();

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
        static void SavesStatsInFile(string statsOfGamePath, string diagnose, float percentRightAnswers, string name)
        {
            string currentGameStat = String.Join(';', new[] { diagnose, percentRightAnswers.ToString("0.00"), name }) + Environment.NewLine;
            File.AppendAllText(statsOfGamePath, currentGameStat);
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

        static bool IsCurrentGameStatistic(string nameUserCheckGame, string statCheckGame, string nameUserCurGame, string statCurGame)
        {
            if (nameUserCheckGame == nameUserCurGame && statCheckGame == statCurGame)
                return true;
            return false;
        }

        private static IEnumerable<string> SortGameStatByDesc(string pathToFileWithStatsOfGame)
        {
            return File.ReadAllText(pathToFileWithStatsOfGame).Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries)
                .OrderByDescending(s => s, new StatsComparer()).Select(s => s);
        }

        static string OutputFormatConsole(string param1, string param2, string param3)
        {
            return String.Format("{0,-10} {1, -9:0.00} {2, 10} ", param1, param2, param3);
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