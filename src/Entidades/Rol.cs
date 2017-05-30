using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UberFrba.Entidades
{
    public class Rol
    {
        public String nombre { get; set; }
        public List<Funcionalidad> funcionalidades { get; set; }
        public String estado { get; set; }
        public String desc { get; set; }

        public Rol(String nombre, String estado, String desc, List<Funcionalidad> func)
        {
            this.nombre = nombre;
            this.estado = estado;
            this.desc = desc;
            this.funcionalidades = func;
        }
    }
}
