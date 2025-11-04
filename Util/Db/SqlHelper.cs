using Devyatochka.Database;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devyatochka.Util.Db
{
    public class SqlHelper
    {
        private static DevyatochkaEntities instance = new DevyatochkaEntities();

        public static void LoadAllEntities()
        {
            instance.User.Load();
            instance.Role.Load();
            instance.Country.Load();
            instance.ProductCategory.Load();
            instance.Brand.Load();
            instance.WeightType.Load();
            instance.Product.Load();
            instance.DiscountType.Load();
            instance.ProductCost.Load();

        }

        // Get all.
        public static ObservableCollection<User> GetUsers() { return instance.User.Local; }
        public static ObservableCollection<Role> GetRoles() { return instance.Role.Local; }
        public static ObservableCollection<Country> GetCountries() { return instance.Country.Local; }
        public static ObservableCollection<ProductCategory> GetProductCategories() { return instance.ProductCategory.Local; }
        public static ObservableCollection<Brand> GetBrands() { return instance.Brand.Local; }
        public static ObservableCollection<WeightType> GetWeightTypes() { return instance.WeightType.Local; }
        public static ObservableCollection<Product> GetProducts() { return instance.Product.Local; }
        public static ObservableCollection<DiscountType> GetDiscountTypes() { return instance.DiscountType.Local; }
        public static ObservableCollection<ProductCost> GetProductCosts() { return instance.ProductCost.Local; }

        // Get by ID.
        public static User GetUserById(long id) { return instance.User.Find(id); }
        public static Role GetRoleById(long id) { return instance.Role.Find(id); }
        public static Country GetCountryById(long id) { return instance.Country.Find(id); }
        public static ProductCategory GetProductCategoryById(long id) { return instance.ProductCategory.Find(id); }
        public static Brand GetBrandById(long id) { return instance.Brand.Find(id); }
        public static WeightType GetWeightTypeById(long id) { return instance.WeightType.Find(id); }
        public static Product GetProductById(long id) { return instance.Product.Find(id); }
        public static DiscountType GetDiscountTypeById(long id) { return instance.DiscountType.Find(id); }
        public static ProductCost GetProductCostById(long id) { return instance.ProductCost.Find(id); }

        // Create.
        public static User CreateUser(User newEntity)
        {
            User savedEntity = instance.User.Add(newEntity);
            instance.SaveChanges();

            return savedEntity;
        }

        public static Role CreateRole(Role newEntity)
        {
            Role savedEntity = instance.Role.Add(newEntity);
            instance.SaveChanges();

            return savedEntity;
        }

        public static Country CreateCountry(Country newEntity)
        {
            Country savedEntity = instance.Country.Add(newEntity);
            instance.SaveChanges();

            return savedEntity;
        }

        public static ProductCategory CreateProductCategory(ProductCategory newEntity)
        {
            ProductCategory savedEntity = instance.ProductCategory.Add(newEntity);
            instance.SaveChanges();

            return savedEntity;
        }

        public static Brand CreateBrand(Brand newEntity)
        {
            Brand savedEntity = instance.Brand.Add(newEntity);
            instance.SaveChanges();

            return savedEntity;
        }

        public static WeightType CreateWeightType(WeightType newEntity)
        {
            WeightType savedEntity = instance.WeightType.Add(newEntity);
            instance.SaveChanges();

            return savedEntity;
        }

        public static Product CreateProduct(Product newEntity)
        {
            Product savedEntity = instance.Product.Add(newEntity);
            instance.SaveChanges();

            return savedEntity;
        }

        public static DiscountType CreateDiscountType(DiscountType newEntity)
        {
            DiscountType savedEntity = instance.DiscountType.Add(newEntity);
            instance.SaveChanges();

            return savedEntity;
        }

        public static ProductCost CreateProductCost(ProductCost newEntity)
        {
            ProductCost savedEntity = instance.ProductCost.Add(newEntity);
            instance.SaveChanges();

            return savedEntity;
        }

        // Update.
        public static User UpdateUser(User modifiedEntity)
        {
            instance.User.Attach(modifiedEntity);
            instance.Entry(modifiedEntity).State = System.Data.EntityState.Modified;

            instance.SaveChanges();

            return GetUserById(modifiedEntity.Id);
        }

        public static Role UpdateRole(Role modifiedEntity)
        {
            instance.Role.Attach(modifiedEntity);
            instance.Entry(modifiedEntity).State = System.Data.EntityState.Modified;

            instance.SaveChanges();

            return GetRoleById(modifiedEntity.Id);
        }

        public static Country UpdateCountry(Country modifiedEntity)
        {
            instance.Country.Attach(modifiedEntity);
            instance.Entry(modifiedEntity).State = System.Data.EntityState.Modified;

            instance.SaveChanges();

            return GetCountryById(modifiedEntity.Id);
        }

        public static ProductCategory UpdateProductCategory(ProductCategory modifiedEntity)
        {
            instance.ProductCategory.Attach(modifiedEntity);
            instance.Entry(modifiedEntity).State = System.Data.EntityState.Modified;

            instance.SaveChanges();

            return GetProductCategoryById(modifiedEntity.Id);
        }

        public static Brand UpdateBrand(Brand modifiedEntity)
        {
            instance.Brand.Attach(modifiedEntity);
            instance.Entry(modifiedEntity).State = System.Data.EntityState.Modified;

            instance.SaveChanges();

            return GetBrandById(modifiedEntity.Id);
        }

        public static WeightType UpdateWeightType(WeightType modifiedEntity)
        {
            instance.WeightType.Attach(modifiedEntity);
            instance.Entry(modifiedEntity).State = System.Data.EntityState.Modified;

            instance.SaveChanges();

            return GetWeightTypeById(modifiedEntity.Id);
        }

        public static Product UpdateProduct(Product modifiedEntity)
        {
            instance.Product.Attach(modifiedEntity);
            instance.Entry(modifiedEntity).State = System.Data.EntityState.Modified;

            instance.SaveChanges();

            return GetProductById(modifiedEntity.Id);
        }

        public static DiscountType UpdateDiscountType(DiscountType modifiedEntity)
        {
            instance.DiscountType.Attach(modifiedEntity);
            instance.Entry(modifiedEntity).State = System.Data.EntityState.Modified;

            instance.SaveChanges();

            return GetDiscountTypeById(modifiedEntity.Id);
        }

        public static ProductCost UpdateProductCost(ProductCost modifiedEntity)
        {
            instance.ProductCost.Attach(modifiedEntity);
            instance.Entry(modifiedEntity).State = System.Data.EntityState.Modified;

            instance.SaveChanges();

            return GetProductCostById(modifiedEntity.Id);
        }

        // Delete.
        public static void DeleteUser(User entity)
        {
            instance.User.Remove(entity);
            instance.SaveChanges();
        }

        public static void DeleteRole(Role entity)
        {
            instance.Role.Remove(entity);
            instance.SaveChanges();
        }

        public static void DeleteCountry(Country entity)
        {
            instance.Country.Remove(entity);
            instance.SaveChanges();
        }

        public static void DeleteProductCategory(ProductCategory entity)
        {
            instance.ProductCategory.Remove(entity);
            instance.SaveChanges();
        }

        public static void DeleteBrand(Brand entity)
        {
            instance.Brand.Remove(entity);
            instance.SaveChanges();
        }

        public static void DeleteWeightType(WeightType entity)
        {
            instance.WeightType.Remove(entity);
            instance.SaveChanges();
        }

        public static void DeleteProduct(Product entity)
        {
            instance.Product.Remove(entity);
            instance.SaveChanges();
        }

        public static void DeleteDiscountType(DiscountType entity)
        {
            instance.DiscountType.Remove(entity);
            instance.SaveChanges();
        }

        public static void DeleteProductCost(ProductCost entity)
        {
            instance.ProductCost.Remove(entity);
            instance.SaveChanges();
        }

        // Get custom.
        public static User GetUserByLoginAndPassword(string login, string password)
        {
            return instance.User
                .Where(x => x.Login.Equals(login) && x.Password.Equals(password))
                .First();
        }

        public static User ExistsUserWithLogin(string login)
        {
            return instance.User
                .Where(x => x.Login.Equals(login))
                .First();
        }
    }
}
