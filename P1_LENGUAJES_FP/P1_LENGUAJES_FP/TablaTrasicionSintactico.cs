using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;
using System.Windows.Forms;

namespace P1_LENGUAJES_FP
{
    class TablaTrasicionSintactico : AnalizadorSintactico
    {
        protected String numeroNodo = "";
        public TablaTrasicionSintactico()
        {
            numeroNodo = numNodo.ToString();
        }

        public void ejecutarProduccionE(String lexema, String tipo, int fila, int columna)
        {
            try {
                if (lexema.Equals(principal))
                {
                    arbol += "E1-> \"N6\"; \n";
                    pila.EliminarNodo();
                    pila.InsertarNodo(N);
                    pila.InsertarNodo("{");
                    pila.InsertarNodo(")");
                    pila.InsertarNodo("(");
                    //MessageBox.Show(arbol);
                }
                else
                {
                    errorLexema = true;
                    imprimirError(lexema, tipo, fila, columna);
                }
            }
            catch (Exception e) {
                MessageBox.Show("error ccv \n" + e);
            }      
        }

        public void ejecutarProduccionN(String lexema, String tipo, int fila, int columna)
        {
            if (lexema.Equals("}"))
            {
                arbol += "N"+numeroNodo+ "-> \"}" + numeroNodo + "\"; \n";
                numNodo++;
                pila.EliminarNodo();
            }
            else if (lexema.Equals(desde) || lexema.Equals(hacer) || lexema.Equals(mientras)
                || lexema.Equals(si))
            {
                numNodo++;
                String nuevoNodo = numNodo.ToString();
                arbol += "N" + numeroNodo + "-> \"N" + nuevoNodo + "\"; \n";
                arbol += "N" + nuevoNodo + "-> \"D" + nuevoNodo + "\"; \n";
                numeroNodo = nuevoNodo;
                pila.InsertarNodo(N);
                ejecutarProduccionD(lexema, tipo, fila, columna);
            }
            else if(lexema.Equals(entero) || lexema.Equals(numDecimal)
                || lexema.Equals(cadena) || lexema.Equals(caracter) || lexema.Equals(escribir)
                || lexema.Equals(booleano) || lexema.Equals(leer))
            {
                arbol += "N" + numeroNodo + "-> \"R" + numeroNodo + "\"; \n";
                ejecutarProduccionR(lexema, tipo, fila, columna);
                numNodo++;
            } 
            else if (tipo.Equals("id"))
            {
                arbol += "N" + numeroNodo + "-> \"O" + numeroNodo + "\"; \n";
                ejecutarProduccionO(lexema, tipo, fila, columna);
            }
            else
            {
                errorLexema = true;
                imprimirError(lexema, tipo, fila, columna);
            }
        }

        public void ejecutarProduccionD(String lexema, String tipo, int fila, int columna)
        {
            if (lexema.Equals(desde))
            {
                arbol += "D" + numeroNodo + "-> \"DESDE" + numeroNodo + "\"; \n";
                arbol += "D" + numeroNodo + "-> \"A" + numeroNodo + "\"; \n";
                arbol += "D" + numeroNodo + "-> \"C" + numeroNodo + "\"; \n";
                pila.InsertarNodo(C);
                pila.InsertarNodo(A);
            }
            else if (lexema.Equals(hacer))
            {
                arbol += "D" + numeroNodo + "-> \"HACER" + numeroNodo + "\"; \n";
                arbol += "D" + numeroNodo + "-> \"{" + numeroNodo + "\"; \n";
                arbol += "D" + numeroNodo + "-> \"B" + numeroNodo + "\"; \n";
                pila.InsertarNodo(B);
                pila.InsertarNodo("{");
            }
            else if (lexema.Equals(mientras))
            {
                arbol += "D" + numeroNodo + "-> \"MIENTRAS" + numeroNodo + "\"; \n";
                arbol += "D" + numeroNodo + "-> \"(" + numeroNodo + "\"; \n";
                arbol += "D" + numeroNodo + "-> \"K" + numeroNodo + "\"; \n";
                arbol += "D" + numeroNodo + "-> \")" + numeroNodo + "\"; \n";
                arbol += "D" + numeroNodo + "-> \"{" + numeroNodo + "\"; \n";
                arbol += "D" + numeroNodo + "-> \"C" + numeroNodo + "\"; \n";
                pila.InsertarNodo(C);
                pila.InsertarNodo("{");
                pila.InsertarNodo(")");
                pila.InsertarNodo(K);
                pila.InsertarNodo("(");
            }
            else if (lexema.Equals(si))
            {
                arbol += "D" + numeroNodo + "-> \"SI" + numeroNodo + "\"; \n";
                arbol += "D" + numeroNodo + "-> \"(" + numeroNodo + "\"; \n";
                arbol += "D" + numeroNodo + "-> \"K" + numeroNodo + "\"; \n";
                arbol += "D" + numeroNodo + "-> \")" + numeroNodo + "\"; \n";
                arbol += "D" + numeroNodo + "-> \"{" + numeroNodo + "\"; \n";
                arbol += "D" + numeroNodo + "-> \"F" + numeroNodo + "\"; \n";
                pila.InsertarNodo(F);
                pila.InsertarNodo("{");
                pila.InsertarNodo(")");
                pila.InsertarNodo(K);
                pila.InsertarNodo("(");
            }
            else
            {
                errorLexema = true;
                imprimirError(lexema, tipo, fila, columna);
            }
        }

        public void ejecutarProduccionR(String lexema, String tipo, int fila, int columna)
        {
            if (lexema.Equals(entero))
            {
                arbol += "R" + numeroNodo + "-> \"entero" + numeroNodo + "\"; \n";
                arbol += "R" + numeroNodo + "-> \"L" + numeroNodo + "\"; \n";
                pila.InsertarNodo(L);
            }
            else if (lexema.Equals(numDecimal))
            {
                arbol += "R" + numeroNodo + "-> \"decimal" + numeroNodo + "\"; \n";
                arbol += "R" + numeroNodo + "-> \"M" + numeroNodo + "\"; \n";
                pila.InsertarNodo(M);
            }
            else if (lexema.Equals(cadena))
            {
                arbol += "R" + numeroNodo + "-> \"cadena" + numeroNodo + "\"; \n";
                arbol += "R" + numeroNodo + "-> \"U" + numeroNodo + "\"; \n";
                pila.InsertarNodo(U);
            }
            else if (lexema.Equals(booleano))
            {
                arbol += "R" + numeroNodo + "-> \"booleano" + numeroNodo + "\"; \n";
                arbol += "R" + numeroNodo + "-> \"Q" + numeroNodo + "\"; \n";
                pila.InsertarNodo(Q);
            }
            else if (lexema.Equals(caracter))
            {
                arbol += "R" + numeroNodo + "-> \"caracter" + numeroNodo + "\"; \n";
                arbol += "R" + numeroNodo + "-> \"P" + numeroNodo + "\"; \n";
                pila.InsertarNodo(P);
            }
            else if (lexema.Equals(leer))
            {
                arbol += "R" + numeroNodo + "-> \"leer" + numeroNodo + "\"; \n";
                arbol += "R" + numeroNodo + "-> \"S" + numeroNodo + "\"; \n";
                pila.InsertarNodo(S);
            }
            else if (lexema.Equals(escribir))
            {
                arbol += "R" + numeroNodo + "-> \"imprimir" + numeroNodo + "\"; \n";
                arbol += "R" + numeroNodo + "-> \"T" + numeroNodo + "\"; \n";
                pila.InsertarNodo(T);
            }
            else
            {
                errorLexema = true;
                imprimirError(lexema, tipo, fila, columna);
            }
        }

        public void ejecutarProduccionA(String lexema, String tipo, int fila, int columna)
        {
            if (tipo.Equals("id"))
            {
                arbol += "A" + numeroNodo + "-> \"ID" + numeroNodo + "\"; \n";
                arbol += "A" + numeroNodo + "-> \"=" + numeroNodo + "\"; \n";
                arbol += "A" + numeroNodo + "-> \"numero" + numeroNodo + "\"; \n";
                arbol += "A" + numeroNodo + "-> \"HASTA" + numeroNodo + "\"; \n";
                arbol += "A" + numeroNodo + "-> \"ID1" + numeroNodo + "\"; \n";
                arbol += "A" + numeroNodo + "-> \"signo" + numeroNodo + "\"; \n";
                arbol += "A" + numeroNodo + "-> \"numero1" + numeroNodo + "\"; \n";
                arbol += "A" + numeroNodo + "-> \"INCREMENTO" + numeroNodo + "\"; \n";
                arbol += "A" + numeroNodo + "-> \"ID2" + numeroNodo + "\"; \n";
                arbol += "A" + numeroNodo + "-> \"numero3" + numeroNodo + "\"; \n";
                arbol += "A" + numeroNodo + "-> \"{" + numeroNodo + "\"; \n";
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
            }
            else
            {
                errorLexema = true;
                imprimirError(lexema, tipo, fila, columna);
            }
        }

        public void ejecutarProduccionB(String lexema, String tipo, int fila, int columna)
        {
            if (lexema.Equals("}"))
            {
                arbol += "B" + numeroNodo + "-> \"}" + numeroNodo + "\"; \n";
                arbol += "B" + numeroNodo + "-> \"MIENTRAS" + numeroNodo + "\"; \n";
                arbol += "B" + numeroNodo + "-> \"(" + numeroNodo + "\"; \n";
                arbol += "B" + numeroNodo + "-> \"K" + numeroNodo + "\"; \n";
                arbol += "B" + numeroNodo + "-> \")" + numeroNodo + "\"; \n";
                arbol += "B" + numeroNodo + "-> \";" + numeroNodo + "\"; \n";
                pila.EliminarNodo();
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
                arbol += "B" + numeroNodo + "-> \"N" + numeroNodo + "\"; \n";
                ejecutarProduccionN(lexema, tipo, fila, columna);
            }
            else
            {
                errorLexema = true;
                imprimirError(lexema, tipo, fila, columna);
            }
        }

        public void ejecutarProduccionC(String lexema, String tipo, int fila, int columna)
        {
            if (lexema.Equals("}"))
            {
                arbol += "C" + numeroNodo + "-> \"}" + numeroNodo + "\"; \n";
                pila.EliminarNodo();
                pila.EliminarNodo();
            }
            else if (lexema.Equals(desde) || lexema.Equals(hacer) || lexema.Equals(mientras)
                || lexema.Equals(si) || lexema.Equals(entero) || lexema.Equals(numDecimal)
                || lexema.Equals(cadena) || lexema.Equals(caracter) || lexema.Equals(escribir) || tipo.Equals("id")
                || lexema.Equals(booleano) || lexema.Equals(leer))
            {
                arbol += "C" + numeroNodo + "-> \"N" + numeroNodo + "\"; \n";
                ejecutarProduccionN(lexema, tipo, fila, columna);
            }
            else
            {
                errorLexema = true;
                imprimirError(lexema, tipo, fila, columna);
            }
        }

        public void ejecutarProduccionF(String lexema, String tipo, int fila, int columna)
        {
            if (lexema.Equals("}"))
            {
                arbol += "F" + numeroNodo + "-> \"}" + numeroNodo + "\"; \n";
                arbol += "F" + numeroNodo + "-> \"FF" + numeroNodo + "\"; \n";
                pila.EliminarNodo();
                pila.InsertarNodo(FF);
            }
            else if (lexema.Equals(desde) || lexema.Equals(hacer) || lexema.Equals(mientras)
                || lexema.Equals(si) || lexema.Equals(entero) || lexema.Equals(numDecimal)
                || lexema.Equals(cadena) || lexema.Equals(caracter) || lexema.Equals(escribir) || tipo.Equals("id")
                || lexema.Equals(booleano) || lexema.Equals(leer))
            {
                arbol += "F" + numeroNodo + "-> \"N" + numeroNodo + "\"; \n";
                ejecutarProduccionN(lexema, tipo, fila, columna);
            }
            else
            {
                errorLexema = true;
                imprimirError(lexema, tipo, fila, columna);
            }
        }

        public void ejecutarProduccionFF(String lexema, String tipo, int fila, int columna)
        {
            if (lexema.Equals(sino) || lexema.Equals(sino_si))
            {;
                arbol += "FF" + numeroNodo + "-> \"H" + numeroNodo + "\"; \n";
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
                arbol += "H" + numeroNodo + "-> \"SINO" + numeroNodo + "\"; \n";
                arbol += "H" + numeroNodo + "-> \"{" + numeroNodo + "\"; \n";
                arbol += "H" + numeroNodo + "-> \"J" + numeroNodo + "\"; \n";
                pila.InsertarNodo(J);
                pila.InsertarNodo("{");
            }
            if (lexema.Equals(sino_si))
            {
                arbol += "H" + numeroNodo + "-> \"SINO_SI" + numeroNodo + "\"; \n";
                arbol += "H" + numeroNodo + "-> \"(" + numeroNodo + "\"; \n";
                arbol += "H" + numeroNodo + "-> \"K" + numeroNodo + "\"; \n";
                arbol += "H" + numeroNodo + "-> \")" + numeroNodo + "\"; \n";
                arbol += "H" + numeroNodo + "-> \"{" + numeroNodo + "\"; \n";
                arbol += "H" + numeroNodo + "-> \"I" + numeroNodo + "\"; \n";
                pila.InsertarNodo(I);
                pila.InsertarNodo("{");
                pila.InsertarNodo(")");
                pila.InsertarNodo(K);
                pila.InsertarNodo("(");
            }
            else
            {
                errorLexema = true;
                imprimirError(lexema, tipo, fila, columna);
            }
        }

        public void ejecutarProduccionI(String lexema, String tipo, int fila, int columna)
        {
            if (lexema.Equals("}"))
            {
                arbol += "I" + numeroNodo + "-> \"}" + numeroNodo + "\"; \n";
                arbol += "I" + numeroNodo + "-> \"FF" + numeroNodo + "\"; \n";
                pila.EliminarNodo();
                pila.EliminarNodo();
                pila.InsertarNodo(FF);
            }
            else if (lexema.Equals(desde) || lexema.Equals(hacer) || lexema.Equals(mientras)
                || lexema.Equals(si) || lexema.Equals(entero) || lexema.Equals(numDecimal)
                || lexema.Equals(cadena) || lexema.Equals(caracter) || lexema.Equals(escribir) || tipo.Equals("id")
                || lexema.Equals(booleano) || lexema.Equals(leer))
            {
                arbol += "I" + numeroNodo + "-> \"N" + numeroNodo + "\"; \n";
                ejecutarProduccionN(lexema, tipo, fila, columna);
            }
            else
            {
                errorLexema = true;
                imprimirError(lexema, tipo, fila, columna);
            }
        }

        public void ejecutarProduccionJ(String lexema, String tipo, int fila, int columna)
        {
            if (lexema.Equals("}"))
            {
                arbol += "J" + numeroNodo + "-> \"}" + numeroNodo + "\"; \n";
                pila.EliminarNodo();
                pila.EliminarNodo();
            }
            else if (lexema.Equals(desde) || lexema.Equals(hacer) || lexema.Equals(mientras)
                || lexema.Equals(si) || lexema.Equals(entero) || lexema.Equals(numDecimal)
                || lexema.Equals(cadena) || lexema.Equals(caracter) || lexema.Equals(escribir) || tipo.Equals("id")
                || lexema.Equals(booleano) || lexema.Equals(leer))
            {
                arbol += "J" + numeroNodo + "-> \"N" + numeroNodo + "\"; \n";
                ejecutarProduccionN(lexema, tipo, fila, columna);
            }
            else
            {
                errorLexema = true;
                imprimirError(lexema, tipo, fila, columna);
            }
        }

        public void ejecutarProduccionL(String lexema, String tipo, int fila, int columna)
        {
            if (tipo.Equals("id"))
            {
                arbol += "L" + numeroNodo + "-> \"ID" + numeroNodo + "\"; \n";
                arbol += "L" + numeroNodo + "-> \"LL" + numeroNodo + "\"; \n";
                pila.EliminarNodo();
                pila.InsertarNodo(LL);
            }
            else
            {
                errorLexema = true;
                imprimirError(lexema, tipo, fila, columna);
            }
        }

        public void ejecutarProduccionLL(String lexema, String tipo, int fila, int columna)
        {
            if (lexema.Equals(",") || lexema.Equals(";"))
            {
                arbol += "LL" + numeroNodo + "-> \"LLL" + numeroNodo + "\"; \n";
                ejecutarProduccionLLL(lexema, tipo, fila, columna);
            }
            else if (lexema.Equals("="))
            {
                arbol += "LL" + numeroNodo + "-> \"=" + numeroNodo + "\"; \n";
                arbol += "LL" + numeroNodo + "-> \"numero" + numeroNodo + "\"; \n";
                arbol += "LL" + numeroNodo + "-> \"LLL" + numeroNodo + "\"; \n";
                pila.EliminarNodo();
                pila.InsertarNodo(LLL);
                pila.InsertarNodo("n");
            }
            else
            {
                errorLexema = true;
                imprimirError(lexema, tipo, fila, columna);
            }
        }

        public void ejecutarProduccionLLL(String lexema, String tipo, int fila, int columna)
        {
            if (lexema.Equals(","))
            {
                arbol += "LLL" + numeroNodo + "-> \"," + numeroNodo + "\"; \n";
                arbol += "LLL" + numeroNodo + "-> \"L" + numeroNodo + "\"; \n";
                pila.EliminarNodo();
                pila.InsertarNodo(L);
            }
            else if (lexema.Equals(";"))
            {
                arbol += "LLL" + numeroNodo + "-> \";" + numeroNodo + "\"; \n";
                pila.EliminarNodo();
            }
            else
            {
                errorLexema = true;
                imprimirError(lexema, tipo, fila, columna);
            }
        }

        public void ejecutarProduccionM(String lexema, String tipo, int fila, int columna)
        {
            if (tipo.Equals("id"))
            {
                arbol += "M" + numeroNodo + "-> \"ID" + numeroNodo + "\"; \n";
                arbol += "M" + numeroNodo + "-> \"MM" + numeroNodo + "\"; \n";
                pila.EliminarNodo();
                pila.InsertarNodo(MM);
            }
            else
            {
                errorLexema = true;
                imprimirError(lexema, tipo, fila, columna);
            }
        }

        public void ejecutarProduccionMM(String lexema, String tipo, int fila, int columna)
        {
            if (lexema.Equals(",") || lexema.Equals(";"))
            {
                arbol += "MM" + numeroNodo + "-> \"MMM" + numeroNodo + "\"; \n";
                ejecutarProduccionMMM(lexema, tipo, fila, columna);
            }
            else if (lexema.Equals("="))
            {
                arbol += "MM" + numeroNodo + "-> \"=" + numeroNodo + "\"; \n";
                arbol += "MM" + numeroNodo + "-> \"numdecimal" + numeroNodo + "\"; \n";
                arbol += "MM" + numeroNodo + "-> \"MMM" + numeroNodo + "\"; \n";
                pila.EliminarNodo();
                pila.InsertarNodo(MMM);
                pila.InsertarNodo("np");
            }
            else
            {
                errorLexema = true;
                imprimirError(lexema, tipo, fila, columna);
            }
        }

        public void ejecutarProduccionMMM(String lexema, String tipo, int fila, int columna)
        {
            if (lexema.Equals(","))
            {
                arbol += "MMM" + numeroNodo + "-> \"," + numeroNodo + "\"; \n";
                arbol += "MMM" + numeroNodo + "-> \"M" + numeroNodo + "\"; \n";
                pila.EliminarNodo();
                pila.InsertarNodo(M);
            }
            else if (lexema.Equals(";"))
            {
                arbol += "MMMM" + numeroNodo + "-> \";" + numeroNodo + "\"; \n";
                pila.EliminarNodo();
            }
            else
            {
                errorLexema = true;
                imprimirError(lexema, tipo, fila, columna);
            }
        }

        public void ejecutarProduccionU(String lexema, String tipo, int fila, int columna)
        {
            if (tipo.Equals("id"))
            {
                arbol += "U" + numeroNodo + "-> \"ID" + numeroNodo + "\"; \n";
                arbol += "U" + numeroNodo + "-> \"UU" + numeroNodo + "\"; \n";
                pila.EliminarNodo();
                pila.InsertarNodo(UU);
            }
            else
            {
                errorLexema = true;
                imprimirError(lexema, tipo, fila, columna);
            }
        }

        public void ejecutarProduccionUU(String lexema, String tipo, int fila, int columna)
        {
            if (lexema.Equals(",") || lexema.Equals(";"))
            {
                arbol += "UU" + numeroNodo + "-> \"UUU" + numeroNodo + "\"; \n";
                ejecutarProduccionUUU(lexema, tipo, fila, columna);
            }
            else if (lexema.Equals("="))
            {
                arbol += "UU" + numeroNodo + "-> \"=" + numeroNodo + "\"; \n";
                arbol += "UU" + numeroNodo + "-> \"texto" + numeroNodo + "\"; \n";
                arbol += "UU" + numeroNodo + "-> \"UUU" + numeroNodo + "\"; \n";
                pila.EliminarNodo();
                pila.InsertarNodo(UUU);
                pila.InsertarNodo("ct");
            }
            else
            {
                errorLexema = true;
                imprimirError(lexema, tipo, fila, columna);
            }
        }

        public void ejecutarProduccionUUU(String lexema, String tipo, int fila, int columna)
        {
            if (lexema.Equals(","))
            {
                arbol += "UUU-> \",\"; \n";
                arbol += "UUU-> \"U\"; \n";
                pila.EliminarNodo();
                pila.InsertarNodo(U);
            }
            else if (lexema.Equals(";"))
            {
                arbol += "UUU-> \";\"; \n";
                pila.EliminarNodo();
            }
            else
            {
                errorLexema = true;
                imprimirError(lexema, tipo, fila, columna);
            }
        }

        public void ejecutarProduccionP(String lexema, String tipo, int fila, int columna)
        {
            if (tipo.Equals("id"))
            {
                arbol += "P-> \"ID\"; \n";
                arbol += "P-> \"PP\"; \n";
                pila.EliminarNodo();
                pila.InsertarNodo(PP);
            }
            else
            {
                errorLexema = true;
                imprimirError(lexema, tipo, fila, columna);
            }
        }

        public void ejecutarProduccionPP(String lexema, String tipo, int fila, int columna)
        {
            if (lexema.Equals(",") || lexema.Equals(";"))
            {
                arbol += "PP-> \"PPP\"; \n";
                ejecutarProduccionPPP(lexema, tipo, fila, columna);
            }
            else if (lexema.Equals("="))
            {
                arbol += "PP-> \"=\"; \n";
                arbol += "PP-> \"char\"; \n";
                arbol += "PP-> \"PPP\"; \n";
                pila.EliminarNodo();
                pila.InsertarNodo(PPP);
                pila.InsertarNodo("ac");
            }
            else
            {
                errorLexema = true;
                imprimirError(lexema, tipo, fila, columna);
            }
        }

        public void ejecutarProduccionPPP(String lexema, String tipo, int fila, int columna)
        {
            if (lexema.Equals(","))
            {
                arbol += "PPP-> \",\"; \n";
                arbol += "PPP-> \"P\"; \n";
                pila.EliminarNodo();
                pila.InsertarNodo(P);
            }
            else if (lexema.Equals(";"))
            {
                arbol += "PPP-> \";\"; \n";
                pila.EliminarNodo();
            }
            else
            {
                errorLexema = true;
                imprimirError(lexema, tipo, fila, columna);
            }
        }

        public void ejecutarProduccionQ(String lexema, String tipo, int fila, int columna)
        {
            if (tipo.Equals("id"))
            {
                arbol += "Q-> \"ID\"; \n";
                arbol += "Q-> \"QQ\"; \n";
                pila.EliminarNodo();
                pila.InsertarNodo(QQ);
            }
            else
            {
                errorLexema = true;
                imprimirError(lexema, tipo, fila, columna);
            }
        }

        public void ejecutarProduccionQQ(String lexema, String tipo, int fila, int columna)
        {
            if (lexema.Equals(",") || lexema.Equals(";"))
            {
                arbol += "QQ-> \"QQQ\"; \n";
                ejecutarProduccionQQQ(lexema, tipo, fila, columna);
            }
            else if (lexema.Equals("="))
            {
                arbol += "QQ-> \"=\"; \n";
                arbol += "QQ-> \"V\"; \n";
                arbol += "QQ-> \"QQQ\"; \n";
                pila.EliminarNodo();
                pila.InsertarNodo(QQQ);
                pila.InsertarNodo(V);
            }
            else
            {
                errorLexema = true;
                imprimirError(lexema, tipo, fila, columna);
            }
        }

        public void ejecutarProduccionQQQ(String lexema, String tipo, int fila, int columna)
        {
            if (lexema.Equals(","))
            {
                arbol += "QQQ-> \",\"; \n";
                arbol += "QQQ-> \"Q\"; \n";
                pila.EliminarNodo();
                pila.InsertarNodo(Q);
            }
            else if (lexema.Equals(";"))
            {
                arbol += "QQQ-> \";\"; \n";
                pila.EliminarNodo();
            }
            else
            {
                errorLexema = true;
                imprimirError(lexema, tipo, fila, columna);
            }
        }

        public void ejecutarProduccionV(String lexema, String tipo, int fila, int columna)
        {
            if (lexema.Equals(verdadero) || lexema.Equals(falso))
            {
                arbol += "V-> \""+ lexema+"\"; \n";
                pila.EliminarNodo();
            }
            else
            {
                errorLexema = true;
                imprimirError(lexema, tipo, fila, columna);
            }
        }

        public void ejecutarProduccionS(String lexema, String tipo, int fila, int columna)
        {
            if (lexema.Equals("("))
            {
                arbol += "S-> \"(\"; \n";
                arbol += "S-> \"ID\"; \n";
                arbol += "S-> \")\"; \n";
                arbol += "S-> \";\"; \n";
                pila.EliminarNodo();
                pila.InsertarNodo(";");
                pila.InsertarNodo(")");
                pila.InsertarNodo("id");
            }
            else
            {
                errorLexema = true;
                imprimirError(lexema, tipo, fila, columna);
            }
        }

        public void ejecutarProduccionT(String lexema, String tipo, int fila, int columna)
        {
            if (lexema.Equals("("))
            {
                arbol += "T-> \"(\"; \n";
                arbol += "T-> \"TT\"; \n";
                arbol += "T-> \"W\"; \n";
                arbol += "T-> \")\"; \n";
                arbol += "T-> \";\"; \n";
                pila.EliminarNodo();
                pila.InsertarNodo(";");
                pila.InsertarNodo(")");
                pila.InsertarNodo(W);
                pila.InsertarNodo(TT);
            }
            else
            {
                errorLexema = true;
                imprimirError(lexema, tipo, fila, columna);
            }
        }

        public void ejecutarProduccionTT(String lexema, String tipo, int fila, int columna)
        {
            if (tipo.Equals("id") || tipo.Equals("n") || tipo.Equals("ct"))
            {
                arbol += "TT-> \""+lexema+"\"; \n";
                pila.EliminarNodo();
            }
            else
            {
                errorLexema = true;
                imprimirError(lexema, tipo, fila, columna);
            }
        }

        public void ejecutarProduccionW(String lexema, String tipo, int fila, int columna)
        {
            if (lexema.Equals(")"))
            {
                arbol += "W-> \")\"; \n";
                pila.EliminarNodo();
                pila.EliminarNodo();
            }
            else if (lexema.Equals("+"))
            {
                arbol += "W-> \"+\"; \n";
                arbol += "W-> \"TT\"; \n";
                pila.InsertarNodo(TT);
            }
            else
            {
                errorLexema = true;
                imprimirError(lexema, tipo, fila, columna);
            }
        }

        public void ejecutarProduccionO(String lexema, String tipo, int fila, int columna)
        {
            if (tipo.Equals("id"))
            {
                arbol += "O-> \"ID\"; \n";
                arbol += "O-> \"OO\"; \n";
                pila.EliminarNodo();
                pila.InsertarNodo(OO);
            }
            else
            {
                errorLexema = true;
                imprimirError(lexema, tipo, fila, columna);
            }
        }

        public void ejecutarProduccionOO(String lexema, String tipo, int fila, int columna)
        {
            if (lexema.Equals("-"))
            {
                arbol += "OO-> \"--\"; \n";
                arbol += "OO-> \";\"; \n";
                pila.EliminarNodo();
                pila.InsertarNodo(";");
                pila.InsertarNodo("-");
            }
            else if (lexema.Equals("+"))
            {
                arbol += "OO-> \"++\"; \n";
                arbol += "OO-> \";\"; \n";
                pila.EliminarNodo();
                pila.InsertarNodo(";");
                pila.InsertarNodo("+");
            }
            else if (lexema.Equals("="))
            {
                arbol += "OO-> \"=\"; \n";
                arbol += "OO-> \"Z\"; \n";
                pila.EliminarNodo();
                pila.InsertarNodo(Z);
            }
            else
            {
                errorLexema = true;
                imprimirError(lexema, tipo, fila, columna);
            }
        }

        public void ejecutarProduccionZ(String lexema, String tipo, int fila, int columna)
        {
            if (tipo.Equals("id") || tipo.Equals("n") || tipo.Equals("np") || tipo.Equals("ct")
                || tipo.Equals("ac"))
            {
                arbol += "Z-> \""+lexema+"\"; \n";
                arbol += "Z-> \"X\"; \n";
                pila.EliminarNodo();
                pila.InsertarNodo(X);

            }
            else if (lexema.Equals(verdadero) || lexema.Equals(falso))
            {
                arbol += "Z-> \""+lexema+"\"; \n";
                arbol += "Z-> \";\"; \n";
                pila.EliminarNodo();
                pila.InsertarNodo(";");
            }
            else
            {
                errorLexema = true;
                imprimirError(lexema, tipo, fila, columna);
            }
        }

        public void ejecutarProduccionX(String lexema, String tipo, int fila, int columna)
        {
            if (tipo.Equals("s"))
            {
                arbol += "X-> \""+lexema+"\"; \n";
                arbol += "X-> \"Z\"; \n";
                pila.EliminarNodo();
                pila.InsertarNodo(Z);

            }
            else if (lexema.Equals(";"))
            {
                arbol += "X-> \";\"; \n";
                pila.EliminarNodo();
            }
            else
            {
                errorLexema = true;
                imprimirError(lexema, tipo, fila, columna);
            }
        }

        public void ejecutarProduccionK(String lexema, String tipo, int fila, int columna)
        {
            if (tipo.Equals("id"))
            {
                arbol += "K" + numeroNodo + "-> \"ID" + numeroNodo + "\"; \n";
                arbol += "K" + numeroNodo + "-> \"signo1" + numeroNodo + "\"; \n";
                arbol += "K" + numeroNodo + "-> \"KK" + numeroNodo + "\"; \n";
                arbol += "K" + numeroNodo + "-> \"G" + numeroNodo + "\"; \n";
                pila.EliminarNodo();
                pila.InsertarNodo(G);
                pila.InsertarNodo(KK);
                pila.InsertarNodo("s");
            }
            else if (lexema.Equals("!"))
            {
                arbol += "K" + numeroNodo + "-> \"!" + numeroNodo + "\"; \n";
                arbol += "K" + numeroNodo + "-> \"Y" + numeroNodo + "\"; \n";
                arbol += "K" + numeroNodo + "-> \"GG" + numeroNodo + "\"; \n";
                pila.EliminarNodo();
                pila.InsertarNodo(GG);
                pila.InsertarNodo(Y);
            }
            else
            {
                errorLexema = true;
                imprimirError(lexema, tipo, fila, columna);
            }
        }

        public void ejecutarProduccionKK(String lexema, String tipo, int fila, int columna)
        {
            if (tipo.Equals("s"))
            {
                arbol += "KK" + numeroNodo + "-> \"" + lexema+ "" + numeroNodo + "\"; \n";
                pila.EliminarNodo();
            }
            else 
            {
                arbol += "KK" + numeroNodo + "-> \"G" + numeroNodo + "\"; \n";
                pila.EliminarNodo();
                ejecutarProduccionG(lexema, tipo, fila, columna);
            }
        }

        public void ejecutarProduccionG(String lexema, String tipo, int fila, int columna)
        {
            if (tipo.Equals("id") || tipo.Equals("n"))
            {
                arbol += "G" + numeroNodo + "-> \"" + lexema+ "" + numeroNodo + "\"; \n";
                arbol += "G" + numeroNodo + "-> \"GG" + numeroNodo + "\"; \n";
                pila.EliminarNodo();
                pila.InsertarNodo(GG);
            }
            else
            {
                errorLexema = true;
                imprimirError(lexema, tipo, fila, columna);
            }
        }

        public void ejecutarProduccionGG(String lexema, String tipo, int fila, int columna)
        {
            if (lexema.Equals("&"))
            {
                arbol += "GG" + numeroNodo + "-> \"&&" + numeroNodo + "\"; \n";
                arbol += "GG" + numeroNodo + "-> \"K" + numeroNodo + "\"; \n";
                pila.EliminarNodo();
                pila.InsertarNodo(K);
                pila.InsertarNodo("&");
            }
            else if (lexema.Equals("|"))
            {
                arbol += "GG" + numeroNodo + "-> \"||" + numeroNodo + "\"; \n";
                arbol += "GG" + numeroNodo + "-> \"K" + numeroNodo + "\"; \n";
                pila.EliminarNodo();
                pila.InsertarNodo(K);
                pila.InsertarNodo("|");
            }
            else if (lexema.Equals(")"))
            {
                arbol += "GG" + numeroNodo + "-> \")" + numeroNodo + "\"; \n";
                pila.EliminarNodo();
                pila.EliminarNodo();
            }
            else
            {
                errorLexema = true;
                imprimirError(lexema, tipo, fila, columna);
            }
        }

        public void ejecutarProduccionY(String lexema, String tipo, int fila, int columna)
        {
            if (lexema.Equals("!"))
            {
                arbol += "Y-> \"!\"; \n";
                arbol += "Y-> \"Y\"; \n";
                pila.EliminarNodo();
                pila.InsertarNodo(Y);
            }
            else if (lexema.Equals(verdadero) || lexema.Equals(falso))
            {
                arbol += "Y-> \""+lexema+"\"; \n";
                pila.EliminarNodo();
            }
            else
            {
                errorLexema = true;
                imprimirError(lexema, tipo, fila, columna);
            }
        }

        public void imprimirError(String lexema, String tipo, int fila, int columna)
        {
            rtbError.AppendText("error: no se esperaba el lexema: " + lexema + " de tipo " + tipo
                    + " en fila: " + fila + " columna: " + columna + "\n");
        }
    }
}
