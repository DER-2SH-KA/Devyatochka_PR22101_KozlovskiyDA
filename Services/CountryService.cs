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
    public class CountryService
    {
        private static CountryService instance;

        public static CountryService GetInstance()
        {
            if (instance == null)
            {
                instance = new CountryService();
            }

            return instance;
        }

        private CountryService() { }

        public ObservableCollection<Country> GetAll()
        {
            try
            {
                return SqlHelper.GetCountries();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

            return new ObservableCollection<Country>();
        }

        public Country GetById(long id)
        {
            try
            {
                return SqlHelper.GetCountryById(id);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

            return null;
        }

        public Country Create(string titleRaw)
        {
            try
            {
                if (titleRaw == null) { return null; }

                string title = titleRaw.Trim();

                if (title.Equals("")) { return null; }

                Country entityToCreate = new Country();

                entityToCreate.Title = title;

                return SqlHelper.CreateCountry(entityToCreate);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

            return null;
        }

        public Country Update(Country entity)
        {
            try
            {
                if (entity == null)
                {
                    MessageBox.Show("Сущность для обновления равна нулю");
                    return null;
                }

                return SqlHelper.UpdateCountry(entity);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return null;
        }

        public void Delete(Country entity)
        {
            try
            {
                if (entity == null)
                {
                    MessageBox.Show("Сущность для удаления равна нулю");
                }

                SqlHelper.DeleteCountry(entity);
                MessageBox.Show("Сущность удалена");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
