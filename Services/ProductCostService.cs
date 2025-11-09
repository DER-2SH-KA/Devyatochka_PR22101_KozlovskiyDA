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

        public ProductCost Create(string titleRaw)
        {
            try
            {
                if (titleRaw == null) { return null; }

                string title = titleRaw.Trim();

                if (title.Equals("")) { return null; }

                ProductCost entityToCreate = new ProductCost();

                // entityToCreate.Title = title;

                // return SqlHelper.CreateProduct(entityToCreate);
                return null;
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

                // return SqlHelper.UpdateCountry(entity);
                return null;
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
