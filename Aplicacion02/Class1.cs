using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion02
{
    public class Class1
    {
        public string dni { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public DateTime fIngreso { get; set; }
        public string cargo { get; set; }

        public double Basico()
        {
            if (cargo.ToLower() == "administrativo") return 4500;
            else if (cargo.ToLower() == "auxiliar") return 1800;
            else return 2500;
        }
        public virtual double Deduccion()
        {
            return Basico() * 0.05;
        }
        public virtual double Neto()
        {
            return Basico() - Deduccion();
        }

    }
}
