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
    /// Логика взаимодействия для CreateUpdateProductPage.xaml
    /// </summary>
    public partial class CreateUpdateProductPage : Page
    {
        private Product entityToEditing;

        private ProductService service;

        private WeightTypeService weightTypeService;
        private BrandService brandService;
        private ProductCategoryService productCategoryService;
        private CountryService countryService;

        private ObservableCollection<Product> products;

        private ObservableCollection<WeightType> weightTypes;
        private ObservableCollection<Brand> brands;
        private ObservableCollection<ProductCategory> productCategories;
        private ObservableCollection<Country> countries;

        public CreateUpdateProductPage()
        {
            InitializeComponent();

            service = ProductService.GetInstance();

            weightTypeService = WeightTypeService.GetInstance();
            brandService = BrandService.GetInstance();
            productCategoryService = ProductCategoryService.GetInstance();
            countryService = CountryService.GetInstance();

            LoadEntities();

            LoadComboBoxWeightType();
            LoadComboBoxBrand();
            LoadComboBoxProductCategory();
            LoadComboBoxCountries();
        }

        public CreateUpdateProductPage(Product entity)
        {
            InitializeComponent();

            service = ProductService.GetInstance();

            weightTypeService = WeightTypeService.GetInstance();
            brandService = BrandService.GetInstance();
            productCategoryService = ProductCategoryService.GetInstance();
            countryService = CountryService.GetInstance();

            this.entityToEditing = entity;

            LoadEntities();

            LoadComboBoxWeightType();
            LoadComboBoxBrand();
            LoadComboBoxProductCategory();
            LoadComboBoxCountries();

            FillFields();
        }

        private void LoadEntities()
        {
            products = service.GetAll();

            weightTypes = weightTypeService.GetAll();
            brands = brandService.GetAll();
            productCategories = productCategoryService.GetAll();
            countries = countryService.GetAll();
        }

        private void LoadComboBoxWeightType()
        {
            if (weightTypes != null)
            {
                foreach (WeightType entity in weightTypes)
                {
                    comboBoxWeightType.Items.Add(entity);
                }

                comboBoxWeightType.SelectedIndex = 0;
            }
        }

        private void LoadComboBoxBrand()
        {
            if (brands!= null)
            {
                foreach (Brand entity in brands)
                {
                    comboBoxBrand.Items.Add(entity);
                }

                comboBoxBrand.SelectedIndex = 0;
            }
        }

        private void LoadComboBoxProductCategory()
        {
            if (productCategories != null)
            {
                foreach (ProductCategory entity in productCategories)
                {
                    comboBoxProductCategory.Items.Add(entity);
                }

                comboBoxProductCategory.SelectedIndex = 0;
            }
        }

        private void LoadComboBoxCountries()
        {
            if (countries != null)
            {
                foreach (Country entity in countries)
                {
                    comboBoxCountryOfOrigin.Items.Add(entity);
                }

                comboBoxCountryOfOrigin.SelectedIndex = 0;
            }
        }

        private void FillFields()
        {
            if (entityToEditing != null)
            {
                textBoxTitle.Text = entityToEditing.Title;
                textBoxDescription.Text = entityToEditing.Description == null ? 
                    "" : entityToEditing.Description;
                textBoxCompound.Text = entityToEditing.Compound;
                textBoxConditionsOfContain.Text = entityToEditing.ConditionsOfContain;
                textBoxWeight.Text = entityToEditing.Weight.ToString();
                comboBoxWeightType.SelectedItem = entityToEditing.WeightType;
                textBoxExpirationDate.Text = entityToEditing.ExpirationDate == null ? 
                    "" : entityToEditing.ExpirationDate;
                comboBoxBrand.SelectedItem = entityToEditing.Brand;
                comboBoxProductCategory.SelectedItem = entityToEditing.ProductCategory;
                comboBoxCountryOfOrigin.SelectedItem = entityToEditing.Country;
            }
        }

        private void buttonSave_Click(object sender, RoutedEventArgs e)
        {
            if (
                string.IsNullOrWhiteSpace(textBoxTitle.Text) ||
                string.IsNullOrWhiteSpace(textBoxCompound.Text) ||
                string.IsNullOrWhiteSpace(textBoxConditionsOfContain.Text) ||
                string.IsNullOrWhiteSpace(textBoxWeight.Text) || 
                comboBoxWeightType.SelectedItem == null ||
                comboBoxBrand.SelectedItem == null ||
                comboBoxProductCategory.SelectedItem == null ||
                comboBoxCountryOfOrigin.SelectedItem == null
            ) {
                MessageBox.Show("Поля не могут быть пустыми.");
                return;
            }

            if (this.entityToEditing != null)
            {
                try
                {
                    entityToEditing.Title = textBoxTitle.Text.Trim();
                    entityToEditing.Description = textBoxDescription.Text.Equals("") ? 
                        null : textBoxDescription.Text.Trim();
                    entityToEditing.Compound = textBoxCompound.Text;
                    entityToEditing.ConditionsOfContain = textBoxConditionsOfContain.Text;
                    entityToEditing.Weight = float.Parse(textBoxWeight.Text);
                    entityToEditing.WeightType = (WeightType)comboBoxWeightType.SelectedItem;
                    entityToEditing.ExpirationDate = textBoxExpirationDate.Text.Equals("") ?
                        null : textBoxExpirationDate.Text.Trim();
                    entityToEditing.Brand = (Brand)comboBoxBrand.SelectedItem;
                    entityToEditing.ProductCategory = (ProductCategory)comboBoxProductCategory.SelectedItem;
                    entityToEditing.Country = (Country) comboBoxCountryOfOrigin.SelectedItem;

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
                    textBoxDescription.Text,
                    textBoxCompound.Text,
                    textBoxWeight.Text,
                    (WeightType) comboBoxWeightType.SelectedItem,
                    textBoxExpirationDate.Text,
                    textBoxConditionsOfContain.Text,
                    (Brand) comboBoxBrand.SelectedItem,
                    (ProductCategory) comboBoxProductCategory.SelectedItem,
                    (Country) comboBoxCountryOfOrigin.SelectedItem
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
