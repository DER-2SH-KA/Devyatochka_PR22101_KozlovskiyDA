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
    /// Логика взаимодействия для UserCard.xaml
    /// </summary>
    public partial class UserCard : UserControl
    {
        private UserService userService;

        private User userForCard;

        public UserCard(User userForCard)
        {
            this.userForCard = userForCard;

            userService = UserService.GetInstance();

            this.DataContext = userForCard;

            InitializeComponent();
        }

        private void buttonEdit_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GetNavigationService(this).Navigate(new Pages.Admin.CreateUpdatePages.CreateUpdateUserPage(userForCard));
        }

        private void buttonDelete_Click(object sender, RoutedEventArgs e)
        {
            userService.Delete(userForCard);
        }
    }
}
