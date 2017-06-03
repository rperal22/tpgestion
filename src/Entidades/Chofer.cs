using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UberFrba.Entidades
{
    class Chofer
    {
        public String nombre { get; set; }
        public String apellido { get; set; }
        public int dni { get; set; }
        public String direccion { get; set; }
        public int telefono { get; set; }
        public String mail { get; set; }
        public DateTime fechaNacimiento { get; set; }

        public Chofer(String nombre, String apellido, int dni, String direccion, int telefono, String mail, DateTime fechaNacimiento)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.dni = dni;
            this.direccion = direccion;
            this.telefono = telefono;
            this.mail = mail;
            this.fechaNacimiento = fechaNacimiento;
        }

    }


}
