using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;
using System.Timers;

namespace GeniyIdiot.Common
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
    }
}