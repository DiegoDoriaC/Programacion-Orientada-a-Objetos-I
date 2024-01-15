using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion02
{
    public class Empleado : Class1
    {
        public double Bonificacion()
        {
            double b = 0;
            switch(cargo.ToLower())
            {
                case "administrativo":
                case "seguridad": b = 0.05 * Basico(); break;
                case "auxiliar": b = 0.10 * Basico(); break;
            }
            return b;
        }
        public override double Deduccion()
        {
            return 0.10 * (Basico() + Bonificacion());
        }
        public override double Neto()
        {
            return Basico() + Bonificacion() - Deduccion();
        }
    }
}
