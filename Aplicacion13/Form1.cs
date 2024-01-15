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

namespace Aplicacion13
{
    public partial class Form1 : Form
    {
        //Definir el servicio, la key y el vector de inicializacion
        DESCryptoServiceProvider servicio = new DESCryptoServiceProvider();
        byte[] key = { 11, 12, 13, 14, 15, 16, 17, 18 };
        byte[] vi = { 21, 22, 23, 24, 25, 26, 27, 28 };

        public Form1()
        {
            InitializeComponent();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtEncriptado.Clear();
            txtEncriptado.Focus();
        }

        private void btnEncriptar_Click(object sender, EventArgs e)
        {
            SaveFileDialog op = new SaveFileDialog();
            op.Filter = "archivo encriptado|*.txt";
            if(op.ShowDialog() == DialogResult.OK)
            {
                //1. Covertir el contenido del TextBox en una secuencia de bites FileStream para crear el archivo
                byte[] secuencia = Encoding.UTF8.GetBytes(txtEncriptado.Text);

                //2. FileStream para crear el archivo
                FileStream f = new FileStream(op.FileName, FileMode .Create);

                //3. CryptoStream para ejecutar el createEncryptor y de modo write
                CryptoStream proceso = new CryptoStream(f, servicio.CreateEncryptor(key, vi), CryptoStreamMode.Write);

                //4. Escribir leyendo los bytes original
                proceso.Write(secuencia, 0, secuencia.Length);

                //5. cerrar
                proceso.Close();
                f.Close();
            }
        }

        private void btnDesencriptar_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "archivo encriptado|*.txt";
            if(open.ShowDialog() == DialogResult.OK)
            {
                //1. FileStream para abrir el archivo
                FileStream f = new FileStream (open.FileName, FileMode .Open);

                //2. CryptoStream para ejecutar createDecryptor y modo de lectura
                CryptoStream proceso = new CryptoStream(f, servicio.CreateDecryptor(key, vi), CryptoStreamMode.Read);

                //3. instanciar el StreamReader para leer al CryptoStream el contenido
                txtEncriptado.Text = new StreamReader(proceso).ReadToEnd();

                //4. Cerrar
                proceso.Close();
                f.Close();
            }
        }
    }
}
