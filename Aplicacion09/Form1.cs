using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aplicacion09
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtArchivo.Clear();
            txtArchivo.Focus();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            SaveFileDialog op = new SaveFileDialog();
            op.Filter = "archivo de texto|*.txt|archivo sql|*.sql";
            if(op.ShowDialog() == DialogResult.OK )
            {
                FileStream f = new FileStream(op.FileName, FileMode.Create);
                StreamWriter escritor = new StreamWriter(f);
                escritor.Write(txtArchivo.Text);
                escritor.Close();
                f.Close();
            }
        }

        private void btnAbrir_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Filter = "archivo de texto|*.txt|archivo sql|*.sql";
            if( op.ShowDialog() == DialogResult.OK )
            {
                FileStream f = new FileStream(op.FileName, FileMode .Open);
                StreamReader lector = new StreamReader(f);
                txtArchivo.Text = lector.ReadToEnd();
                lector.Close();
                f.Close() ;
            }
        }

        private void btnSerializar_Click(object sender, EventArgs e)
        {
            SaveFileDialog op = new SaveFileDialog();
            op.Filter = "archivo binario|*.bin";
            if(op.ShowDialog()==DialogResult.OK )
            {
                FileStream f = new FileStream(op.FileName,FileMode.Create);
                BinaryWriter escritor = new BinaryWriter(f);
                escritor.Write(txtArchivo.Text);
                escritor.Close();
                f.Close();
            }
        }

        private void btnDeserializar_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Filter = "archivo binario|*.bin";
            if (op.ShowDialog() == DialogResult.OK)
            {
                FileStream f = new FileStream(op.FileName, FileMode.Open);
                BinaryReader lector = new BinaryReader(f);
                txtArchivo.Text= lector.ReadString();
                lector.Close();
                f.Close();
            }
        }
    }
}
