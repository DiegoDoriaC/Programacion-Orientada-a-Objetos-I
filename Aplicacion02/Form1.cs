using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aplicacion02
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            Empleado em = new Empleado();
            em.nombre = txtNombre.Text;
            em.dni = txtDNI.Text;
            em.apellido = txtApellido.Text;
            em.fIngreso = dtIngreso.Value;
            em.cargo = cboCargo.Text;

            txtBasico.Text = em.Basico().ToString();
            txtBonificacion.Text = em.Bonificacion().ToString();
            txtNeto.Text = em.Neto().ToString();
        }
    }
}
