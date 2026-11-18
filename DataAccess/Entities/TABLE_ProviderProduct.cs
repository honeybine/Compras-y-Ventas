using DataAccess.Connection;
using System.Data;

namespace DataAccess.Entities {
    public class TABLE_ProviderProduct {

        public void Create(int provider_id, int product_id) {
            SQLExecuter sql = new SQLExecuter("CreateProviderProduct");

            sql.AddParameter("@INPUT_provider_id", provider_id);
            sql.AddParameter("@INPUT_product_id", product_id);

            sql.Execute();
        }

        public void Delete(int provider_id, int product_id) {
            SQLExecuter sql = new SQLExecuter("DeleteProviderProduct");

            sql.AddParameter("@INPUT_provider_id", provider_id);
            sql.AddParameter("@INPUT_product_id", product_id);

            sql.Execute();
        }

        public DataTable ReadWithPage(int page) {
            SQLExecuter sql = new SQLExecuter("ReadWithPage");

            sql.AddParameter("@INPUT_table", "ProviderProduct");
            sql.AddParameter("@INPUT_page_number", page);

            sql.Execute();

            return sql.Results;
        }

        public DataTable ReadFromColumnWithPage(string column_name, int page) {
            SQLExecuter sql = new SQLExecuter("ReadFromColumnWithPage");

            sql.AddParameter("@INPUT_table", "View_ProviderProduct");
            sql.AddParameter("@INPUT_column", column_name);
            sql.AddParameter("@INPUT_page_number", page);

            sql.Execute();

            return sql.Results;
        }

        public DataTable ReadWhereColumnWithPage(string column_name, string searched_value, int page) {
            SQLExecuter sql = new SQLExecuter("ReadWhereColumnWithPage");

            sql.AddParameter("@INPUT_table", "View_ProviderProduct");
            sql.AddParameter("@INPUT_column", column_name);
            sql.AddParameter("@INPUT_value", searched_value);
            sql.AddParameter("@INPUT_page_number", page);

            sql.Execute();

            return sql.Results;
        }
    }
}