namespace _02.DiagonalDifference
{
    using System;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            int[][] matrix = new int[n][];

            for (int row = 0; row < n; row++)
            {
                matrix[row] =
                    Console.ReadLine()
                        .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse)
                        .ToArray();
            }

            int primaryDiagonalSum = 0;
            int secondaryDiagonalSum = 0;

            int currentRow = 0;
            int currentCol = 0;

            while (currentRow < matrix.Length)
            {
                int currentNumber = matrix[currentRow][currentCol];

                primaryDiagonalSum += currentNumber;

                currentRow++;
                currentCol++;
            }

            currentRow = 0;
            currentCol = matrix.Length - 1;

            while (currentCol >= 0)
            {
                int currentNumber = matrix[currentRow][currentCol];

                secondaryDiagonalSum += currentNumber;

                currentRow++;
                currentCol--;
            }

            int difference = Math.Abs(primaryDiagonalSum - secondaryDiagonalSum);

            Console.WriteLine(difference);
        }
    }
}