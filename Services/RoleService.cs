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
    public class RoleService
    {
        private static RoleService instance;

        public static RoleService GetInstance()
        {
            if (instance == null)
            {
                instance = new RoleService();
            }

            return instance;
        }

        private RoleService() { }

        public ObservableCollection<Role> GetAll()
        {
            try
            {
                return SqlHelper.GetRoles();
            }
            catch(Exception ex) { MessageBox.Show(ex.Message); }

            return new ObservableCollection<Role>();
        }

        public Role GetById(long id)
        {
            try
            {
                return SqlHelper.GetRoleById(id);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

            return null;
        }

        public Role Create(string titleRaw)
        {
            try
            {
                if (titleRaw == null) { return null; }

                string title = titleRaw.Trim();

                if (title.Equals("")) { return null; }

                Role entityToCreate = new Role();

                entityToCreate.Title = title;

                return SqlHelper.CreateRole(entityToCreate);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

            return null;
        }

        public Role Update(Role entity)
        {
            try
            {
                if (entity == null)
                {
                    MessageBox.Show("Сущность для обновления равна нулю");
                    return null;
                }

                return SqlHelper.UpdateRole(entity);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return null;
        }

        public void Delete(Role entity)
        {
            try
            {
                if (entity == null)
                {
                    MessageBox.Show("Сущность для удаления равна нулю");
                }

                SqlHelper.DeleteRole(entity);
                MessageBox.Show("Сущность удалена");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
