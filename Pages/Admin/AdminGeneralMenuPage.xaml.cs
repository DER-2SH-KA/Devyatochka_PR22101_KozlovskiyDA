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

namespace Devyatochka.Pages
{
    /// <summary>
    /// Логика взаимодействия для AdminGeneralMenuPage.xaml
    /// </summary>
    public partial class AdminGeneralMenuPage : Page
    {
        public AdminGeneralMenuPage()
        {
            InitializeComponent();
        }

        private void buttonUserList_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Pages.Admin.UserList());
        }
    }
}
