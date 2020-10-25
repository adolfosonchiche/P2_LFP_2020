using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace P1_LENGUAJES_FP
{
    public partial class Form1 : Form
    {
        /*Declaracion de variables*/
        private Archivo archivo;
        private Automata automata;
        private PintaTokens pinta;
        private String mensaje = "";
        private static int line = 0;
        private static int column = 0;

        /*constructor inicializando variables*/
        public Form1()
        {
            InitializeComponent();
            archivo = new Archivo();
            pinta = new PintaTokens();
            automata = new Automata();
            automata.iniciarVaiables(pinta, txtSalidaError);
        }

        /*metodo que rucupera el texto (codigo) ingreso 
         * el usuario en el richTextBox*/
        public void obtenerTextoRichText()
        {
            mensaje = txtIngresoCodigo.Text;
        }

        /*funcionalidad metodo del menu abrir archivo*/
        private void itemAbrir_Click(object sender, EventArgs e)
        {
            archivo.abrirDocumetno(txtIngresoCodigo, txtSalidaError, lboxArchivosProyecto);
        }

        /*funcionalidad metodo del menu guardar como (otro archivo nuevo) */
        private void itemGuardarComo_Click(object sender, EventArgs e)
        {
            obtenerTextoRichText();
            archivo.nuevoGuardar();
            archivo.guardarDocumeto(mensaje, lboxArchivosProyecto);
        }

        /*funcionalidad metodo del salir (cerrar programa)*/
        private void itemSalir_Click(object sender, EventArgs e)
        {
            string message = "Esta seguro que quiere salir.!";
            string caption = "Salir";
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result = MessageBox.Show(message, caption, buttons);

            if (result == DialogResult.OK)
            {
                this.Close();
            }
        }

        /*funcionalidad metodo menu guardar*/
        private void menuGuardar_Click(object sender, EventArgs e)
        {
            obtenerTextoRichText();
            archivo.guardarDocumeto(mensaje, lboxArchivosProyecto);
        }

        /*funcionalidad metodo del menu crear un nuevo archivo*/
        private void menuCrearNuevo_Click(object sender, EventArgs e)
        {
            obtenerTextoRichText();
            if (archivo.getPat().Equals("") && mensaje.Equals(""))
            {
                archivo.guardarDocumeto(mensaje, lboxArchivosProyecto);
                txtSalidaError.Clear();
                txtIngresoCodigo.Clear();
                archivo.obtenerArchivoProyecto(lboxArchivosProyecto, lblProyecto);
                automata.iniciarVaiables(pinta, txtSalidaError);
            }
            else
            {
                archivo.mensajeGuardar("Nuevo documento", mensaje, txtIngresoCodigo, txtSalidaError, lboxArchivosProyecto, automata, pinta);
                archivo.obtenerArchivoProyecto(lboxArchivosProyecto, lblProyecto);
            }
        }

        /*funcionalidad metodo del menu cerrar archivo*/
        private void menuCerrar_Click(object sender, EventArgs e)
        {
            obtenerTextoRichText();
            if (archivo.getPat().Equals("") && mensaje.Equals(""))
            {
                txtIngresoCodigo.Clear();
                txtSalidaError.Clear();
                mensaje = "";
                archivo.setPat("");
                automata.iniciarVaiables(pinta, txtSalidaError);
            }
            else
            {
                archivo.mensajeGuardar("Cerrar documento", mensaje, txtIngresoCodigo, txtSalidaError, lboxArchivosProyecto, automata, pinta);
            }
        }

        /*metodo que recibe y verifica las teclas (token) que el usuario presiona*/
        private void txtIngresoCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            try 
            {
                obtenerPosicion();
                Char token = e.KeyChar;
                automata.obtenerEstado(token, txtSalidaError, line +1, column);

                pinta.pintarTextoReservada(txtIngresoCodigo);
                pinta.pintarSignosOperadores(txtIngresoCodigo);
                pinta.pintarTokensCompleto(txtIngresoCodigo, pinta.getCadenaTexto(), 3);
                pinta.pintarTokensCompleto(txtIngresoCodigo, pinta.getNumeroEntero(), 0);
                pinta.pintarTokensCompleto(txtIngresoCodigo, pinta.getNumeroDecimal(), 1);
                pinta.pintarTokensCompleto(txtIngresoCodigo, pinta.getComentario(), 4);

            }
            catch(Exception a) { 
                 MessageBox.Show(a.ToString());
            }
        }

        /*metodo que indica la posicion cuando el usuario mueve el cursor con el mouse
         dando click en un lugar*/
        private void txtIngresoCodigo_Click(object sender, EventArgs e)
        {
            obtenerPosicion();
        }

        /*metodo que obtiene la posicion del cursor y lo imprime 
         en un label*/
        public void obtenerPosicion()
        {
            // retorna la linea .
            int index = txtIngresoCodigo.SelectionStart;
            line = txtIngresoCodigo.GetLineFromCharIndex(index);
            int fila = line + 1;
            labelFila.Text = "fila: " + fila.ToString();
            // retorna la columna.
            int firstChar = txtIngresoCodigo.GetFirstCharIndexFromLine(line);
            column = index - firstChar + 1;
            labelColumna.Text = "columna: " + column.ToString();
        }

        /*funcionalidad boton para guradar los errores que se produjeron en un 
         archivo con extension gtE*/
        private void btnGuardarError_Click(object sender, EventArgs e)
        {
            String pat = "";
            String error = txtSalidaError.Text;
            archivo.guardarErrores(error, pat);
        }

        private void itemProyecto_Click(object sender, EventArgs e)
        {
            archivo.obtenerPathProyecto();
            archivo.obtenerArchivoProyecto(lboxArchivosProyecto, lblProyecto);
        }

        private void lboxArchivosProyecto_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Get the currently selected item in the ListBox.
            string curItem = lboxArchivosProyecto.SelectedItem.ToString();
            archivo.abrirArchivoDeProyecto(txtIngresoCodigo, txtSalidaError, curItem);
        }

        private void itemCompilar_Click(object sender, EventArgs e)
        {
            pinta = new PintaTokens();
            automata = new Automata();
            automata.iniciarVaiables(pinta, txtSalidaError);
            obtenerTextoRichText();
            char[] token = mensaje.ToCharArray();
            column = 0;
            line = 0;
            foreach (char tok in token) {

                try
                {
                    automata.obtenerEstado(tok, txtSalidaError, line + 1, column);

                    pinta.pintarTextoReservada(txtIngresoCodigo);
                    pinta.pintarSignosOperadores(txtIngresoCodigo);
                    pinta.pintarTokensCompleto(txtIngresoCodigo, pinta.getCadenaTexto(), 3);
                    pinta.pintarTokensCompleto(txtIngresoCodigo, pinta.getNumeroEntero(), 0);
                    pinta.pintarTokensCompleto(txtIngresoCodigo, pinta.getNumeroDecimal(), 1);
                    pinta.pintarTokensCompleto(txtIngresoCodigo, pinta.getComentario(), 4);

                    if (tok.Equals('\n')){
                        line++;
                        column = 0;
                    } else
                    {
                        column++;
                    }
                }
                catch (Exception a)
                {
                    MessageBox.Show(a.ToString());
                }

            }
        }

        private void btnLimpiarSalida_Click(object sender, EventArgs e)
        {
            txtSalidaError.Clear();
        }
    }
}
