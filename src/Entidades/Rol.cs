using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UberFrba.Entidades
{
    public class Rol
    {
        [System.ComponentModel.DisplayName("Nombre")]
        public String nombre { get; set; }
        public List<Funcionalidad> funcionalidades { get; set; }
        [System.ComponentModel.DisplayName("Estado")]
        public String estado { get; set; }
        [System.ComponentModel.DisplayName("Descripcion")]
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
