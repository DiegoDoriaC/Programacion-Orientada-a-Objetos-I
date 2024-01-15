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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void btnConsulta_Click(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection(
                ConfigurationManager.ConnectionStrings["cn"].ConnectionString );
            SqlDataAdapter da = new SqlDataAdapter("EXEC ListarBoletasPorAnio @Anio", cn);
            da.SelectCommand.Parameters.AddWithValue("@Anio", int.Parse(txtAnio.Text));
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgPedidos.DataSource = dt;
        }
    }
}
