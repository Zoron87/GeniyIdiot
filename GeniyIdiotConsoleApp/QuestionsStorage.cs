using System.IO;
using System;
using System.Linq;


namespace GeniyIdiotConsoleApp
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

                Game.SaveInfoInFile(questionsAnswersPath, newQuestion.ToString(), true);

                Logs.OuputToConsole("Вопрос успешно добавлен. Желаете добавить еще один?");
            } while (user.GetAnswerFromUser());
        }

        public static void DeleteQuestionFromConsole(User user)
        {
            do
            {
                var questions = Game.GetInfoFromFile(questionsAnswersPath).Split("\n", StringSplitOptions.RemoveEmptyEntries).ToList();

                var allowedNumbersForDeleteQuestion = FillArrayFromRange(1, questions.Count);

                Logs.OuputToConsole("Выводим список имеющихся вопросов:");

                int index = 0;
                questions.ForEach(s =>
                {
                    index++;
                    Logs.OuputToConsole($"{index}. {s}");
                });

                Logs.OuputToConsole("Укажите номер вопроса, который необходимо удалить?");

                int answer = user.GetAnswerOnQuestion(allowedNumbersForDeleteQuestion);

                questions.RemoveAt(answer - 1);

               Game.SaveInfoInFile(questionsAnswersPath, String.Join("\n", questions), false);

                Logs.OuputToConsole($"Вопрос №{answer} был удален из файла вопросов. Желаете удалить еще один?");
            } while (user.GetAnswerFromUser());
        }

        private static int[] FillArrayFromRange(int startNumber, int count)
        {
            return Enumerable.Range(startNumber, count).ToArray();
        }
    }
}