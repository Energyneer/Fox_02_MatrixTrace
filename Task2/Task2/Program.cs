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
            matrix.PrintMatrix();
            Console.WriteLine("Matrix trace = " + matrix.CalcTraceMatrix());
            Console.WriteLine("Snake: " + string.Join(",", matrix.SnakeArray()));
        }
    }
}
