using Devyatochka.Database;
using Devyatochka.Util.Db;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Devyatochka.Services
{
    public class UserService
    {
        private static UserService instance;

        public static UserService GetInstance()
        {
            if (instance == null)
            {
                instance = new UserService();
            }

            return instance;
        }

        private UserService() { }

        public ObservableCollection<User> GetUsers()
        {
            try
            {
                return SqlHelper.GetUsers();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

            return new ObservableCollection<User>();
        }

        public User GetUserById(long id)
        {
            try
            {
                return SqlHelper.GetUserById(id);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

            return null;
        }

        public User GetUserByLoginAndPass(string loginRaw, string passwordRaw)
        {
            try
            {
                if (loginRaw == null || passwordRaw == null) { return null; }

                string login = loginRaw.Trim();
                string password = passwordRaw.Trim();

                if (login.Length == 0 || password.Length == 0) { return null; }

                User user = SqlHelper.GetUserByLoginAndPassword(login, password);

                return user;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

            return null;
        }

        public User UserIsExists(string loginRaw)
        {
            try
            {
                if (loginRaw == null) { return null; }

                string login = loginRaw.Trim();

                if (login.Length == 0) { return null; }

                User user = SqlHelper.ExistsUserWithLogin(login);

                return user;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

            return null;
        }
    }
}
