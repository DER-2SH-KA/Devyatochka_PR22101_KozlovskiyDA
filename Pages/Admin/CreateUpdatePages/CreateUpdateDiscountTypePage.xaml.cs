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
    /// Логика взаимодействия для CreateUpdateDiscountTypePage.xaml
    /// </summary>
    public partial class CreateUpdateDiscountTypePage : Page
    {
        private DiscountType entityToEditing;
        private DiscountTypeService service;

        public CreateUpdateDiscountTypePage()
        {
            InitializeComponent();
            service = DiscountTypeService.GetInstance();
        }

        public CreateUpdateDiscountTypePage(DiscountType entity)
        {
            InitializeComponent();
            service = DiscountTypeService.GetInstance();

            this.entityToEditing = entity;
            FillFields();
        }

        private void FillFields()
        {
            if (entityToEditing != null)
            {
                textBoxTitle.Text = entityToEditing.Title;
            }
        }

        private void buttonSave_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxTitle.Text))
            {
                MessageBox.Show("Название не может быть пустым.");
                return;
            }

            if (this.entityToEditing != null)
            {
                entityToEditing.Title = textBoxTitle.Text.Trim();
                var updatedEntity = service.Update(entityToEditing);
                if (updatedEntity != null)
                {
                    MessageBox.Show("Сущность обновлена!");
                    NavigationService.GoBack();
                }
                else { MessageBox.Show("Сущность не была обновлена!"); }
            }
            else
            {
                var createdEntity = service.Create(textBoxTitle.Text.Trim());
                if (createdEntity != null)
                {
                    MessageBox.Show("Сущность создана!");
                    NavigationService.GoBack();
                }
                else { MessageBox.Show("Сущность не была создана!"); }
            }
        }
    }
}
