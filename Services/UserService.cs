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

        public ObservableCollection<User> GetAll()
        {
            try
            {
                return SqlHelper.GetUsers();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

            return new ObservableCollection<User>();
        }

        public User GetById(long id)
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

        public User Create(string loginRaw, string passwordRaw, Role role)
        {
            try
            {
                if (loginRaw == null || passwordRaw == null || role == null) { return null; }

                string login = loginRaw.Trim();
                string password = passwordRaw.Trim();

                if (login.Equals("") || password.Equals("")) { return null; }

                User userToCreate = new User();

                userToCreate.Login = login;
                userToCreate.Password = password;
                userToCreate.Role = role;

                return SqlHelper.CreateUser(userToCreate);
            }
            catch(Exception ex) { MessageBox.Show(ex.Message); }

            return null;
        }

        public User Update(User entity)
        {
            try
            {
                if (entity == null) {
                    MessageBox.Show("Сущность для обновления равна нулю");
                    return null;
                }

                return SqlHelper.UpdateUser(entity);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return null;
        }

        public void Delete(User entity)
        {
            try
            {
                if (entity == null)
                {
                    MessageBox.Show("Сущность для удаления равна нулю");
                }

                SqlHelper.DeleteUser(entity);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
