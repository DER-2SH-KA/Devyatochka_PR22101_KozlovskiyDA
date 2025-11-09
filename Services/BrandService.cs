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

        public Brand Create(
            string titleRaw,
            Country country,
            string addressRaw,
            string directorFirstNameRaw,
            string directorLastNameRaw,
            string directorMiddleNameRaw,
            string directorPhoneRaw,
            string directorPassportRaw
            
        ) {
            try
            {
                if (
                    string.IsNullOrEmpty(titleRaw) || 
                    country == null ||
                    string.IsNullOrEmpty(addressRaw) ||
                    string.IsNullOrEmpty(directorFirstNameRaw) ||
                    string.IsNullOrEmpty(directorLastNameRaw) ||
                    string.IsNullOrEmpty(directorPhoneRaw) ||
                    string.IsNullOrEmpty(directorPassportRaw)
                ) { return null; }

                string title = titleRaw.Trim();
                string address = addressRaw.Trim();
                string directorFirstName = directorFirstNameRaw.Trim();
                string directorLastName = directorLastNameRaw.Trim();
                string directorMiddleName = directorMiddleNameRaw != null ? directorMiddleNameRaw.Trim() : null;
                long directorPhone = Int64.Parse(directorPhoneRaw);
                long directorPassport = Int64.Parse(directorPassportRaw);

                if (
                    string.IsNullOrEmpty(title) ||
                    country == null ||
                    string.IsNullOrEmpty(address) ||
                    string.IsNullOrEmpty(directorFirstName) ||
                    string.IsNullOrEmpty(directorLastName)
                ) { return null; }

                Brand entityToCreate = new Brand();

                entityToCreate.Title = title;
                entityToCreate.CountryId = country.Id;
                entityToCreate.Address = address;
                entityToCreate.DirectorFirstName = directorFirstName;
                entityToCreate.DirectorLastName = directorLastName;
                entityToCreate.DirectorMiddleName = directorMiddleName;
                entityToCreate.DirectorPhone = directorPhone;
                entityToCreate.DirectorPassport = directorPassport;

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
