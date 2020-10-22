using System;
using System.Collections.Generic;
using System.Text;

namespace P1_LENGUAJES_FP
{
    class Pila
    {

        private Nodo UltimoValorIngresado;
        protected int tamano = 0;
        protected String Lista = "";

        public Pila()
        {
            UltimoValorIngresado = null;
            tamano = 0;
        }

        //Método para saber cuando la pila esta vacia
        public Boolean PilaVacia()
        {
            return UltimoValorIngresado == null;
        }

        //Método para insertar un nodo en la pila
        public void InsertarNodo(String nodo)
        {
            Nodo nuevo_nocdo = new Nodo(nodo);
            nuevo_nocdo.setSiguiente(UltimoValorIngresado);
            UltimoValorIngresado = nuevo_nocdo;
            tamano++;
        }

        //Método para eliminar un nodo de la pila
        public String EliminarNodo()
        {
            String auxiliar = UltimoValorIngresado.getInformacion();
            UltimoValorIngresado = UltimoValorIngresado.getSiguiente();
            tamano--;
            return auxiliar;
        }

        //Método para conocer cual es el último valor ingresado
        public String MostrarUltimoValorIngresado()
        {
            return UltimoValorIngresado.getInformacion();
        }

        //Método para conocer el tamaño de la Pila
        public int TamanoPila()
        {
            return tamano;
        }

        //Método para vaciar la Pila
        public void VaciarPila()
        {
            while (!PilaVacia())
            {
                EliminarNodo();
            }
        }

    }
}
