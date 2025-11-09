using Devyatochka.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devyatochka.Model
{
    public class ProductCostModel
    {
        public long Id { get; set; }
        public Product Product { get; set; }
        public float DefaultCost { get; set; }
        public Nullable<short> Discount { get; set; }
        public DiscountType DiscountType { get; set; }
        public double FinalCost { get; set; }

        public double GetFinalCost()
        {
            if (Discount == null)
            {
                return DefaultCost;
            }
            else
            {
                return Math.Round((double) (DefaultCost * (1.0 - (Discount.Value / 100))), 2);
            }
        }

        public ProductCostModel(ProductCost entity) { 
            this.Id = entity.Id;
            this.Product = entity.Product;
            this.DefaultCost = entity.DefaultCost;
            this.Discount = entity.Discount;
            this.DiscountType = entity.DiscountType;
            this.FinalCost = GetFinalCost();
        }
    }
}
