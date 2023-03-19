using System.IO;
using System;
using System.Linq;


namespace GeniyIdiotConsoleApp
{
    internal partial class Program
    {
        public static class QuestionsStorage
        {
            public static void AddQuestionFromConsole(User user)
            {
                do
                {
                    Console.WriteLine("Введите свой вопрос:");
                    string questionForAdd = Console.ReadLine();
                    Console.WriteLine("Введите ответ на него:");
                    int answerOnQuestionForAdd = user.CheckIntRangeAnswerUser();

                    File.AppendAllText(questionsAnswersPath, new Question(questionForAdd, answerOnQuestionForAdd).ToString());

                    Console.WriteLine("Вопрос успешно добавлен. Желаете добавить еще один?");
                } while (user.GetAnswerFromUser());
            }

            public static void DeleteQuestionFromConsole(User user)
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

                    int answer = user.GetAnswerOnQuestion(allowedNumbersForDeleteQuestion);

                    questions.RemoveAt(answer - 1);

                    File.WriteAllLines(questionsAnswersPath, questions);

                    Console.WriteLine($"Вопрос №{answer} был удален из файла вопросов. Желаете удалить еще один?");
                } while (user.GetAnswerFromUser());
            }

            private static int[] FillArrayFromRange(int startNumber, int count)
            {
                return Enumerable.Range(startNumber, count).ToArray();
            }
        }
    }
}