using Devyatochka.Database;
using Devyatochka.Services;
using Devyatochka.Util.Db;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Devyatochka.Pages.Admin
{
    /// <summary>
    /// Логика взаимодействия для UserList.xaml
    /// </summary>
    public partial class UserList : Page
    {
        private UserService userService;
        private RoleService roleService;

        private ObservableCollection<User> users;
        private ObservableCollection<Role> roles;

        private ObservableCollection<User> usersFiltered;

        public UserList()
        {
            InitializeComponent();

            userService = UserService.GetInstance();
            roleService = RoleService.GetInstance();

            LoadEntities();
            LoadComboBoxRoles();

            RefreshWrapPanelContent();
        }

        private void RefreshWrapPanelContent()
        {
            if (comboBoxRole.SelectedIndex == 0)
            {
                usersFiltered = new ObservableCollection<User>(
                    users.Where(x => 
                        textBoxLogin.Text.Trim().Equals("") || 
                        x.Login
                            .ToLower()
                            .Trim()
                            .Contains(
                                textBoxLogin.Text
                                    .Trim()
                                    .ToLower()
                            )
                        )
                );
            }
            else
            {
                Role role = (Role) comboBoxRole.SelectedItem;

                usersFiltered = new ObservableCollection<User>(
                    users.Where(x =>
                        (
                        textBoxLogin.Text.Trim().Equals("") ||
                        x.Login
                            .ToLower()
                            .Trim()
                            .Contains(
                                textBoxLogin.Text
                                    .Trim()
                                    .ToLower()
                            )
                        ) && x.RoleId == role.Id
                    )

                );
            }

            foreach (User user in usersFiltered)
            {
                wrapPanelContainer.Children.Add(new Pages.SubComponents.UserCard(user));
            }
        }

        private void LoadEntities()
        {
            users = userService.GetAll();
            roles = roleService.GetAll();
        }

        private void LoadComboBoxRoles()
        {
            Role unselected = new Role();
            unselected.Id = 0;
            unselected.Title = "<Не выбрано>";

            comboBoxRole.Items.Add( unselected );

            if (roles != null)
            {
                foreach (Role role in roles)
                {
                    comboBoxRole.Items.Add(role);
                }
            }

            comboBoxRole.SelectedIndex = 0;
        }

        private void comboBoxRole_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void buttonRefresh_Click(object sender, RoutedEventArgs e)
        {
            LoadEntities();

            wrapPanelContainer.Children.Clear();

            RefreshWrapPanelContent();
        }
    }
}
