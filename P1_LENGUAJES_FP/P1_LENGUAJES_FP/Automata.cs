using System;
using System.Collections;
using System.Diagnostics.Tracing;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace P1_LENGUAJES_FP
{
    class Automata
    {
        /*declaracion de variables*/
        private EstadoAceptacion aceptacion;
        private EstadoNoAceptacion noAceptacion;
        protected static int estado = 0;
        protected static int puntoEstadoB = 0;
        protected static int tipoToken = 0;
        protected static int cadCom = 2;
        protected Boolean moverToken = false;
        protected static Boolean errorToken = false;
        protected string tokens = "";
        protected string comentar = "";
        protected PintaTokens pintaT;
        protected String tok = "";
        protected static String tipoLexema = "";
        protected static Boolean idToken = false;
        private string[] signosOperadores = new string[] {"+", "-", "++", "--", "<", ">",
           "<=", ">=", "==", "!=", "!", "|", "&", "(", ")", "=", ";", ",", "*"};
        private TablaTrasicionSintactico sintactico;
        protected Boolean enviarLexema = true;
       // private string datosArbol = "";

        /*metodo para instanciar algunas variables*/
        public void iniciarVaiables(PintaTokens pintar, RichTextBox rtbErr)
        {
            aceptacion = new EstadoAceptacion();
            noAceptacion = new EstadoNoAceptacion();
            this.pintaT = pintar;
            sintactico = new TablaTrasicionSintactico();         
            /*datosArbol = "digraph Figura {\n"
            + "Raiz-> E; \n"
            + "E-> \"principal\"; \n"
            + "E-> \"(\"; \n"
            + "E-> \")\"; \n"
            + "E-> \"{\"; \n";*/
            sintactico.inicializarVariableSintactico(rtbErr);
            //+ "}";
        }

        /*metodo para obtener el movimineto en los estados 
         * e imprime si exite error en el token, verifica si ya 
         * se completo un token*/
        public void obtenerEstado(/*KeyPressEventArgs e*/ char tokeni, RichTextBox rtbError, int fila, int columna)
        {
            char token = tokeni;//e.KeyChar;//obtenemos el token (caracter)

            /*verificamos si ya se termino el token o nos seguimo moviendo*/
            for (int cont = 0; cont < signosOperadores.Length; cont++)
            {
                if(signosOperadores[cont].Equals(token.ToString()) || token.ToString().Equals("") 
                    || token.ToString().Equals(" ") || token.ToString().Equals("\r") || token.Equals('\n')
                    || token.Equals(' '))
                {
                    moverToken = false;
                    break;
                }
                else
                {
                    moverToken = true;
                }
            }

            /*sentencia para que se acepten token de tipo espacio y seguir moviendonos en estados*/
            if((estado == 6 || estado == 7 || estado == 8 || estado == 10) && !token.Equals('\n'))
            {
                moverToken = true;
            }
            if (estado == 9 || estado == 5 && !token.Equals('*'))
            {
                moverToken = true;
            }
            if (estado == 4 || estado == 5 && token.Equals('*'))
            {
                moverToken = true;
            }
            /*sentencia para movernos en los estados*/
            if (moverToken) //si se mueve entra aqui
            {
                //verificar si el usuario teclo  borra un caracter (token)
                try {
                    if (token.Equals('') && !tokens.Equals(""))
                    {
                        String a = tokens.Remove(tokens.Length - 1, 1);
                        tokens = a;
                        String b = tokens.Remove(0, a.Length - 1);

                        token = Convert.ToChar(b);
                        errorToken = false;
                    }
                    else
                    {
                        tokens += token.ToString();
                    }
                } catch (Exception) { }
                

                switch (estado) //verificamos el estado en el que nos encontramos y mandamos el token
                {
                    /* cada estado nos devuelve un nuevo estado segun sea el token
                    * estado A = 0, estdo B = 1, estado C = 2, estado D = 3, estado E = 4, estado F = 5
                    * estado G = 6, estdo H = 7, estado I = 8, estado J = 9, estado K = 10, estado L = 11 */
                    case 0:
                        estado = noAceptacion.estadoA(token);
                        break;

                    case 1:
                       estado = aceptacion.estadoB(token);
                        break;

                    case 2:
                        estado = noAceptacion.estadoC(token);
                        break;

                    case 3:
                        estado = aceptacion.estadoD(token);
                        break;

                    case 4:
                        estado = noAceptacion.estadoE(token);
                        break;

                    case 5:
                        estado = noAceptacion.estadoF(token);
                        break;

                    case 6:
                        estado = noAceptacion.estadoG(token);
                        break;

                    case 7:
                        estado = noAceptacion.estadoH(token);
                        break;

                    case 8:
                        estado = noAceptacion.estadoI(token);
                        break;

                    case 9:
                        estado = noAceptacion.estadoJ(token);
                        break;

                    case 10:
                        estado = aceptacion.estadoK(token);
                        break;

                    case 11:
                        estado = noAceptacion.estadoL(token);
                        break;

                    default:
                        estado = 0;
                        break;
                }
            }
            /*si ya no hay movimiento entonces el token esta completo y entramos aqui*/
            else if (!moverToken)
            {
                /*verificamos si el token es una palabra reservada para que no sea un error*/
                for (int ctd = 0; ctd < pintaT.getTextoReservado().Count; ctd++)
                {
                    if (pintaT.getTextoReservado()[ctd].Equals(tokens))
                    {
                        errorToken = false;
                        cadCom = 10;
                        tokens = pintaT.getTextoReservado()[ctd];
                        tipoLexema = "reservada";
                        break;
                    } else if(tokens.Equals("principal") || tokens.Equals("leer")
                        || tokens.Equals("escribir"))
                    {
                        errorToken = false;
                        cadCom = 10;
                        break;
                    }
                }
                if (token.Equals('\r') && tokens.Equals("") || tokens.Equals("") || tokens.Equals(""))
                {
                    errorToken = false;
                    enviarLexema = false;
                }

                /*si el token no finalizo en un estado de aceptacion imprimimos que es un error*/
                if (errorToken)
                {
                    rtbError.AppendText("Error: no se reconoce token: " + tokens + "       fila: " + fila 
                        + "   columna: " + (columna - tokens.Length + 1) + " \n");
                }
                else //si finalizo en un estado de aceptacion guardamos el token para pintarlo
                {
                    if(puntoEstadoB == 0 && estado == 1)
                    {
                        tipoToken = 0;
                        pintaT.setNumeroEntero(tokens);
                        tipoLexema = "n";
                    }
                    else if(puntoEstadoB == 1 && estado == 1)
                    {
                        pintaT.setNumeroDecimal(tokens);
                        tipoLexema = "np";
                        tipoToken = 1;
                    }
                    else if (estado == 3 && tokens.Length == 1)
                    {
                        pintaT.setCaracter(tokens);
                        tipoLexema = "ac";
                    }
                    else if (cadCom == 0)
                    {
                        pintaT.setCadenaTexto(tokens);
                        tipoLexema = "ct";
                        tipoToken = 3;
                    }
                    else if((cadCom == 1 && estado != 0) || estado == 10)
                    {                      
                        pintaT.setComentario(tokens);                      
                        tipoToken = 4;
                        errorToken = true;
                    }
                }

                if (!errorToken && enviarLexema)
                {
                    sintactico.analizarLexema(tokens, tipoLexema, fila, (columna - tokens.Length + 1));
                }

                for (int cont = 0; cont < signosOperadores.Length; cont++)
                {
                    if (signosOperadores[cont].Equals(token.ToString()))
                    {
                        tokens = signosOperadores[cont];
                        tipoLexema = "s";
                        enviarLexema = true;
                        errorToken = false;
                        if (!errorToken && enviarLexema)
                        {
                            sintactico.analizarLexema(tokens, tipoLexema, fila, (columna - tokens.Length + 1));
                        }
                        break;
                    }
                }       

                /*iniciamos el estado, y el token para ingresar uno nuevo*/
                tokens = "";
                estado = 0;   
                puntoEstadoB = 0;
                errorToken = true;
                idToken = false;
                tipoLexema = "";
                enviarLexema = true;
                cadCom = 2;
            }            
        }

        public Pila GetPilaActual()
        {
            return sintactico.getPila();
        }
      
        public String getDatosArbol()
        {
            return sintactico.getArbol();
        }

    }
}
