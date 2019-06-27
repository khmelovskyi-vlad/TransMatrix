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
            Console.WriteLine("Transponing matrix");
            int[,] matrix = ReadMatrix();
            WriteMatrix(matrix);
            WriteTransMartix(matrix);
            Console.ReadKey();
        }
        static int[,] ReadMatrix()
        {
            var (n, m) = ReadBorder();
            Console.WriteLine("Write matrix");
            int[,] matrix = new int[n, m];
            for(int i = 0; i < n; i++)
            {
                for(int j = 0; j < m; j++)
                {
                    matrix[i, j] = ReadIntUntil(' ');
                }
                Console.WriteLine("");
            }
            return matrix;
            
        }
        static int ReadIntUntil(params char[] unitSymbol)
        {
            StringBuilder sb = new StringBuilder();
            while (true)
            {
                try
                {
                    var key = Console.ReadKey(true);
                    if (key.Key != ConsoleKey.Enter)
                    {
                        Console.Write(key.KeyChar);
                        if (key.Key == ConsoleKey.Escape)
                        {
                            throw new OperationCanceledException();
                        }
                        else if (key.Key == ConsoleKey.Backspace)
                        {
                            sb.Remove(sb.Length - 1, 1);
                        }
                        else if (unitSymbol.Contains(key.KeyChar))
                        {
                            return Int32.Parse(sb.ToString());
                        }
                        else
                        {
                            sb.Append(key.KeyChar);
                        }
                    }
                }
                catch (FormatException ex)
                {
                    sb.Remove(0, sb.Length);
                    Console.Write($"Bed input {ex.Message}, try again or click Escape ");
                }
            }
        }
        static (int n, int m) ReadBorder()
        {
            Console.WriteLine("Enter matrix size n:m");
            Console.Write("n = ");
            var n = ReadInt();
            Console.Write("m = ");
            var m = ReadInt();
            return (n, m);
        }
        static int ReadInt()
        {
            do
            {
                try
                {
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
        static void WriteMatrix (int[,] matrix)
        {
            Console.WriteLine("Your matrix is: ");
            for(int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write($"{matrix[i, j]}\t");
                }
                Console.WriteLine();
            }
        }
        static void WriteTransMartix (int[,] matrix)
        {
            Console.WriteLine("Transponing matrix is: ");
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                for(int j = 0; j < matrix.GetLength(0); j++)
                {
                    Console.Write($"{matrix[j, i]}\t");
                }
                Console.WriteLine();
            }
        }
    }
}