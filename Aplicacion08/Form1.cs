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
using System.IO.Compression;

namespace Aplicacion08
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtBlock.Clear();
            txtBlock.Focus();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            SaveFileDialog op = new SaveFileDialog();
            op.Filter = "archivo de texto|*.txt|archivo sql|*.sql";
            if(op.ShowDialog() == DialogResult.OK)
            {
                FileStream f = new FileStream(op.FileName, FileMode.Create);
                StreamWriter escritor = new StreamWriter(f);
                
                escritor.Write(txtBlock.Text);
                MessageBox.Show("archivo guardado con exito!");
                escritor.Close();
                f.Close();

            }
        }

        private void btnAbrir_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Filter = "archivo de texto|*.txt|archivo sql|*.sql";
            if(op.ShowDialog() == DialogResult.OK)
            {
                FileStream f = new FileStream(op.FileName, FileMode .Open);
                StreamReader lector = new StreamReader(f);
                txtBlock.Text = lector.ReadToEnd();
                lector .Close();
                f.Close ();
            }
        }

        private void btnComprimir_Click(object sender, EventArgs e)
        {
            //Cuadro de dialogo para guardar archivo de extension cmp
            SaveFileDialog op = new SaveFileDialog();
            op.Filter = "archivo comprimido|*.cmp";

            //si aceptas guardar el archivo
            if(op.ShowDialog() == DialogResult.OK)
            {
                //necesito la secuencia original de bytes del texto a comprimir
                byte[] datos = System.Text.Encoding.UTF8.GetBytes(txtBlock.Text);
                
                //definir el FileStream para CREAR el archivo de tipo cmp
                FileStream f = new FileStream(op.FileName, FileMode.Create);

                //definir el gZipStream para comprimir los bytes originales
                GZipStream zip = new GZipStream(f, CompressionMode.Compress);

                //para comprimir secribir leyendo cada byte de datos desde
                //el indice 0 hasta la longitud final
                zip.Write(datos, 0, datos.Length);

                //cerrar
                zip.Close();
                f.Close() ;
                MessageBox.Show("Archivo comprimido correctamente");

            }
        }

        private void btnDescomprimir_Click(object sender, EventArgs e)
        {
            OpenFileDialog op =new OpenFileDialog();
            op.Filter = "archivo comprimido|*.cmp";
            if(op.ShowDialog()== DialogResult.OK)
            {
                //FileStream para abrir el archivo cmp
                FileStream f = new FileStream(op.FileName, FileMode.Open);

                //el gZipStream para descomprimir
                GZipStream zip = new GZipStream (f, CompressionMode.Decompress);

                //visualizar los datos descomprimirdos leyendo a zip
                txtBlock.Text = new StreamReader(zip).ReadToEnd();

                //Cerra los objetos
                zip.Close();
                f.Close();
            }
        }
    }
}
