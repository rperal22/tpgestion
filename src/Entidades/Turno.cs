using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UberFrba.Entidades
{
    public class Turno
    {
        [System.ComponentModel.DisplayName("ID")]
        public int id { get; set; }
        [System.ComponentModel.DisplayName("Hora Inicio")]
        public int hi { get; set; }
        [System.ComponentModel.DisplayName("Hora Fin")]
        public int hf { get; set; }
        [System.ComponentModel.DisplayName("Descripcion")]
        public string desc { get; set; }
        [System.ComponentModel.DisplayName("Valor Kilometro")]
        public float valor_kilometro { get; set; }
        [System.ComponentModel.DisplayName("Precio Base")]
        public float precio_base { get; set; }
        [System.ComponentModel.DisplayName("Estado")]
        public String estado { get; set; }

        public Turno(int id, int hi, int hf, string desc, float valor_kilometro, float precio_base)
        {
            this.id = id;
            this.hi = hi;
            this.hf = hf;
            this.desc = desc;
            this.valor_kilometro = valor_kilometro;
            this.precio_base = precio_base;
        }
    }
}
