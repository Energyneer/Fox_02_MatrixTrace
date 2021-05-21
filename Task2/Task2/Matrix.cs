using System;

namespace Task2
{
    public class Matrix
    {
        public int[,] MatrixForTest
        {
            get
            {
                return matrix;
            }
        }
        private readonly int[,] matrix;
        private readonly int rows;
        private readonly int cols;

        public Matrix(int rows, int columns)
        {
            if (columns < 1 || rows < 1)
            {
                Console.WriteLine("Input params isn't correct");
                matrix = new int[1, 1];
            }
            else
            {
                matrix = new int[rows, columns];
            }

            this.rows = matrix.GetLength(0);
            this.cols = matrix.GetLength(1);

            Random rnd = new Random();
            for (int i = 0; i < this.rows; i++)
            {
                for (int j = 0; j < this.cols; j++)
                {
                    matrix[i, j] = rnd.Next(0, 101);
                }
            }
        }

        public void PrintMatrix()
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    PrintMatrixCell(j, i);
                }
                Console.WriteLine();
            }
        }

        void PrintMatrixCell(int column, int row)
        {
            if (column == row)
                Console.ForegroundColor = ConsoleColor.Green;

            Console.Write(matrix[row, column]);

            if (column == row)
                Console.ResetColor();

            PrintCellsSeparator(matrix[row, column]);
        }

        // Align columns with spaces
        private void PrintCellsSeparator(int value)
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

        public decimal CalcTraceMatrix()
        {
            decimal summ = 0;
            for (int i = 0; i < Math.Min(rows, cols); i++)
            {
                summ += matrix[i, i];
            }
            return summ;
        }

        public int[] SnakeArray()
        {
            int[] snakeArray = new int[matrix.Length];

            /*  Direction of moving: 1: Left > Right; 65: Top > Down;
             *  129: Right > Left; 193: Down > Top;
             */
            byte direction = 1;
            int currentRowIndex = 0, currentColIndex = 0;
            
            for (int i = 0; i < matrix.Length; i++)
            {
                snakeArray[i] = matrix[currentRowIndex, currentColIndex];

                // Change direction if current cell is on the diagonal
                if (isDiagonal(currentRowIndex, currentColIndex))
                    direction += 64;

                switch (direction)
                {
                    case 1: currentColIndex++; break;
                    case 65: currentRowIndex++; break;
                    case 129: currentColIndex--; break;
                    case 193: currentRowIndex--; break;
                }
            }
            return snakeArray;
        }

        private bool isDiagonal(int row, int col)
        {
            bool leftSector = col <= (cols - 2) / 2;
            bool upSector = row <= (rows - 1) / 2;

            return (leftSector && upSector && (row == col + 1)) ||
                    (!leftSector && upSector && (cols - 1 - col == row)) ||
                    (!leftSector && !upSector && (cols - 1 - col == rows - 1 - row)) ||
                    (leftSector && !upSector && (rows - 1 - row == col));
        }
    }
}
