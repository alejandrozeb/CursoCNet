using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace FundamentosCSHarp.Models
{
    class CervezaBD
    {
        //conectar a la bad con un cadena de conexion
        private string connectionString = "Data Source=localhost;Initial Catalog=FundamentosCSharp" + 
            "User=sa;Password=123456;";
        //sql server debe tener algunos atributos

        public List<Cerveza> Get() {
            List<Cerveza> cervezas = new List<Cerveza>();
            //una clase recibe otra clase

            //consulta
            string query = "select nombre, marca, alcohol, cantidad" +
                            "from cerveza";
            //using tiene dos funciones
            //agegar los namessapce
            //todo lo que existe en using se muere al salir
            using (SqlConnection connection = new SqlConnection(connectionString)) {
                //sirve para enviar consultas
                SqlCommand command = new SqlCommand(query, connection);
                //abrimos la conexion
                connection.Open();
                //ejecutamos la lectura de datos
                //uno a uno, s eejcuta el codigo
                SqlDataReader reader = command.ExecuteReader();

                //leemos registro por registro
                while (reader.Read()) {
                    int Cantidad = reader.GetInt32(3);
                    string Nombre = reader.GetString(0);

                    Cerveza cerveza = new Cerveza(Cantidad, Nombre);

                    cerveza.Alcohol = reader.GetInt32(2);
                    cerveza.Marca = reader.GetString(1);
                    cervezas.Add(cerveza);
                }
                //cerrando el reader
                reader.Close();
                connection.Close();
            }
                return cervezas;
        }

        public void Add(Cerveza cerveza) {
            String query
                = "insert into cerveza(nombre, marca, alcohol, cantidad) "+
                "values(@nombre, @marca, @alcohol, @cantidad)";
            //no es bueno concatenar una consulta

            using (var connection = new SqlConnection(connectionString)) {
                var command = new SqlCommand(query,connection);
                //agregando valores de cerveza
                command.Parameters.AddWithValue("@nombre", cerveza.Nombre);
                command.Parameters.AddWithValue("@marca", cerveza.Marca);
                command.Parameters.AddWithValue("@alcohol", cerveza.Alcohol);
                command.Parameters.AddWithValue("@cantidad", cerveza.Cantidad);

                connection.Open();

                command.ExecuteNonQuery();
                //indicamos que es un insert

                connection.Close();
            }
        }

        public void Edit(Cerveza cerveza, int Id)
        {
            String query
                = "update cerveza set nombre=@cerveza, " +
                "marca = @marca, alcohol=@alcohol, cantidad=@cantidad "+
                "where id=@id";
            //no es bueno concatenar una consulta

            using (var connection = new SqlConnection(connectionString))
            {
                var command = new SqlCommand(query, connection);
                //agregando valores de cerveza
                command.Parameters.AddWithValue("@nombre", cerveza.Nombre);
                command.Parameters.AddWithValue("@marca", cerveza.Marca);
                command.Parameters.AddWithValue("@alcohol", cerveza.Alcohol);
                command.Parameters.AddWithValue("@cantidad", cerveza.Cantidad);
                command.Parameters.AddWithValue("@id", Id);

                connection.Open();

                command.ExecuteNonQuery();
                //indicamos que es un insert

                connection.Close();
            }
        }

        public void Delete(int Id)
        {
            String query
                = "delete from cerveza " +
                "where id=@id";
            //no es bueno concatenar una consulta

            using (var connection = new SqlConnection(connectionString))
            {
                var command = new SqlCommand(query, connection);
                //agregando valores de cerveza
                command.Parameters.AddWithValue("@id", Id);

                connection.Open();

                command.ExecuteNonQuery();
                //indicamos que es un insert

                connection.Close();
            }
        }
    }
}
