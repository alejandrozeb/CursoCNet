using System;
using System.Collections.Generic;
using System.Text;

namespace FundamentosCSHarp.Models
{
    class Cerveza : Bebida, IBebidaAlcoholica, IRequestTable
    {
        public string Marca { get; set; }
        public Cerveza(int Cantidad, string Nombre = "Cerveza") 
            : base(Nombre, Cantidad) { 
            //con base instanciamos el constructor

            //primero van las variables sin datos y al final las con default
        }

        //otro contructor
        public Cerveza() : base(null, 0) { 
        }
        //implementando interfaz
        public int Alcohol { set; get; }

        public int Id { get; set; }
        //implementando metodo
        public void MaxRecomendado() {
            //implementar metodo
            Console.WriteLine("el maximo permitido es 10");
        }
    }
}
