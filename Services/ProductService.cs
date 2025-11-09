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

        public Product Create(string titleRaw)
        {
            try
            {
                if (titleRaw == null) { return null; }

                string title = titleRaw.Trim();

                if (title.Equals("")) { return null; }

                Product entityToCreate = new Product();

                entityToCreate.Title = title;

                // return SqlHelper.CreateProduct(entityToCreate);
                return null;
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

                // return SqlHelper.UpdateCountry(entity);
                return null;
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
