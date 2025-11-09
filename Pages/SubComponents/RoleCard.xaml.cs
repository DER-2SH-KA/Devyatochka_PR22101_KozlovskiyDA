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

namespace Devyatochka.Pages.SubComponents
{
    /// <summary>
    /// Логика взаимодействия для RoleCard.xaml
    /// </summary>
    public partial class RoleCard : UserControl
    {
        private RoleService roleService;
        private Role roleForCard;

        public RoleCard(Role role)
        {
            InitializeComponent();

            this.roleForCard = role;
            this.roleService = RoleService.GetInstance();
            this.DataContext = roleForCard;
        }

        private void buttonEdit_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GetNavigationService(this).Navigate(new Admin.CreateUpdatePages.CreateUpdateRolePage(roleForCard));
        }

        private void buttonDelete_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show($"Вы уверены, что хотите удалить роль \"{roleForCard.Title}\"?", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                roleService.Delete(roleForCard);
                MessageBox.Show("Роль удалена. Обновите список.");
            }
        }
    }
}
