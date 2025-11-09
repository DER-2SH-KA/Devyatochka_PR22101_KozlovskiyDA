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
    public class ProductCategoryService
    {
        private static ProductCategoryService instance;

        public static ProductCategoryService GetInstance()
        {
            if (instance == null)
            {
                instance = new ProductCategoryService();
            }

            return instance;
        }

        private ProductCategoryService() { }

        public ObservableCollection<ProductCategory> GetAll()
        {
            try
            {
                return SqlHelper.GetProductCategories();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

            return new ObservableCollection<ProductCategory>();
        }

        public ProductCategory GetById(long id)
        {
            try
            {
                return SqlHelper.GetProductCategoryById(id);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

            return null;
        }

        public ProductCategory Create(string titleRaw)
        {
            try
            {
                if (titleRaw == null) { return null; }

                string title = titleRaw.Trim();

                if (title.Equals("")) { return null; }

                ProductCategory entityToCreate = new ProductCategory();

                entityToCreate.Title = title;

                return SqlHelper.CreateProductCategory(entityToCreate);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

            return null;
        }

        public ProductCategory Update(ProductCategory entity)
        {
            try
            {
                if (entity == null)
                {
                    MessageBox.Show("Сущность для обновления равна нулю");
                    return null;
                }

                return SqlHelper.UpdateProductCategory(entity);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return null;
        }

        public void Delete(ProductCategory entity)
        {
            try
            {
                if (entity == null)
                {
                    MessageBox.Show("Сущность для удаления равна нулю");
                }

                SqlHelper.DeleteProductCategory(entity);
                MessageBox.Show("Сущность удалена");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
