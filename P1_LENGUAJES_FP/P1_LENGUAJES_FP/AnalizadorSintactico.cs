﻿using System;
using System.Collections.Generic;
using System.Text;

namespace P1_LENGUAJES_FP
{
    class AnalizadorSintactico : ConstantesUse
    {
        protected String lexema;
        protected String tipo;
        protected int fila;
        protected int columna;
        protected static Pila pila;
        protected String ultimoValor = "";
        protected Boolean errorLexema = false;
        protected String mensajeErrorLexema = "";
        TablaTrasicionSintactico tablaSintactico;


        public AnalizadorSintactico()
        {
            pila = new Pila();
            pila.InsertarNodo(E);
            tablaSintactico = new TablaTrasicionSintactico();
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
            if (!pila.PilaVacia())
            {
                ultimoValor = pila.MostrarUltimoValorIngresado();
            }
            
            if (ultimoValor.Equals(lexema))
            {
                pila.EliminarNodo();
            }
            else
            {
                if (ultimoValor.Equals(E))
                {
                    tablaSintactico.ejecutarProduccionE(lexema, tipo, fila, columna);
                }
                else if (ultimoValor.Equals(N))
                {

                }
            }
        }
    }
}
