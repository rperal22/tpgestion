using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UberFrba.Entidades
{
    public class Automovil
    {
        [System.ComponentModel.Browsable(false)]
        public int id { get; set; }
        [System.ComponentModel.DisplayName("Patente")]
        public String patente {get; set;}
        [System.ComponentModel.DisplayName("Marca")]
        public String marca {get; set;}
        [System.ComponentModel.DisplayName("Modelo")]
        public String modelo { get; set; }
        [System.ComponentModel.DisplayName("Licencia")]
        public String licencia { get; set; }
        [System.ComponentModel.DisplayName("Rodado")]
        public String rodado { get; set; }
        [System.ComponentModel.DisplayName("Chofer")]
        public int chofer { get; set; }
        [System.ComponentModel.Browsable(false)]
        public List<Turno> turnos { get; set; }
        [System.ComponentModel.DisplayName("Estado")]
        public String estado { get; set; }

        public Automovil(int id, String patente, String marca, String modelo, int chofer, List<Turno> turnos, String licencia, String rodado, String estado)
        {
            this.id = id;
            this.patente = patente;
            this.marca = marca;
            this.modelo = modelo;
            this.chofer = chofer;
            this.turnos = turnos;
            this.licencia = licencia;
            this.rodado = rodado;
            this.estado = estado;
        }

    }
}
