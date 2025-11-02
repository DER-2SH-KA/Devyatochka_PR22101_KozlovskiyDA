using Devyatochka.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devyatochka.Util.Db
{
    public class SqlHelper
    {
        private static DevyatochkaEntities instance;

        public static List<User> GetUsers() { return instance.User.ToList(); }
        
        public static User GetUserById(long id)
        {
            return instance.User
                .Where(x => x.Id == id)
                .FirstOrDefault();
        }

        public static User GetUserByLoginAndPassword(string login, string password)
        {
            return instance.User
                .Where(x => x.Login.Equals(login) && x.Password.Equals(password))
                .FirstOrDefault();
        }
    }
}
