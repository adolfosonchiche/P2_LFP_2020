using System;
using System.Collections.Generic;
using System.Text;

namespace P1_LENGUAJES_FP
{
    class AnalizadorSintactico
    {
        protected String lexema;
        protected String tipo;
        protected int fila;
        protected int columna;
        protected static Pila pila;

        public AnalizadorSintactico()
        {
            pila = new Pila();
        }

        public void obtenerLexema(String lexema, String tipo, int fila, int columna)
        {
            this.lexema = lexema;
            this.tipo = tipo;
            this.fila = fila;
            this.columna = columna;
        }

        public void analizarLexema()
        {
            String ultimoValor = pila.MostrarUltimoValorIngresado();

            if (ultimoValor.Equals(lexema))
            {
                pila.EliminarNodo();
            }
            else
            {
                if (ultimoValor.Equals("E"))
                {

                }
            }
        }
    }
}
