using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UberFrba.Entidades
{
    public class Funcionalidad
    {
        public String nombreFuncion { get; set; }
        public String descFuncion { get; set; }

        public Funcionalidad(String nombre, String desc)
        {
            this.nombreFuncion = nombre;
            this.descFuncion = desc;
        }
    }
}
