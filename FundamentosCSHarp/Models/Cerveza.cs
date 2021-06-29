using System;
using System.Collections.Generic;
using System.Text;

namespace FundamentosCSHarp.Models
{
    class Cerveza : Bebida
    {
        public Cerveza(int Cantidad, string Nombre = "Cerveza") 
            : base(Nombre, Cantidad) { 
            //con base instanciamos el constructor

            //primero van las variables sin datos y al final las con default
            
        }
    }
}
