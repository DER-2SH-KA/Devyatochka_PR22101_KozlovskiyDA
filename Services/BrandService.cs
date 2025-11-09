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
    public class BrandService
    {
        private static BrandService instance;

        public static BrandService GetInstance()
        {
            if (instance == null)
            {
                instance = new BrandService();
            }

            return instance;
        }

        private BrandService() { }

        public ObservableCollection<Brand> GetAll()
        {
            try
            {
                return SqlHelper.GetBrands();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

            return new ObservableCollection<Brand>();
        }

        public Brand GetById(long id)
        {
            try
            {
                return SqlHelper.GetBrandById(id);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

            return null;
        }

        public Brand Create(string titleRaw)
        {
            try
            {
                if (titleRaw == null) { return null; }

                string title = titleRaw.Trim();

                if (title.Equals("")) { return null; }

                Brand entityToCreate = new Brand();

                entityToCreate.Title = title;

                return SqlHelper.CreateBrand(entityToCreate);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

            return null;
        }

        public Brand Update(Brand entity)
        {
            try
            {
                if (entity == null)
                {
                    MessageBox.Show("Сущность для обновления равна нулю");
                    return null;
                }

                return SqlHelper.UpdateBrand(entity);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return null;
        }

        public void Delete(Brand entity)
        {
            try
            {
                if (entity == null)
                {
                    MessageBox.Show("Сущность для удаления равна нулю");
                }

                SqlHelper.DeleteBrand(entity);
                MessageBox.Show("Сущность удалена");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
