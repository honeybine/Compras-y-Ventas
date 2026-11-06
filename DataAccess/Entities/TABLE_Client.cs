
using Common.Attributes;
using Common.Interfaces;
using DataAccess.Connection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;

namespace DataAccess.Entities {
    public class TABLE_Client : ICrud {
        public void Create(AttributeBaseClass attributes) {
            if (!(attributes is ATTR_Client client))
                throw new ArgumentException("Invalid client attributes.");

            SQLExecuter exec = new SQLExecuter("CreateClient");

            exec.AddParameter("@INPUT_name", client.Name);
            exec.AddParameter("@INPUT_phone_number", client.PhoneNumber);
            exec.AddParameter("@INPUT_email", client.Email);
            exec.AddParameter("@INPUT_dni", client.DNI);
            exec.AddParameter("@INPUT_cuit", client.CUIT);
            exec.AddParameter("@INPUT_address", client.Address);
            exec.AddParameter("@INPUT_payment_method", client.PaymentMethod);
            exec.AddParameter("@INPUT_credit_limit", client.CreditLimit);

            exec.Execute();
        }

        public void Update(int id, AttributeBaseClass attributes) {
            if (!(attributes is ATTR_Client client))
                throw new ArgumentException("Invalid client attributes.");

            SQLExecuter exec = new SQLExecuter("UpdateClient");

            exec.AddParameter("@INPUT_id", id);
            exec.AddParameter("@INPUT_name", client.Name);
            exec.AddParameter("@INPUT_phone_number", client.PhoneNumber);
            exec.AddParameter("@INPUT_email", client.Email);
            exec.AddParameter("@INPUT_dni", client.DNI);
            exec.AddParameter("@INPUT_cuit", client.CUIT);
            exec.AddParameter("@INPUT_address", client.Address);
            exec.AddParameter("@INPUT_payment_method", client.PaymentMethod);
            exec.AddParameter("@INPUT_credit_limit", client.CreditLimit);

            exec.Execute();
        }

        public AttributeBaseClass Read(int id) {
            ATTR_Client attributes = new ATTR_Client();

            SQLExecuter exec = new SQLExecuter("Read");
            exec.AddParameter("@INPUT_table", "Client");
            exec.AddParameter("@INPUT_id", id);
            exec.Execute();

            Type attributes_type = attributes.GetType();

            foreach (DataRow row in exec.Results.Rows) {
                foreach (DataColumn column in exec.Results.Columns) {
                    string column_name = column.ColumnName;
                    PropertyInfo? property_info = attributes_type.GetProperty(column_name);

                    if (property_info != null && !row.IsNull(column)) {
                        Type property_type =
                            Nullable.GetUnderlyingType(property_info.PropertyType)
                            ?? property_info.PropertyType;

                        object value = Convert.ChangeType(row[column], property_type);
                        property_info.SetValue(attributes, value);
                    }
                }
            }

            return attributes;
        }

        public List<AttributeBaseClass> ReadWithPage(int page) {
            SQLExecuter exec = new SQLExecuter("ReadWithPage");
            exec.AddParameter("@INPUT_table", "Client");
            exec.AddParameter("@INPUT_page_number", page);
            exec.Execute();

            return mapResults(exec.Results);
        }

        public List<AttributeBaseClass> ReadWhereColumnWithPage(
            string searched_column,
            string searched_value,
            int page
        ) {
            SQLExecuter exec = new SQLExecuter("ReadWhereColumnWithPage");
            exec.AddParameter("@INPUT_table", "Client");
            exec.AddParameter("@INPUT_column", searched_column);
            exec.AddParameter("@INPUT_value", searched_value);
            exec.AddParameter("@INPUT_page_number", page);
            exec.Execute();

            return mapResults(exec.Results);
        }

        public List<AttributeBaseClass> ReadFromColumnWithPage(
            string searched_column,
            int page
        ) {
            SQLExecuter exec = new SQLExecuter("ReadFromColumnWithPage");
            exec.AddParameter("@INPUT_table", "Client");
            exec.AddParameter("@INPUT_column", searched_column);
            exec.AddParameter("@INPUT_page_number", page);
            exec.Execute();

            return mapResults(exec.Results);
        }

        List<AttributeBaseClass> mapResults(DataTable results) {
            List<AttributeBaseClass> list_of_clients = new List<AttributeBaseClass>();
            Type attributes_type = typeof(ATTR_Client);

            foreach (DataRow row in results.Rows) {
                ATTR_Client new_client = new ATTR_Client();

                foreach (DataColumn column in results.Columns) {
                    string column_name = column.ColumnName;
                    PropertyInfo? property_info = attributes_type.GetProperty(column_name);

                    if (property_info != null && !row.IsNull(column)) {
                        Type property_type =
                            Nullable.GetUnderlyingType(property_info.PropertyType)
                            ?? property_info.PropertyType;

                        object value = Convert.ChangeType(row[column], property_type);
                        property_info.SetValue(new_client, value);
                    }
                }

                list_of_clients.Add(new_client);
            }

            return list_of_clients;
        }

        public void Delete(int id) {
            SQLExecuter exec = new SQLExecuter("DeleteClient");

            exec.AddParameter("@INPUT_id", id);
            exec.Execute();
        }
    }
}
