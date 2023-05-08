using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeniyIdiot.Common
{
    public interface IQuestionsStorage
    {
        public void Add(Question question);
        public void Delete(Question questionForDelete);
        public List<Question> GetAll();
    }
}
