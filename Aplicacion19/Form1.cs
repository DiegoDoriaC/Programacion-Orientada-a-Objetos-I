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

namespace Aplicacion19
{
    public partial class Form1 : Form
    {
        string cadena = "server=DESKTOP-3SVGOT8\\SQLEXPRESS;database=VENTAS2017;Integrated security=true";

        void Mostrar()
        {
            SqlConnection cn = new SqlConnection(@cadena);
            SqlDataAdapter da = new SqlDataAdapter("exec usp_material_lista", cn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgMateriales.DataSource = dt;
        }

        DataTable clientes()
        {
            SqlConnection cn = new SqlConnection(@cadena);
            SqlDataAdapter da = new SqlDataAdapter("usp_clientes_lista", cn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public Form1()
        {
            InitializeComponent();
            cboClientes.DataSource = clientes();
            cboClientes.ValueMember = "ID_CLIENTE";
            cboClientes.DisplayMember = "NOMBRES";

            Mostrar();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtCodigo.Clear();
            txtDescripcion.Clear();
            txtPrecio.Clear();
            txtStock.Clear();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection(@cadena);
            SqlCommand cmd = new SqlCommand("usp_material_agrega", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@valor1", txtCodigo.Text);
            cmd.Parameters.AddWithValue("@valor2", txtDescripcion.Text);
            cmd.Parameters.AddWithValue("@valor3", txtPrecio.Text);
            cmd.Parameters.AddWithValue("@valor4", txtStock.Text);
            cn.Open();
            try
            {
                int i = cmd.ExecuteNonQuery();
                MessageBox.Show(i + " Registro Ingresado!");

            } 
            catch (Exception ex) { MessageBox.Show(ex.Message); } 
            finally { cn.Close(); }
            Mostrar();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection(@cadena);
            SqlCommand cmd = new SqlCommand("usp_material_actualiza", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@valor1", txtDescripcion.Text);
            cmd.Parameters.AddWithValue("@valor2", txtPrecio.Text);
            cmd.Parameters.AddWithValue("@valor3", txtStock.Text);
            cmd.Parameters.AddWithValue("@codigo", txtCodigo.Text);
            cn.Open();
            try
            {
                int i = cmd.ExecuteNonQuery();
                MessageBox.Show(i + " Registro Actualizado!!!");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { cn.Close(); }
            Mostrar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection(@cadena);
            SqlCommand cmd = new SqlCommand("usp_material_elimina", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@valor1", txtCodigo.Text);
            cn.Open();
            try
            {
                int i = cmd.ExecuteNonQuery();
                MessageBox.Show(i + " Registro Eliminado!!!");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { cn.Close(); }
            Mostrar();
        }

        private void dgMateriales_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //al hacer click visualizamos los datos en los Text
            txtCodigo.Text = dgMateriales.CurrentRow.Cells[0].Value.ToString();
            txtDescripcion.Text = dgMateriales.CurrentRow.Cells[1].Value.ToString();
            txtPrecio.Text = dgMateriales.CurrentRow.Cells[2].Value.ToString();
            txtStock.Text = dgMateriales.CurrentRow.Cells[3].Value.ToString();
        }

    }
}
