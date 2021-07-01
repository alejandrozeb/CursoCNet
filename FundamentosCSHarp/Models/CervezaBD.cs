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

            }
                return cervezas;
        }
    }
}
