using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UberFrba.Entidades
{
    class Viaje
    {
        [System.ComponentModel.Browsable(false)]
        public int id { get; set; }
        [System.ComponentModel.DisplayName("Cantidad de kilometros")]
        public float cantKilometros { get; set; }
        [System.ComponentModel.DisplayName("Fecha de inicio")]
        public DateTime fechaInicio { get; set; }
        [System.ComponentModel.DisplayName("Fecha de finalizacion")]
        public DateTime fechaFin { get; set; }
        [System.ComponentModel.DisplayName("Patente automovil usado")]
        public string patente { get; set; }
        [System.ComponentModel.DisplayName("Chofer id")]
        public int choferid { get; set; }
        [System.ComponentModel.DisplayName("Turno id")]
        public int turnoid { get; set; }
        [System.ComponentModel.DisplayName("Cliente id")]
        public int clienteid { get; set; }

        public Viaje(int id, float ck, DateTime fi, DateTime ff, String patente, int chofeid, int turnoid, int clienteid)
        {
            this.id = id;
            this.cantKilometros = ck;
            this.fechaInicio = fi;
            this.fechaFin = ff;
            this.patente = patente;
            this.choferid = chofeid;
            this.turnoid = turnoid;
            this.clienteid = clienteid;
        }
    
    }
}
