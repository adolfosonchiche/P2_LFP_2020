using System;
using System.Collections.Generic;
using System.Text;

namespace P1_LENGUAJES_FP
{
    class TablaTrasicionSintactico : AnalizadorSintactico
    {

        public void ejecutarProduccionE(String lexema, String tipo, int fila, int columna)
        {
            if (lexema.Equals(principal))
            {
                pila.EliminarNodo();
                pila.InsertarNodo(N);
                pila.InsertarNodo(")");
                pila.InsertarNodo("(");
            }
            else
            {
                errorLexema = true;
            }
        }

        public void ejecutarProduccionN(String lexema, String tipo, int fila, int columna)
        {
            if (lexema.Equals("}"))
            {
                pila.EliminarNodo();
            }
            else if (lexema.Equals(desde) || lexema.Equals(hacer) || lexema.Equals(mientras)
                || lexema.Equals(si))
            {
                ejecutarProduccionD(lexema, tipo, fila, columna);
            }
            else if(lexema.Equals(entero) || lexema.Equals(numDecimal)
                || lexema.Equals(cadena) || lexema.Equals(caracter) || lexema.Equals(escribir)
                || lexema.Equals(booleano) || lexema.Equals(leer))
            {
                ejecutarProduccionR(lexema, tipo, fila, columna);
            } 
            else if (tipo.Equals("id"))
            {

            }
            else
            {
                errorLexema = true;
            }
        }

        public void ejecutarProduccionD(String lexema, String tipo, int fila, int columna)
        {
            if (lexema.Equals(desde))
            {
                pila.InsertarNodo(C);
                pila.InsertarNodo(A);
            }
            else if (lexema.Equals(hacer))
            {
                pila.InsertarNodo(B);
                pila.InsertarNodo("{");
            }
            else if (lexema.Equals(mientras))
            {
                pila.InsertarNodo(C);
                pila.InsertarNodo("{");
                pila.InsertarNodo(")");
                pila.InsertarNodo("K");
                pila.InsertarNodo("(");
            }
            else if (lexema.Equals(si))
            {
                pila.InsertarNodo(F);
                pila.InsertarNodo("{");
                pila.InsertarNodo(")");
                pila.InsertarNodo(K);
                pila.InsertarNodo("(");
            }
            else
            {
                errorLexema = true;
            }
        }

        public void ejecutarProduccionR(String lexema, String tipo, int fila, int columna)
        {
            if (lexema.Equals(entero))
            {
                pila.InsertarNodo(L);
            }
            else if (lexema.Equals(numDecimal))
            {
                pila.InsertarNodo(M);
            }
            else if (lexema.Equals(cadena))
            {
                pila.InsertarNodo(U);
            }
            else if (lexema.Equals(booleano))
            {
                pila.InsertarNodo(Q);
            }
            else if (lexema.Equals(caracter))
            {
                pila.InsertarNodo(P);
            }
            else if (lexema.Equals(leer))
            {
                pila.InsertarNodo(S);
            }
            else if (lexema.Equals(escribir))
            {
                pila.InsertarNodo(T);
            }
            else
            {
                errorLexema = true;
            }
        }

        public void ejecutarProduccionA(String lexema, String tipo, int fila, int columna)
        {
            if (tipo.Equals("id"))
            {
                pila.EliminarNodo();
                pila.InsertarNodo("{");
                pila.InsertarNodo("n");
                pila.InsertarNodo(incremento);
                pila.InsertarNodo("n");
                pila.InsertarNodo("s");
                pila.InsertarNodo("id");
                pila.InsertarNodo(hasta);
                pila.InsertarNodo("n");
                pila.InsertarNodo("=");
                pila.InsertarNodo("id");
            }
            else
            {
                errorLexema = true;
            }
        }

        public void ejecutarProduccionB(String lexema, String tipo, int fila, int columna)
        {
            if (lexema.Equals("}"))
            {
                pila.EliminarNodo();
                pila.InsertarNodo(";");
                pila.InsertarNodo(")");
                pila.InsertarNodo(K);
                pila.InsertarNodo("(");
                pila.InsertarNodo(mientras);
            }
            else if (lexema.Equals(desde) || lexema.Equals(hacer) || lexema.Equals(mientras)
                || lexema.Equals(si) || lexema.Equals(entero) || lexema.Equals(numDecimal)
                || lexema.Equals(cadena) || lexema.Equals(caracter) || lexema.Equals(escribir) || tipo.Equals("id")
                || lexema.Equals(booleano) || lexema.Equals(leer))
            {
                ejecutarProduccionN(lexema, tipo, fila, columna);
            }
            else
            {
                errorLexema = true;
            }
        }

        public void ejecutarProduccionC(String lexema, String tipo, int fila, int columna)
        {
            if (lexema.Equals("}"))
            {
                pila.EliminarNodo();
            }
            else if (lexema.Equals(desde) || lexema.Equals(hacer) || lexema.Equals(mientras)
                || lexema.Equals(si) || lexema.Equals(entero) || lexema.Equals(numDecimal)
                || lexema.Equals(cadena) || lexema.Equals(caracter) || lexema.Equals(escribir) || tipo.Equals("id")
                || lexema.Equals(booleano) || lexema.Equals(leer))
            {
                ejecutarProduccionN(lexema, tipo, fila, columna);
            }
            else
            {
                errorLexema = true;
            }
        }

        public void ejecutarProduccionF(String lexema, String tipo, int fila, int columna)
        {
            if (lexema.Equals("}"))
            {
                pila.EliminarNodo();
                pila.InsertarNodo(FF);
            }
            else if (lexema.Equals(desde) || lexema.Equals(hacer) || lexema.Equals(mientras)
                || lexema.Equals(si) || lexema.Equals(entero) || lexema.Equals(numDecimal)
                || lexema.Equals(cadena) || lexema.Equals(caracter) || lexema.Equals(escribir) || tipo.Equals("id")
                || lexema.Equals(booleano) || lexema.Equals(leer))
            {
                ejecutarProduccionN(lexema, tipo, fila, columna);
            }
            else
            {
                errorLexema = true;
            }
        }

        public void ejecutarProduccionFF(String lexema, String tipo, int fila, int columna)
        {
            if (lexema.Equals(sino) || lexema.Equals(sino_si))
            {
                pila.EliminarNodo();
                ejecutarProduccionH(lexema, tipo, fila, columna);
            }
            else 
            {
                pila.EliminarNodo();
                ejecutarProduccionN(lexema, tipo, fila, columna);
            }
        }

        public void ejecutarProduccionH(String lexema, String tipo, int fila, int columna)
        {
            if (lexema.Equals(sino))
            {
                pila.InsertarNodo(J);
                pila.InsertarNodo("{");
            }
            if (lexema.Equals(sino_si))
            {
                pila.InsertarNodo(I);
                pila.InsertarNodo("{");
                pila.InsertarNodo(")");
                pila.InsertarNodo(K);
                pila.InsertarNodo("(");
            }
            else
            {
                errorLexema = true;
            }
        }

        public void ejecutarProduccionI(String lexema, String tipo, int fila, int columna)
        {
            if (lexema.Equals("}"))
            {
                pila.EliminarNodo();
                pila.InsertarNodo(FF);
            }
            else if (lexema.Equals(desde) || lexema.Equals(hacer) || lexema.Equals(mientras)
                || lexema.Equals(si) || lexema.Equals(entero) || lexema.Equals(numDecimal)
                || lexema.Equals(cadena) || lexema.Equals(caracter) || lexema.Equals(escribir) || tipo.Equals("id")
                || lexema.Equals(booleano) || lexema.Equals(leer))
            {
                ejecutarProduccionN(lexema, tipo, fila, columna);
            }
            else
            {
                errorLexema = true;
            }
        }

        public void ejecutarProduccionJ(String lexema, String tipo, int fila, int columna)
        {
            if (lexema.Equals("}"))
            {
                pila.EliminarNodo();
            }
            else if (lexema.Equals(desde) || lexema.Equals(hacer) || lexema.Equals(mientras)
                || lexema.Equals(si) || lexema.Equals(entero) || lexema.Equals(numDecimal)
                || lexema.Equals(cadena) || lexema.Equals(caracter) || lexema.Equals(escribir) || tipo.Equals("id")
                || lexema.Equals(booleano) || lexema.Equals(leer))
            {
                ejecutarProduccionN(lexema, tipo, fila, columna);
            }
            else
            {
                errorLexema = true;
            }
        }

        public void ejecutarProduccionL(String lexema, String tipo, int fila, int columna)
        {
            if (tipo.Equals("id"))
            {
                pila.EliminarNodo();
                pila.InsertarNodo(LL);
            }
            else
            {
                errorLexema = true;
            }
        }

        public void ejecutarProduccionLL(String lexema, String tipo, int fila, int columna)
        {
            if (lexema.Equals(",") || lexema.Equals(";"))
            {
                ejecutarProduccionLLL(lexema, tipo, fila, columna);
            }
            else if (lexema.Equals("="))
            {
                pila.EliminarNodo();
                pila.InsertarNodo(LLL);
                pila.InsertarNodo("n");
            }
            else
            {
                errorLexema = true;
            }
        }

        public void ejecutarProduccionLLL(String lexema, String tipo, int fila, int columna)
        {
            if (lexema.Equals(","))
            {
                pila.EliminarNodo();
                pila.InsertarNodo(L);
            }
            else if (lexema.Equals(";"))
            {
                pila.EliminarNodo();
            }
            else
            {
                errorLexema = true;
            }
        }

        public void ejecutarProduccionM(String lexema, String tipo, int fila, int columna)
        {
            if (tipo.Equals("id"))
            {
                pila.EliminarNodo();
                pila.InsertarNodo(MM);
            }
            else
            {
                errorLexema = true;
            }
        }

        public void ejecutarProduccionMM(String lexema, String tipo, int fila, int columna)
        {
            if (lexema.Equals(",") || lexema.Equals(";"))
            {
                ejecutarProduccionMMM(lexema, tipo, fila, columna);
            }
            else if (lexema.Equals("="))
            {
                pila.EliminarNodo();
                pila.InsertarNodo(MMM);
                pila.InsertarNodo("np");
            }
            else
            {
                errorLexema = true;
            }
        }

        public void ejecutarProduccionMMM(String lexema, String tipo, int fila, int columna)
        {
            if (lexema.Equals(","))
            {
                pila.EliminarNodo();
                pila.InsertarNodo(M);
            }
            else if (lexema.Equals(";"))
            {
                pila.EliminarNodo();
            }
            else
            {
                errorLexema = true;
            }
        }

        public void ejecutarProduccionU(String lexema, String tipo, int fila, int columna)
        {
            if (tipo.Equals("id"))
            {
                pila.EliminarNodo();
                pila.InsertarNodo(UU);
            }
            else
            {
                errorLexema = true;
            }
        }

        public void ejecutarProduccionUU(String lexema, String tipo, int fila, int columna)
        {
            if (lexema.Equals(",") || lexema.Equals(";"))
            {
                ejecutarProduccionUUU(lexema, tipo, fila, columna);
            }
            else if (lexema.Equals("="))
            {
                pila.EliminarNodo();
                pila.InsertarNodo(UUU);
                pila.InsertarNodo("ct");
            }
            else
            {
                errorLexema = true;
            }
        }

        public void ejecutarProduccionUUU(String lexema, String tipo, int fila, int columna)
        {
            if (lexema.Equals(","))
            {
                pila.EliminarNodo();
                pila.InsertarNodo(U);
            }
            else if (lexema.Equals(";"))
            {
                pila.EliminarNodo();
            }
            else
            {
                errorLexema = true;
            }
        }

        public void ejecutarProduccionP(String lexema, String tipo, int fila, int columna)
        {
            if (tipo.Equals("id"))
            {
                pila.EliminarNodo();
                pila.InsertarNodo(PP);
            }
            else
            {
                errorLexema = true;
            }
        }

        public void ejecutarProduccionPP(String lexema, String tipo, int fila, int columna)
        {
            if (lexema.Equals(",") || lexema.Equals(";"))
            {
                ejecutarProduccionPPP(lexema, tipo, fila, columna);
            }
            else if (lexema.Equals("="))
            {
                pila.EliminarNodo();
                pila.InsertarNodo(PPP);
                pila.InsertarNodo("ac");
            }
            else
            {
                errorLexema = true;
            }
        }

        public void ejecutarProduccionPPP(String lexema, String tipo, int fila, int columna)
        {
            if (lexema.Equals(","))
            {
                pila.EliminarNodo();
                pila.InsertarNodo(P);
            }
            else if (lexema.Equals(";"))
            {
                pila.EliminarNodo();
            }
            else
            {
                errorLexema = true;
            }
        }

        public void ejecutarProduccionQ(String lexema, String tipo, int fila, int columna)
        {
            if (tipo.Equals("id"))
            {
                pila.EliminarNodo();
                pila.InsertarNodo(QQ);
            }
            else
            {
                errorLexema = true;
            }
        }

        public void ejecutarProduccionQQ(String lexema, String tipo, int fila, int columna)
        {
            if (lexema.Equals(",") || lexema.Equals(";"))
            {
                ejecutarProduccionQQQ(lexema, tipo, fila, columna);
            }
            else if (lexema.Equals("="))
            {
                pila.EliminarNodo();
                pila.InsertarNodo(QQQ);
                pila.InsertarNodo(V);
            }
            else
            {
                errorLexema = true;
            }
        }

        public void ejecutarProduccionQQQ(String lexema, String tipo, int fila, int columna)
        {
            if (lexema.Equals(","))
            {
                pila.EliminarNodo();
                pila.InsertarNodo(Q);
            }
            else if (lexema.Equals(";"))
            {
                pila.EliminarNodo();
            }
            else
            {
                errorLexema = true;
            }
        }

        public void ejecutarProduccionV(String lexema, String tipo, int fila, int columna)
        {
            if (lexema.Equals(verdadero) || lexema.Equals(falso))
            {
                pila.EliminarNodo();
            }
            else
            {
                errorLexema = true;
            }
        }

        public void ejecutarProduccionS(String lexema, String tipo, int fila, int columna)
        {
            if (lexema.Equals("("))
            {
                pila.EliminarNodo();
                pila.InsertarNodo(";");
                pila.InsertarNodo(")");
                pila.InsertarNodo("id");
            }
            else
            {
                errorLexema = true;
            }
        }

        public void ejecutarProduccionT(String lexema, String tipo, int fila, int columna)
        {
            if (lexema.Equals("("))
            {
                pila.EliminarNodo();
                pila.InsertarNodo(";");
                pila.InsertarNodo(")");
                pila.InsertarNodo(W);
                pila.InsertarNodo(TT);
            }
            else
            {
                errorLexema = true;
            }
        }

        public void ejecutarProduccionTT(String lexema, String tipo, int fila, int columna)
        {
            if (tipo.Equals("id") || tipo.Equals("n") || tipo.Equals("ct"))
            {
                pila.EliminarNodo();
            }
            else
            {
                errorLexema = true;
            }
        }

        public void ejecutarProduccionW(String lexema, String tipo, int fila, int columna)
        {
            if (lexema.Equals(")"))
            {
                pila.EliminarNodo();
                pila.EliminarNodo();
            }
            else if (lexema.Equals("+"))
            {
                pila.InsertarNodo(TT);
            }
            else
            {
                errorLexema = true;
            }
        }

        public void ejecutarProduccionO(String lexema, String tipo, int fila, int columna)
        {
            if (tipo.Equals("id"))
            {
                pila.EliminarNodo();
                pila.InsertarNodo(OO);
            }
            else
            {
                errorLexema = true;
            }
        }
    }
}
