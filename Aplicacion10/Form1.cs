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

namespace Aplicacion10
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtDNI.Clear();
            txtNombre.Clear();
            txtApellido.Clear();
            txtDireccion.Clear();
            txtEmail.Clear();
            txtDNI.Focus();
        }

        private void btnSerializar_Click(object sender, EventArgs e)
        {
            //cuadro de dialogo para serializar Json
            SaveFileDialog op = new SaveFileDialog();
            op.Filter = "archivo JSON|*.json";
            if(op.ShowDialog() == DialogResult.OK)
            {
                //Instanciar la clase y pasar los datos a los atributos
                Cliente reg = new Cliente();
                reg.dni = txtDNI.Text;
                reg.nombre = txtNombre.Text;
                reg.apellido = txtApellido.Text;
                reg.direccion = txtDireccion.Text;
                reg.email = txtEmail.Text;

                //Crear el FileStream
                FileStream f = new FileStream(op.FileName, FileMode.Create);

                //Definir el serializador Json de tipo Cliente
                DataContractJsonSerializer json = new DataContractJsonSerializer(typeof(Cliente));

                //Serializar el contenido del objeto Cliente hacia el FileStream
                json.WriteObject(f, reg);

                //Cerrar los objetos
                f.Close();
                MessageBox.Show("Archivo Json guardado!!");
            }
        }

        private void btnDeserializar_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Filter = "archivo JSON|*.json";
            if(op.ShowDialog()== DialogResult.OK)
            {
                FileStream f = new FileStream(op.FileName, FileMode .Open);
                DataContractJsonSerializer json = new DataContractJsonSerializer(typeof(Cliente));
                Cliente reg = (Cliente) json.ReadObject(f);
                f.Close();
                txtDNI.Text = reg.dni;
                txtNombre.Text = reg.nombre;
                txtApellido.Text = reg.apellido;
                txtDireccion.Text = reg.direccion;
                txtEmail.Text = reg.email;

            }
        }
    }
}
