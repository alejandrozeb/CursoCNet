using System;
using System.Collections.Generic;
using System.Text;

namespace FundamentosCSHarp.Models
{
    class Vino: Bebida, IBebidaAlcoholica
    {
        public int Alcohol { set; get; }
        public Vino(int Cantidad, string Nombre = "Vino")
            : base(Nombre, Cantidad)
        {
      
        }
       
        public void MaxRecomendado()
        {
            //implementar metodo
            Console.WriteLine("el maximo permitido es 3 copas");
        }
    }
}
