using Common.Attributes;
using Common.Interfaces;
using DataAccess.Connection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;

namespace DataAccess.Entities {
    public class TABLE_Product : ICrud {
        // Odio las acciones repetitivas
        public void Create(AttributeBaseClass attributes) {
            if (!(attributes is ATTR_Product product))
                throw new ArgumentException("Invalid product attributes.");

            SQLExecuter exec = new SQLExecuter("CreateProduct");

            exec.AddParameter("@INPUT_name",            product.Name);
            exec.AddParameter("@INPUT_category",        product.CategoryID);
            exec.AddParameter("@INPUT_description",     product.Description);
            exec.AddParameter("@INPUT_brand",           product.Brand);
            exec.AddParameter("@INPUT_expiration_date", product.ExpirationDate);
            exec.AddParameter("@INPUT_lot",             product.Lot);
            exec.AddParameter("@INPUT_purchase_price",  product.PurchasePrice);
            exec.AddParameter("@INPUT_sale_price",      product.SalePrice);
            exec.AddParameter("@INPUT_lead_time_days",   product.LeadTimeDays);
            exec.AddParameter("@INPUT_minimum_stock",   product.MinimumStock);
            exec.AddParameter("@INPUT_critical_stock",  product.CriticalStock);
            exec.AddParameter("@INPUT_ideal_stock",     product.IdealStock);
            exec.AddParameter("@INPUT_stock_type",      product.StockType);

            exec.Execute();
        }

        // cree un script para que me cree automaticamente las SP para esto. es una garcha. pero funca
        public void Update(int id, AttributeBaseClass attributes) {
            if (!(attributes is ATTR_Product product))
                throw new ArgumentException("Invalid product attributes.");

            SQLExecuter exec = new SQLExecuter("UpdateProduct");

            exec.AddParameter("@INPUT_id",              id);
            exec.AddParameter("@INPUT_name",            product.Name);
            exec.AddParameter("@INPUT_category",        product.CategoryID);
            exec.AddParameter("@INPUT_description",     product.Description);
            exec.AddParameter("@INPUT_brand_id",           product.BrandID);
            exec.AddParameter("@INPUT_expiration_date", product.ExpirationDate);
            exec.AddParameter("@INPUT_lot_id",             product.LotID);
            exec.AddParameter("@INPUT_purchase_price",  product.PurchasePrice);
            exec.AddParameter("@INPUT_sale_price",      product.SalePrice);
            exec.AddParameter("@INPUT_lead_time_days", product.LeadTimeDays);
            exec.AddParameter("@INPUT_minimum_stock",   product.MinimumStock);
            exec.AddParameter("@INPUT_critical_stock",  product.CriticalStock);
            exec.AddParameter("@INPUT_ideal_stock",     product.IdealStock);
            exec.AddParameter("@INPUT_stock_type",      product.StockType);

            exec.Execute();
        }

        // La razon de porque decidi usar una SP dinamica en SQL es rara
        //
        // No queria crear 3 SPs más (leer unica fila, leer una pagina de filas, y 
        // leer una pagina de filas ordenadas por una columna) por cada entidad
        //
        // No estoy seguro si esto es muy seguro, pero tampoco me importa mucho
        // Igual se ve piola, eh, jajaj
        //
        // No hice esto con las otras SP (crear/modificar) porque son significadamente
        // más complicadas
        // Junto a que no se me ocurre otra manera de hacerlas que no sea construyendo
        // una query desde C#, y no quiero hacer eso para evitar lo que decia Gónzalez
        // -- Noé

        // Lee la info del producto dependiendo de la ID/Codigo dado.
        public AttributeBaseClass Read(int id) {
            // CAMBIAR CLASE ACORDE DE LA ENTIDAD
            ATTR_Product attributes = new ATTR_Product();

            SQLExecuter exec = new SQLExecuter("Read");
            exec.AddParameter("@INPUT_table", "Product");
            exec.AddParameter("@INPUT_id", id);
            exec.Execute();
            
            Type ProductAttributesType = attributes.GetType();

            foreach(DataRow row in exec.Results.Rows) {
                foreach(DataColumn column in exec.Results.Columns) {
                    // estoy orgulloso mal de este codigo. incluso si no se entiende un pingo
                    string column_name = column.ColumnName;
                    PropertyInfo AttributePropertyInfo = ProductAttributesType.GetProperty(column_name);

                    if (AttributePropertyInfo != null && !row.IsNull(column)) {
                        Type property_type = Nullable.GetUnderlyingType(AttributePropertyInfo.PropertyType)
                            ?? AttributePropertyInfo.PropertyType;

                        object value = Convert.ChangeType(row[column], property_type);

                        AttributePropertyInfo.SetValue(attributes, value);
                    }
                }
            }

            return attributes;
        }

        // Lee una pagina (10 elementos) de la lista de productos.
        public List<AttributeBaseClass> ReadWithPage(int page) {
            // CAMBIAR CLASE ACORDE DE LA ENTIDAD
            ATTR_Product AttributeTemplate = new ATTR_Product();

            SQLExecuter exec = new SQLExecuter("ReadWithPage");
            exec.AddParameter("@INPUT_table", "Product");
            exec.AddParameter("@INPUT_page_number", page);
            exec.Execute();

            List<AttributeBaseClass> list_of_products = new List<AttributeBaseClass>();
            Type ProductAttributesType = AttributeTemplate.GetType();

            foreach (DataRow row in exec.Results.Rows) {
                ATTR_Product new_product = new ATTR_Product();

                foreach (DataColumn column in exec.Results.Columns) {
                    string column_name = column.ColumnName;
                    PropertyInfo AttributePropertyInfo = ProductAttributesType.GetProperty(column_name);

                    if (AttributePropertyInfo != null && !row.IsNull(column)) {
                        Type property_type = Nullable.GetUnderlyingType(AttributePropertyInfo.PropertyType)
                            ?? AttributePropertyInfo.PropertyType;

                        object value = Convert.ChangeType(row[column], property_type);

                        AttributePropertyInfo.SetValue(new_product, value);
                    }
                }

                list_of_products.Add(new_product);
            }

            return list_of_products;
        }

        public List<AttributeBaseClass> ReadWhereColumnWithPage(string searched_column, string searched_value, int page) {
            // CAMBIAR CLASE ACORDE DE LA ENTIDAD
            ATTR_Product AttributeTemplate = new ATTR_Product();

            SQLExecuter exec = new SQLExecuter("ReadWhereColumnWithPage");
            exec.AddParameter("@INPUT_table", "Product");
            exec.AddParameter("@INPUT_column", searched_column);
            exec.AddParameter("@INPUT_value", searched_value);
            exec.AddParameter("@INPUT_page_number", page);
            exec.Execute();

            List<AttributeBaseClass> list_of_products = new List<AttributeBaseClass>();
            Type ProductAttributesType = AttributeTemplate.GetType();

            foreach (DataRow row in exec.Results.Rows) {
                ATTR_Product new_product = new ATTR_Product();

                foreach (DataColumn column in exec.Results.Columns) {
                    string column_name = column.ColumnName;
                    PropertyInfo AttributePropertyInfo = ProductAttributesType.GetProperty(column_name);

                    if (AttributePropertyInfo != null && !row.IsNull(column)) {
                        Type property_type = Nullable.GetUnderlyingType(AttributePropertyInfo.PropertyType)
                            ?? AttributePropertyInfo.PropertyType;

                        object value = Convert.ChangeType(row[column], property_type);

                        AttributePropertyInfo.SetValue(new_product, value);
                    }
                }

                list_of_products.Add(new_product);
            }

            return list_of_products;
        }

        public List<AttributeBaseClass> ReadFromColumnWithPage(string searched_column, int page) {
            // CAMBIAR CLASE ACORDE DE LA ENTIDAD
            ATTR_Product AttributeTemplate = new ATTR_Product();

            SQLExecuter exec = new SQLExecuter("ReadFromColumnWithPage");
            exec.AddParameter("@INPUT_table", "Product");
            exec.AddParameter("@INPUT_column", searched_column);
            exec.AddParameter("@INPUT_page_number", page);
            exec.Execute();

            List<AttributeBaseClass> list_of_products = new List<AttributeBaseClass>();
            Type ProductAttributesType = AttributeTemplate.GetType();

            foreach (DataRow row in exec.Results.Rows) {
                ATTR_Product new_product = new ATTR_Product();

                foreach (DataColumn column in exec.Results.Columns) {
                    string column_name = column.ColumnName;
                    PropertyInfo AttributePropertyInfo = ProductAttributesType.GetProperty(column_name);

                    if (AttributePropertyInfo != null && !row.IsNull(column)) {
                        Type property_type = Nullable.GetUnderlyingType(AttributePropertyInfo.PropertyType)
                            ?? AttributePropertyInfo.PropertyType;

                        object value = Convert.ChangeType(row[column], property_type);

                        AttributePropertyInfo.SetValue(new_product, value);
                    }
                }

                list_of_products.Add(new_product);
            }

            return list_of_products;
        }

        public void Delete(int id) {
            SQLExecuter exec = new SQLExecuter("DeleteProduct");

            exec.AddParameter("@INPUT_id", id);
            exec.Execute();
        }
    }
}