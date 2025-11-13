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
    public class ProductService
    {
        private static ProductService instance;

        public static ProductService GetInstance()
        {
            if (instance == null)
            {
                instance = new ProductService();
            }

            return instance;
        }

        private ProductService() { }

        public ObservableCollection<Product> GetAll()
        {
            try
            {
                return SqlHelper.GetProducts();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

            return new ObservableCollection<Product>();
        }

        public Product GetById(long id)
        {
            try
            {
                return SqlHelper.GetProductById(id);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

            return null;
        }

        public Product Create(
            string titleRaw,
            string descriptionRaw,
            string compoundRaw,
            string weightRaw,
            WeightType weightType,
            string expirationDateRaw,
            string conditionsOfContainRaw,
            Brand brand,
            ProductCategory productCategory,
            Country countryOfOrigin
        )
        {
            try
            {
                if (
                string.IsNullOrWhiteSpace(titleRaw) ||
                string.IsNullOrWhiteSpace(compoundRaw) ||
                string.IsNullOrWhiteSpace(conditionsOfContainRaw) ||
                string.IsNullOrWhiteSpace(weightRaw) ||
                weightType == null ||
                brand == null ||
                productCategory == null ||
                countryOfOrigin == null
                ) { return null; }

                string title = titleRaw.Trim();
                string description = descriptionRaw.Trim().Equals("") ? 
                    null : descriptionRaw.Trim();
                string compound = compoundRaw.Trim();
                float weight = float.Parse(weightRaw.Trim());
                string expirationDate = expirationDateRaw.Trim().Equals("") ?
                    null : expirationDateRaw.Trim();
                string conditionsOfContain = conditionsOfContainRaw.Trim();

                if (
                string.IsNullOrWhiteSpace(titleRaw) ||
                string.IsNullOrWhiteSpace(compoundRaw) ||
                string.IsNullOrWhiteSpace(conditionsOfContainRaw) ||
                string.IsNullOrWhiteSpace(weightRaw)
                ) { return null; }

                Product entityToCreate = new Product();

                entityToCreate.Title = title;
                entityToCreate.Description = description;
                entityToCreate.Compound = compound;
                entityToCreate.Weight = weight;
                entityToCreate.WeightType = weightType;
                entityToCreate.ExpirationDate = expirationDate;
                entityToCreate.ConditionsOfContain = conditionsOfContain;
                entityToCreate.Brand = brand;
                entityToCreate.ProductCategory = productCategory;
                entityToCreate.Country = countryOfOrigin;

                return SqlHelper.CreateProduct(entityToCreate);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

            return null;
        }

        public Product Update(Product entity)
        {
            try
            {
                if (entity == null)
                {
                    MessageBox.Show("Сущность для обновления равна нулю");
                    return null;
                }

                return SqlHelper.UpdateProduct(entity);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return null;
        }

        public void Delete(Product entity)
        {
            try
            {
                if (entity == null)
                {
                    MessageBox.Show("Сущность для удаления равна нулю");
                }

                SqlHelper.DeleteProduct(entity);
                MessageBox.Show("Сущность удалена");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
