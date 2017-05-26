using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UberFrba.Entidades
{
    public class Usuario
    {
        public String username {get; set;}
        public Rol userrol {get; set;}

        public Usuario(String nombre, Rol userrol)
        {
            this.username = nombre;
            this.userrol = userrol;
        }
    }
}
