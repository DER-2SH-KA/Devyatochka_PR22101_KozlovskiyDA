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

        public ObservableCollection<Role> GetRoles()
        {
            try
            {
                return SqlHelper.GetRoles();
            }
            catch(Exception ex) { MessageBox.Show(ex.Message); }

            return new ObservableCollection<Role>();
        }

        public Role GetRoleById(long id)
        {
            try
            {
                return SqlHelper.GetRoleById(id);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

            return null;
        }
    }
}
