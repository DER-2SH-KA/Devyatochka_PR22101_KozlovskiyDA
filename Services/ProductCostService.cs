using Devyatochka.Database;
using Devyatochka.Util.Db;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Devyatochka.Services
{
    public class ProductCostService
    {
        private static ProductCostService instance;

        public static ProductCostService GetInstance()
        {
            if (instance == null)
            {
                instance = new ProductCostService();
            }

            return instance;
        }

        private ProductCostService() { }

        public ObservableCollection<ProductCost> GetAll()
        {
            try
            {
                return SqlHelper.GetProductCosts();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

            return new ObservableCollection<ProductCost>();
        }

        public ProductCost GetById(long id)
        {
            try
            {
                return SqlHelper.GetProductCostById(id);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

            return null;
        }

        public ProductCost Create(
            Product product,
            string defaultCostRaw,
            string discountRaw,
            DiscountType discountType
        )
        {
            try
            {
                if (
                    product == null ||
                    string.IsNullOrWhiteSpace(defaultCostRaw)
                ) { return null; }

                float defaultCost = float.Parse(defaultCostRaw.Trim());
                Int16 discount = string.IsNullOrWhiteSpace(discountRaw) ? 
                    (short) -1 : Int16.Parse(discountRaw.Trim());

                ProductCost entityToCreate = new ProductCost();

                entityToCreate.Product = product;
                entityToCreate.DefaultCost = defaultCost;

                if (discount == -1) {
                    entityToCreate.Discount = null;
                    entityToCreate.DiscountType = null;
                }
                else
                {
                    entityToCreate.Discount = discount;
                    entityToCreate.DiscountType = discountType;
                }

                return SqlHelper.CreateProductCost(entityToCreate);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

            return null;
        }

        public ProductCost Update(ProductCost entity)
        {
            try
            {
                if (entity == null)
                {
                    MessageBox.Show("Сущность для обновления равна нулю");
                    return null;
                }

                return SqlHelper.UpdateProductCost(entity);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return null;
        }

        public void Delete(ProductCost entity)
        {
            try
            {
                if (entity == null)
                {
                    MessageBox.Show("Сущность для удаления равна нулю");
                }

                SqlHelper.DeleteProductCost(entity);
                MessageBox.Show("Сущность удалена");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
