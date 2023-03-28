using System.IO;
using System;
using System.Linq;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace GeniyIdiot.Common
{
    public static class QuestionsStorage
    {
        private const string questionsAnswersPath = "QuestionsAnswers.txt";

        public static void AddQuestionFromConsole(User user)
        {
            do
            {
                Logs.OuputToConsole("Введите свой вопрос:");
                string questionForAdd = Logs.InputFromConsole();
                Logs.OuputToConsole("Введите ответ на него:");
                int answerOnQuestionForAdd = user.CheckIntRangeAnswerUser();

                var newQuestion = new Question(questionForAdd, answerOnQuestionForAdd);

                FileSystem.SaveInfo(questionsAnswersPath, newQuestion.ToString(), true);

                Logs.OuputToConsole("Вопрос успешно добавлен. Желаете добавить еще один?");
            } while (user.GetAnswerFromUser());
        }

        public static void DeleteQuestionFromConsole(User user)
        {
            do
            {
                var questions = GetAll().ToList();

                var allowedNumbersForDeleteQuestion = FillArrayFromRange(1, questions.Count);

                Logs.OuputToConsole("Выводим список имеющихся вопросов:");

                int index = 0;
                questions.ForEach(s =>
                {
                    index++;
                    Logs.OuputToConsole($"{index}. Вопрос: {s.Text}. Ответ: {s.Answer}");
                });

                Logs.OuputToConsole("Укажите номер вопроса, который необходимо удалить?");

                int answer = user.GetAnswerOnQuestion(allowedNumbersForDeleteQuestion);

                questions.RemoveAt(answer - 1);

                SaveAll(questions);

                Logs.OuputToConsole($"Вопрос №{answer} был удален из файла вопросов. Желаете удалить еще один?");
            } while (user.GetAnswerFromUser());
        }

        private static int[] FillArrayFromRange(int startNumber, int count)
        {
            return Enumerable.Range(startNumber, count).ToArray();
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