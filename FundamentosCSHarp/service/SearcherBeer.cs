using FundamentosCSHarp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FundamentosCSHarp.Service
{
    public class SearcherBeer
    {
        List<Cerveza> cervezas = new List<Cerveza>() {
            new Cerveza(){ Alcohol = 7, Cantidad = 10, Marca = "Pale Ale", Nombre = "Minerva" },
            new Cerveza(){ Alcohol = 9, Cantidad = 5, Marca = "Ticus", Nombre = "Colima" },
            new Cerveza(){ Alcohol = 7, Cantidad = 8, Marca = "Stout", Nombre = "Minerva" },
        };

        public int GetCantidad(string Nombre) {
            var cerveza = (from d in cervezas
                           where d.Nombre == Nombre
                           select d).First();

            return cerveza.Cantidad;
        }
    }
}
