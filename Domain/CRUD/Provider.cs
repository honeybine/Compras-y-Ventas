
using Common.Attributes;
using System;
using System.Collections.Generic;
using Common.Interfaces;
using DataAccess.Entities;

namespace Domain.CRUD {
    public class Provider : ICrud {
        TABLE_Provider SQLProviderTable = new TABLE_Provider();

        public void Create(AttributeBaseClass attributes) {
            if (!(attributes is ATTR_Provider provider))
                throw new ArgumentException("Invalid provider attributes.");

            SQLProviderTable.Create(attributes);
        }

        public void Update(int id, AttributeBaseClass attributes) {
            if (!(attributes is ATTR_Provider provider))
                throw new ArgumentException("Invalid provider attributes.");

            SQLProviderTable.Update(id, attributes);
        }

        public AttributeBaseClass Read(int id) {
            return SQLProviderTable.Read(id);
        }

        public List<AttributeBaseClass> ReadWithPage(int page) {
            return SQLProviderTable.ReadWithPage(page);
        }

        public List<AttributeBaseClass> ReadWhereColumnWithPage(string column_name, string searched_value, int page) {
            return SQLProviderTable.ReadWhereColumnWithPage(column_name, searched_value, page);
        }

        public List<AttributeBaseClass> ReadFromColumnWithPage(string column_name, int page) {
            return SQLProviderTable.ReadFromColumnWithPage(column_name, page);
        }

        public void Delete(int id) {
            SQLProviderTable.Delete(id);
        }
    }
}
