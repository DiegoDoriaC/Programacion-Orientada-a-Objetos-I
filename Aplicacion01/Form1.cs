using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aplicacion01
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            //Instanciar la Clase
            Recibo r = new Recibo();

            //Ingresar los datos a los Atributos-Propiedades
            r.numero = txtNumero.Text;
            r.fecha = DateTime.Parse(txtFecha.Text);
            r.nombre = txtNombre.Text;
            r.dni = txtDNI.Text;
            r.sueldo = double.Parse(txtSueldo.Text);

            //Visualizar los resultados de los metodos en los TextBox
            txtBonificacion.Text = r.Bonificacion().ToString();
            txtRefrigerio.Text = r.Refrigerio().ToString();
            txtMonto.Text = r.Monto().ToString();
            txtImpuesto.Text = r.Impuesto().ToString();
            txtSaldo.Text = r.Saldo().ToString();

        }
    }
}
