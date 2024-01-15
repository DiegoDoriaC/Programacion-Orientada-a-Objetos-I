using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aplicacion05
{
    public partial class Form1 : Form
    {
        //Definir la lista de clientes y le agrego 2 clientes
        List<Cliente> cliente = new List<Cliente>() { 
            new Cliente(){dni="12345678", nombre="Juan Medina", direccion="Lima", email="", telefono=""},
            new Cliente(){dni="87654321", nombre="Iris Luna", direccion="Trujillo", email="iluna@gmail.com", telefono="928109364"},
        };

        void Buscar()
        {
            dgClientes.DataSource = cliente.ToArray();
        }

        public Form1()
        {
            InitializeComponent();
            Buscar();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtDNI.Clear();
            txtNombre.Clear();
            txtDireccion.Clear();
            txtEmail.Clear();
            txtTelefono.Clear();
            txtDNI.Focus();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Cliente c = new Cliente();
            c.dni = txtDNI.Text;
            c.nombre = txtNombre.Text;
            c.direccion = txtDireccion.Text;
            c.email = txtEmail.Text;
            c.telefono = txtTelefono.Text;

            cliente.Add(c);
            Buscar();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Cliente reg = cliente.Find(c => c.dni == txtDNI.Text);
            if (reg == null)
            {
                MessageBox.Show("El cliente no existe");
            }
            else
            {
                MessageBox.Show("Cliente encontrado");
                txtNombre.Text = reg.nombre;
                txtDireccion.Text = reg.direccion;
                txtEmail.Text = reg.email;
                txtTelefono.Text = reg.telefono;
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Cliente reg = cliente.Find(c => c.dni == txtDNI.Text);
            if (reg == null)
            {
                MessageBox.Show("El cliente no puede ser actualizado o no existe");
            }
            else
            {
                reg.nombre = txtNombre.Text;
                reg.direccion = txtEmail.Text;
                reg.email = txtEmail.Text;
                reg.telefono = txtTelefono.Text;
                Buscar();
                MessageBox.Show("Cliente actualizado");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Cliente reg = cliente.Find(c => c.dni == txtDNI.Text);
            if (reg != null)
            {
                if(MessageBox.Show("Desea Eliminar?", "Eliminar", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                cliente.Remove(reg);
                Buscar();
                MessageBox.Show("Cliente eliminado");
                }
                else
                {
                    MessageBox.Show("Cliente NO eliminado");
                }
            }
            else
            {
                MessageBox.Show("El cliente no fue encontrado");
            }
        }
    }
}
