using System;
using System.Collections.Generic;

namespace Common.Attributes {
    public class ATTR_Client : AttributeBaseClass {
        public int? ClientID { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string DNI { get; set; }
        public string CUIT { get; set; }

        public string Address { get; set; }
        public string PaymentMethod { get; set; }

        public Dictionary<int, float>? AppliedDiscounts;
        public float? CreditLimit { get; set; }

        public ATTR_Client() {
            SearchThroughWith = [
                "Name",
                "DNI",
                "CUIT"
            ];
        }

        public ATTR_Client(
            int? client_id,
            string name,
            string phone_number,
            string email,
            string dni,
            string cuit,
            string address,
            string payment_method,
            Dictionary<int, float>? applied_discounts,
            float? credit_limit
        ) {
            SearchThroughWith = [
                "Name",
                "DNI",
                "CUIT"
            ];

            ClientID = client_id;
            Name = name;
            PhoneNumber = phone_number;
            Email = email;
            DNI = dni;
            CUIT = cuit;
            Address = address;
            PaymentMethod = payment_method;
            AppliedDiscounts = applied_discounts;
            CreditLimit = credit_limit;
        }
    }
}