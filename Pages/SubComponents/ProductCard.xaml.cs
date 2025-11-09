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
    /// Логика взаимодействия для ProductCard.xaml
    /// </summary>
    public partial class ProductCard : UserControl
    {
        private ProductService service;
        private Product entityForCard;

        public ProductCard(Product entity)
        {
            InitializeComponent();

            this.entityForCard = entity;
            this.service = ProductService.GetInstance();
            this.DataContext = entityForCard;
        }

        private void buttonEdit_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GetNavigationService(this).Navigate(new Admin.CreateUpdatePages.CreateUpdateProductPage(entityForCard));
        }

        private void buttonDelete_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show($"Вы уверены, что хотите удалить \"{entityForCard.Title}\"?", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                service.Delete(entityForCard);
                MessageBox.Show("Сущность удалена. Обновите список.");
            }
        }
    }
}
