using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace LectorDeArchivos
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //using System.IO;
            Stream myStream = null;
            OpenFileDialog openFileDialog1 = new OpenFileDialog(); //instancia con la que se abre el buscador

            openFileDialog1.InitialDirectory = ""; //lo abre en el directorio especificado ej. c:\\
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*"; //muestra todos los archivos
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;


            if (openFileDialog1.ShowDialog(this) == DialogResult.OK)
            {
                String strfilename = openFileDialog1.InitialDirectory + openFileDialog1.FileName; //agrega a la direccion el nombre del archivo
                textBox1.Text = strfilename;
            }


            

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((myStream = openFileDialog1.OpenFile()) != null)//checa que el stream sea igual al archivo abierto
                    {                                                   //y que no sea nulo
                        using (myStream)
                        {

                            using (StreamReader lector = new StreamReader(myStream))
                            {
                                string contenido = lector.ReadToEnd();
                                textBox2.Text = contenido;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }

        
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
