using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.IO;
using System.Runtime.Serialization.Json;

namespace Aplicacion12
{
    public partial class Form2 : Form
    {

        List<Usuario> usuarios = new List<Usuario>();

        public Form2()
        {
            InitializeComponent();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtDNI.Clear();
            txtClave.Clear();
            txtDNI.Focus();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            //antes de guardar encriptamos la clave
            Usuario u = new Usuario();
            u.dni = txtDNI.Text;
            byte[] original = Encoding.UTF8.GetBytes(txtClave.Text);
            SHA1CryptoServiceProvider servicio = new SHA1CryptoServiceProvider();
            byte[] encripta = servicio.ComputeHash(original);
            foreach (byte x in encripta) u.clave += x.ToString();

            //Instanciar Usuario
            
            usuarios.Add(u);
            dgUsuarios.DataSource = usuarios.ToArray();
            
        }

        private void btnSerializar_Click(object sender, EventArgs e)
        {
            SaveFileDialog op = new SaveFileDialog();
            op.Filter = "archivo json|*.json";
            if(op.ShowDialog() == DialogResult.OK)
            {
                FileStream f = new FileStream(op.FileName, FileMode .Create);
                DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(List<Usuario>));
                js.WriteObject(f, usuarios);
                f.Close();
            }
        }
    }
}
