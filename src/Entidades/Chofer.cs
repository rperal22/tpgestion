using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UberFrba.Entidades
{
    public class Chofer
    {
        [System.ComponentModel.DisplayName("Nombre")]
        public String nombre { get; set; }
        [System.ComponentModel.DisplayName("Apellido")]
        public String apellido { get; set; }
        [System.ComponentModel.DisplayName("DNI")]
        public int dni { get; set; }
        [System.ComponentModel.DisplayName("Direccion")]
        public String direccion { get; set; }
        [System.ComponentModel.DisplayName("Telefono")]
        public int telefono { get; set; }
        [System.ComponentModel.DisplayName("Mail")]
        public String mail { get; set; }
        [System.ComponentModel.DisplayName("Fecha de nacimiento")]
        public DateTime fechaNacimiento { get; set; }
        [System.ComponentModel.DisplayName("Estado")]
        public String estado { get; set; }
        [System.ComponentModel.Browsable(false)]
        public int id { get; set; }

        public Chofer(String nombre, String apellido, int dni, String direccion, int telefono, String mail, DateTime fechaNacimiento, String estado)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.dni = dni;
            this.direccion = direccion;
            this.telefono = telefono;
            this.mail = mail;
            this.fechaNacimiento = fechaNacimiento;
            this.estado = estado;
        }

    }


}
