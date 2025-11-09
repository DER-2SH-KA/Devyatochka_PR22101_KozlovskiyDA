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
    /// Логика взаимодействия для ChooseMenuType.xaml
    /// </summary>
    public partial class ChooseMenuType : Page
    {
        public ChooseMenuType()
        {
            InitializeComponent();
        }

        private void btnIAmAdmin_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Pages.AuthPage());
        }

        private void btnIAmClient_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Pages.Admin.ProductCostList(false));
        }
    }
}
