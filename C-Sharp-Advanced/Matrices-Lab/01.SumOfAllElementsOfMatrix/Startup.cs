namespace _01.SumMatrixElements
{
    using System;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            var dimensions = Console.ReadLine().Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int[][] matrix = new int[dimensions[0]][];

            int sum = 0;

            for (int row = 0; row < matrix.Length; row++)
            {
                matrix[row] =
                    Console.ReadLine()
                        .Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse)
                        .ToArray();
            }

            int rows = dimensions[0];
            int cols = dimensions[1];

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    sum += matrix[row][col];
                }
            }

            Console.WriteLine(rows);
            Console.WriteLine(cols);
            Console.WriteLine(sum);
        }
    }
}