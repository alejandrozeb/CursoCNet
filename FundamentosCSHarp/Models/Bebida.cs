using System;
using System.Collections.Generic;
using System.Text;

namespace FundamentosCSHarp.Models
{
    public class Bebida
    {
        //atributos
        public string Nombre { get; set; }
        //podemos agregar getters y setters y ya estanlopr defecto
        //si no damos public se queda como internal y solos e usa en el objeo

        //namespaces FundamentosCSHarp.Models podemos importar el objeto en otro 
        //lugar con la ayuda de namespace

        //existen atributos privados que no se puede acceder private
        //existe protegido que si se puede acceder pero solo clases heredadas protected
        public int Cantidad { get; set; }
        
        //implementado interface
        //contructor
        public Bebida(string Nombre,int Cantidad) {
            //el contructor siempre lleva el mismo nombre de la clase
            this.Nombre = Nombre;
            this.Cantidad = Cantidad;
            //no regresa mada, el por defeco no lleva nada
        }
        //metodo
        //no necesita instancia, con void
        public void beberse(int cuantoBebio) {
            this.Cantidad -= cuantoBebio;
            //cantidad en mls
        }
    }
}
