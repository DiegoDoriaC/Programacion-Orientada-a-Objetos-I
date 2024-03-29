﻿using System;
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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnConsulta_Click(object sender, EventArgs e)
        {
            //1.conexion
            SqlConnection cn = new SqlConnection(
                ConfigurationManager.ConnectionStrings["cn"].ConnectionString);
            //2. Ejecutar el procedure
            SqlDataAdapter da = new SqlDataAdapter("ListarClientesYDistritos", cn);

            //3. DataTable, poblar y visualizar
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgClientes.DataSource = dt;
        }
    }
}
