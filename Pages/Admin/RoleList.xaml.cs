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
    /// Логика взаимодействия для RoleList.xaml
    /// </summary>
    public partial class RoleList : Page
    {
        private RoleService roleService;
        private ObservableCollection<Role> roles;

        public RoleList()
        {
            InitializeComponent();
            roleService = RoleService.GetInstance();
            LoadEntities();
            RefreshWrapPanelContent();
        }

        private void LoadEntities()
        {
            roles = roleService.GetAll();
        }

        private void RefreshWrapPanelContent()
        {
            wrapPanelContainer.Children.Clear();

            var filteredRoles = roles.Where(r =>
                string.IsNullOrWhiteSpace(textBoxTitle.Text) ||
                r.Title.ToLower().Contains(textBoxTitle.Text.Trim().ToLower())
            );

            foreach (var role in filteredRoles)
            {
                wrapPanelContainer.Children.Add(new SubComponents.RoleCard(role));
            }
        }

        private void buttonRefresh_Click(object sender, RoutedEventArgs e)
        {
            LoadEntities();
            RefreshWrapPanelContent();
        }

        private void buttonCreate_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new CreateUpdatePages.CreateUpdateRolePage());
        }
    }
}
