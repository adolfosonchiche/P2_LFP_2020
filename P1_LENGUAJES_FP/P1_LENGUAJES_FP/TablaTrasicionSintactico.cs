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
                    pila.EliminarNodo();
                    pila.InsertarNodo(N);
                    pila.InsertarNodo("{");
                    pila.InsertarNodo(")");
                    pila.InsertarNodo("(");
                    arbol += "E-> \"N\"; \n";
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
                arbol += "N-> \"}\"; \n";
                pila.EliminarNodo();
            }
            else if (lexema.Equals(desde) || lexema.Equals(hacer) || lexema.Equals(mientras)
                || lexema.Equals(si))
            {
                arbol += "N-> \"N\"; \n";
                arbol += "N-> \"D\"; \n";
                pila.InsertarNodo(N);
                ejecutarProduccionD(lexema, tipo, fila, columna);
            }
            else if(lexema.Equals(entero) || lexema.Equals(numDecimal)
                || lexema.Equals(cadena) || lexema.Equals(caracter) || lexema.Equals(escribir)
                || lexema.Equals(booleano) || lexema.Equals(leer))
            {
                arbol += "N-> \"R\"; \n";
                ejecutarProduccionR(lexema, tipo, fila, columna);
            } 
            else if (tipo.Equals("id"))
            {
                arbol += "N-> \"O\"; \n";
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
                arbol += "D-> \"DESDE\"; \n";
                arbol += "D-> \"A\"; \n";
                arbol += "D-> \"C\"; \n";
                pila.InsertarNodo(C);
                pila.InsertarNodo(A);
            }
            else if (lexema.Equals(hacer))
            {
                arbol += "D-> \"HACER\"; \n";
                arbol += "D-> \"{\"; \n";
                arbol += "D-> \"B\"; \n";
                pila.InsertarNodo(B);
                pila.InsertarNodo("{");
            }
            else if (lexema.Equals(mientras))
            {
                arbol += "D-> \"MIENTRAS\"; \n";
                arbol += "D-> \"(\"; \n";
                arbol += "D-> \"K\"; \n";
                arbol += "D-> \")\"; \n";
                arbol += "D-> \"{\"; \n";
                arbol += "D-> \"C\"; \n";
                pila.InsertarNodo(C);
                pila.InsertarNodo("{");
                pila.InsertarNodo(")");
                pila.InsertarNodo(K);
                pila.InsertarNodo("(");
            }
            else if (lexema.Equals(si))
            {
                arbol += "D-> \"SI\"; \n";
                arbol += "D-> \"(\"; \n";
                arbol += "D-> \"K\"; \n";
                arbol += "D-> \")\"; \n";
                arbol += "D-> \"{\"; \n";
                arbol += "D-> \"F\"; \n";
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
                arbol += "R-> \"entero\"; \n";
                arbol += "R-> \"L\"; \n";
                pila.InsertarNodo(L);
            }
            else if (lexema.Equals(numDecimal))
            {
                arbol += "R-> \"decimal\"; \n";
                arbol += "R-> \"M\"; \n";
                pila.InsertarNodo(M);
            }
            else if (lexema.Equals(cadena))
            {
                arbol += "R-> \"cadena\"; \n";
                arbol += "R-> \"U\"; \n";
                pila.InsertarNodo(U);
            }
            else if (lexema.Equals(booleano))
            {
                arbol += "R-> \"booleano\"; \n";
                arbol += "R-> \"Q\"; \n";
                pila.InsertarNodo(Q);
            }
            else if (lexema.Equals(caracter))
            {
                arbol += "R-> \"caracter\"; \n";
                arbol += "R-> \"P\"; \n";
                pila.InsertarNodo(P);
            }
            else if (lexema.Equals(leer))
            {
                arbol += "R-> \"leer\"; \n";
                arbol += "R-> \"S\"; \n";
                pila.InsertarNodo(S);
            }
            else if (lexema.Equals(escribir))
            {
                arbol += "R-> \"imprimir\"; \n";
                arbol += "R-> \"T\"; \n";
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
                arbol += "A-> \"ID\"; \n";
                arbol += "A-> \"=\"; \n";
                arbol += "A-> \"numero\"; \n";
                arbol += "A-> \"HASTA\"; \n";
                arbol += "A-> \"ID\"; \n";
                arbol += "A-> \"signo\"; \n";
                arbol += "A-> \"num\"; \n";
                arbol += "A-> \"INCREMENTO\"; \n";
                arbol += "A-> \"ID\"; \n";
                arbol += "A-> \"nu\"; \n";
                arbol += "A-> \"{\"; \n";
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
                arbol += "B-> \"}\"; \n";
                arbol += "B-> \"MIENTRAS\"; \n";
                arbol += "B-> \"(\"; \n";
                arbol += "B-> \"K\"; \n";
                arbol += "B-> \")\"; \n";
                arbol += "B-> \";\"; \n";
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
                arbol += "B-> \"N\"; \n";
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
                arbol += "C-> \"}\"; \n";
                pila.EliminarNodo();
                pila.EliminarNodo();
            }
            else if (lexema.Equals(desde) || lexema.Equals(hacer) || lexema.Equals(mientras)
                || lexema.Equals(si) || lexema.Equals(entero) || lexema.Equals(numDecimal)
                || lexema.Equals(cadena) || lexema.Equals(caracter) || lexema.Equals(escribir) || tipo.Equals("id")
                || lexema.Equals(booleano) || lexema.Equals(leer))
            {
                arbol += "C-> \"N\"; \n";
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
                arbol += "F-> \"}\"; \n";
                arbol += "F-> \"FF\"; \n";
                pila.EliminarNodo();
                pila.InsertarNodo(FF);
            }
            else if (lexema.Equals(desde) || lexema.Equals(hacer) || lexema.Equals(mientras)
                || lexema.Equals(si) || lexema.Equals(entero) || lexema.Equals(numDecimal)
                || lexema.Equals(cadena) || lexema.Equals(caracter) || lexema.Equals(escribir) || tipo.Equals("id")
                || lexema.Equals(booleano) || lexema.Equals(leer))
            {
                arbol += "F-> \"N\"; \n";
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
                arbol += "FF-> \"H\"; \n";
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
                arbol += "H-> \"SINO\"; \n";
                arbol += "H-> \"{\"; \n";
                arbol += "H-> \"J\"; \n";
                pila.InsertarNodo(J);
                pila.InsertarNodo("{");
            }
            if (lexema.Equals(sino_si))
            {
                arbol += "H-> \"SINO_SI\"; \n";
                arbol += "H-> \"(\"; \n";
                arbol += "H-> \"K\"; \n";
                arbol += "H-> \")\"; \n";
                arbol += "H-> \"{\"; \n";
                arbol += "H-> \"I\"; \n";
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
                arbol += "I-> \"}\"; \n";
                arbol += "I-> \"FF\"; \n";
                pila.EliminarNodo();
                pila.EliminarNodo();
                pila.InsertarNodo(FF);
            }
            else if (lexema.Equals(desde) || lexema.Equals(hacer) || lexema.Equals(mientras)
                || lexema.Equals(si) || lexema.Equals(entero) || lexema.Equals(numDecimal)
                || lexema.Equals(cadena) || lexema.Equals(caracter) || lexema.Equals(escribir) || tipo.Equals("id")
                || lexema.Equals(booleano) || lexema.Equals(leer))
            {
                arbol += "I-> \"N\"; \n";
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
                arbol += "J-> \"}\"; \n";
                pila.EliminarNodo();
                pila.EliminarNodo();
            }
            else if (lexema.Equals(desde) || lexema.Equals(hacer) || lexema.Equals(mientras)
                || lexema.Equals(si) || lexema.Equals(entero) || lexema.Equals(numDecimal)
                || lexema.Equals(cadena) || lexema.Equals(caracter) || lexema.Equals(escribir) || tipo.Equals("id")
                || lexema.Equals(booleano) || lexema.Equals(leer))
            {
                arbol += "J-> \"N\"; \n";
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
                arbol += "L-> \"ID\"; \n";
                arbol += "L-> \"LL\"; \n";
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
                arbol += "LL-> \"LLL\"; \n";
                ejecutarProduccionLLL(lexema, tipo, fila, columna);
            }
            else if (lexema.Equals("="))
            {
                arbol += "LL-> \"=\"; \n";
                arbol += "LL-> \"num\"; \n";
                arbol += "LL-> \"LLL\"; \n";
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
                arbol += "LLL-> \",\"; \n";
                arbol += "LLL-> \"L\"; \n";
                pila.EliminarNodo();
                pila.InsertarNodo(L);
            }
            else if (lexema.Equals(";"))
            {
                arbol += "LLL-> \";\"; \n";
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
                arbol += "M-> \"ID\"; \n";
                arbol += "M-> \"MM\"; \n";
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
                arbol += "MM-> \"MMM\"; \n";
                ejecutarProduccionMMM(lexema, tipo, fila, columna);
            }
            else if (lexema.Equals("="))
            {
                arbol += "MM-> \"=\"; \n";
                arbol += "MM-> \"numdec\"; \n";
                arbol += "MM-> \"MMM\"; \n";
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
                arbol += "MMM-> \",\"; \n";
                arbol += "MMM-> \"M\"; \n";
                pila.EliminarNodo();
                pila.InsertarNodo(M);
            }
            else if (lexema.Equals(";"))
            {
                arbol += "MMMM-> \";\"; \n";
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
                arbol += "U-> \"ID\"; \n";
                arbol += "U-> \"UU\"; \n";
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
                arbol += "UU-> \"UUU\"; \n";
                ejecutarProduccionUUU(lexema, tipo, fila, columna);
            }
            else if (lexema.Equals("="))
            {
                arbol += "UU-> \"=\"; \n";
                arbol += "UU-> \"texto\"; \n";
                arbol += "UU-> \"UUU\"; \n";
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
                imprimirError(lexema, tipo, fila, columna);
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
                imprimirError(lexema, tipo, fila, columna);
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
                imprimirError(lexema, tipo, fila, columna);
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
                imprimirError(lexema, tipo, fila, columna);
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
                imprimirError(lexema, tipo, fila, columna);
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
                imprimirError(lexema, tipo, fila, columna);
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
                imprimirError(lexema, tipo, fila, columna);
            }
        }

        public void ejecutarProduccionO(String lexema, String tipo, int fila, int columna)
        {
            if (tipo.Equals("id"))
            {
                arbol += "O-> \"id\"; \n";
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
                imprimirError(lexema, tipo, fila, columna);
            }
        }

        public void ejecutarProduccionX(String lexema, String tipo, int fila, int columna)
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
                imprimirError(lexema, tipo, fila, columna);
            }
        }

        public void ejecutarProduccionK(String lexema, String tipo, int fila, int columna)
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
                imprimirError(lexema, tipo, fila, columna);
            }
        }

        public void ejecutarProduccionKK(String lexema, String tipo, int fila, int columna)
        {
            if (tipo.Equals("s"))
            {
                pila.EliminarNodo();
            }
            else 
            {
                pila.EliminarNodo();
                ejecutarProduccionG(lexema, tipo, fila, columna);
            }
        }

        public void ejecutarProduccionG(String lexema, String tipo, int fila, int columna)
        {
            if (tipo.Equals("id") || tipo.Equals("n"))
            {
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
                imprimirError(lexema, tipo, fila, columna);
            }
        }

        public void ejecutarProduccionY(String lexema, String tipo, int fila, int columna)
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
