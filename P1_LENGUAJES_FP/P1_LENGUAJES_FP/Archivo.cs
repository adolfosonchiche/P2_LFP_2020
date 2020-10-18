using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
namespace P1_LENGUAJES_FP
{
class Archivo
{

/* declaracion de variables*/
        private String pat = "";
        protected String nuevoPat = "";
        protected String pathProyecto = "";

        /* Metodo para guardar un archivo nuevo o crear un archivo
         *tambien para guardar archivos ya creados*/
        public void guardarDocumeto(string mensaje)
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "gt files (*.gt)|*.gt";
            saveFile.FilterIndex = 2;
            saveFile.RestoreDirectory = true;

            if (pat.Equals(""))
            {
                try
                {

                    if (saveFile.ShowDialog() == DialogResult.OK)
                    {
                        if (File.Exists(saveFile.FileName))
                        {
                            pat = saveFile.FileName;
                            StreamWriter texto = File.CreateText(pat);
                            texto.Write(mensaje + "\n");
                            texto.Close();

                        }
                        else
                        {
                            pat = saveFile.FileName;
                            StreamWriter texto = File.CreateText(pat);
                            texto.Write(mensaje);
                            texto.Close();
                        }
                        MessageBox.Show("Archivo creado.", "Guardar archivo");
                    }
                    else
                    {
                        MessageBox.Show("no se creo nada.", "Guardaar Archivo");
                        pat = nuevoPat;
                    }

                }
                catch (Exception)
                {
                    MessageBox.Show("Error en guardar el archivo.", "Guardar archivo");
                    pat = nuevoPat;
                }

            }
            else
            {
                try
                {
                    StreamWriter texto = File.CreateText(pat);
                    texto.Write(mensaje);
                    texto.Close();
                    MessageBox.Show("Archivo guradado Exitosamente.", "Guardar archivo");
                }
                catch (Exception)
                {
                    MessageBox.Show("Error: no se puedo guardar el archivo", "Guardar Arcchivo");
                }
            }
        }

        /* Metodo para abrir un archivo*/
        public void abrirDocumetno(RichTextBox txt_ingreso, RichTextBox salidaError)
        {
            String resultado = "";
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Text documents (.gt)|*.gt";

            try
            {
                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    pat = openFile.FileName;
                    resultado = File.ReadAllText(pat);
                }
                txt_ingreso.Clear();
                txt_ingreso.AppendText(resultado);
                salidaError.Clear();
                MessageBox.Show("Archivo leido correctamente.", "Abrir archivo");

            }
            catch (Exception)
            {
                MessageBox.Show("Error en leer el archivo.", "Abrir archivo");
            }
        }

        /* Metodo para preguntar al usuario y guardar su seleccion
         * si desea guradar el archivo antes de cerrarlo */
        public void mensajeGuardar(String texto, String mensaje,
            RichTextBox txtIngresoCodigo, RichTextBox txtError)
        {
            string message = "Deseas guardar el documento.!";
            string caption = texto;
            MessageBoxButtons buttons = MessageBoxButtons.YesNoCancel;
            // mensaje en el text box
            DialogResult result = MessageBox.Show(message, caption, buttons);

            if (result == DialogResult.Yes)
            {
                guardarDocumeto(mensaje);
                txtIngresoCodigo.Clear();
                txtError.Clear();
                mensaje = "";
                pat = "";
            }
            else if (result == DialogResult.No)
            {
                txtIngresoCodigo.Clear();
                txtError.Clear();
                mensaje = "";
                pat = "";
            }

            if (texto.Equals("Nuevo documento") && result != DialogResult.Cancel)
            {
                guardarDocumeto("");
            }
        }

        /* Metodo que retorna el pat de un archivo*/
        public String getPat()
        {
            return pat;
        }

        /* Metodo para establecer un nuevo valor al pat de un archivo*/
        public void setPat(String pat)
        {
            this.pat = pat;
        }

        /* Metodo que guarda el pat anterior para que el usuario busque otro pat*/
        public void nuevoGuardar()
        {
            nuevoPat = pat;
            pat = "";
        }

        /* Metodo para guardar los errores que existen
         * que estan en la componente de salida
         *tambien para guardar archivos ya creados*/
        public void guardarErrores(string mensaje, String pat)
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "gt files (*.gtE)|*.gtE";
            saveFile.FilterIndex = 2;
            saveFile.RestoreDirectory = true;

            if (pat.Equals(""))
            {
                try
                {

                    if (saveFile.ShowDialog() == DialogResult.OK)
                    {
                        if (File.Exists(saveFile.FileName))
                        {
                            pat = saveFile.FileName;
                            StreamWriter texto = File.CreateText(pat);
                            texto.Write(mensaje + "\n");
                            texto.Close();

                        }
                        else
                        {
                            pat = saveFile.FileName;
                            StreamWriter texto = File.CreateText(pat);
                            texto.Write(mensaje);
                            texto.Close();
                        }
                        MessageBox.Show("Archivo creado.", "Guardar archivo");
                    }
                    else
                    {
                        MessageBox.Show("no se creo nada.", "Guardaar Archivo");
                    }

                }
                catch (Exception)
                {
                    MessageBox.Show("Error en guardar el archivo.", "Guardar archivo");
                    pat = nuevoPat;
                }

            }
            else
            {
                try
                {
                    StreamWriter texto = File.CreateText(pat);
                    texto.Write(mensaje);
                    texto.Close();
                    MessageBox.Show("Archivo guradado Exitosamente.", "Guardar archivo");
                }
                catch (Exception)
                {
                    MessageBox.Show("Error: no se puedo guardar el archivo", "Guardar Arcchivo");
                }
            }
        }

        /* Metodo para obtener el path de un proyecto*/
        public void obtenerPathProyecto()
        {

            try
            {

            FolderBrowserDialog folderDialog = new FolderBrowserDialog();
                folderDialog.ShowNewFolderButton = true;
            // Muestra el FolderBrowserDialog. 
            DialogResult result = folderDialog.ShowDialog();
                  
            if (result == DialogResult.OK)
            {
                 pathProyecto = folderDialog.SelectedPath;
                //Use folder path
            }
            else
            {
                    //Operation aborted by the user
                    MessageBox.Show("proyecto leido correctamente.", "Abrir Proyecto");
                }

                

            }
            catch (Exception)
            {
                MessageBox.Show("Error en leer el proyecto.", "Abrir Proyecto");
            }
        }

        public void obtenerArchivoProyecto(ListBox archivosProyecto)
        {
            if (!pathProyecto.Equals(""))
            {
                String[] listaArchivos = Directory.GetFiles(pathProyecto);
                int a = 0;
                foreach (var sfile in listaArchivos)
                {
                    
                    string [] archivo = sfile.Split("\\");
                    if (a == 0)
                    {
                        archivosProyecto.Items.Add("PROYECTO: " + archivo[archivo.Length-2]);
                    }
                    archivosProyecto.Items.Add("  " + archivo[archivo.Length - 1]);
                    a++;
                }
            }
            
        }
    }

}
