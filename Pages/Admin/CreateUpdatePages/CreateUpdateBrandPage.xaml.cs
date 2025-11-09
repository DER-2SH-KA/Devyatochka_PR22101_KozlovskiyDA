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

namespace Devyatochka.Pages.Admin.CreateUpdatePages
{
    /// <summary>
    /// Логика взаимодействия для CreateUpdateBrandPage.xaml
    /// </summary>
    public partial class CreateUpdateBrandPage : Page
    {
        private Brand entityToEditing;

        private BrandService service;
        private CountryService countryService;

        private ObservableCollection<Country> countries;

        public CreateUpdateBrandPage()
        {
            InitializeComponent();

            service = BrandService.GetInstance();
            countryService = CountryService.GetInstance();

            LoadEntities();
            LoadComboBoxCountries();
        }

        public CreateUpdateBrandPage(Brand entity)
        {
            InitializeComponent();

            service = BrandService.GetInstance();
            countryService = CountryService.GetInstance();

            this.entityToEditing = entity;

            LoadEntities();
            LoadComboBoxCountries();

            FillFields();
        }

        private void LoadEntities()
        {
            countries = countryService.GetAll();
        }

        private void LoadComboBoxCountries()
        {
            if (countries != null)
            {
                foreach (Country entity in countries)
                {
                    comboBoxCountry.Items.Add(entity);
                }

                comboBoxCountry.SelectedIndex = 0;
            }
        }

        private void FillFields()
        {
            if (entityToEditing != null)
            {
                textBoxTitle.Text = entityToEditing.Title;
                comboBoxCountry.SelectedItem = entityToEditing.Country;
                textBoxAddress.Text = entityToEditing.Address;
                textBoxFName.Text = entityToEditing.DirectorFirstName;
                textBoxLName.Text = entityToEditing.DirectorLastName;
                textBoxMName.Text = entityToEditing.DirectorMiddleName == null ? "" : entityToEditing.DirectorMiddleName;
                textBoxPhone.Text = entityToEditing.DirectorPhone.ToString();
                textBoxPassport.Text = entityToEditing.DirectorPassport.ToString();
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
                try
                {
                    entityToEditing.Title = textBoxTitle.Text.Trim();
                    entityToEditing.Title = textBoxTitle.Text.Trim();
                    entityToEditing.Country = (Country)comboBoxCountry.SelectedItem;
                    entityToEditing.Address = textBoxAddress.Text.Trim();
                    entityToEditing.DirectorFirstName = textBoxFName.Text.Trim();
                    entityToEditing.DirectorLastName = textBoxLName.Text.Trim();
                    entityToEditing.DirectorMiddleName = textBoxMName.Text.Equals("") ? null : textBoxMName.Text.Trim();
                    entityToEditing.DirectorPhone = Convert.ToInt64(textBoxPhone.Text.Trim());
                    entityToEditing.DirectorPassport = Convert.ToInt64(textBoxPassport.Text.Trim());

                    var updatedEntity = service.Update(entityToEditing);
                    if (updatedEntity != null)
                    {
                        MessageBox.Show("Сущность обновлена!");
                        NavigationService.GoBack();
                    }
                    else { MessageBox.Show("Сущность не была обновлена!"); }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
            }
            else
            {
                var createdEntity = service.Create(
                    textBoxTitle.Text,
                    (Country) comboBoxCountry.SelectedItem,
                    textBoxAddress.Text,
                    textBoxFName.Text,
                    textBoxLName.Text,
                    textBoxMName.Text,
                    textBoxPhone.Text,
                    textBoxPassport.Text
                );

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
