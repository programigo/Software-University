namespace _04.MaximalSum
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

            int[][] matrix = new int[rows][];

            for (int currentRow = 0; currentRow < rows; currentRow++)
            {
                matrix[currentRow] =
                    Console.ReadLine()
                        .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse)
                        .ToArray();
            }

            int topLeftCell = 0;
            int topMidCell = 0;
            int topRightCell = 0;
            int middleLeftCell = 0;
            int middleMidCell = 0;
            int middleRightCell = 0;
            int bottomLeftCell = 0;
            int bottomMidCell = 0;
            int bottomRightCell = 0;

            int biggestSum = int.MinValue;

            for (int row = 0; row < matrix.Length - 2; row++)
            {
                for (int col = 0; col < matrix[row].Length - 2; col++)
                {
                    int currenttopLeftCell = matrix[row][col];
                    int currenttopMidCell = matrix[row][col + 1];
                    int currenttopRightCell = matrix[row][col + 2];
                    int currentmiddleLeftCell = matrix[row + 1][col];
                    int currentmiddleMidCell = matrix[row + 1][col + 1];
                    int currentmiddleRightCell = matrix[row + 1][col + 2];
                    int currentbottomLeftCell = matrix[row + 2][col];
                    int currentbottomMidCell = matrix[row + 2][col + 1];
                    int currentbottomRightCell = matrix[row + 2][col + 2];

                    int currentBiggestSum = currenttopLeftCell + currenttopMidCell + currenttopRightCell +
                                            currentmiddleLeftCell + currentmiddleMidCell + currentmiddleRightCell +
                                            currentbottomLeftCell + currentbottomMidCell + currentbottomRightCell;

                    if (biggestSum < currentBiggestSum)
                    {
                        biggestSum = currentBiggestSum;

                        topLeftCell = currenttopLeftCell;
                        topMidCell = currenttopMidCell;
                        topRightCell = currenttopRightCell;
                        middleLeftCell = currentmiddleLeftCell;
                        middleMidCell = currentmiddleMidCell;
                        middleRightCell = currentmiddleRightCell;
                        bottomLeftCell = currentbottomLeftCell;
                        bottomMidCell = currentbottomMidCell;
                        bottomRightCell = currentbottomRightCell;
                    }
                }
            }

            Console.WriteLine($"Sum = {biggestSum}");

            Console.WriteLine($"{topLeftCell} {topMidCell} {topRightCell}");
            Console.WriteLine($"{middleLeftCell} {middleMidCell} {middleRightCell}");
            Console.WriteLine($"{bottomLeftCell} {bottomMidCell} {bottomRightCell}");
        }
    }
}