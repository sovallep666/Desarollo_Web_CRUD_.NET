using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using MySql.Data.MySqlClient;
using System.Web.UI.WebControls;

namespace pr_web_umg_2021
{
    public class Empleado
    {
        ConexionBD conectar;

        private DataTable drop_puesto()
        {
            DataTable tabla = new DataTable();
            conectar = new ConexionBD();
            string strConsulta = string.Format("SELECT id_puesto as id, puesto FROM db_empresa_2021.puestos;");

            conectar.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(strConsulta, conectar.conectar);
            consulta.Fill(tabla);

            conectar.CerrarConexion();
            return tabla;
        }

        public void drop_puesto(DropDownList drop)
        {
            drop.ClearSelection();
            drop.Items.Clear();
            drop.AppendDataBoundItems = true;
            drop.Items.Add("<<< Elige Puesto >>>");
            drop.Items[0].Value = "0";
            drop.DataSource = drop_puesto();
            drop.DataTextField = "puesto";
            drop.DataValueField = "id";
            drop.DataBind();

        }

         private DataTable grid_empleados()
        {
            DataTable tabla = new DataTable();
            conectar = new ConexionBD();
            conectar.AbrirConexion();
            string strConsulta = string.Format("SELECT e.id_empleado as id, e.codigo, e.nombres, e.apellidos, e.direccion, e.telefono, e.fecha_nacimiento, p.puesto, p.id_puesto FROM db_empresa_2021.empleados AS e INNER JOIN db_empresa_2021.puestos AS p ON e.id_puesto = p.id_puesto;");
            
            MySqlDataAdapter consulta = new MySqlDataAdapter(strConsulta, conectar.conectar);
            consulta.Fill(tabla);

            conectar.CerrarConexion();
            return tabla;
        }
        public void grid_empleados(GridView grid)
        {
            grid.DataSource = grid_empleados();
            grid.DataBind();

        }

        public int agregar(string codigo, string nombres, string apellidos, string direccion, string telefono, string fecha, int id_puesto)
        {
            int no_ingreso = 0;
            conectar = new ConexionBD();
            conectar.AbrirConexion();
            string strConsulta = string.Format("INSERT INTO db_empresa_2021.empleados(codigo,nombres,apellidos,direccion,telefono,fecha_nacimiento,id_puesto) VALUES ('{0}','{1}','{2}','{3}','{4}','{5}',{6});", codigo, nombres, apellidos, direccion, telefono, fecha, id_puesto);
            MySqlCommand insertar = new MySqlCommand(strConsulta, conectar.conectar);
            insertar.Connection = conectar.conectar;
            no_ingreso = insertar.ExecuteNonQuery();
            conectar.CerrarConexion();
            return no_ingreso;
        }

        public int modificar(int id, string codigo, string nombres, string apellidos, string direccion, string telefono, string fecha, int id_puesto)
        {
            int no_ingreso = 0;
            conectar = new ConexionBD();
            conectar.AbrirConexion();
            string strConsulta = string.Format("UPDATE INTO db_empresa_2021.empleados SET codigo = '{0}',nombres = '{1}',apellidos = '{2}',direccion = '{3}',telefono = '{4}',fecha_nacimiento = '{5}',id_puesto = {6} WHERE id = {7};", codigo, nombres, apellidos, direccion, telefono, fecha, id_puesto, id);
            MySqlCommand insertar = new MySqlCommand(strConsulta, conectar.conectar);
            insertar.Connection = conectar.conectar;
            no_ingreso = insertar.ExecuteNonQuery();
            conectar.CerrarConexion();
            return no_ingreso;
        }

        public int eliminar(int id)
        {
            int no_ingreso = 0;
            conectar = new ConexionBD();
            conectar.AbrirConexion();
            string strConsulta = string.Format("DELETE FROM empleados WHERE id_empleados = {0}", id);
            MySqlCommand insertar = new MySqlCommand(strConsulta, conectar.conectar);
            insertar.Connection = conectar.conectar;
            no_ingreso = insertar.ExecuteNonQuery();
            conectar.CerrarConexion();
            return no_ingreso;
        }

    }
}