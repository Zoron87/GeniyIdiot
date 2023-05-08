using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2048WinFormsApp
{
    public interface IUserResultsStorage
    {
        public void SaveAll(User user);

        public List<User> GetAll();
    }
}
