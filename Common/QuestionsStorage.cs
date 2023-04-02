using System.IO;
using System;
using System.Linq;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Windows;

namespace GeniyIdiot.Common
{
    public static class QuestionsStorage
    {
        private const string questionsAnswersPath = "QuestionsAnswers.txt";

        public static void AddQuestion(Question question)
        {
            var questions = QuestionsStorage.GetAll().ToList();

            questions.Add(question);

            QuestionsStorage.SaveAll(questions);
        }

        public static void DeleteQuestion(Question questionForDelete)
        {
            var questions = QuestionsStorage.GetAll().ToList();

            for (int i = 0; i < questions.Count; i++)
            {
                if (questions[i].Text == questionForDelete.Text)
                {
                    questions.RemoveAt(i);
                    break;
                }
            }

            QuestionsStorage.SaveAll(questions);
        }

        public static IEnumerable<Question> GetAll()
        {
            return JsonConvert.DeserializeObject<IEnumerable<Question>>(FileSystem.GetInfo(questionsAnswersPath)).OrderBy(s => new Random().Next());
        }

        public static void SaveAll(IEnumerable<Question> questions)
        {
            var newQuestions = JsonConvert.SerializeObject(questions.ToList());
            FileSystem.SaveInfo(questionsAnswersPath, newQuestions);
        }
    }
}