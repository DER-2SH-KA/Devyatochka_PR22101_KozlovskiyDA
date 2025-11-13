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
    /// Логика взаимодействия для CreateUpdateProductCostPage.xaml
    /// </summary>
    public partial class CreateUpdateProductCostPage : Page
    {
        private ProductCost entityToEditing;

        private ProductCostService service;

        private ProductService productService;
        private DiscountTypeService discountTypeService;

        private ObservableCollection<ProductCost> productCosts;
        private ObservableCollection<Product> products;
        private ObservableCollection<DiscountType> discountTypes;

        public CreateUpdateProductCostPage()
        {
            InitializeComponent();

            service = ProductCostService.GetInstance();

            productService = ProductService.GetInstance();
            discountTypeService = DiscountTypeService.GetInstance();

            LoadEntities();

            LoadComboBoxProduct();
            LoadComboBoxDiscountType();
        }

        public CreateUpdateProductCostPage(ProductCost entity)
        {
            InitializeComponent();

            InitializeComponent();

            service = ProductCostService.GetInstance();

            productService = ProductService.GetInstance();
            discountTypeService = DiscountTypeService.GetInstance();

            this.entityToEditing = entity;

            LoadEntities();

            LoadComboBoxProduct();
            LoadComboBoxDiscountType();

            FillFields();
        }

        private void LoadEntities()
        {
            productCosts = service.GetAll();

            products = productService.GetAll();
            discountTypes = discountTypeService.GetAll();
        }

        private void LoadComboBoxProduct()
        {
            if (products != null)
            {
                foreach (Product entity in products)
                {
                    comboBoxProduct.Items.Add(entity);
                }

                comboBoxProduct.SelectedIndex = 0;
            }
        }

        private void LoadComboBoxDiscountType()
        {
            if (discountTypes != null)
            {
                foreach (DiscountType entity in discountTypes)
                {
                    comboBoxDiscountType.Items.Add(entity);
                }

                comboBoxDiscountType.SelectedIndex = 0;
            }
        }

        private void FillFields()
        {
            if (entityToEditing != null)
            {
                comboBoxProduct.SelectedItem = entityToEditing.Product;
                textBoxDefaultCost.Text = entityToEditing.DefaultCost.ToString();
                textBoxDicsount.Text = entityToEditing.Discount == null ?
                    "" : entityToEditing.Discount.ToString();

                DiscountType emptyDiscountType = new DiscountType();
                emptyDiscountType.Title = "<Не выбрано>";

                comboBoxDiscountType.SelectedItem = entityToEditing.DiscountType == null ? 
                    emptyDiscountType : entityToEditing.DiscountType;
            }
        }

        private void buttonSave_Click(object sender, RoutedEventArgs e)
        {
            if (
                comboBoxProduct.SelectedItem == null ||
                string.IsNullOrWhiteSpace(textBoxDefaultCost.Text.Trim())
            ) {
                MessageBox.Show("Поля не могут быть пустыми.");
                return;
            }

            if (this.entityToEditing != null)
            {
                try
                {
                    float defaultCost = float.Parse(textBoxDefaultCost.Text.Trim());
                    Int16 discount = string.IsNullOrWhiteSpace(textBoxDicsount.Text.Trim()) ?
                        (short)-1 : Int16.Parse(textBoxDicsount.Text.Trim());

                    MessageBox.Show(discount.ToString());

                    entityToEditing.Product = (Product) comboBoxProduct.SelectedItem;
                    entityToEditing.DefaultCost = defaultCost;

                    if (discount == (short)-1) {
                        entityToEditing.Discount = null;
                        entityToEditing.DiscountType = null;
                    }
                    else
                    {
                        entityToEditing.Discount = discount;
                        entityToEditing.DiscountType = (DiscountType)comboBoxDiscountType.SelectedItem;
                    }

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
                if (productCosts.Where(x => x.Product == (Product)comboBoxProduct.SelectedItem).First() != null) {
                    MessageBox.Show("Цена на этот товар уже указана!");
                    return;
                }

                var createdEntity = service.Create(
                    (Product) comboBoxProduct.SelectedItem,
                    textBoxDefaultCost.Text,
                    textBoxDicsount.Text,
                    (DiscountType) comboBoxDiscountType.SelectedItem
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
