using System;

namespace Common.Attributes {
    public class ATTR_Product : AttributeBaseClass {
        public int? ProductID { get; set; }
        public string       Name { get; set; }
        public int       CategoryID { get; set; }
        public string       Description { get; set; }
        public int       BrandID { get; set; }

        public DateTime    ExpirationDate { get; set; }

        public int         LotID { get; set; }
        public float       PurchasePrice { get; set; }
        public float       SalePrice { get; set; }

        public int LeadTimeDays;
        public int MinimumStock;
        public int CriticalStock;
        public int IdealStock;
        public string StockType { get; set; }

        public ATTR_Product() {
            SearchThroughWith = [
                    "Name",
                    "CategoryID",
                    "BrandID"
                ];
        }

        public ATTR_Product(
            int? product_id,
            string name,
            int category_id,
            string description,
            int brand_id,
            DateTime expiration_date,
            int lot_id,
            float purchase_price,
            float sale_price,
            int lead_time_days,
            int minimum_stock,
            int critical_stock,
            int ideal_stock,
            string stock_type
        ) {
            SearchThroughWith = [
                "Name",
                "CategoryID",
                "BrandID"
            ];
            ProductID = product_id;
            Name = name;
            CategoryID = category_id;
            Description = description;
            BrandID = brand_id;
            ExpirationDate = expiration_date;
            LotID = lot_id;
            PurchasePrice = purchase_price;
            SalePrice = sale_price;
            LeadTimeDays = lead_time_days;
            MinimumStock = minimum_stock;
            CriticalStock = critical_stock;
            IdealStock = ideal_stock;
            StockType = stock_type;
        }
    }
}