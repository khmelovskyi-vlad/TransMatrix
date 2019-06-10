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
            Console.WriteLine("Transpose matrices");
            var widht = Enter("matrix weiht");
            var height = Enter("matrix height");
            int[,] matrix = new int[widht, height];
            while (true)
            {
                try
                {
                    
                    for (int i = 0; i < matrix.GetLength(0); i++)
                    {
                        for (int j = 0; j < matrix.GetLength(1); j++)
                        {
                            var key = Console.ReadKey();
                            if (key.Key == ConsoleKey.Escape)
                            {
                                throw new OperationCanceledException();
                            }
                            var line = Console.ReadLine();
                            var keyLine = $"{key.KeyChar}{line}";
                            matrix[i, j] = Convert.ToInt32(keyLine);
                        }
                    }
                    break;
                }
                catch(FormatException ex)
                {
                    Console.WriteLine($"Bed input {ex.Message}, try again or click enter");
                }
            }
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
                for(int j = 0; j < matrix.GetLength(0); j++)
                {
                    Console.Write(String.Format("{0,3}", matrix[j, i]));
                }
                Console.WriteLine("");
            }
            Console.ReadKey();
        }
        static int Enter (string ent)
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
