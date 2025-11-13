using Devyatochka.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

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
            if (Discount == null || Discount == (short) 0)
            {
                return DefaultCost;
            }
            else
            {
                double disc =
                    ((double)DefaultCost * ((double) ((short) 100 - Discount.Value) / 100));

                return disc;
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
