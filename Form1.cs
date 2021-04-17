using ejemplos_case8__arreglos.clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ejemplos_case8__arreglos
{
    public partial class Form1 : Form
    {

        private string[] ArregloNotas;
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonArreglo_Click(object sender, EventArgs e)
        {
            int[] arreglo = new int[5]; //creando el arreglo
            arreglo[0] = 10;//asignando valor a la posicion 0 del arreglo
            arreglo[1] = 8;
            arreglo[2] = 16;
            arreglo[3] = 36;
            arreglo[4] = 1;

            ClsArreglos ObjArreglo = new ClsArreglos(arreglo);
            int[] resultado = ObjArreglo.MetodoBurbuja();

            for (int indice = 0; indice < resultado.Length; indice++)//esta diciendo que vaya de 0 hasta la ultima posicion del arreglo o vector
            {
                //  listBoxResultado.Items.Add(arreglo[indice]);
                listBoxResultado.Items.Add($"valor= {resultado[indice]} posicion={indice} ");

            }

            //podemos usar un for o un foreach y es lo mismo

            // foreach(int r in arreglo)//estamos diciendo que interactue r en arreglo que es el nombre del vector y el int es porque el vector es tipo int
            //{
            //   listBoxResultado.Items.Add(arreglo[indice]);
            //}

        }

        private void buttonCargar_Click(object sender, EventArgs e)
        {
            ClsArchivos ar = new ClsArchivos();
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Selecciona tu archivo plano ";
            ofd.InitialDirectory = @"C:\Users\W10\Downloads\archivoplano2.csv";
            ofd.Filter = "archivoplano2(*.csv)|*.csv";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                var archivo = ofd.FileName; //devuelve el nombre y el lugar del archivo
                string resultado = ar.LeerTodoArchivo(archivo);

                ArregloNotas = ar.LeerArchivo(archivo); //retorna arreglo

                textBoxContenido.Text = resultado;
            }

        }

        private void buttonNombres_Click(object sender, EventArgs e)
        {
            int contador = 0;
            string[] nombres = new string[ArregloNotas.Length - 1];
            foreach (string linea in ArregloNotas)
            {
                if (contador != 0)
                {
                    string[] datos = linea.Split(';'); //devuelve una posicion arreglo por cada punto y cma que divida los nombres
                    nombres[contador - 1] = datos[1];
                }

                contador++;
            }
            ClsArreglos arreglonombres = new ClsArreglos(nombres);
            string[] resultados = arreglonombres.MetodoBurbujaNombres();
            for (int indice = 0; indice < resultados.Length; indice++)//esta diciendo que vaya de 0 hasta la ultima posicion del arreglo o vector
            {
                listBoxNombres.Items.Add(resultados[indice]); //devuelve la posicion uno del arreglo datos que es el nombre
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (string linea in ArregloNotas)
            {

                string[] datos = linea.Split(';');
                parcial1.Items.Add(datos[2]);
                parcial2.Items.Add(datos[3]);
                parcial3.Items.Add(datos[4]);

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //para el primer parcial
            label1.Text = "Nota maximo de el primer parcial";
            label2.Text = "Nota minimo de el primer parcial";
            label3.Text = "promedio de el primer parcial";
            textBox1.Text = parcial1.Items.Cast<string>().Max(x => Convert.ToInt32(x)).ToString();
            textBox2.Text = parcial1.Items.Cast<string>().Min(x => Convert.ToInt32(x)).ToString();
            textBox3.Text = parcial1.Items.Cast<string>().Average(x => Convert.ToInt32(x)).ToString();

            //para el segundo parcial
            label4.Text = "Nota maximo de el segundo parcial";
            label5.Text = "Nota minimo de el segundo parcial";
            label6.Text = "promedio de el segundo parcial";
            textBox4.Text = parcial2.Items.Cast<string>().Max(x => Convert.ToInt32(x)).ToString();
            textBox5.Text = parcial2.Items.Cast<string>().Min(x => Convert.ToInt32(x)).ToString();
            textBox6.Text = parcial2.Items.Cast<string>().Average(x => Convert.ToInt32(x)).ToString();


            // para el tercer parcial
            label7.Text = "Nota maximo de el tercer parcial";
            label8.Text = "Nota minimo de el tercer parcial";
            label9.Text = "promedio de el tercer parcial";
            textBox7.Text = parcial3.Items.Cast<string>().Max(x => Convert.ToInt32(x)).ToString();
            textBox8.Text = parcial3.Items.Cast<string>().Min(x => Convert.ToInt32(x)).ToString();
           // textBox9.Text = parcial3.Items.Cast<string>().Average(x => Convert.ToInt32(x)).ToString();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void listBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void listBoxResultado_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            int contador = 0;
            string[,] ArregloDosDimensiones = new string[ArregloNotas.Length - 0, 6];
            foreach (string linea in ArregloNotas)
            {
                string[] datos = linea.Split(';');

                ArregloDosDimensiones[contador, 0] = datos[0];
                ArregloDosDimensiones[contador, 1] = datos[1];
                ArregloDosDimensiones[contador, 2] = datos[2];
                ArregloDosDimensiones[contador, 3] = datos[3];
                ArregloDosDimensiones[contador, 4] = datos[4];
                ArregloDosDimensiones[contador, 5] = datos[5];

                contador++;

            }
            clspromedios porparcial = new clspromedios();
            double promporparcial = porparcial.promedios_por_parcial(ArregloDosDimensiones,3);
            textBox12.Text = Convert.ToString(promporparcial);

            clspromedios porseccion = new clspromedios();
            double promporseccion = porseccion.promedios_por_seccion(ArregloDosDimensiones,4,"a");
            textBox11.Text = Convert.ToString(promporseccion);

            clspromedios secciongene = new clspromedios();
            double seccion = secciongene.promedios_general_seccion(ArregloDosDimensiones,2,"a");
            double seccion2 = secciongene.promedios_general_seccion(ArregloDosDimensiones, 3, "a");
            double seccion3 = secciongene.promedios_general_seccion(ArregloDosDimensiones, 4, "a");
            double promtot = (seccion + seccion2 + seccion3)/3;
            textBox10.Text = Convert.ToString(promtot);

            clspromedios sumgene = new clspromedios();
            string[,] suma = sumgene.sumatoria_general_por_alumno(ArregloDosDimensiones);
            for (int i=0;i<ArregloNotas.Length-1;i++)
            {
               listBox1.Items.Add(" "+ suma[i,0] + " " +suma[i,1]);
            }

            clspromedios clasificacion = new clspromedios();
            string[,] cl = clasificacion.Clasificar_Alumnos(ArregloDosDimensiones,"c");
            for (int i = 0; i < ArregloNotas.Length - 1; i++)
            {
                listBox2.Items.Add(" " + cl[i, 0] + " " + cl[i, 1]);
            }
        }

        private void listBox1_SelectedIndexChanged_2(object sender, EventArgs e)
        {

        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
