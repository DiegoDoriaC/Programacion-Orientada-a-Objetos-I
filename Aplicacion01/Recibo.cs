using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion01
{
    public class Recibo
    {
        public string numero { get; set; }
        public DateTime fecha { get; set; }
        public string nombre { get; set; }
        public string dni { get; set; }
        public double sueldo { get; set; }

        public Recibo()
        {
            numero = "";
            fecha = DateTime.Today;
            nombre = string.Empty;
            dni = "";
            sueldo = 0;
        }

        public double Bonificacion()
        {
            if (sueldo <= 950) return sueldo * 0.1;
            else if (sueldo <= 5000) return sueldo * 0.05;
            else return sueldo * 0.03;
        }
        public double Refrigerio()
        {
            return sueldo * 0.075;
        }
        public double Monto()
        {
            return sueldo + Bonificacion() + Refrigerio();
        }
        public double Impuesto()
        {
            if (Monto() >= 2500) return (Monto() - 2500) * 0.3;
            else return 0;
        }
        public double Saldo()
        {
            return Monto() - Impuesto();
        }

    }
}
