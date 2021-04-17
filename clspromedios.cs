using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejemplos_case8__arreglos.clases
{
    class clspromedios : InterfacePromedio
    {
        public string[,] Clasificar_Alumnos(string[,] matriz, string seccion)
        {


          
            string[,] clasi = new string[matriz.GetLength(0), 2];
            int totalfilas = matriz.GetLength(0);
            int contador = 0;
            for (int fila = 1; fila < matriz.GetLength(0); fila++)
            {
                if (matriz[fila, 5].Trim().Equals(seccion))
                {
                    clasi[contador, 0] = matriz[fila, 1];
                    clasi[contador, 1] = matriz[fila, 5];
                }
                contador++;
            }

            return clasi;

        }
         

        



    

        public int promedios_general_seccion(string[,] matriz, int columna_parcial, string seccion)
        {
                int acum = 0;
            double prom;
            int totalfilas = matriz.GetLength(0);
            int contador = 0;
            for (int fila = 1; fila < matriz.GetLength(0); fila++)
            {
                if (matriz[fila, 5].Trim().Equals(seccion))
                {
                    acum = acum+(Convert.ToInt32(matriz[fila,columna_parcial]));
                    contador++;
                }


            }
            prom = acum / contador;
            return Convert.ToInt32(prom);
        }

        public int promedios_por_parcial(string[,] matriz, int columna_parcial)
        {
            int acum = 0;
            int prom;
            int totalfilas = matriz.GetLength(0);

            for (int fila = 1; fila < matriz.GetLength(0); fila++)
            {
                acum = acum + Convert.ToInt32(matriz[fila, columna_parcial]);
            }
            prom = acum / (matriz.GetLength(0) - 1);
            return prom;
        }

        public int promedios_por_seccion(string[,] matriz, int columna_parcial, string seccion)
        {

                int acum = 0;
                double prom;
                int totalfilas = matriz.GetLength(0);
            int contador = 0;
                for (int fila = 1; fila < matriz.GetLength(0); fila++)
                {
                    if (matriz[fila,5].Trim().Equals(seccion))
                    {
                        acum = acum + Convert.ToInt32(matriz[fila, columna_parcial]);
                    contador++;
                }
                
                
            }
            prom = acum / contador;
                return Convert.ToInt32(prom);
               
            }
            
        

        public string[,] sumatoria_general_por_alumno(string[,] matriz)
        {

            double sum = 0;
            int totalfilas = matriz.GetLength(0);
            int contador = 0;
            string[,] sumgen = new string[matriz.GetLength(0), 2];
            
            for (int fila = 1; fila < matriz.GetLength(0); fila++)
            {
                
                sum = Convert.ToInt32(matriz[fila,2]) + Convert.ToInt32(matriz[fila, 3]) + Convert.ToInt32(matriz[fila, 4]);
                sumgen[contador, 0] = matriz[fila, 1];
                sumgen[contador, 1] =Convert.ToString(sum);
                contador++;
            }

            return sumgen;

        }

    }
}
