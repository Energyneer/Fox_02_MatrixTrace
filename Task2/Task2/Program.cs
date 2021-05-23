using System;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter number columns: ");
            int cols = int.Parse(Console.ReadLine());
            Console.Write("Enter number rows: ");
            int rows = int.Parse(Console.ReadLine());

            Matrix matrix = new Matrix(rows, cols);
            PrintMatrix(matrix.MatrixArray);
            Console.WriteLine("Matrix trace = " + matrix.CalcTraceMatrix());
            Console.WriteLine("Snake: " + string.Join(",", matrix.SnakeArray()));
        }

        private static void PrintMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (i == j)
                        Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(matrix[i, j]);
                    if (i == j)
                        Console.ResetColor();
                    PrintCellsSeparator(matrix[i, j]);
                }
                Console.WriteLine();
            }
        }

        private static void PrintCellsSeparator(int value)
        {
            int spaces = 3;
            if (value > 9)
                spaces--;
            if (value > 99)
                spaces--;

            for (int i = spaces; i > 0; i--)
            {
                Console.Write(" ");
            }
        }
    }
}
