using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace P1_LENGUAJES_FP
{
    class PintaTokens : ConstantesUse
    {
        /*declaracion de variables*/
        private static List<String> textoReservado = new List<String>(new String[] {entero, numDecimal, cadena, booleano, caracter, si, sino, sino_si, mientras, hacer, desde, hasta, incremento,
            verdadero, falso});

        string[] signosOperadores = new string[] {"+", "-", "*", "++", "--", "/", "<", ">",
           "<=", ">=", "==", "!=", "!", "||", "&&", "(", ")", "=", ";"};

        private static List<String> numeroEnteros = new List<String>(new String[] { });
        private static List<String> numeroDecimal = new List<String>(new String[] { });
        private static List<String> comentario = new List<String>(new String[] { });
        private static List<String> cadenaTexto = new List<String>(new String[] { });

        /*metodo que pinta las palabras reservadas que se ingresan en el cuadro de texto*/
        public void pintarTextoReservada(RichTextBox txtTexto)
        {

            try /*captura errores*/
            {


                /*inicia la seleccion de un token ingresado*/
                txtTexto.SelectionStart = 0;
                txtTexto.SelectionLength = txtTexto.TextLength;
                txtTexto.SelectionColor = txtTexto.ForeColor;

                /* ciclo para comprobar tokens y pintarlos */
                foreach (string reservadaAuxiliar in textoReservado)
                { 
                    int INDEX = 0;  /* posicion de tokens*/
                    /*ciclo  para buscar la palabra  */
                    while (INDEX <= txtTexto.Text.LastIndexOf(reservadaAuxiliar))
                    {
                        txtTexto.Find(reservadaAuxiliar, INDEX, txtTexto.TextLength, RichTextBoxFinds.WholeWord); //'CUANDO LA ENCUENTRA LA SELECCIONA Y....
                        //verificamos el tipo de palabra reservada
                        if (reservadaAuxiliar.Equals("entero"))
                        {
                            txtTexto.SelectionColor = Color.MediumOrchid;
                        }
                        else if (reservadaAuxiliar.Equals("decimal"))
                        {
                            txtTexto.SelectionColor = Color.Aqua;
                        }
                        else if (reservadaAuxiliar.Equals("cadena"))
                        {
                            txtTexto.SelectionColor = Color.DimGray;
                        }
                        else if (reservadaAuxiliar.Equals("booleano") || reservadaAuxiliar.Equals("verdadero")
                            || reservadaAuxiliar.Equals("falso"))
                        {
                            txtTexto.SelectionColor = Color.Orange;
                        }
                        else if (reservadaAuxiliar.Equals("caracter") || reservadaAuxiliar.Length == 1)
                        {
                            txtTexto.SelectionColor = Color.SaddleBrown;
                        }                       
                        else if (reservadaAuxiliar.Equals("SI") || reservadaAuxiliar.Equals("SINO") ||
                            reservadaAuxiliar.Equals("SINO_SI") || reservadaAuxiliar.Equals("MIENTRAS") ||
                            reservadaAuxiliar.Equals("HACER") || reservadaAuxiliar.Equals("DESDE") ||
                            reservadaAuxiliar.Equals("HASTA") || reservadaAuxiliar.Equals("INCREMENTO"))
                        {
                            txtTexto.SelectionColor = Color.DarkGreen;
                        }
                        else
                        {

                            txtTexto.SelectionColor = Color.Black; 
                        }

                        /* pasa a la siguiente palabra */
                        INDEX = txtTexto.Text.IndexOf(reservadaAuxiliar, INDEX) + 1; 

                    }
                }

                /* volvemos al color normal y la posicion */
                txtTexto.SelectionStart = txtTexto.TextLength;
                txtTexto.SelectionColor = txtTexto.ForeColor;

            }
            catch (Exception e)
            {
                Console.WriteLine("error al pintar texto " + e);
            }

        }

        /*metodo para pintar los signos u operadores que se ingresan en el cauadro de texto*/
        public void pintarSignosOperadores(RichTextBox txtTextoIngresado)
        {
            try
            {
                //buscamos si exiten signos en el cuadro del codigo
                foreach (String word in signosOperadores)
                {
                    int startIndex = 0;

                    while (startIndex <= txtTextoIngresado.Text.LastIndexOf(word))
                    {
                        int wordStartIndex =
                        txtTextoIngresado.Find(word, startIndex, txtTextoIngresado.TextLength,
                        RichTextBoxFinds.NoHighlight);

                        if (wordStartIndex != -1)
                        {
                            txtTextoIngresado.SelectionStart = wordStartIndex;
                            txtTextoIngresado.SelectionLength = word.Length;
                         //verificamos el tipo de operador o signo
                            if (word.Equals("+") || word.Equals("-") || word.Equals("*") || word.Equals("/") || 
                                   word.Equals("++") || word.Equals("--") || word.Equals(">") ||
                                   word.Equals("<") || word.Equals(">=") || word.Equals("<=") ||
                                   word.Equals("==") || word.Equals("!=") || word.Equals("!") ||
                                   word.Equals("&&") || word.Equals("||") || word.Equals("(") ||
                                   word.Equals(")")) 
                            {
                                txtTextoIngresado.SelectionColor = Color.DarkBlue;
                            }
                            else if (word.Equals("=") || word.Equals(";") || word.Equals("\""))
                            {
                                txtTextoIngresado.SelectionColor = Color.DeepPink;
                            }

                        }
                        else
                            break;
                        startIndex += wordStartIndex + word.Length;

                    }

                }
                 txtTextoIngresado.SelectionStart = txtTextoIngresado.TextLength;

            }
            catch (Exception e)
            {
                Console.WriteLine("error al pintar signos u operadores " + e);
            }
        }

        /*metodo que retorna la lista de signo operadores*/
        public String[] getOperadorSigno()
        {
            return signosOperadores;
        }

        /*metodo que retorna la lista de palabras reservadas*/
        public List<String> getTextoReservado()
        {
            return textoReservado;
        }

        /*metodo que pinta los tokens que se ingresaron
         de forma correct */
        public void pintarTokensCompleto(RichTextBox txtTextoIngresado, List<String> tokensCompleto, 
            int tipoToken)
        {
            try
            {
                foreach (String word in tokensCompleto)
                {
                    int startIndex = 0;
                    
                    while (startIndex <= txtTextoIngresado.Text.LastIndexOf(word))
                    {
                        int wordStartIndex =
                        txtTextoIngresado.Find(word, startIndex, txtTextoIngresado.TextLength,
                        RichTextBoxFinds.NoHighlight);
                        //verificamos el tipo de token ingresado para pintarlo
                        if (wordStartIndex != -1)
                        {
                            txtTextoIngresado.SelectionStart = wordStartIndex;
                            txtTextoIngresado.SelectionLength = word.Length;

                            if (tipoToken == 0)
                            {
                                txtTextoIngresado.SelectionColor = Color.MediumOrchid;
                            }
                            else if (tipoToken == 1)
                            {
                                txtTextoIngresado.SelectionColor = Color.Aqua;
                            }
                            else if (tipoToken == 3)
                            {
                                txtTextoIngresado.SelectionColor = Color.DimGray;
                            }
                            else if (tipoToken == 4)
                            {
                                txtTextoIngresado.SelectionColor = Color.Red;
                            }

                        }
                        else
                            break;
                        startIndex += wordStartIndex + word.Length;
                    }
                }
                txtTextoIngresado.SelectionStart = txtTextoIngresado.TextLength;

            }
            catch (Exception e)
            {
                Console.WriteLine("error al pintar signos u operadores " + e);
            }
        }

        /*metodo para ingresar un nuevo valor a la lista de numeros enteros*/
        public void setNumeroEntero(String num)
        {
            numeroEnteros.Add(num);
        }

        /*metodo para ingresar un nuevo valor a la lista de numeros decimal*/
        public void setNumeroDecimal(String num)
        {
            numeroDecimal.Add(num);
        }

        /*metodo para ingresar un nuevo valor a la lista de cadena de texto*/
        public void setCadenaTexto(String text)
        {
            cadenaTexto.Add(text);
        }

        /*metodo para ingresar un nuevo valor a la lista de comentarios*/
        public void setComentario(String com)
        {
            comentario.Add(com);
        }
        /*metodo para ingresar un nuevo valor a la lista*/
        public void setCaracter(String ca)
        {
            textoReservado.Add(ca);
        }

        /*metodo retorna la lista de numeros enteros*/
        public List<String> getNumeroEntero()
        {
            return numeroEnteros;
        }

        /*metodo retorna la lista de numeros decimal*/
        public List<String> getNumeroDecimal()
        {
            return numeroDecimal;
        }

        /*metodo retorna la lista cadena de texto*/
        public List<String> getCadenaTexto()
        {
            return cadenaTexto;
        }

        /*metodo retorna la lista de comentario*/
        public List<String> getComentario()
        {
            return comentario;
        }

    }
}
