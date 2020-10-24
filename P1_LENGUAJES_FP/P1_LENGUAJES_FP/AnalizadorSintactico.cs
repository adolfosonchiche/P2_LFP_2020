using System;
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


        public void inicializarVariableSintactico()
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
            } else if (tipo.Equals(ultimoValor))
            {
                pila.EliminarNodo();
            }
            else
            {
                if (ultimoValor.Equals(E))
                {
                    tablaSintactico.ejecutarProduccionE();
                }
                else if (ultimoValor.Equals(N))
                {
                    tablaSintactico.ejecutarProduccionN();
                }
                else if (ultimoValor.Equals(D))
                {
                    tablaSintactico.ejecutarProduccionD();
                }
                else if (ultimoValor.Equals(R))
                {
                    tablaSintactico.ejecutarProduccionR();
                }
                else if (ultimoValor.Equals(A))
                {
                    tablaSintactico.ejecutarProduccionA();
                }
                else if (ultimoValor.Equals(B))
                {
                    tablaSintactico.ejecutarProduccionB();
                }
                else if (ultimoValor.Equals(C))
                {
                    tablaSintactico.ejecutarProduccionC();
                }
                else if (ultimoValor.Equals(F))
                {
                    tablaSintactico.ejecutarProduccionF();
                }
                else if (ultimoValor.Equals(FF))
                {
                    tablaSintactico.ejecutarProduccionFF();
                }
                else if (ultimoValor.Equals(H))
                {
                    tablaSintactico.ejecutarProduccionH();
                }
                else if (ultimoValor.Equals(I))
                {
                    tablaSintactico.ejecutarProduccionI();
                }
                else if (ultimoValor.Equals(J))
                {
                    tablaSintactico.ejecutarProduccionJ();
                }
                else if (ultimoValor.Equals(L))
                {
                    tablaSintactico.ejecutarProduccionL();
                }
                else if (ultimoValor.Equals(LL))
                {
                    tablaSintactico.ejecutarProduccionLL();
                }
                else if (ultimoValor.Equals(LLL))
                {
                    tablaSintactico.ejecutarProduccionLLL();
                }
                else if (ultimoValor.Equals(M))
                {
                    tablaSintactico.ejecutarProduccionM();
                }
                else if (ultimoValor.Equals(MM))
                {
                    tablaSintactico.ejecutarProduccionMM();
                }
                else if (ultimoValor.Equals(MMM))
                {
                    tablaSintactico.ejecutarProduccionMMM();
                }
                else if (ultimoValor.Equals(U))
                {
                    tablaSintactico.ejecutarProduccionU();
                }
                else if (ultimoValor.Equals(UU))
                {
                    tablaSintactico.ejecutarProduccionUU();
                }
                else if (ultimoValor.Equals(UUU))
                {
                    tablaSintactico.ejecutarProduccionUUU();
                }
                else if (ultimoValor.Equals(P))
                {
                    tablaSintactico.ejecutarProduccionP();
                }
                else if (ultimoValor.Equals(PP))
                {
                    tablaSintactico.ejecutarProduccionPP();
                }
                else if (ultimoValor.Equals(PPP))
                {
                    tablaSintactico.ejecutarProduccionPPP();
                }
                else if (ultimoValor.Equals(Q))
                {
                    tablaSintactico.ejecutarProduccionQ();
                }
                else if (ultimoValor.Equals(QQ))
                {
                    tablaSintactico.ejecutarProduccionQ();
                }
                else if (ultimoValor.Equals(QQQ))
                {
                    tablaSintactico.ejecutarProduccionQQQ();
                }
                else if (ultimoValor.Equals(V))
                {
                    tablaSintactico.ejecutarProduccionV();
                }
                else if (ultimoValor.Equals(S))
                {
                    tablaSintactico.ejecutarProduccionS();
                }
                else if (ultimoValor.Equals(T))
                {
                    tablaSintactico.ejecutarProduccionT();
                }
                else if (ultimoValor.Equals(TT))
                {
                    tablaSintactico.ejecutarProduccionTT();
                }
                else if (ultimoValor.Equals(W))
                {
                    tablaSintactico.ejecutarProduccionW();
                }
                else if (ultimoValor.Equals(O))
                {
                    tablaSintactico.ejecutarProduccionO();
                }
                else if (ultimoValor.Equals(OO))
                {
                    tablaSintactico.ejecutarProduccionOO();
                }
                else if (ultimoValor.Equals(Z))
                {
                    tablaSintactico.ejecutarProduccionZ();
                }
                else if (ultimoValor.Equals(X))
                {
                    tablaSintactico.ejecutarProduccionX();
                }
                else if (ultimoValor.Equals(K))
                {
                    tablaSintactico.ejecutarProduccionK();
                }
                else if (ultimoValor.Equals(KK))
                {
                    tablaSintactico.ejecutarProduccionKK();
                }
                else if (ultimoValor.Equals(G))
                {
                    tablaSintactico.ejecutarProduccionG();
                }
                else if (ultimoValor.Equals(GG))
                {
                    tablaSintactico.ejecutarProduccionGG();
                }
                else if (ultimoValor.Equals(Y))
                {
                    tablaSintactico.ejecutarProduccionY();
                }
                else
                {

                }
            }
        }
    }
}
