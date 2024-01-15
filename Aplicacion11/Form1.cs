using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Json;

namespace Aplicacion11
{
    public partial class Form1 : Form
    {
        List<Producto> productos = new List<Producto>();
        public Form1()
        {
            InitializeComponent();
            Mostrar();
        }


        private void Mostrar()
        {
            dgProductos.DataSource = productos.ToArray();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtCodigo.Clear();
            txtDescripcion.Clear();
            txtMedida.Clear();
            txtPrecio.Clear();
            txtStock.Clear();
            txtCodigo.Focus();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Producto p = new Producto();
            p.codigo = int.Parse(txtCodigo.Text);
            p.descripcion = txtDescripcion.Text;
            p.medida = txtMedida.Text;
            p.precio = double.Parse(txtPrecio.Text);
            p.stock = int.Parse(txtStock.Text);
            productos.Add(p);
            Mostrar();
            MessageBox.Show("Producto agregado correctamente!!!");
        }

        private void btnSerializar_Click(object sender, EventArgs e)
        {
            SaveFileDialog op = new SaveFileDialog();
            op.Filter = "archivo json|*.json";
            if(op.ShowDialog() == DialogResult.OK)
            {
                //FileStream para crear
                FileStream f = new FileStream(op.FileName, FileMode .Create);

                //Serializador de tipo List de Productos
                DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(List<Producto>));

                //Serializar
                js.WriteObject(f, productos);
                f.Close();
                MessageBox.Show("Lista serializada!");
                
            }
        }

        private void btnDeserializar_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Filter = "archivo json|*.json";
            if (op.ShowDialog() == DialogResult.OK)
            {
                FileStream f = new FileStream (op.FileName, FileMode .Open);
                DataContractJsonSerializer js = new DataContractJsonSerializer (typeof(List<Producto>));
                List<Producto> yo = (List<Producto>)js.ReadObject(f);
                dgProductos.DataSource = yo.ToArray();
            }
        }
    }



}
