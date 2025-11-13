using Devyatochka.Database;
using Devyatochka.Model;
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
    /// Логика взаимодействия для ProductCostCard.xaml
    /// </summary>
    public partial class ProductCostCard : UserControl
    {
        private ProductCostService service;

        private ProductCost entityForCard;
        private ProductCostModel model;

        public ProductCostCard(ProductCost entity, bool isAdmin)
        {
            InitializeComponent();

            this.entityForCard = entity;
            this.service = ProductCostService.GetInstance();
            this.model = new ProductCostModel(entityForCard);

            this.DataContext = model;

            try
            {
                if (string.IsNullOrWhiteSpace(entity.Product.ImageUri))
                {
                    imageProductPhoto.Visibility = Visibility.Collapsed;
                }
                else
                {
                    imageProductPhoto.Visibility = Visibility.Visible;
                    imageProductPhoto.Source = new BitmapImage(
                        new Uri(model.Product.ImageUri, UriKind.Absolute)
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Не удалось загрузить карточку товара: " + model.Product.Title);
            }

            if (entity.Discount == null)
            {
                textBlockDiscount.Visibility = Visibility.Collapsed;
                textBlockDiscountType.Visibility = Visibility.Collapsed;
            }
            else
            {
                textBlockDiscount.Visibility = Visibility.Visible;
                textBlockDiscountType.Visibility= Visibility.Visible;
            }

            buttonEdit.Visibility = isAdmin ? Visibility.Visible : Visibility.Collapsed;
            buttonDelete.Visibility = isAdmin ? Visibility.Visible : Visibility.Collapsed;
        }

        private void buttonEdit_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GetNavigationService(this).Navigate(new Admin.CreateUpdatePages.CreateUpdateProductCostPage(entityForCard));
        }

        private void buttonDelete_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show($"Вы уверены, что хотите удалить \"{entityForCard.Product.Title}\"?", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                service.Delete(entityForCard);
                MessageBox.Show("Сущность удалена. Обновите список.");
            }
        }
    }
}
