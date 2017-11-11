namespace _02.SquareWithMaximumSum
{
    using System;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            var dimensions = Console.ReadLine().Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int[][] matrix = new int[dimensions[0]][];

            int maxRow = 0;
            int maxCol = 0;
            int maxSum = int.MinValue;

            for (int row = 0; row < matrix.Length; row++)
            {
                matrix[row] =
                    Console.ReadLine()
                        .Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse)
                        .ToArray();
            }

            for (int row = 0; row < matrix.Length - 1; row++)
            {
                for (int col = 0; col < matrix[row].Length - 1; col++)
                {
                    int topLeft = matrix[row][col];
                    int topRight = matrix[row][col + 1];
                    int bottomLeft = matrix[row + 1][col];
                    int bottomRight = matrix[row + 1][col + 1];

                    int currentSum = topLeft + topRight + bottomLeft + bottomRight;

                    if (maxSum < currentSum)
                    {
                        maxSum = currentSum;
                        maxRow = row;
                        maxCol = col;
                    }
                }
            }

            Console.WriteLine($"{matrix[maxRow][maxCol]} {matrix[maxRow][maxCol + 1]}\n{matrix[maxRow + 1][maxCol]} {matrix[maxRow + 1][maxCol + 1]}");
            Console.WriteLine(maxSum);
        }
    }
}