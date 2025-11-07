using Devyatochka.Database;
using Devyatochka.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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

namespace Devyatochka.Pages
{
    /// <summary>
    /// Логика взаимодействия для SignUpPage.xaml
    /// </summary>
    public partial class SignUpPage : Page
    {
        private UserService userService;
        private RoleService roleService;

        private ObservableCollection<Role> roles;

        public SignUpPage()
        {
            InitializeComponent();

            userService = UserService.GetInstance();
            roleService = RoleService.GetInstance();

            LoadEntities();
            LoadComboBoxRoles();

            ClearFields();
        }

        private void buttonRegister_Click(object sender, RoutedEventArgs e)
        {
            User createdUser = userService.Create(
                textBoxLogin.Text,
                passwordBoxPassword.Password,
                (Role) comboBoxRole.SelectedItem
            );

            if (createdUser != null)
            {
                MessageBox.Show("Пользователь успешно создан!");
                ClearFields();
                this.NavigationService.Navigate(new Pages.AdminGeneralMenuPage());
            }
            else
            {
                MessageBox.Show("Пользователь не был создан!");
            }
        }

        private void LoadEntities()
        {
            roles = roleService.GetAll();
        }

        private void LoadComboBoxRoles()
        {
            if (roles != null)
            {
                foreach (Role role in roles)
                {
                    comboBoxRole.Items.Add(role);
                }
            }

            comboBoxRole.SelectedIndex = 0;
        }

        private void ClearFields()
        {
            textBoxLogin.Clear();
            passwordBoxPassword.Clear();
            comboBoxRole.SelectedIndex = 0;
        }
    }
}
