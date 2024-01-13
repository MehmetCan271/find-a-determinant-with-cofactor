using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter the size of the square matrix (at least 3):");
        int size = Convert.ToInt32(Console.ReadLine());

        if (size < 3)
        {
            Console.WriteLine("The matrix size should be at least 3.");
            return;
        }

        double[,] matrix = new double[size, size];

        Console.WriteLine($"Enter the elements of the matrix ({size}x{size}):");

        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                Console.Write($"Element [{i + 1},{j + 1}]: ");
                matrix[i, j] = Convert.ToDouble(Console.ReadLine());
            }
        }

        double determinant = CalculateDeterminant(matrix);
        Console.WriteLine($"Determinant of the matrix: {determinant}");
    }

    static double CalculateDeterminant(double[,] matrix)
    {
        int size = matrix.GetLength(0);

        if (size == 2)
        {
            // Determinant of a 2x2 matrix
            return matrix[0, 0] * matrix[1, 1] - matrix[0, 1] * matrix[1, 0];
        }

        double determinant = 0;

        for (int i = 0; i < size; i++)
        {
            determinant += matrix[0, i] * Cofactor(matrix, 0, i);
        }

        return determinant;
    }

    static double Cofactor(double[,] matrix, int row, int col)
    {
        int size = matrix.GetLength(0);
        double[,] minorMatrix = new double[size - 1, size - 1];

        int minorRow = 0, minorCol = 0;
        for (int i = 0; i < size; i++)
        {
            if (i == row) continue;

            for (int j = 0; j < size; j++)
            {
                if (j == col) continue;

                minorMatrix[minorRow, minorCol] = matrix[i, j];
                minorCol++;
            }

            minorRow++;
            minorCol = 0;
        }

        return Math.Pow(-1, row + col) * CalculateDeterminant(minorMatrix);
    }
}
