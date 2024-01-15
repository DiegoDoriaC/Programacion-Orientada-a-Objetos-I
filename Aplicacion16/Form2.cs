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
using System.Configuration; //app.config

namespace Aplicacion16
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void btnConsulta_Click(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection(
                ConfigurationManager.ConnectionStrings["cn"].ConnectionString );
            //Ejecutar el procedure con su parametro
            SqlDataAdapter da = new SqlDataAdapter("EXEC ListarInicialesNombre @nombre", cn);

            //Pasar el valor al parametro @nombre
            da.SelectCommand.Parameters.AddWithValue("@nombre", txtProducto.Text);

            //DataTable, poblar y visualizar
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgClientes.DataSource = dt;
        }
    }
}
