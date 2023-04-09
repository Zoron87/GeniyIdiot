using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeniyIdiot.Common
{
    public class UserResultsStorageInDB : IUserResultsStorage
    {
        DatabaseContext context = new DatabaseContext();

        public List<User> GetAll(bool IsOrderByDescending = true)
        {
            if (!IsOrderByDescending) return context.User.ToList();

            return context.User.OrderByDescending(s => s.PercentCorrectAnswers).ToList();
        }

        public void SaveAll(User user)
        {
            context.User.Add(user);
            context.SaveChanges();
        }
    }
}
