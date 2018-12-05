using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;

namespace ExamenUnidad5
{
    public class BubbleSort
    {
        int[] arreglo;
        int tam = 0, temp = 0;

        public void Captura()//Captura del tamaño del arreglo y de los datos
        {
            Console.WriteLine("\t\t\tMetodo de la burbuja\n");
            Console.WriteLine("Inserta el tamaño del arreglo: ");//Entrada del tamaño del array
            tam = int.Parse(Console.ReadLine());
            arreglo = new int[tam];

            for (int i = 0; i < tam; i++)
            {
                Console.WriteLine("Inserta el valor {0} del arreglo: ", i + 1);//Entrada de datos de los n numeros
                arreglo[i] = int.Parse(Console.ReadLine());
            }
            Ordernamiento();//Llamada al metodo para ordenar el arreglo
        }

        public void Ordernamiento()
        {
            for (int i = 0; i < arreglo.Length; i++)//Ciclo for que va desde el primer elemento hasta el ultimo
            {
                for (int j = 0; j < arreglo.Length - 1; j++)//Otro ciclo for para poder ir comparando uno con otro
                {
                    if (arreglo[j] > arreglo[j + 1])//La comparacion del "primer" elemento con el siguiente
                    {
                        temp = arreglo[j]; //La variable temporal toma el valor de la posicion j ya que es el mas grande
                        arreglo[j] = arreglo[j + 1]; //El numero de la posicion actual se iguala por el de la siguiente posicion
                        arreglo[j + 1] = temp; // El valor de la siguiente posicion se iguala al valor que teniamos almacenado en temporal
                    }

                }
            }       
            Console.WriteLine("Los valores ordenados son: ");
            foreach (var item in arreglo)//Un foreach para imprimir todos los elementos del arreglo
            {
                Console.Write(item + " ");//Imprime el elemento con un espacio despues del numero
            }
        }

    }

    class Example
    {
        private List<int> k = new List<int>();//
        private IList<IList<int>> digitos = new List<IList<int>>();//Creamos una lista de listas donde guardaremos los arreglos
        private int maxLength = 0;
        Random random = new Random();
        List<int> listaNumeros = new List<int>();
        int numeroAleatorio;

        public Example()
        {

            for (int i = 0; i < 80; i++)
            {
                do
                {
                    numeroAleatorio = random.Next(1,800);
                } while (listaNumeros.Contains(numeroAleatorio));
                listaNumeros.Add(numeroAleatorio);
            }
        }

        public void InsertarValores()//Mandamos los valores a test mehtod
        {
            Prueba(listaNumeros, 1);
          
        }

        public void Prueba(List<int> lista, int num)//Los recibe en sus PARAMETERS
        {
            for (int i = 0; i < 10; i++)//Un ciclo para agregarle listas a la lista digios
            {
                digitos.Add(new List<int>());
            }
            for (int i = 0; i < lista.Count; i++)
            {

                if (maxLength < lista[i].ToString().Length)//Una condicion iterativa a traves de los valores del arreglo
                    maxLength = lista[i].ToString().Length;
            }
            RadixSort(lista, num);
        }

        public void RadixSort(List<int> lista, int num)
        {
            for (int i = 0; i < maxLength; i++)
            {
                for (int j = 0; j < lista.Count; j++)
                {
                    int digit = (int)((lista[j] % Math.Pow(10, i + 1)) / Math.Pow(10, i));//A technique  para conseguir los digito y le arregamos los valores del arreglo actual

                    digitos[digit].Add(lista[j]);//El digito sera la posicion de la lista de digitos, donde iremos agregando os valores del arreglo mientras itera
                }

                int index = 0;
                for (int k = 0; k < digitos.Count; k++)
                {
                    IList<int> selDigit = digitos[k];

                    for (int l = 0; l < selDigit.Count; l++)
                    {
                        lista[index++] = selDigit[l];
                    }
                }
                ClearDigits();
            }
            printSortedData(lista, num);
        }
        private void ClearDigits()
        {
            for (int k = 0; k < digitos.Count; k++)
            {
                digitos[k].Clear();
            }
        }


        public void printSortedData(List<int> ordenado, int num)
        {
            Console.WriteLine("\t\t\tMetodo Radix\n");
            Console.WriteLine("Lista ordenada {0}: ", num);
            for (int i = 0; i < ordenado.Count; i++)
            {
                Console.WriteLine(ordenado[i]);
            }
        }



        public static void ShellSort()
        {
            int temporal;
            //Entrada de datos
            Console.WriteLine("\t\t\tMetodo Shell Sort\n");
            Console.Write("Inserta el tamaño del arreglo: ");
            int tam = int.Parse(Console.ReadLine());
            int[] arreglo = new int[tam];
            for (int i = 0; i < arreglo.Length; i++)
            {
                Console.Write("Inserta el numero {0}: ", i + 1);
                arreglo[i] = int.Parse(Console.ReadLine());
            }
            int partitura = arreglo.Length;
            do
            {
                partitura = (partitura + 1) / 2;
                for (int i = 0; i < (arreglo.Length - partitura); i++)
                {
                    if (arreglo[i + partitura] > arreglo[i])
                    {
                        temporal = arreglo[i + partitura];
                        arreglo[i + partitura] = arreglo[i];
                        arreglo[i] = temporal;
                    }
                }
            } while (partitura > 1);
            Console.WriteLine("Arreglo ordenado de forma descendente:");
            foreach (var item in arreglo)
            {
                Console.Write(item + " ");
            }

        }
        public static void Quick_Sort(IComparable[] arreglo, int left, int right)
        {
        
            int izq = left, derecha = right;
            IComparable pivot = arreglo[(left + right) / 2];

            while (izq <= derecha)
            {
                while (arreglo[izq].CompareTo(pivot) < 0)
                {
                    izq++;
                }

                while (arreglo[derecha].CompareTo(pivot) > 0)
                {
                    derecha--;
                }

                if (izq <= derecha)
                {
                    IComparable temporal = arreglo[izq];
                    arreglo[izq] = arreglo[derecha];
                    arreglo[derecha] = temporal;

                    izq++;
                    derecha--;
                }
            }

           

            if (left < derecha)
            {
                Quick_Sort(arreglo, left, derecha);
            }

            if (izq < right)
            {
                Quick_Sort(arreglo, izq, right);
            }
        }

        public static void InsertarDatos()
        {
            string[] frase = { "Lorem", "ipsum", "dolor", "sit", "amet", "consectetur", "adipiscing", "elit", "Fusce", "varius", "augue", "vitae", "tincidunt", "viverra", "sem", "felis", "bibendum", "nisl", "id", "cursus", "diam", "leo", "sit", "amet", "urna", "Duis", "ac", "massa", "est" };
            Quick_Sort(frase, 0, frase.Length - 1);
            Console.WriteLine("\n\t\t\tMetodo Quick Sort -  para string\n\n");
            foreach (var item in frase)
            {
                Console.Write(item + " ");
            }
        }
        class MainClass
        {
            public static void Main(string[] args)
            {
                BubbleSort burbuja = new BubbleSort();// Bubble Sort
                burbuja.Captura();//Bubble Sort
                Console.ReadKey();//Separador------------------------
                Example radix = new Example();//Radix Method
                radix.InsertarValores();//Radix Method
                Console.ReadKey();//Separador------------------------
                ShellSort();//Shell Sort
                Console.ReadKey();//Separador------------------------
                InsertarDatos();//Quick Sort
                Console.ReadKey();
         
            }
        }
    }
}