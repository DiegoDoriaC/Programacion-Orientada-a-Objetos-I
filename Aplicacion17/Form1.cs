using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Aplicacion17
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void txtAdapter_Click(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection(
                @"server=DESKTOP-3SVGOT8\SQLEXPRESS;database=VENTAS2017;Integrated security=true");
            SqlDataAdapter ad = new SqlDataAdapter("select * from Empleado", cn);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            dgClientes.DataSource = dt;
        }

        private void txtReader_Click(object sender, EventArgs e)
        {
            //1. Definir la conexion
            SqlConnection cn = new SqlConnection(
                @"server=DESKTOP-3SVGOT8\SQLEXPRESS;database=VENTAS2017;Integrated security=true");
            //2. Definir al SQLComand el cual ejecutara la secuencia Select
            SqlCommand cmd = new SqlCommand(
                "select ID_CLIENTE,NOMBRES,APELLIDOS,DIRECCION,FONO,ID_DISTRITO,EMAIL from CLIENTE", cn);
            //3. Abrir la conexion
            cn.Open();

            //4. Ejecutar el command y almacenar el resultado de un DataReader
            SqlDataReader dr = cmd.ExecuteReader();

            //5. Definir una lista de Clientes, la cual almacenara el resultado
            List<Cliente> clientes = new List<Cliente>();

            //6. Mientras que se lea a fila del DataReader agregamos el Cliente
            while (dr.Read())
            {
                Cliente reg = new Cliente();
                reg.idCliente = dr.GetString(0);
                reg.nombres = dr.GetString(1);
                reg.apellidos = dr.GetString(2);
                reg.direccion = dr.GetString(3);
                reg.telefono = int.Parse(dr.GetString(4));
                reg.distrito = dr.GetString(5);
                reg.email = dr.GetString(6);
                clientes.Add(reg);
            }

            dgClientes.DataSource= clientes;

        }
    }
}
