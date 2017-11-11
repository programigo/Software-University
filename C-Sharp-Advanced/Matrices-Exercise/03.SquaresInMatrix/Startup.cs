namespace _03.SquaresInMatrix
{
    using System;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            int[] input =
                Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int rows = input[0];
            int cols = input[1];

            string[][] matrix = new string[rows][];

            int squaresCount = 0;

            for (int currentRow = 0; currentRow < rows; currentRow++)
            {
                matrix[currentRow] =
                    Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            }

            for (int row = 0; row < matrix.Length - 1; row++)
            {
                for (int col = 0; col < matrix[row].Length - 1; col++)
                {
                    string topLeftLetter = matrix[row][col];
                    string topRightLetter = matrix[row][col + 1];
                    string bottomLeftLetter = matrix[row + 1][col];
                    string bottomRightLetter = matrix[row + 1][col + 1];

                    if (topLeftLetter == topRightLetter && topLeftLetter == bottomLeftLetter && topLeftLetter == bottomRightLetter)
                    {
                        squaresCount++;
                    }
                }
            }

            Console.WriteLine(squaresCount);
        }
    }
}