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

namespace Aplicacion06
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtBlock.Text = "";
            txtBlock.Focus();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            //definir un cuadro de dialogo para guardar un archivo de tipo txt
            SaveFileDialog op = new SaveFileDialog();
            op.Filter = "Archivos de texto|*.txt";

            if(op.ShowDialog() == DialogResult.OK)
            {
                //definir el StreamWrite con el nombre del archivo creado
                StreamWriter escritor = new StreamWriter(op.FileName);

                //escribir utilizando el contenido del TextBox
                escritor.Write(txtBlock.Text);

                //cerrar
                escritor.Close();
                MessageBox.Show("Archivo guardado");
            }
        }

        private void btnAbrir_Click(object sender, EventArgs e)
        {
            //cuadro de dialogo para abrir el archivo de texto txt
            OpenFileDialog op = new OpenFileDialog();
            op.Filter = "archivo de texto secuencial|*.txt";
            if(op.ShowDialog()== DialogResult.OK)
            {
                //definir el lector de stream del archivo txt seleccionado
                StreamReader lector = new StreamReader(op.FileName);

                //leer el contenido y visualizarlo en el TextBox
                txtBlock.Text = lector.ReadToEnd();

                //cerrar el lector
                lector.Close();

                MessageBox.Show("Archivo abierto correctamente!!!");
            }

        }
    }
}
