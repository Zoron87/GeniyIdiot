using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeniyIdiot.Common
{
    public interface IQuestionsStorage
    {
        public void AddQuestion(Question question);
        public void DeleteQuestion(Question questionForDelete);

        public IEnumerable<Question> GetAll();
        public void SaveAll(IEnumerable<Question> questions);
    }
}
