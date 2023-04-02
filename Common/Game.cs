using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace GeniyIdiot.Common
{
    public class Game
    {
        private List<Question> questions;
        private Question currentQuestion;
        public User user;
        private Diagnose diagnose;
        private int countRightAnswers;
        private int questionsCounter = -1;
        private decimal userAnswer = -1;

        public Game(User user)
        {
            this.user = user;
            questions = QuestionsStorage.GetAll().ToList();
        }

        public Question GetNextQuestion()
        {
            questionsCounter++;
            currentQuestion = questions[questionsCounter];

            return currentQuestion;
        }

        public void AcceptAnswer(decimal userAnswer)
        {
            var rightAnswer = questions[questionsCounter].Answer;

            if (userAnswer == rightAnswer)
            {
                countRightAnswers++;
            }
        }

        public bool End()
        {
            return questionsCounter == questions.Count - 1;
        }

        public string CalculateDiagnose(User user)
        {
            Diagnose diagnose = new Diagnose();

            user.Diagnose = diagnose.Calc(user);

            UsersResultStorage.SaveAll(user);

            return $"{user.Name}, Ваш диагноз - {user.Diagnose}";
        }

        public double CalculatePercentCorrectAnswers()
        {
            return Math.Round((double)countRightAnswers / questions.Count * 100, 2);
        }

    }
}
