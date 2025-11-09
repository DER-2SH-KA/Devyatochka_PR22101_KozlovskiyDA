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

        public ObservableCollection<DiscountType> GetAll()
        {
            try
            {
                return SqlHelper.GetDiscountTypes();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

            return new ObservableCollection<DiscountType>();
        }

        public DiscountType GetById(long id)
        {
            try
            {
                return SqlHelper.GetDiscountTypeById(id);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

            return null;
        }

        public DiscountType Create(string titleRaw)
        {
            try
            {
                if (titleRaw == null) { return null; }

                string title = titleRaw.Trim();

                if (title.Equals("")) { return null; }

                DiscountType entityToCreate = new DiscountType();

                entityToCreate.Title = title;

                return SqlHelper.CreateDiscountType(entityToCreate);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

            return null;
        }

        public DiscountType Update(DiscountType entity)
        {
            try
            {
                if (entity == null)
                {
                    MessageBox.Show("Сущность для обновления равна нулю");
                    return null;
                }

                return SqlHelper.UpdateDiscountType(entity);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return null;
        }

        public void Delete(DiscountType entity)
        {
            try
            {
                if (entity == null)
                {
                    MessageBox.Show("Сущность для удаления равна нулю");
                }

                SqlHelper.DeleteDiscountType(entity);
                MessageBox.Show("Сущность удалена");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
