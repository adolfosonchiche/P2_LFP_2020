using System;
using System.Collections.Generic;
using System.Text;

namespace P1_LENGUAJES_FP
{
    class Nodo
    {
        private String informacion;
        private Nodo siguiente;

        public Nodo(String valor)
        {
            informacion = valor;
            siguiente = null;
        }

        public void setSiguiente(Nodo nodo)
        {
            siguiente = nodo;
        }

        public void setInformacion(String info)
        {
            informacion = info;
        }

        public Nodo getSiguiente()
        {
            return siguiente;
        }

        public String getInformacion()
        {
            return informacion;
        }
    }
}
