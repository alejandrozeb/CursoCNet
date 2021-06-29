using System;
using FundamentosCSHarp.Models;
//importamos donde esta bebida
namespace FundamentosCSHarp
{
    class Program
    {
        static void Main(string[] args)
        {
            byte numero = 255;
            sbyte numeroNegativo = -128;

            int numero3 = 1351351;
            uint numero4 = 132;
            
            long numero5 = 51321;
            ulong numero6 = 45;


            /* flotante*/

            //4bytes
            float numero7 = 169.1f;

            //8bytes
            double numero8 = 5445.56d;

            //mas alcanze
            decimal numero9 = 189.1m;

            //caracteres
            //una letra con comilla simple representa 2 bytes
            char caracter = 'A';

            string caracter2 = "ñsldañsdl";

            //es de tipo date objeto
            //saca la fecha de hoy
            DateTime date = DateTime.Now;

            //true false
            bool siOno = true;

            //valores por defecto
            int numero10 = new int();
            Console.WriteLine(numero10);
            //se inicializa con 0 como objeto

            //para que no tenga nada
            int? numeroNull = null;

            //var por si misma representa su tipo, csharp identifica el tipo y la asigna

            var nombre = "hecto";

            //object todos los elementos de c heredan de este objeto
            object persona = new { mbre = "hector", apellido = "sadklasd" };
            //tipos anonimos

            //---------objetos-------
            //con el namesapce evitamos el import ya podemos usar elobjeto
            Bebida bebida = new Bebida("Coca Cola", 1000);
            bebida.Nombre = "Coca Cola";
            bebida.beberse(500);
            Console.WriteLine(bebida.Cantidad);

            Cerveza cerveza = new Cerveza(500);
            cerveza.beberse(10);
        }
    }
}
