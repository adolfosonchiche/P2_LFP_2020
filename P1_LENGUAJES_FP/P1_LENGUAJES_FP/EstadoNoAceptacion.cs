using System;
using System.Collections.Generic;
using System.Text;

namespace P1_LENGUAJES_FP
{
    class EstadoNoAceptacion : Automata
    {

        /*metodo estado A inicial
         * retorna un 1 si es un entero, decimal
         * retorna un 7 si es una cadena
         *retorna un 4 si es un comentario
         * retorna 3 si es un caracter, palabra reservada*/
        public int estadoA(Char token)
        {
            tok = token.ToString();
            if (tok.Equals("0") || tok.Equals("1") || tok.Equals("2") || tok.Equals("3") 
                || tok.Equals("4") || tok.Equals("5") || tok.Equals("6") || tok.Equals("7")
                || tok.Equals("8") || tok.Equals("9"))
            {
                return 1;
            }
            else if (tok.Equals("\""))
            {
                return 7;
            }
            else if (tok.Equals("/"))
            {
                return 4;
            }
            else 
            {
                errorToken = false;
                return 3;
            }
        }

        /*metodo de estado C , retorna un 1 si es un numero, o 2 si es un punto*/
        public int estadoC(Char token)
        {
            tok = token.ToString();
            if (tok.Equals("0") || tok.Equals("1") || tok.Equals("2") || tok.Equals("3")
                || tok.Equals("4") || tok.Equals("5") || tok.Equals("6") || tok.Equals("7")
                || tok.Equals("8") || tok.Equals("9"))
            {
                errorToken = true;
                return 1;
            }
            else if (tok.Equals("."))
            {
                errorToken = true;
                puntoEstadoB++;
                return 2;
            }
            else
            {
                errorToken = true;
                return 2;
            }
        }

        /*Estado E, retorna 8 si es un diagonal o un 9 si es un * 
         * retorna 4 si no se ingresa nada de lo anterior*/
        public int estadoE(Char token)
        {
            tok = token.ToString();
            if (tok.Equals("/"))
            {
                errorToken = true;
                return 8;
            }
            else if (tok.Equals("*"))
            {
                errorToken = true;
                return 9;
            }
             else 
            {
                errorToken = true;
                return 4;
            }
        }

        /*estado F etorna 11 si es un *, retorna 5 si es otro tipo de token*/
        public int estadoF(Char token)
        {
            tok = token.ToString();
            if (tok.Equals("*"))
            {
                cadCom = 1;
                errorToken = true;
                return 11;
            }
            else
            {
                errorToken = true;
                return 5;
            }
        }

        /*retorna 3 si es un comilla, retorna 6 si es otro tipo de token*/
        public int estadoG(Char token)
        {
            tok = token.ToString();
            if (tok.Equals("\""))
            {
                cadCom = 0;
                errorToken = false;
                return 3;
            }           
            else
            {
                errorToken = true;
                return 6;
            }
        }

        /*retorna 6 no importa el token  ingresada*/
        public int estadoH(Char token)
        {
                errorToken = true;
                return 6;        
        }

        /*retorna 10 no importa el token  ingresada*/
        public int estadoI(Char token)
        {
            errorToken = false;
            return 10;
        }

        /*retorna 5 no importa el token  ingresada*/
        public int estadoJ(Char token)
        {
            errorToken = true;
            return 5;
        }

        /*retorna 3 si se ingresa un diagonal, retorna 11 si es otro tipo de token*/
        public int estadoL(Char token)
        {
            tok = token.ToString();
            if (tok.Equals("/"))
            {
                cadCom = 1;
                errorToken = false;
                return 3;
            }
            else
            {
                errorToken = true;
                return 11;
            }
        }

    }
}
