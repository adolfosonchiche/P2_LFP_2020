using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace P1_LENGUAJES_FP
{
    class AnalizadorSintactico : ConstantesUse
    {
        protected String lexema = "";
        protected String tipo = "";
        protected int fila;
        protected int columna;
        protected static Pila pila;
        protected String ultimoValor = "";
        protected static Boolean errorLexema = false;
        protected String mensajeErrorLexema = "";
        TablaTrasicionSintactico tablaSintactico;
        protected static RichTextBox rtbError;
        protected static String arbol;


        public void inicializarVariableSintactico(RichTextBox rtberr)
        {
            pila = new Pila();
            pila.InsertarNodo(E);
            tablaSintactico = new TablaTrasicionSintactico();
            rtbError = rtberr;
            arbol = "digraph Figura {\n"
            + "Raiz-> E; \n"
            + "E-> \"principal\"; \n"
            + "E-> \"(\"; \n"
            + "E-> \")\"; \n"
            + "E-> \"{\"; \n";           
        }

        public void analizarLexema(String lexema, String tipo, int fila, int columna)
        {
            this.lexema = lexema;
            this.tipo = tipo;
            this.fila = fila;
            this.columna = columna;
            ultimoValor = "";

            if (!pila.PilaVacia())
            {
                ultimoValor = pila.MostrarUltimoValorIngresado();
            }
            
            if ((ultimoValor.Equals(lexema) || tipo.Equals(ultimoValor)) && !pila.PilaVacia())
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
                    tablaSintactico.ejecutarProduccionN(lexema, tipo, fila, columna);
                }
                else if (ultimoValor.Equals(D))
                {
                    tablaSintactico.ejecutarProduccionD(lexema, tipo, fila, columna);
                }
                else if (ultimoValor.Equals(R))
                {
                    tablaSintactico.ejecutarProduccionR(lexema, tipo, fila, columna);
                }
                else if (ultimoValor.Equals(A))
                {
                    tablaSintactico.ejecutarProduccionA(lexema, tipo, fila, columna);
                }
                else if (ultimoValor.Equals(B))
                {
                    tablaSintactico.ejecutarProduccionB(lexema, tipo, fila, columna);
                }
                else if (ultimoValor.Equals(C))
                {
                    tablaSintactico.ejecutarProduccionC(lexema, tipo, fila, columna);
                }
                else if (ultimoValor.Equals(F))
                {
                    tablaSintactico.ejecutarProduccionF(lexema, tipo, fila, columna);
                }
                else if (ultimoValor.Equals(FF))
                {
                    tablaSintactico.ejecutarProduccionFF(lexema, tipo, fila, columna);
                }
                else if (ultimoValor.Equals(H))
                {
                    tablaSintactico.ejecutarProduccionH(lexema, tipo, fila, columna);
                }
                else if (ultimoValor.Equals(I))
                {
                    tablaSintactico.ejecutarProduccionI(lexema, tipo, fila, columna);
                }
                else if (ultimoValor.Equals(J))
                {
                    tablaSintactico.ejecutarProduccionJ(lexema, tipo, fila, columna);
                }
                else if (ultimoValor.Equals(L))
                {
                    tablaSintactico.ejecutarProduccionL(lexema, tipo, fila, columna);
                }
                else if (ultimoValor.Equals(LL))
                {
                    tablaSintactico.ejecutarProduccionLL(lexema, tipo, fila, columna);
                }
                else if (ultimoValor.Equals(LLL))
                {
                    tablaSintactico.ejecutarProduccionLLL(lexema, tipo, fila, columna);
                }
                else if (ultimoValor.Equals(M))
                {
                    tablaSintactico.ejecutarProduccionM(lexema, tipo, fila, columna);
                }
                else if (ultimoValor.Equals(MM))
                {
                    tablaSintactico.ejecutarProduccionMM(lexema, tipo, fila, columna);
                }
                else if (ultimoValor.Equals(MMM))
                {
                    tablaSintactico.ejecutarProduccionMMM(lexema, tipo, fila, columna);
                }
                else if (ultimoValor.Equals(U))
                {
                    tablaSintactico.ejecutarProduccionU(lexema, tipo, fila, columna);
                }
                else if (ultimoValor.Equals(UU))
                {
                    tablaSintactico.ejecutarProduccionUU(lexema, tipo, fila, columna);
                }
                else if (ultimoValor.Equals(UUU))
                {
                    tablaSintactico.ejecutarProduccionUUU(lexema, tipo, fila, columna);
                }
                else if (ultimoValor.Equals(P))
                {
                    tablaSintactico.ejecutarProduccionP(lexema, tipo, fila, columna);
                }
                else if (ultimoValor.Equals(PP))
                {
                    tablaSintactico.ejecutarProduccionPP(lexema, tipo, fila, columna);
                }
                else if (ultimoValor.Equals(PPP))
                {
                    tablaSintactico.ejecutarProduccionPPP(lexema, tipo, fila, columna);
                }
                else if (ultimoValor.Equals(Q))
                {
                    tablaSintactico.ejecutarProduccionQ(lexema, tipo, fila, columna);
                }
                else if (ultimoValor.Equals(QQ))
                {
                    tablaSintactico.ejecutarProduccionQQ(lexema, tipo, fila, columna);
                }
                else if (ultimoValor.Equals(QQQ))
                {
                    tablaSintactico.ejecutarProduccionQQQ(lexema, tipo, fila, columna);
                }
                else if (ultimoValor.Equals(V))
                {
                    tablaSintactico.ejecutarProduccionV(lexema, tipo, fila, columna);
                }
                else if (ultimoValor.Equals(S))
                {
                    tablaSintactico.ejecutarProduccionS(lexema, tipo, fila, columna);
                }
                else if (ultimoValor.Equals(T))
                {
                    tablaSintactico.ejecutarProduccionT(lexema, tipo, fila, columna);
                }
                else if (ultimoValor.Equals(TT))
                {
                    tablaSintactico.ejecutarProduccionTT(lexema, tipo, fila, columna);
                }
                else if (ultimoValor.Equals(W))
                {
                    tablaSintactico.ejecutarProduccionW(lexema, tipo, fila, columna);
                }
                else if (ultimoValor.Equals(O))
                {
                    tablaSintactico.ejecutarProduccionO(lexema, tipo, fila, columna);
                }
                else if (ultimoValor.Equals(OO))
                {
                    tablaSintactico.ejecutarProduccionOO(lexema, tipo, fila, columna);
                }
                else if (ultimoValor.Equals(Z))
                {
                    tablaSintactico.ejecutarProduccionZ(lexema, tipo, fila, columna);
                }
                else if (ultimoValor.Equals(X))
                {
                    tablaSintactico.ejecutarProduccionX(lexema, tipo, fila, columna);
                }
                else if (ultimoValor.Equals(K))
                {
                    tablaSintactico.ejecutarProduccionK(lexema, tipo, fila, columna);
                }
                else if (ultimoValor.Equals(KK))
                {
                    tablaSintactico.ejecutarProduccionKK(lexema, tipo, fila, columna);
                }
                else if (ultimoValor.Equals(G))
                {
                    tablaSintactico.ejecutarProduccionG(lexema, tipo, fila, columna);
                }
                else if (ultimoValor.Equals(GG))
                {
                    tablaSintactico.ejecutarProduccionGG(lexema, tipo, fila, columna);
                }
                else if (ultimoValor.Equals(Y))
                {
                    tablaSintactico.ejecutarProduccionY(lexema, tipo, fila, columna);
                }
                else
                {
                    rtbError.AppendText("error en lexema: " + lexema + " de tipo " + tipo + " en fila: " + fila
                        + " columna: " + columna + "\n" + "ya no se esperaba nada");
                }
            }
        }

        public Pila getPila()
        {
            return pila;
        }

        public string getArbol()
        {
            return arbol;
        }
    }
}
