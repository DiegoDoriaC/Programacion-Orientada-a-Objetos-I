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

namespace Aplicacion07
{
    public partial class Form1 : Form
    {
        //definir una lista de Clientes a nivel formulario
        private List<Cliente> clientes = new List<Cliente>();
        public Form1()
        {
            InitializeComponent();
            //visualizar el contenido de clientes en dgClientes
            dgClientes.DataSource = clientes.ToArray();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtCodigo.Clear();
            txtNombre.Clear();
            txtEmail.Clear();
            txtDireccion.Clear();
            txtTelefono.Clear();
            txtCodigo.Focus();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Cliente c = new Cliente();
            Cliente reg = clientes.Find(x => x.codigo == int.Parse(txtCodigo.Text));
            if(reg == null)
            {
                c.codigo = int.Parse(txtCodigo.Text);
                c.nombre = txtNombre.Text;
                c.direccion = txtDireccion.Text;
                c.email = txtEmail.Text;
                c.telefono = txtTelefono.Text;
                clientes.Add(c);
                dgClientes.DataSource = clientes.ToArray();
                MessageBox.Show("Usuario agregado correctamente");
            }
            else
            {
                dgClientes.DataSource = clientes.ToArray();
                MessageBox.Show("Usuario ya existente");
            }

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            //el contenido de la lista de clientes se guardara en un archivo txt
            SaveFileDialog op = new SaveFileDialog();
            op.Filter = "archivo de texto|*.txt";
            if(op.ShowDialog() == DialogResult.OK)
            {
                //definir al escritor Stream
                StreamWriter escritor = new StreamWriter(op.FileName);

                //lear cada fila de la coleccion utilizando un ForEach
                foreach(var item in clientes)
                {
                    //escribir una fila, linea por linea donde los campos se separan por ;
                    escritor.WriteLine(string.Concat(item.codigo,"; ", item.nombre,"; ",item.direccion,"; ",item.email,"; ",item.telefono));
                }
                
                //cerrar el escritor
                escritor.Close();
                MessageBox.Show("guardado correctamente!!!");
                
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Filter = "archivo de texto|*.txt";
            if(op.ShowDialog() == DialogResult.OK)
            {
                StreamReader lector = new StreamReader(op.FileName);

                //leer fila por fila, preguntar si el siguiente no es el final
                while(lector.Peek() != -1)
                {
                    //almaceno la linea como un arreglo string, cada campo se separa por un ;
                    string[] campos = lector.ReadLine().Split(';');
                    Cliente reg = new Cliente();
                    reg.codigo = int.Parse(campos[0]);
                    reg.nombre = campos[1];
                    reg.direccion = campos[2];
                    reg.email = campos[3];
                    reg.telefono = campos[4];
                    clientes.Add(reg);
                }

                //cerrar el lector
                lector.Close();
                dgClientes.DataSource = clientes.ToArray();
            }

        }
    }
}
