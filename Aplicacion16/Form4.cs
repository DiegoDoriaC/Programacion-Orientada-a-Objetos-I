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
using System.Configuration;

namespace Aplicacion16
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void btnConsulta_Click(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection(
                ConfigurationManager.ConnectionStrings["cn"].ConnectionString);
            SqlDataAdapter da = new SqlDataAdapter("ListarProductosPrecio @Valor1, @Valor2", cn);
            da.SelectCommand.Parameters.AddWithValue("@Valor1", decimal.Parse(txtPrecio1.Text));
            da.SelectCommand.Parameters.AddWithValue("@Valor2", decimal.Parse(txtPrecio2.Text));
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgPedidos.DataSource = dt;
        }
    }
}
