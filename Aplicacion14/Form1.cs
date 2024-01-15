using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Text.RegularExpressions;

namespace Aplicacion14
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtUsuario.Clear();
            txtClave.Clear();
            txtUsuario.Focus();
        }

        private void btnEjecutar_Click(object sender, EventArgs e)
        {
            /*
            //Validar el txtUsuario no este valio y solo sea 8 digitos
            Regex valida = new Regex(@"\d{8}");

            if(string.IsNullOrEmpty(txtUsuario.Text) )
            {
                MessageBox.Show("ingrese el usuario");
                return;
            }
            
            if (!valida.IsMatch(txtUsuario.Text)){
                MessageBox.Show("ingrese datos validos");
                return;
            }

            //validad que txtClave no este vacio y solo sea 5 caracteres
            Regex valida2 = new Regex(@"[a-z0-9]{5}");

            if (string.IsNullOrEmpty(txtClave.Text))
            {
                MessageBox.Show("ingrese el clave");
                return;
            }

            if (!valida2.IsMatch(txtClave.Text))
            {
                MessageBox.Show("la clave debe tener minimo 5 caracteres");
                return;
            }
            */
            //Si todo esta ok, iniciamos el proceso asincrono
            bgInicio.RunWorkerAsync();

        }

        private void bgInicio_DoWork(object sender, DoWorkEventArgs e)
        {
            //vamos a ejecutar el proceso para el relleno del pbInicio(repetitivo)
            for (int i = pbInicio.Minimum; i<=pbInicio.Maximum; i++)
            {
                //enviar el valor al progressChanged(ReportProgress)
                bgInicio.ReportProgress(i);
                //esperar un intervalo de 150milisegundos
                Thread.Sleep(150);
            }
        }

        private void bgInicio_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //Inicio el valor enviado por el DoWork (ReportProgress)
            pbInicio.Value = e.ProgressPercentage;
        }

        private void bgInicio_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //Cuando finaliza, enviamos un mensaje
            MessageBox.Show("Proceso Completado");
            //podriamos cerrar el for y abrir un segundo formulario

        }
    }
}
