using Devyatochka.Database;
using Devyatochka.Services;
using System;
using System.Collections.Generic;
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
    /// Логика взаимодействия для CreateUpdateRolePage.xaml
    /// </summary>
    public partial class CreateUpdateRolePage : Page
    {
        private Role roleToEditing;
        private RoleService roleService;

        public CreateUpdateRolePage()
        {
            InitializeComponent();
            roleService = RoleService.GetInstance();
        }

        public CreateUpdateRolePage(Role role)
        {
            InitializeComponent();
            roleService = RoleService.GetInstance();

            this.roleToEditing = role;
            FillFields();
        }

        private void FillFields()
        {
            if (roleToEditing != null)
            {
                textBoxTitle.Text = roleToEditing.Title;
            }
        }

        private void buttonSave_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxTitle.Text))
            {
                MessageBox.Show("Название не может быть пустым.");
                return;
            }

            if (this.roleToEditing != null)
            {
                roleToEditing.Title = textBoxTitle.Text.Trim();
                var updatedRole = roleService.Update(roleToEditing);
                if (updatedRole != null)
                {
                    MessageBox.Show("Сущность обновлена!");
                    NavigationService.GoBack();
                }
                else { MessageBox.Show("Сущность не была обновлена!"); }
            }
            else
            {
                var createdRole = roleService.Create(textBoxTitle.Text.Trim());
                if (createdRole != null)
                {
                    MessageBox.Show("Сущность создана!");
                    NavigationService.GoBack();
                }
                else { MessageBox.Show("Сущность не была создана!"); }
            }
        }
    }
}
