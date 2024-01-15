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

namespace Aplicacion12
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtCadena.Clear();
            txtEncriptado.Clear();
            txtCadena.Focus();
        }

        private void btnEncriptar_Click(object sender, EventArgs e)
        {
            //1. Debemos almacenar la cadena como una secuencia de bites
            byte[] original = Encoding.UTF8.GetBytes(txtCadena.Text);

            //2. Definir el servicio Sha1
            SHA1CryptoServiceProvider sha1 = new SHA1CryptoServiceProvider();

            //3. Calcular la secuencia encriptada de original
            byte[] encripta = sha1.ComputeHash(original);

            //4. Visualizar en el txtEncriptado la secuencia encriptada
            foreach (byte x in encripta) 
                txtEncriptado.Text += x.ToString();
            {
                
            }
        }
    }
}
