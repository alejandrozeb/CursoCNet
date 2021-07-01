using System;
using System.Collections.Generic;
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

            //tipos de datos

            int[] numeros = new int[10] {1,2,3,4,5,6,7,8,9,0};
            //indicmos que es un arreglo, le damos una dimension y datos por default si queremos
            int numeroNuevo = numeros[0];

            //recorridos
            for (int i = 0; i < numeros.Length; i++) {
                Console.WriteLine("iteracion"+i+"-"+numeros[i]);
            }

            foreach (var numeroI in numeros) {
                Console.WriteLine(numeroI);
            }
            //tambien sirve para lista

            //listas en arreglos damos una longitud inicial
            //un arreglo es mas rapido que una lista
            //la lista es una clase de C su longitud va cambiando
            //tambien existe pilas y colas

            //implemetacion
            //palabra reservada
            List<int> lista = new List<int>() { 1,2,3,4,5,6,7,8,9};
            //() con parentesis indicamos que es una clase ademas impoortados 
            //los genericos
            lista.Add(1);
            lista.Add(2);
            lista.Remove(2);
            foreach (var item in lista)
            {
                Console.WriteLine(item);
            }
            //podemos agregar cualquier cantidad de elemnetos
            //colas
            Queue<int> cola = new Queue<int>();

            //tambien puede ser una lista de objetos
            List<Cerveza> cervezas = new List<Cerveza>() { new Cerveza(10)};

            cervezas.Add(new Cerveza(500));
            Cerveza erdinger = new Cerveza(60);
            cervezas.Add(erdinger);

            //formas de agregar elementos

            foreach (var cerveza2 in cervezas)
            {
                Console.WriteLine(cerveza2);
            }

            //----interfaces-----
            //resolver problemas de multi herencia
            
        }
    }
}
