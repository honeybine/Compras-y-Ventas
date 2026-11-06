using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using Common.Attributes;

namespace DataAccess.Connection
{
    // Se crea la clase SQLExecuter.
    public class SQLExecuter
    {
        // Variable con la informacion para la conexion a base de datos.
        private readonly string Parameters = "" +
                    "server=DESKTOP-O9EPAM2;" +
                    "database=ComprasYVentas;" +
                    "Integrated Security=True;" +
                    "TrustServerCertificate=True;";
        // Objetos SQL.
        private SqlConnection ServerConnection;
        private SqlCommand Command;

        // Crea un objeto de tipo diccionario para los resultados
        public DataTable Results { get; set; }

        // Variable booleana que indica exito en la consulta.
        public bool Success { get; set; }

        // Funcion para cargar un procedimiento almacenado.
        public SQLExecuter(string sp_name) {
            this.Results = new DataTable();
            this.Success = false;

            this.ServerConnection = new SqlConnection(this.Parameters);

            this.Command = new SqlCommand(sp_name, this.ServerConnection);
            this.Command.CommandType = CommandType.StoredProcedure;
        }

        public void AddParameter(string name, object value)
        {
            Command.Parameters.AddWithValue(name, value ?? DBNull.Value);
        }

        public void Execute() {
            try {
                this.ServerConnection.Open();

                using (this.ServerConnection) {
                    if (this.Command.CommandType == CommandType.Text) {
                        int rows_affected = this.Command.ExecuteNonQuery();
                        this.Success = rows_affected > 0;
                    } else {
                        using (SqlDataReader reader = this.Command.ExecuteReader()) {
                            this.Results.Load(reader);
                        }

                        this.Success = true;
                    }
                }
            } catch (Exception error) {
                this.Success = false;
                throw;
            }
        }
    }
}