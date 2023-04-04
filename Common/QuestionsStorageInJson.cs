using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeniyIdiot.Common
{
    public class QuestionsStorageInJson : IQuestionsStorage
    {
        private const string questionsAnswersPath = "QuestionsAnswers.txt";

        public void AddQuestion(Question question)
        {
            var questions = GetAll().ToList();

            questions.Add(question);

            SaveAll(questions);
        }

        public void DeleteQuestion(Question questionForDelete)
        {
            var questions = GetAll().ToList();

            for (int i = 0; i < questions.Count; i++)
            {
                if (questions[i].Text == questionForDelete.Text)
                {
                    questions.RemoveAt(i);
                    break;
                }
            }

            SaveAll(questions);
        }

        public IEnumerable<Question> GetAll()
        {
            return JsonConvert.DeserializeObject<IEnumerable<Question>>(FileSystem.GetInfo(questionsAnswersPath)).OrderBy(s => new Random().Next());
        }

        public void SaveAll(IEnumerable<Question> questions)
        {
            var newQuestions = JsonConvert.SerializeObject(questions.ToList());
            FileSystem.SaveInfo(questionsAnswersPath, newQuestions);
        }
    }
}
