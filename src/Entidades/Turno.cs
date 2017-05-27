using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UberFrba.Entidades
{
    public class Turno
    {
        public int id { get; set; }
        public int hi { get; set; }
        public int hf { get; set; }
        public string desc { get; set; }
        public float valor_kilometro { get; set; }
        public float precio_base { get; set; }

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
