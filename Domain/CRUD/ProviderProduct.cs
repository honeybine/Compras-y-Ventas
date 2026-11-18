using DataAccess.Entities;
using System.Data;

namespace Domain.CRUD {
    public class ProviderProduct {
        TABLE_ProviderProduct SQLProviderProductTable = new TABLE_ProviderProduct();

        public void Create(int provider_id, int product_id) {
            SQLProviderProductTable.Create(provider_id, product_id);
        }

        public void Delete(int provider_id, int product_id) {
            SQLProviderProductTable.Delete(provider_id, product_id);
        }

        public DataTable ReadWithPage(int page) {
            return SQLProviderProductTable.ReadWithPage(page);
        }

        public DataTable ReadFromColumnWithPage(string column_name, int page) {
            return SQLProviderProductTable.ReadFromColumnWithPage(column_name, page);
        }

        public DataTable ReadWhereColumnWithPage(string column_name, string searched_value, int page) {
            return SQLProviderProductTable.ReadWhereColumnWithPage(column_name, searched_value, page);
        }
    }
}