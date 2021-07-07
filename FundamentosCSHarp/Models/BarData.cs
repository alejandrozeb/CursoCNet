using System;
using System.Collections.Generic;
using System.Text;

namespace FundamentosCSHarp.Models
{
    public class BarData
    {
        public string Nombre { get; set; }
        public List<Bebida> cervezas = new List<Bebida>();
    
        public BarData(string nombre)
        {
            this.Nombre = nombre;
        }
            

    }
}
