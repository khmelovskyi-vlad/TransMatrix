using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int width, height;
            int[,] matrix;
            Matrix(out matrix, out width, out height);
            Console.WriteLine("Your matrix is");
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(String.Format("{0,3}", matrix[i, j]));
                }
                Console.WriteLine("");
            }
            Console.WriteLine("Your transponing matrix is");
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                for (int j = 0; j < matrix.GetLength(0); j++)
                {
                    Console.Write(String.Format("{0,3}", matrix[j, i]));
                }
                Console.WriteLine("");
            }
            Console.ReadKey();
        }
        static void Matrix(out int[,] mat, out int width, out int height)
        {
            Console.WriteLine("Transpose matrices");
            width = Enter("matrix weiht");
            height = Enter("matrix height");
            mat = new int[width, height];
            Console.WriteLine("Enter matrix");
            while (true)
            {
                try
                {

                    for (int i = 0; i < mat.GetLength(0); i++)
                    {
                        for (int j = 0; j < mat.GetLength(1); j++)
                        {
                            var key = Console.ReadKey();
                            if (key.Key == ConsoleKey.Escape)
                            {
                                throw new OperationCanceledException();
                            }
                            var line = Console.ReadLine();
                            var keyLine = $"{key.KeyChar}{line}";
                            mat[i, j] = Convert.ToInt32(keyLine);
                        }
                    }
                    break;
                }
                catch (FormatException ex)
                {
                    Console.WriteLine($"Bed input {ex.Message}, try again or click enter");
                }
            }
        }
        static int Enter(string ent)
        {
            do
            {
                try
                {
                    Console.WriteLine($"Enter {ent}");
                    var key = Console.ReadKey();
                    if (key.Key == ConsoleKey.Escape)
                    {
                        throw new OperationCanceledException();
                    }
                    var line = Console.ReadLine();
                    var keyLine = $"{key.KeyChar}{line}";
                    return Convert.ToInt32(keyLine);
                }
                catch (FormatException ex)
                {
                    Console.WriteLine($"Bed input {ex.Message}, try again or click escape");
                }
            } while (true);
        }
    }
}