using System;
using System.Collections.Generic;
using System.Text;

namespace P1_LENGUAJES_FP
{
    class EstadoAceptacion  : Automata 
    {
        /*retorna 1 si se ingresa un numero, retorna 2 si es un punto, 
         * retornaa 1 si es un otro token*/
        public int estadoB(Char token)
        {
            tok = token.ToString();
            if ((tok.Equals("0") || tok.Equals("1") || tok.Equals("2") || tok.Equals("3")
                || tok.Equals("4") || tok.Equals("5") || tok.Equals("6") || tok.Equals("7")
                || tok.Equals("8") || tok.Equals("9")) && (puntoEstadoB == 0 || puntoEstadoB == 1))
            {
                errorToken = false;
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
                return 1;               
            }
           
        }

        /*retorna 0 si es un token vacio, 
         * retorna 3 si es un token de tipo letra*/
        public int estadoD(Char token)
        {
            if (tok.Equals(" "))
            {
                errorToken = false;
                return 0;
            }
            else
            {
                errorToken = true;
                return 3;
            }
        }

        /*retorna 10 no importa el token  ingresada*/
        public int estadoK(Char token)
        {
            cadCom = 1;
            errorToken = false;
            return 10;          
        }
    }
}
