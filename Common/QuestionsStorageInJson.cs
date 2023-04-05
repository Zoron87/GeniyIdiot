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

        public void Add(Question question)
        {
            var questions = GetAll().ToList();

            questions.Add(question);

            SaveAll(questions);
        }

        public void Delete(Question questionForDelete)
        {
            var questions = GetAll().ToList();

            var questionForRemove = questions.FirstOrDefault(q => q.Text == questionForDelete.Text);

            if (questionForRemove != null)
                questions.Remove(questionForRemove);

            SaveAll(questions);
        }

        public List<Question> GetAll()
        {
            return JsonConvert.DeserializeObject<IEnumerable<Question>>(FileSystem.GetInfo(questionsAnswersPath)).OrderBy(s => new Random().Next()).ToList();
        }

        private void SaveAll(List<Question> questions)
        {
            var newQuestions = JsonConvert.SerializeObject(questions.ToList());
            FileSystem.SaveInfo(questionsAnswersPath, newQuestions);
        }
    }
}
