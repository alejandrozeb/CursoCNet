using System;
using System.Collections.Generic;
using FundamentosCSHarp.Models;
using FundamentosCSHarp.Service;
//importamos donde esta bebida

//JSON
using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;
using System.Threading.Tasks;
using System.Net.Http;
using System.Linq;
using FundamentosCSHarp.Errors;

namespace FundamentosCSHarp
{
    static class Program
    {
        //delegate
        //public delegate string Mostrar(string cadena);
        //para no crear muchos delegados

       
        static async Task Main(string[] args)
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

            var bebidaAlcoholica = new Vino(100);
            MostrarRecomendacion(bebidaAlcoholica);
            //respeta las interfaz

            var bebidaAlcoholica2 = new Cerveza(100);
            MostrarRecomendacion(bebidaAlcoholica);
            //poemos implmentar muchas interfaces en una clase

            //podemos usar en una peticion

            //los tipo list tiene varias interfaces implementadas

            //insertamos una cerveza
            CervezaBD cervezaBD = new CervezaBD();

            {
                Cerveza cerveza4 = new Cerveza(15, "Pale ale");
                cerveza.Marca = "Minerva";
                cerveza.Alcohol = 6;
                cervezaBD.Add(cerveza4);
            }
            //creamos el objeto en un objeto

            //actualizando
            {
                Cerveza cerveza4 = new Cerveza(5, "Pale ale");
                cerveza.Marca = "Minerva";
                cerveza.Alcohol = 5;
                cervezaBD.Edit(cerveza4,5);
            }

            //eliiminando
            {
                cervezaBD.Delete(5);
            }
            //consulta bd
            
            var cervezas3 = cervezaBD.Get();

            foreach (var item in cervezas3)
            {
                Console.WriteLine(item.Nombre);
            }

            //serializacion de objetos json

            Cerveza cervezaJson = new Cerveza(10, "Cerveza");

            //JSON
            //{ cantida:10, Nombre:"cerveza", cosas: [], }
            //necesitamso un namespace

            string miJSon = JsonSerializer.Serialize(cervezaJson);
            //podemos mandar a un servicio

            //de escribe en txt
            File.WriteAllText("objeto.txt", miJSon);

            //de txt a objeto
            string miJson2 = File.ReadAllText("objeto.txt");
            Cerveza cervezaDes = JsonSerializer.Deserialize<Cerveza>(miJson2);



            //---get a una APi
            string urla = "https://jsonplaceholder.typicode.com/posts";
            HttpClient client = new HttpClient();

            //esto es ayncrono
            //var res = client.GetAsync(urla);

            Console.WriteLine("mordi mi nugget");
            //esperamos la respuesta
            //await res;

            //se ejecutara despes de res por el await

            Console.WriteLine("beber cerveza");

            var httpResponse = await client.GetAsync(urla);
            if (httpResponse.IsSuccessStatusCode) {
                //devuelve el body y es asincrono
                var content = await httpResponse.Content.ReadAsStringAsync();
                //deserializamos
                List<Models.Post> posts =
                    JsonSerializer.Deserialize<List<Models.Post>>(content);
            }


            //-----Post----------

            //añadimos async task para que se pueda realizar asincronismo
            //using System.Net.Http; usaremos para pode realizar las consultas

            string url = "https://jsonplaceholder.typicode.com/posts";
            var client2 = new HttpClient();
            Post post = new Post()
            { 
                userId = 50,
                body = "hola como estas",
                title = "titulo de saludo"
            };

            //serializamos el contenido del objetp

            var data = JsonSerializer.Serialize<Post>(post);
            //contenido especifico de la consulta
            HttpContent content2 = new StringContent(data, System.Text.Encoding.UTF8, "application/json")
            //enviamos la data, el encode y decimos que sera un json
            //debemo ignorar las mayusculas o ninusculas con el json de respuesta

            var httpResponse3 = await client.PostAsync(url, content2);
            //cambia a put pero debemos cambiar la url
            //con var s ele asigna el tipo de la derecha
            if (httpResponse3.IsSuccessStatusCode) {
                //verifica los estdos del 200 al 299
                var resulPost = await httpResponse3.Content.ReadAsStringAsync();
                var postResult = JsonSerializer.Deserialize<Post>(resulPost);
            }


            //GENEREICOS---- como las listas <> 

            var cervezaG = new Cerveza()
            { Alcohol = 5, Cantidad = 500, Marca = "Colima", Nombre = "Ticus" };

            Service.SendRequest<Cerveza> service = new Service.SendRequest<Cerveza>();
            var CervezaRespuesta = await service.Send(cervezaG);

            //podemos cambiar por post u otro objeto

            //Linq 
            //permite realizar consulta a coleccioes bds, listas, arreglos

            //using system.linq
            List<int> numerosLinq = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8 };
            var numeroLi = numerosLinq.Where(d => d == 7 ).FirstOrDefault();
            //exprecion lamda
            //el predicado indica la coleccion de numeros, seguido de la condicion u expresion
            //default te devuelve el defautl
            Console.WriteLine(numeroLi);
            //sin for o un ciclo se realizo con una funcion
            //linq es un lenguaje de extension de c sharp, si no existe el valor devuelve 0
            //linq es un lenguje de consulta

            var numerosOrdenados = numerosLinq.OrderBy(d => d);
            //ordena los numeros


            var numerosSumados = numerosLinq.Sum(d => d);
            //sumatoria de toda la lista
            //average
            //linq tambien se puede usar con objetos creados
            //from d in cervezas order by d.Marca select d 
            //para ordenar por marca
            //from d in cervezas where d.Nobmre=="Pale Ale" order by d.Marca select d 

            //se pueden hacer uniones

            //-----objetos complejos y linq------

            List<Bar> bares = new List<Bar>()
            {
                new Bar("El bar")
                {
                    cervezas = new List<Cerveza>()
                    {
                        new Cerveza(){ Alcohol = 7, Cantidad = 10, Marca = "Pale Ale", Nombre = "Minerva" },
                        new Cerveza(){ Alcohol = 9, Cantidad = 5, Marca = "Ticus", Nombre = "Colima" },
                        new Cerveza(){ Alcohol = 7, Cantidad = 8, Marca = "Stout", Nombre = "Minerva" },
                    }
                },
                new Bar("El bar 2")
                {
                    cervezas = new List<Cerveza>()
                    {
                    new Cerveza(){ Alcohol = 7, Cantidad = 10, Marca = "Pale Ale", Nombre = "Minerva" },
                    new Cerveza(){ Alcohol = 6, Cantidad = 100, Marca = "Piedra lisa", Nombre = "Colima" },
                    }
                },
                new Bar("El bar nuevo")
            };

            //buscando  una cerveza
            var bar = (from d in bares
                      where d.cervezas.Where(c => c.Nombre == "Ticus").Count() > 0
                      select d).ToList();
            //parceamos a tipo list

            var barData = (from d in bares
                           where d.cervezas.Where(c => c.Nombre == "Ticus").Count() > 0
                           select new BarData(d.Nombre)
                           {
                                bebida = (from c in d.cervezas
                                         select new Bebida(c.Nombre,c.Cantidad)
                                         ).ToList()
                           }
                           ).ToList();

            List < Cerveza > cervezas2Linq = new List<Cerveza>()
            {
                new Cerveza(){ Alcohol = 7, Cantidad = 10, Marca = "Pale Ale", Nombre = "Minerva" },
                new Cerveza(){ Alcohol = 9, Cantidad = 5, Marca = "Ticus", Nombre = "Colima" },
                new Cerveza(){ Alcohol = 7, Cantidad = 8, Marca = "Stout", Nombre = "Minerva" },
                new Cerveza(){ Alcohol = 6, Cantidad = 100, Marca = "Piedra Lisa", Nombre = "Colima" },
            };

            //Exceptions 

            //using sirve para crear un objeto
            try {
                using (var archivo = new StreamWriter(@"C:\hola.txt"))
                {
                    //streamWriter sirve para leer un fichero mandamos la ubicacion
                    archivo.WriteLine("patito");
                }
            }
            catch(Exception e) {
                Console.WriteLine(e);
            }

            //muestra mensajes de error y el programa sigue corriendo

            //busca cerveza

            try
            {
                var searcherBeer = new SearcherBeer();
            }
            //podemos categorizae
            catch (FieldAccessException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (NotFoundBeerException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
            finally {
                //siemrpepp se ejecuta
                Console.WriteLine();
            }
            //las exceptions van en secuencia podemos usar especificas
            //y una opcion general

            //-----delegados------
            //podemos enviar una funcion como argumento en otro funcion
            //envio de correo y luego tener otra funcionalidad
            //programacion funcional
            Func<string, int> mostrar = Show;
            //puedes agregar 16 posibles regresos
            //string es el valor a enciar y int el valor de regreso
            //asi ya no creamos delegates para cada tipo
            //HacerAlgo(mostrar);

            //accion no regresa nada
            Action<string, string> mostrar2 = Show2;


            //---------Predicate------
            //es una implementacion de los delegados
            //te permite evitar los tipos, regresa una sentencia true o false
            //podemos guardar la logica
            var numbers = new List<int> { 1, 56, 2, 3, 3, 45, 6 };
            var predicate = new Predicate<int>(IsDivider2);
            //el generic es el atributo que recibir
            var predicate2 = new Predicate<int>(x => x % 2 == 0);
            //como funcion anonima o lamda

            var dividers2 = numbers.FindAll(predicate2);
            //regresa todos los divisibles entre 2


            //tambien podemos hacer negacion
            Predicate<int> negativePredicate = x => !predicate2(x);
            //recibe lo contrario
            var dividers3 = numbers.FindAll(negativePredicate);



            //otra funcion
            var beers = new List<Beer>() {
                new Beer(){ Name= "Ipa", Alcohol=3 },
                new Beer(){ Name= "Pale ale", Alcohol=8 },
                new Beer(){ Name= "Stout", Alcohol=9 },
                new Beer(){ Name= "Tripel", Alcohol=15 }
            };

            ShowBeerThatIGetDrunk(beers, x=> x.Alcohol >=8);
            //devuelve las cervezas con mas 8 grados

            //con static
            beers.ShowBeerThatIGetDrunk(x => (x.Alcohol >= 8 && x.Alcohol<15));
            //pueden recibir mas de una condicion
        }   

        public static void Show2(string cad, string cad2) {
            Console.WriteLine(cad+cad2);
        }

        static void MostrarRecomendacion(IBebidaAlcoholica bebida) {
            //mostramos cualquier bebida alcoholica
            //podemos asegurarnos de los metodos
            bebida.MaxRecomendado();
        }
        //para delegate
        public static void HacerAlgo(Action<string, string> funcionFinal)
        {
            //Console.WriteLine(funcionFinal("se envio desde otra funcion", "otra"));
        }

        //para delegate
        public static int Show(string cad)
        {
            return cad.Count();
        }

        //definimos el predicate
        static bool IsDivider2(int x) => x % 2 == 0;


        public class Beer
        {
            public string Name { get; set; }
            public int Alcohol { get; set; }
        }

        //predicado cerveza

        static void ShowBeerThatIGetDrunk(this List<Beer> beers, Predicate<Beer> condition) {
            var evilBeers = beers.FindAll(condition);
            //devuelve como lista

            evilBeers.ForEach(d => Console.WriteLine(d.Name));
        }

        //con this extendemos la funcionalidad pero la clase que lo aloja debe ser de tipo estatico
    }
}
