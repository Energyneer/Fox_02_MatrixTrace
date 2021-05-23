using System;

namespace Task2
{
    public class Matrix
    {
        public int[,] MatrixArray
        {
            get
            {
                return matrixArray;
            }
            set
            {
                if (value != null)
                {
                    matrixArray = value;
                    rows = value.GetLength(0);
                    cols = value.GetLength(1);
                }
            }
        }
        private int[,] matrixArray;
        private int rows;
        private int cols;

        public Matrix(int rows, int columns)
        {
            if (columns < 1 || rows < 1)
            {
                Console.WriteLine("Input params isn't correct");
                matrixArray = new int[1, 1];
            }
            else
            {
                matrixArray = new int[rows, columns];
            }

            this.rows = matrixArray.GetLength(0);
            this.cols = matrixArray.GetLength(1);

            Random rnd = new Random();
            for (int i = 0; i < this.rows; i++)
            {
                for (int j = 0; j < this.cols; j++)
                {
                    matrixArray[i, j] = rnd.Next(0, 101);
                }
            }
        }

        public decimal CalcTraceMatrix()
        {
            decimal summ = 0;
            for (int i = 0; i < Math.Min(rows, cols); i++)
            {
                summ += matrixArray[i, i];
            }
            return summ;
        }

        public int[] SnakeArray()
        {
            int[] snakeArray = new int[matrixArray.Length];
            byte direction = 1;
            int currentRowIndex = 0, currentColIndex = 0;
            
            for (int i = 0; i < matrixArray.Length; i++)
            {
                snakeArray[i] = matrixArray[currentRowIndex, currentColIndex];

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
