using System;
using System.Collections.Generic;
using System.Text;

namespace FundamentosCSHarp.Models
{
    public class Bar
    {
        public string Nombre { get; set; }
        public List<Cerveza> cervezas = new List<Cerveza>();

        public Bar(string Nombre) {
            this.Nombre = Nombre;
        }
    }
}
