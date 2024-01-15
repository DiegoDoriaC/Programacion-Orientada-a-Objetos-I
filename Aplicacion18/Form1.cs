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

namespace Aplicacion18
{
    public partial class Form1 : Form
    {
        string cadena = "server=DESKTOP-3SVGOT8\\SQLEXPRESS;database=VENTAS2017;Integrated security=true";
        private DataTable materiales()
        {
            //ejecutar el procedure usp_material_lista y retornar
            SqlConnection cn = new SqlConnection(@cadena);
            SqlDataAdapter da = new SqlDataAdapter("exec usp_material_lista", cn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public Form1()
        {
            InitializeComponent();
            dgMateriales.DataSource = materiales();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtCodigo.Clear();
            txtDescripcion.Clear();
            txtPrecio.Clear();
            txtStock.Clear();
            txtCodigo.Focus();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection(cadena);
            cn.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("usp_material_agrega", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                //Aniadir parametros
                cmd.Parameters.AddWithValue("@valor1", txtCodigo.Text);
                cmd.Parameters.AddWithValue("@valor2", txtDescripcion.Text);
                cmd.Parameters.AddWithValue("@valor3", txtPrecio.Text);
                cmd.Parameters.AddWithValue("@valor4", txtStock.Text);
                
                //Ejecutar y almacenar la cantidad de registros agregados
                int i = cmd.ExecuteNonQuery();
                MessageBox.Show(i + " Registro agregado correctamente");
                
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            } finally 
            { 
                cn.Close(); 
            }
            dgMateriales.DataSource = materiales();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection(@cadena);
            cn.Open();
            try
            {

                SqlCommand cmd = new SqlCommand("usp_material_actualiza", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@valor1", txtDescripcion.Text);
                cmd.Parameters.AddWithValue("@valor2", txtPrecio.Text);
                cmd.Parameters.AddWithValue("@valor3", txtStock.Text);
                cmd.Parameters.AddWithValue("@codigo", txtCodigo.Text);
                int i = cmd.ExecuteNonQuery();
                MessageBox.Show(i + " Registro actualizado correctamente");

            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            } finally { cn.Close(); }
            dgMateriales.DataSource = materiales();
        }
    }
}
