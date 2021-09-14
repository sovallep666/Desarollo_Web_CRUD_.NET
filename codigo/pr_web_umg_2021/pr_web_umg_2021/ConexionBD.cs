using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace pr_web_umg_2021
{
    public class ConexionBD
    {
        private string contenido = "server=localhost; database=db_empresa_2021; user=root; password=admin";
        public MySqlConnection conectar = new MySqlConnection();
        public MySqlDataAdapter adaptador = new MySqlDataAdapter();

        public void AbrirConexion()
        {
            try
            {
                string sConn;
                sConn = contenido;
                conectar = new MySqlConnection();

                conectar.ConnectionString = sConn;
                conectar.Open();

                System.Diagnostics.Debug.WriteLine("Conexion exitosa");

            }
            catch (Exception ex)
            {

                System.Diagnostics.Debug.WriteLine(ex.Message);

            }

        }

        public void CerrarConexion()
        {
            if (conectar.State == ConnectionState.Open)
            {
                conectar.Close();
            }
        }
    }
}