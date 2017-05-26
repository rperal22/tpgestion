using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UberFrba.Entidades
{
    public class Rol
    {
        public List<String> funcionalidades {get; set;}

        public Rol(List<String> func)
        {
            funcionalidades = func;
        }
    }
}
