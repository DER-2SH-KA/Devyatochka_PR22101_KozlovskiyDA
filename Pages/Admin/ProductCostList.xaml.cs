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

namespace Devyatochka.Pages.Admin
{
    /// <summary>
    /// Логика взаимодействия для ProductCostList.xaml
    /// </summary>
    public partial class ProductCostList : Page
    {
        private ProductCostService service;
        private ObservableCollection<ProductCost> entities;
        private bool isAdminPrivate = false;

        public ProductCostList(bool isAdmin)
        {
            InitializeComponent();
            service = ProductCostService.GetInstance();

            this.isAdminPrivate = isAdmin;

            LoadEntities();
            RefreshWrapPanelContent();

            buttonCreate.Visibility = isAdminPrivate ? Visibility.Visible : Visibility.Hidden;
        }

        private void LoadEntities()
        {
            entities = service.GetAll();
        }

        private void RefreshWrapPanelContent()
        {
            wrapPanelContainer.Children.Clear();

            var filteredEntities = entities.Where(r =>
                string.IsNullOrWhiteSpace(textBoxTitle.Text) ||
                r.Product.Title.ToLower().Contains(textBoxTitle.Text.Trim().ToLower())
            );

            foreach (var entity in filteredEntities)
            {
                wrapPanelContainer.Children.Add(new SubComponents.ProductCostCard(entity, isAdminPrivate));
            }
        }

        private void buttonRefresh_Click(object sender, RoutedEventArgs e)
        {
            LoadEntities();
            RefreshWrapPanelContent();
        }

        private void buttonCreate_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new CreateUpdatePages.CreateUpdateProductCostPage());
        }
    }
}
