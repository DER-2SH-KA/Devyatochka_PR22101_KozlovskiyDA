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
    /// Логика взаимодействия для BrandList.xaml
    /// </summary>
    public partial class BrandList : Page
    {
        private BrandService service;
        private ObservableCollection<Brand> entities;

        public BrandList()
        {
            InitializeComponent();
            service = BrandService.GetInstance();
            LoadEntities();
            RefreshWrapPanelContent();
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
                r.Title.ToLower().Contains(textBoxTitle.Text.Trim().ToLower())
            );

            foreach (var entity in filteredEntities)
            {
                wrapPanelContainer.Children.Add(new SubComponents.BrandCard(entity));
            }
        }

        private void buttonRefresh_Click(object sender, RoutedEventArgs e)
        {
            LoadEntities();
            RefreshWrapPanelContent();
        }

        private void buttonCreate_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new CreateUpdatePages.CreateUpdateBrandPage());
        }
    }
}
