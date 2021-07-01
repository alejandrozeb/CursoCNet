using System;
using System.Collections.Generic;
using System.Text;

namespace FundamentosCSHarp.Models
{
    interface IBebidaAlcoholica
    {
        //estos atributos se implementaran
        public int Alcohol { get; set; }
        //se implementaran estos metodos
        //a partir del 7 no se podia implemnetar un metodo en la interfaz

        public void MaxRecomendado();
    }
}
