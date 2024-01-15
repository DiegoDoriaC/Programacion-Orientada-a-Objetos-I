using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aplicacion03
{
    public partial class Form1 : Form
    {
        //Definir una lista de productos, el cual le cargamos 1 producto
        List<Producto> producto = new List<Producto>()
        {
            new Producto(){codigo = "1", descripcion = "teclado",medida = "Unidad", precio = 30.00, stock = 20},
            new Producto(){codigo = "2", descripcion = "mouse",medida = "Unidad", precio = 120.00, stock = 50},
        };
        public Form1()
        {
            InitializeComponent();
            //Cargar o visualizar la lista en el DataGridView
            dgProductos.DataSource = producto.ToArray();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtCodigo.Clear();
            txtDescripcion.Clear();
            txtMedida.Clear();
            txtPrecio.Clear();
            nmStock.Value= 0;

            txtCodigo.Focus();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //instanciar la clase producto y pasarle los valores a cada atributo
            Producto p = new Producto();
            p.codigo = txtCodigo.Text;
            p.descripcion = txtDescripcion.Text;
            p.medida = txtMedida.Text;
            p.precio = double.Parse(txtPrecio.Text);
            p.stock = (int)nmStock.Value;

            producto.Add(p);
            dgProductos.DataSource = producto.ToArray();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //aprender a buscar, el List provee el metodo FIND, con el uso de un predicado
            //si lo encuentra apunta al objeto encontrado, el cual podras almacenar
            Producto reg = producto.Find(p => p.codigo == txtCodigo.Text);
            if (reg == null)
            {
                MessageBox.Show("El codigo no existe");
            }
            else
            {
                txtDescripcion.Text = reg.descripcion;
                txtMedida.Text = reg.medida;
                txtPrecio.Text = reg.medida;
                txtPrecio.Text = reg.precio.ToString();
                nmStock.Value = reg.stock;

            }
        }
    }
}
