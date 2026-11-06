using System;
using System.Collections.Generic;

namespace Common.Attributes {
    public class ATTR_Provider : AttributeBaseClass {
        public int? ProviderID { get; set; }
        public string Name { get; set; }
        public int PhoneNumber { get; set; }
        public string Email { get; set; }
        public string CUIT { get; set; }

        public string Address { get; set; }
        public string PaymentMethod { get; set; }
        //public List<string>? DeliveryTimes { get; set; }

        //public Dictionary<int, float>? AppliedDiscounts { get; set; }
        //public List<string>? OfferedProductCategories { get; set; }

        public ATTR_Provider() {
            SearchThroughWith = [
                "Name",
                "CUIT"
            ];
        }

        public ATTR_Provider(
            int? provider_id,
            string name,
            int phone_number,
            string email,
            string cuit,
            string address,
            string payment_method
            //List<string>? delivery_times,
            //Dictionary<int, float>? applied_discounts,
            //List<string>? offered_product_categories
        ) {
            SearchThroughWith = [
                "Name",
                "CUIT"
            ];

            ProviderID = provider_id;
            Name = name;
            PhoneNumber = phone_number;
            Email = email;
            CUIT = cuit;
            Address = address;
            PaymentMethod = payment_method;
            //DeliveryTimes = delivery_times;
            //AppliedDiscounts = applied_discounts;
            //OfferedProductCategories = offered_product_categories;
        }
    }
}