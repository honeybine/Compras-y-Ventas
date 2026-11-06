
using Common.Attributes;
using System;
using System.Collections.Generic;
using Common.Interfaces;
using DataAccess.Entities;

namespace Domain.CRUD {
    public class Client : ICrud {
        TABLE_Client SQLClientTable = new TABLE_Client();

        public void Create(AttributeBaseClass attributes) {
            if (!(attributes is ATTR_Client client))
                throw new ArgumentException("Invalid client attributes.");

            SQLClientTable.Create(attributes);
        }

        public void Update(int id, AttributeBaseClass attributes) {
            if (!(attributes is ATTR_Client client))
                throw new ArgumentException("Invalid client attributes.");

            SQLClientTable.Update(id, attributes);
        }

        public AttributeBaseClass Read(int id) {
            return SQLClientTable.Read(id);
        }

        public List<AttributeBaseClass> ReadWithPage(int page) {
            return SQLClientTable.ReadWithPage(page);
        }

        public List<AttributeBaseClass> ReadWhereColumnWithPage(string column_name, string searched_value, int page) {
            return SQLClientTable.ReadWhereColumnWithPage(column_name, searched_value, page);
        }

        public List<AttributeBaseClass> ReadFromColumnWithPage(string column_name, int page) {
            return SQLClientTable.ReadFromColumnWithPage(column_name, page);
        }

        public void Delete(int id) {
            SQLClientTable.Delete(id);
        }
    }
}
