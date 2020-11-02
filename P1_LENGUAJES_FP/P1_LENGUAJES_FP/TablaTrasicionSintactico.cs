using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;
using System.Windows.Forms;

namespace P1_LENGUAJES_FP
{
    class TablaTrasicionSintactico : AnalizadorSintactico
    {
        
        public TablaTrasicionSintactico()
        {
            
        }

        public void ejecutarProduccionE(String lexema, String tipo, int fila, int columna)
        {
            try {
                if (lexema.Equals(principal))
                {
                    arbol += "E-> \"N2\"; \n";
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
               // String nodoN = (numNodo - 1).ToString();
                arbol += "N2 -> \"}" + (numNodo+2) + "\"; \n";
                pila.EliminarNodo();
            }
            else if (lexema.Equals(desde) || lexema.Equals(hacer) || lexema.Equals(mientras)
                || lexema.Equals(si))
            {
                numNodo++;
                String nuevoNodo = (numNodo+1).ToString();
                String nodoN = (numNodo - 1).ToString();
                arbol += "N" + nodoN + "-> \"D" + nuevoNodo + "\"; \n";
                arbol += "N" + nodoN + "-> \"N" + nuevoNodo + "\"; \n";
                numeroNodo = nuevoNodo;
                pila.InsertarNodo(N);
                ejecutarProduccionD(lexema, tipo, fila, columna);
            }
            else if(lexema.Equals(entero) || lexema.Equals(numDecimal)
                || lexema.Equals(cadena) || lexema.Equals(caracter) || lexema.Equals(escribir)
                || lexema.Equals(booleano) || lexema.Equals(leer))
            {
                numNodo++;
                String nuevoNodo = (numNodo).ToString();
                String nodoN = (numNodo - 1).ToString();
                numeroNodo = nuevoNodo;
                arbol += "N" + nodoN + "-> \"R" + numeroNodo + "\"; \n";
                arbol += "N" + nodoN + "-> \"N" + (nuevoNodo) + "\"; \n";
                ejecutarProduccionR(lexema, tipo, fila, columna);
                
            } 
            else if (tipo.Equals("id"))
            {
                numNodo++;
                String nuevoNodo = numNodo.ToString();
                String nodoN = (numNodo - 1).ToString();
                numeroNodo = nuevoNodo;
                arbol += "N" + nodoN + "-> \"O" + numeroNodo + "\"; \n";
                arbol += "N" + nodoN + "-> \"N" + (nuevoNodo) + "\"; \n";
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
                arbol += "D" + numeroNodo + "-> \"K" + useSino + "\"; \n";
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
                arbol += "D" + numeroNodo + "-> \"K" + useSino + "\"; \n";
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
                arbol += "R" + numeroNodo + "-> \"entero" + nodoReservado + "\"; \n";
                arbol += "R" + numeroNodo + "-> \"L" + nodoReservado + "\"; \n";
                pila.InsertarNodo(L);
            }
            else if (lexema.Equals(numDecimal))
            {
                arbol += "R" + numeroNodo + "-> \"decimal" + nodoReservado + "\"; \n";
                arbol += "R" + numeroNodo + "-> \"M" + nodoReservado + "\"; \n";
                pila.InsertarNodo(M);
            }
            else if (lexema.Equals(cadena))
            {
                arbol += "R" + numeroNodo + "-> \"cadena" + nodoReservado + "\"; \n";
                arbol += "R" + numeroNodo + "-> \"U" + nodoReservado + "\"; \n";
                pila.InsertarNodo(U);
            }
            else if (lexema.Equals(booleano))
            {
                arbol += "R" + numeroNodo + "-> \"booleano" + nodoReservado + "\"; \n";
                arbol += "R" + numeroNodo + "-> \"Q" + nodoReservado + "\"; \n";
                pila.InsertarNodo(Q);
            }
            else if (lexema.Equals(caracter))
            {
                arbol += "R" + numeroNodo + "-> \"caracter" + nodoReservado + "\"; \n";
                arbol += "R" + numeroNodo + "-> \"P" + nodoReservado + "\"; \n";
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
                arbol += "R" + numeroNodo + "-> \"escribir" + numeroNodo + "\"; \n";
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
                arbol += "A" + numeroNodo + "-> \"ID"  + nodoId + "\"; \n";
                nodoId++;
                arbol += "A" + numeroNodo + "-> \"=" + numeroNodo + "\"; \n";
                arbol += "A" + numeroNodo + "-> \"numero" + numeroNodo + "\"; \n";
                arbol += "A" + numeroNodo + "-> \"HASTA" + numeroNodo + "\"; \n";
                nodoId++;
                arbol += "A" + numeroNodo + "-> \"ID" + nodoId + "\"; \n";
                arbol += "A" + numeroNodo + "-> \"signo" + nodoId + "\"; \n";
                arbol += "A" + numeroNodo + "-> \"numero1" + numeroNodo + "\"; \n";
                arbol += "A" + numeroNodo + "-> \"INCREMENTO" + numeroNodo + "\"; \n";
                //nodoId++;
                //arbol += "A" + numeroNodo + "-> \"ID" + nodoId + "\"; \n";
                arbol += "A" + numeroNodo + "-> \"numero3" + numeroNodo + "\"; \n";
                arbol += "A" + numeroNodo + "-> \"{" + numeroNodo + "\"; \n";
                nodoId++;
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
                arbol += "B" + numeroNodo + "-> \"K" + useSino + "\"; \n";
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
                arbol += "C" + (numNodo) + "-> \"}" + nodoId + "\"; \n";
                numNodo++;
                nodoId++;
                pila.EliminarNodo();
                pila.EliminarNodo();
            }
            else if (lexema.Equals(desde) || lexema.Equals(hacer) || lexema.Equals(mientras)
                || lexema.Equals(si) || lexema.Equals(entero) || lexema.Equals(numDecimal)
                || lexema.Equals(cadena) || lexema.Equals(caracter) || lexema.Equals(escribir) || tipo.Equals("id")
                || lexema.Equals(booleano) || lexema.Equals(leer))
            {
                int num = numNodo;
                String nuevoN = num.ToString();
                arbol += "C" + numeroNodo + "-> \"N" + nuevoN + "\"; \n";
               // numNodo++;
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
                arbol += "F" + numeroNodo + "-> \"}" + nodoId + "\"; \n";
                arbol += "F" + numeroNodo + "-> \"FF" + numeroNodo + "\"; \n";
                numNodo++;
                nodoId++;
                //pila.EliminarNodo();
                pila.EliminarNodo();
                pila.EliminarNodo();
                pila.InsertarNodo(FF);
            }
            else if (lexema.Equals(desde) || lexema.Equals(hacer) || lexema.Equals(mientras)
                || lexema.Equals(si) || lexema.Equals(entero) || lexema.Equals(numDecimal)
                || lexema.Equals(cadena) || lexema.Equals(caracter) || lexema.Equals(escribir) || tipo.Equals("id")
                || lexema.Equals(booleano) || lexema.Equals(leer))
            {
               // pila.EliminarNodo();
                int num = numNodo;
                String nuevoN = num.ToString();              
                arbol += "F" + numeroNodo + "-> \"N" + nuevoN + "\"; \n";
               // numNodo++;
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
            {
                arbol += "FF" + numeroNodo + "-> \"H" + numeroNodo + "\"; \n";
                pila.EliminarNodo();
                ejecutarProduccionH(lexema, tipo, fila, columna);
            }
            else 
            {
                pila.EliminarNodo();
               // pila.EliminarNodo();
                //pila.EliminarNodo();
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
             else if (lexema.Equals(sino_si))
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
                //pila.EliminarNodo();
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
                //pila.EliminarNodo();
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
                arbol += "L" + nodoReservado + "-> \"ID" + nodoId + "\"; \n";
                arbol += "L" + nodoReservado + "-> \"LL" + nodoReservado + "\"; \n";
                nodoId++;
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
                arbol += "LL" + nodoReservado + "-> \"LLL" + nodoReservado + "\"; \n";
                ejecutarProduccionLLL(lexema, tipo, fila, columna);
            }
            else if (lexema.Equals("="))
            {
                arbol += "LL" + nodoReservado + "-> \"=" + nodoReservado + "\"; \n";
                arbol += "LL" + nodoReservado + "-> \"numero" + nodoReservado + "\"; \n";
                arbol += "LL" + nodoReservado + "-> \"LLL" + nodoReservado + "\"; \n";
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
                arbol += "LLL" + nodoReservado + "-> \"," + nodoReservado + "\"; \n";
                arbol += "LLL" + nodoReservado + "-> \"L" + (nodoReservado+1) + "\"; \n";
                nodoReservado++;
                pila.EliminarNodo();
                pila.InsertarNodo(L);
            }
            else if (lexema.Equals(";"))
            {
                arbol += "LLL" + nodoReservado + "-> \";" + nodoReservado + "\"; \n";
                pila.EliminarNodo();
                nodoReservado++;
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
                arbol += "M" + nodoReservado + "-> \"ID" + nodoId + "\"; \n";
                arbol += "M" + nodoReservado + "-> \"MM" + nodoReservado + "\"; \n";
                nodoId++;
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
                arbol += "MM" + nodoReservado + "-> \"MMM" + nodoReservado + "\"; \n";
                ejecutarProduccionMMM(lexema, tipo, fila, columna);
            }
            else if (lexema.Equals("="))
            {
                arbol += "MM" + nodoReservado + "-> \"=" + nodoReservado + "\"; \n";
                arbol += "MM" + nodoReservado + "-> \"numdecimal" + nodoReservado + "\"; \n";
                arbol += "MM" + nodoReservado + "-> \"MMM" + nodoReservado + "\"; \n";
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
                arbol += "MMM" + nodoReservado + "-> \"," + nodoReservado + "\"; \n";
                arbol += "MMM" + nodoReservado + "-> \"M" + (nodoReservado + 1) + "\"; \n";
                nodoReservado++;
                pila.EliminarNodo();
                pila.InsertarNodo(M);
            }
            else if (lexema.Equals(";"))
            {
                arbol += "MMM" + nodoReservado + "-> \";" + nodoReservado + "\"; \n";
                nodoReservado++;
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
                arbol += "U" + nodoReservado + "-> \"ID" + nodoId + "\"; \n";
                arbol += "U" + nodoReservado + "-> \"UU" + nodoReservado + "\"; \n";
                nodoId++;
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
                arbol += "UU" + nodoReservado + "-> \"UUU" + nodoReservado + "\"; \n";
                ejecutarProduccionUUU(lexema, tipo, fila, columna);
            }
            else if (lexema.Equals("="))
            {
                arbol += "UU" + nodoReservado + "-> \"=" + nodoReservado + "\"; \n";
                arbol += "UU" + nodoReservado + "-> \"texto" + nodoReservado + "\"; \n";
                arbol += "UU" + nodoReservado + "-> \"UUU" + nodoReservado + "\"; \n";
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
                arbol += "UUU" + nodoReservado + "-> \"," + nodoReservado + "\"; \n";
                arbol += "UUU" + nodoReservado + "-> \"U" + (nodoReservado + 1) + "\"; \n";
                nodoReservado++;
                pila.EliminarNodo();
                pila.InsertarNodo(U);
            }
            else if (lexema.Equals(";"))
            {
                arbol += "UUU" + nodoReservado + "-> \";" + nodoReservado + "\"; \n";
                nodoReservado++;
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
                arbol += "P" + nodoReservado + "-> \"ID" + nodoId + "\"; \n";
                arbol += "P" + nodoReservado + "-> \"PP" + nodoReservado + "\"; \n";
                nodoId++;
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
                arbol += "PP" + nodoReservado + "-> \"PPP" + nodoReservado + "\"; \n";
                ejecutarProduccionPPP(lexema, tipo, fila, columna);
            }
            else if (lexema.Equals("="))
            {
                arbol += "PP" + nodoReservado + "-> \"=" + nodoReservado + "\"; \n";
                arbol += "PP" + nodoReservado + "-> \"char" + nodoReservado + "\"; \n";
                arbol += "PP" + nodoReservado + "-> \"PPP" + nodoReservado + "\"; \n";
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
                arbol += "PPP" + nodoReservado + "-> \"," + nodoReservado + "\"; \n";
                arbol += "PPP" + nodoReservado + "-> \"P" + (nodoReservado + 1) + "\"; \n";
                nodoReservado++;
                pila.EliminarNodo();
                pila.InsertarNodo(P);
            }
            else if (lexema.Equals(";"))
            {
                arbol += "PPP" + numeroNodo + "-> \";" + nodoReservado + "\"; \n";
                nodoReservado++;
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
                arbol += "Q" + nodoReservado + "-> \"ID" + nodoId + "\"; \n";
                arbol += "Q" + nodoReservado + "-> \"QQ" + nodoReservado + "\"; \n";
                nodoId++;
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
                arbol += "QQ" + nodoReservado + "-> \"QQQ" + nodoReservado + "\"; \n";
                ejecutarProduccionQQQ(lexema, tipo, fila, columna);
            }
            else if (lexema.Equals("="))
            {
                arbol += "QQ" + nodoReservado + "-> \"=" + nodoReservado + "\"; \n";
                arbol += "QQ" + nodoReservado + "-> \"V" + numeroNodo + "\"; \n";
                arbol += "QQ" + nodoReservado + "-> \"QQQ" + nodoReservado + "\"; \n";
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
                arbol += "QQQ" + nodoReservado + "-> \"," + nodoReservado + "\"; \n";
                arbol += "QQQ" + nodoReservado + "-> \"Q" + (nodoReservado + 1) + "\"; \n";
                nodoReservado++;
                pila.EliminarNodo();
                pila.InsertarNodo(Q);
            }
            else if (lexema.Equals(";"))
            {
                arbol += "QQQ" + numeroNodo + "-> \";" + nodoReservado + "\"; \n";
                nodoReservado++;
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
                arbol += "V" + numeroNodo + "-> \"" + lexema + nodoId + "\"; \n";
                nodoId++;
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
                arbol += "S" + numeroNodo + "-> \"(" + numeroNodo + "\"; \n";
                arbol += "S" + numeroNodo + "-> \"ID" + nodoId + "\"; \n";
                arbol += "S" + numeroNodo + "-> \")" + numeroNodo + "\"; \n";
                arbol += "S" + numeroNodo + "-> \";" + numeroNodo + "\"; \n";
                nodoId++;
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
                arbol += "T" + numeroNodo + "-> \"(" + numeroNodo + "\"; \n";
                //arbol += "T" + numeroNodo + "-> \"TT" + numeroNodo + "\"; \n";
                arbol += "T" + numeroNodo + "-> \"W" + numeroNodo + "\"; \n";
                arbol += "T" + numeroNodo + "-> \")" + numeroNodo + "\"; \n";
                arbol += "T" + numeroNodo + "-> \";" + numeroNodo + "\"; \n";
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
                arbol += "W" + numeroNodo + "-> \"TT" + nodoId + "\"; \n";
                arbol += "TT" + nodoId + "-> \"" + tipo + nodoId + "\"; \n";
                nodoId++;
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
                //arbol += "W" + numeroNodo + "-> \")" + numeroNodo + "\"; \n";
                pila.EliminarNodo();
                pila.EliminarNodo();
            }
            else if (lexema.Equals("+"))
            {
                arbol += "W" + numeroNodo + "-> \"+" + nodoId + "\"; \n";
                //arbol += "W" + numeroNodo + "-> \"TT" + numeroNodo + "\"; \n";
                nodoId++;
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
                arbol += "O" + numeroNodo + "-> \"ID" + nodoId + "\"; \n";
                arbol += "O" + numeroNodo + "-> \"OO" + numeroNodo + "\"; \n";
                nodoId++;
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
                arbol += "OO" + numeroNodo + "-> \"--" + numeroNodo + "\"; \n";
                arbol += "OO" + numeroNodo + "-> \";" + numeroNodo + "\"; \n";
                pila.EliminarNodo();
                pila.InsertarNodo(";");
                pila.InsertarNodo("-");
            }
            else if (lexema.Equals("+"))
            {
                arbol += "OO" + numeroNodo + "-> \"++" + numeroNodo + "\"; \n";
                arbol += "OO" + numeroNodo + "-> \";" + numeroNodo + "\"; \n";
                pila.EliminarNodo();
                pila.InsertarNodo(";");
                pila.InsertarNodo("+");
            }
            else if (lexema.Equals("="))
            {
                arbol += "OO" + numeroNodo + "-> \"=" + nodoId + "\"; \n";
                arbol += "OO" + numeroNodo + "-> \"Z" + nodoId + "\"; \n";
                //nodoId++;
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
                arbol += "Z" + (nodoId) + "-> \"" + tipo + nodoId + "\"; \n";
                arbol += "Z" + (nodoId) + "-> \"X" + nodoId + "\"; \n";
                //nodoId++;
                pila.EliminarNodo();
                pila.InsertarNodo(X);

            }
            else if (lexema.Equals(verdadero) || lexema.Equals(falso))
            {
                arbol += "Z" + nodoId + "-> \"" + lexema + nodoId + "\"; \n";
                arbol += "Z" + nodoId + "-> \";" + numeroNodo + "\"; \n";
                nodoId++;
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
            if (lexema.Equals(";"))
                {
                    arbol += "X" + nodoId + "-> \";" + nodoId + "\"; \n";
                nodoId++;
                    pila.EliminarNodo();
                } 
            else if (tipo.Equals("s"))
            {
                arbol += "X" + nodoId + "-> \"" + lexema + nodoId + "\"; \n";
                arbol += "X" + nodoId + "-> \"Z" + (nodoId+1) + "\"; \n";
                nodoId++;
                pila.EliminarNodo();
                pila.InsertarNodo(Z);

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
                arbol += "K" + useSino + "-> \"ID" + nodoId + "\"; \n";
                arbol += "K" + useSino + "-> \"signo0" + useSino + "\"; \n";
                arbol += "K" + useSino + "-> \"KK" + useSino + "\"; \n";
                arbol += "K" + useSino + "-> \"G" + useSino + "\"; \n";
                nodoId++;
                pila.EliminarNodo();
                pila.InsertarNodo(G);
                pila.InsertarNodo(KK);
                pila.InsertarNodo("s");
            }
            else if (lexema.Equals("!"))
            {
                arbol += "K" + useSino + "-> \"!" + 0 + "\"; \n";
                arbol += "K" + useSino + "-> \"Y" + nodoId + "\"; \n";
                arbol += "K" + useSino + "-> \"GG" + useSino + "\"; \n";
                pila.EliminarNodo();
                pila.InsertarNodo(GG);
                pila.InsertarNodo(Y);
            }
            else if (lexema.Equals(verdadero) || lexema.Equals(falso))
            {
                arbol += "K" + useSino + "-> \"" + lexema + nodoId + "\"; \n";
                arbol += "K" + useSino + "-> \"GG" + useSino + "\"; \n";
                nodoId++;
                pila.EliminarNodo();
                pila.InsertarNodo(GG);
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
                arbol += "KK" + useSino + "-> \"" + lexema+ "" + useSino + "\"; \n";
                pila.EliminarNodo();
            }
            else 
            {
                //arbol += "KK" + numeroNodo + "-> \"G" + numeroNodo + "\"; \n";
                pila.EliminarNodo();
                ejecutarProduccionG(lexema, tipo, fila, columna);
            }
        }

        public void ejecutarProduccionG(String lexema, String tipo, int fila, int columna)
        {
            if (tipo.Equals("id") || tipo.Equals("n"))
            {
                arbol += "G" + useSino + "-> \"" + tipo + nodoId + "\"; \n";
                arbol += "G" + useSino + "-> \"GG" + useSino + "\"; \n";
                nodoId++;
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
                arbol += "GG" + useSino + "-> \"&&" + useSino + "\"; \n";
                arbol += "GG" + useSino + "-> \"K" + (useSino+1) + "\"; \n";
                useSino++;
                pila.EliminarNodo();
                pila.InsertarNodo(K);
                pila.InsertarNodo("&");
            }
            else if (lexema.Equals("|"))
            {
                arbol += "GG" + useSino + "-> \"||" + useSino + "\"; \n";
                arbol += "GG" + useSino + "-> \"K" + (useSino+1) + "\"; \n";
                useSino++;
                pila.EliminarNodo();
                pila.InsertarNodo(K);
                pila.InsertarNodo("|");
            }
            else if (lexema.Equals(")"))
            {
                //arbol += "GG" + numeroNodo + "-> \")" + numeroNodo + "\"; \n";
                useSino++;
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
                arbol += "Y" + nodoId + "-> \"!" + nodoId + "\"; \n";
                arbol += "Y" + nodoId + "-> \"Y" + (nodoId+1) + "\"; \n";
                nodoId++;
                pila.EliminarNodo();
                pila.InsertarNodo(Y);
            }
            else if (lexema.Equals(verdadero) || lexema.Equals(falso))
            {
                arbol += "Y" + nodoId + "-> \"" + lexema + nodoId + "\"; \n";
                nodoId++;
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
