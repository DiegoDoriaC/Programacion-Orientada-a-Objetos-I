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
    public partial class Form2 : Form
    {
        public Form2()
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
            //filter debe definir dos archivos de tipo txt o sql
            op.Filter = "archivo de texto|*.txt|archivo sql|*.sql";

            if(op.ShowDialog() == DialogResult.OK)
            {
                //definir el FileStream para crear el archivo antes de escribirlo
                FileStream f = new FileStream(op.FileName, FileMode.Create);

                //definir al StreamWriter para escribir en f(FileStream)
                StreamWriter escritor = new StreamWriter(f);

                //escribir
                escritor.Write(txtBlock.Text);
                
                //cerrar los 2 objetos
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
                //FileStream para abrir el archivo
                FileStream f = new FileStream(op.FileName, FileMode .Open);

                //definir al StreamReader de f
                StreamReader lector = new StreamReader(f);

                //leer y visualizar en el textbox
                txtBlock.Text = lector.ReadToEnd();

                //cerrar
                lector.Close();
                f.Close();
            }
        }
    }
}
