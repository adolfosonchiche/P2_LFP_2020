using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;

namespace P1_LENGUAJES_FP
{
    class TablaTrasicionSintactico : AnalizadorSintactico
    {
        public TablaTrasicionSintactico()
        {
            
        }

        public void ejecutarProduccionE()
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

        public void ejecutarProduccionN()
        {
            if (lexema.Equals("}"))
            {
                pila.EliminarNodo();
            }
            else if (lexema.Equals(desde) || lexema.Equals(hacer) || lexema.Equals(mientras)
                || lexema.Equals(si))
            {
                ejecutarProduccionD();
            }
            else if(lexema.Equals(entero) || lexema.Equals(numDecimal)
                || lexema.Equals(cadena) || lexema.Equals(caracter) || lexema.Equals(escribir)
                || lexema.Equals(booleano) || lexema.Equals(leer))
            {
                ejecutarProduccionR();
            } 
            else if (tipo.Equals("id"))
            {
                ejecutarProduccionO();
            }
            else
            {
                errorLexema = true;
            }
        }

        public void ejecutarProduccionD()
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

        public void ejecutarProduccionR()
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

        public void ejecutarProduccionA()
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

        public void ejecutarProduccionB()
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
                ejecutarProduccionN();
            }
            else
            {
                errorLexema = true;
            }
        }

        public void ejecutarProduccionC()
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
                ejecutarProduccionN();
            }
            else
            {
                errorLexema = true;
            }
        }

        public void ejecutarProduccionF()
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
                ejecutarProduccionN();
            }
            else
            {
                errorLexema = true;
            }
        }

        public void ejecutarProduccionFF()
        {
            if (lexema.Equals(sino) || lexema.Equals(sino_si))
            {
                pila.EliminarNodo();
                ejecutarProduccionH();
            }
            else 
            {
                pila.EliminarNodo();
                ejecutarProduccionN();
            }
        }

        public void ejecutarProduccionH()
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

        public void ejecutarProduccionI()
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
                ejecutarProduccionN();
            }
            else
            {
                errorLexema = true;
            }
        }

        public void ejecutarProduccionJ()
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
                ejecutarProduccionN();
            }
            else
            {
                errorLexema = true;
            }
        }

        public void ejecutarProduccionL()
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

        public void ejecutarProduccionLL()
        {
            if (lexema.Equals(",") || lexema.Equals(";"))
            {
                ejecutarProduccionLLL();
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

        public void ejecutarProduccionLLL()
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

        public void ejecutarProduccionM()
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

        public void ejecutarProduccionMM()
        {
            if (lexema.Equals(",") || lexema.Equals(";"))
            {
                ejecutarProduccionMMM();
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

        public void ejecutarProduccionMMM()
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

        public void ejecutarProduccionU()
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

        public void ejecutarProduccionUU()
        {
            if (lexema.Equals(",") || lexema.Equals(";"))
            {
                ejecutarProduccionUUU();
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

        public void ejecutarProduccionUUU()
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

        public void ejecutarProduccionP()
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

        public void ejecutarProduccionPP()
        {
            if (lexema.Equals(",") || lexema.Equals(";"))
            {
                ejecutarProduccionPPP();
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

        public void ejecutarProduccionPPP()
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

        public void ejecutarProduccionQ()
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

        public void ejecutarProduccionQQ()
        {
            if (lexema.Equals(",") || lexema.Equals(";"))
            {
                ejecutarProduccionQQQ();
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

        public void ejecutarProduccionQQQ()
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

        public void ejecutarProduccionV()
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

        public void ejecutarProduccionS()
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

        public void ejecutarProduccionT()
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

        public void ejecutarProduccionTT()
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

        public void ejecutarProduccionW()
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

        public void ejecutarProduccionO()
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

        public void ejecutarProduccionOO()
        {
            if (lexema.Equals("-"))
            {
                pila.EliminarNodo();
                pila.InsertarNodo(";");
                pila.InsertarNodo("-");
            }
            else if (lexema.Equals("+"))
            {
                pila.EliminarNodo();
                pila.InsertarNodo(";");
                pila.InsertarNodo("+");
            }
            else if (lexema.Equals("="))
            {
                pila.EliminarNodo();
                pila.InsertarNodo(Z);
            }
            else
            {
                errorLexema = true;
            }
        }

        public void ejecutarProduccionZ()
        {
            if (tipo.Equals("id") || tipo.Equals("n") || tipo.Equals("np") || tipo.Equals("ct")
                || tipo.Equals("ac"))
            {
                pila.EliminarNodo();
                pila.InsertarNodo(X);

            }
            else if (lexema.Equals(verdadero) || lexema.Equals(falso))
            {
                pila.EliminarNodo();
                pila.InsertarNodo(";");
            }
            else
            {
                errorLexema = true;
            }
        }

        public void ejecutarProduccionX()
        {
            if (tipo.Equals("s"))
            {
                pila.EliminarNodo();
                pila.InsertarNodo(Z);

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

        public void ejecutarProduccionK()
        {
            if (tipo.Equals("id"))
            {
                pila.EliminarNodo();
                pila.InsertarNodo(G);
                pila.InsertarNodo(KK);
                pila.InsertarNodo("s");
            }
            else if (lexema.Equals("!"))
            {
                pila.EliminarNodo();
                pila.InsertarNodo(GG);
                pila.InsertarNodo(Y);
            }
            else
            {
                errorLexema = true;
            }
        }

        public void ejecutarProduccionKK()
        {
            if (tipo.Equals("s"))
            {
                pila.EliminarNodo();
            }
            else 
            {
                pila.EliminarNodo();
                ejecutarProduccionG();
            }
        }

        public void ejecutarProduccionG()
        {
            if (tipo.Equals("id") || tipo.Equals("n"))
            {
                pila.EliminarNodo();
                pila.InsertarNodo(GG);
            }
            else
            {
                errorLexema = true;
            }
        }

        public void ejecutarProduccionGG()
        {
            if (lexema.Equals("&"))
            {
                pila.EliminarNodo();
                pila.InsertarNodo(K);
                pila.InsertarNodo("&");
            }
            else if (lexema.Equals("|"))
            {
                pila.EliminarNodo();
                pila.InsertarNodo(K);
                pila.InsertarNodo("|");
            }
            else if (lexema.Equals(")"))
            {
                pila.EliminarNodo();
                pila.EliminarNodo();
            }
            else
            {
                errorLexema = true;
            }
        }

        public void ejecutarProduccionY()
        {
            if (lexema.Equals("!"))
            {
                pila.EliminarNodo();
                pila.InsertarNodo(Y);
            }
            else if (lexema.Equals(verdadero) || lexema.Equals(falso))
            {
                pila.EliminarNodo();
            }
            else
            {
                errorLexema = true;
            }
        }
    }
}
