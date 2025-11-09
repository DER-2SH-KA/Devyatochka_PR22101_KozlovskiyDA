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
    public class WeightTypeService
    {
        private static WeightTypeService instance;

        public static WeightTypeService GetInstance()
        {
            if (instance == null)
            {
                instance = new WeightTypeService();
            }

            return instance;
        }

        private WeightTypeService() { }

        public ObservableCollection<WeightType> GetAll()
        {
            try
            {
                return SqlHelper.GetWeightTypes();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

            return new ObservableCollection<WeightType>();
        }

        public WeightType GetById(long id)
        {
            try
            {
                return SqlHelper.GetWeightTypeById(id);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

            return null;
        }

        public WeightType Create(string titleRaw)
        {
            try
            {
                if (titleRaw == null) { return null; }

                string title = titleRaw.Trim();

                if (title.Equals("")) { return null; }

                WeightType entityToCreate = new WeightType();

                entityToCreate.Title = title;

                return SqlHelper.CreateWeightType(entityToCreate);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

            return null;
        }

        public WeightType Update(WeightType entity)
        {
            try
            {
                if (entity == null)
                {
                    MessageBox.Show("Сущность для обновления равна нулю");
                    return null;
                }

                return SqlHelper.UpdateWeightType(entity);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return null;
        }

        public void Delete(WeightType entity)
        {
            try
            {
                if (entity == null)
                {
                    MessageBox.Show("Сущность для удаления равна нулю");
                }

                SqlHelper.DeleteWeightType(entity);
                MessageBox.Show("Сущность удалена");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
