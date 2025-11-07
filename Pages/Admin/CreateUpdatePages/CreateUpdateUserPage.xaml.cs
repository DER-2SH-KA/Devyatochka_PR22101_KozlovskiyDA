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

namespace Devyatochka.Pages.Admin.CreateUpdatePages
{
    /// <summary>
    /// Логика взаимодействия для CreateUpdateUserPage.xaml
    /// </summary>
    public partial class CreateUpdateUserPage : Page
    {
        private User userToEditing;
        private ObservableCollection<Role> roles;

        private RoleService roleService;
        private UserService userService;


        public CreateUpdateUserPage()
        {
            roleService = RoleService.GetInstance();
            userService = UserService.GetInstance();

            InitializeComponent();

            LoadEntities();
            LoadComboBoxRoles();
        }

        public CreateUpdateUserPage(User user)
        {
            this.userToEditing = user;

            roleService = RoleService.GetInstance();
            userService = UserService.GetInstance();

            InitializeComponent();

            LoadEntities();
            LoadComboBoxRoles();

            FillFields();
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

        private void LoadEntities()
        {
            roles = roleService.GetAll();
        }

        private void FillFields()
        {
            if (userToEditing != null)
            {
                textBoxLogin.Text = userToEditing.Login;
                textBoxPassword.Text = userToEditing.Password;

                comboBoxRole.SelectedItem = userToEditing.Role;
            }
        }

        private void ClearFields()
        {
            textBoxLogin.Clear();
            textBoxPassword.Clear();

            if (comboBoxRole.Items.Count > 0) { comboBoxRole.SelectedIndex = 0; }
        }

        private void buttonSave_Click(object sender, RoutedEventArgs e)
        {
            if (this.userToEditing != null) {
                userToEditing.Login = textBoxLogin.Text.Trim();
                userToEditing.Password = textBoxPassword.Text.Trim();
                userToEditing.Role = (Role) comboBoxRole.SelectedItem;

                User savedUser = userService.Update(userToEditing);

                if (savedUser != null) { MessageBox.Show("Сущность обновлена!"); }
                else { MessageBox.Show("Сущность не была обновлена!");  }
            }
            else
            {
                User savedUser = userService.Create(textBoxLogin.Text, textBoxPassword.Text, (Role)comboBoxRole.SelectedItem);

                if (savedUser != null) { MessageBox.Show("Сущность создана!"); }
                else { MessageBox.Show("Сущность не была создана!"); }

            }
        }
    }
}
