using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeniyIdiot.Common
{
    public class QuestionsStorageInDB : IQuestionsStorage
    {
        DatabaseContext context = new DatabaseContext();

        public void Add(Question question)
        {
            context.Question.Add(question);
            context.SaveChanges();
        }

        public void Delete(Question questionForDelete)
        {
            context.Question.Remove(questionForDelete);
            context.SaveChanges();
        }

        public List<Question> GetAll()
        {
            return context.Question.ToList().Select(q=>q).OrderBy(q => new Random().Next()).ToList();
        }
    }
}
