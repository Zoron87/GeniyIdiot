using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeniyIdiot.Common
{
    internal class QuestionsStorageInDB : IQuestionsStorage
    {
        public void AddQuestion(Question question)
        {
            throw new NotImplementedException();
        }

        public void DeleteQuestion(Question questionForDelete)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Question> GetAll()
        {
            throw new NotImplementedException();
        }

        public void SaveAll(IEnumerable<Question> questions)
        {
            throw new NotImplementedException();
        }
    }
}
