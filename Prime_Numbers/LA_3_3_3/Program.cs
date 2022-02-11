using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LA_3_3_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Input the size of your i-index of your array:");
            int arraySize = int.Parse(Console.ReadLine());

            Console.WriteLine("Input the size of yourk-index of your array:");
            int arraySize2 = int.Parse(Console.ReadLine());

            Console.WriteLine("Input your seed size:");
            int seedSize = int.Parse(Console.ReadLine());

            int[,] myArray = CreateArray(arraySize,arraySize2, seedSize);
            Console.Write("The array looks like: ");
            PrintArray(myArray);
            PrimeNumber(myArray);
            Console.Read();
        }
        static int[,] CreateArray(int arraySize, int arraySize2,int seedSize)
        {
            int[,] arrayValues = new int[arraySize, arraySize2];
            Random random = new Random(seedSize);
            for (int i = 0; i < arraySize; i++)
            {
                for (int j = 0; j < arraySize2; j++)
                {
                    arrayValues[i,j] = random.Next(2, seedSize);
                }
                             }
            return arrayValues;
        }
        static void PrintArray(int[,] arrayValues)
        {
            for (int i = 0; i < arrayValues.GetLength(0); i++)
            {
                for (int j = 0; j < arrayValues.GetLength(1); j++)
                {
                    Console.Write(string.Format("{0,3}", arrayValues[i, j]) + " ");
                }        
            }
            Console.WriteLine();
        }
        
        static void PrimeNumber(int [,] myArray)
        {
            for (int i = 0; i < myArray.GetLength(0); i++)
            {
                for (int j = 0; j < myArray.GetLength(1); j++)
                {
                    if (IsPrimeOrNot(myArray[i, j]))
                       {
                        Console.Write(" {0} ", myArray[i, j]);
                       }
                    else
                        {
                        Console.Write(" - - ", myArray[i, j]);
                     }
                }
            }    
        } 
        static bool IsPrimeOrNot(int value)
        {
            bool isPrime = true;
            for (int i=2; i <= Math.Ceiling(Math.Sqrt(value)); i++)
            {
                if (value % i == 0)
                {
                    isPrime = false;
                }
            }
            return isPrime;
        }
    }
}
