namespace _06.TargetPractice
{
    using System;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            int[] dimensions = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rows = dimensions[0];
            int cols = dimensions[1];
            char[,] charSnake = new char[rows, cols];
            string snake = Console.ReadLine();
            int[] shotParams = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int impactRow = shotParams[0];
            int impactCol = shotParams[1];
            int radius = shotParams[2];
            int currentPosition = 0;

            char curentLetter;

            for (int currentRow = rows - 1; currentRow >= 0; currentRow--)
            {
                for (int currentCol = cols - 1; currentCol >= 0; currentCol--)
                {
                    if (currentRow % 2 == 1 && currentCol == cols - 1)
                    {
                        int currentIteration = 0;
                        for (int i = 0; i < cols; i++)
                        {
                            curentLetter = snake[currentPosition];
                            charSnake[currentRow, currentIteration] = curentLetter;

                            int deltaRow = currentRow - impactRow;
                            int deltaCol = currentIteration - impactCol;

                            bool isInRadius = deltaRow * deltaRow + deltaCol * deltaCol <=
                                              radius * radius;

                            if (isInRadius)
                            {
                                charSnake[currentRow, currentIteration] = ' ';
                            }

                            currentPosition++;

                            if (currentPosition > snake.Length - 1)
                            {
                                currentPosition = 0;
                            }

                            currentIteration++;
                        }

                        if (currentIteration == cols)
                        {
                            break;
                        }
                    }
                    else
                    {
                        curentLetter = snake[currentPosition];
                        charSnake[currentRow, currentCol] = curentLetter;

                        int deltaRow = currentRow - impactRow;
                        int deltaCol = currentCol - impactCol;

                        bool isInRadius = deltaRow * deltaRow + deltaCol * deltaCol <=
                                          radius * radius;

                        if (isInRadius)
                        {
                            charSnake[currentRow, currentCol] = ' ';
                        }

                        currentPosition++;

                        if (currentPosition > snake.Length - 1)
                        {
                            currentPosition = 0;
                        }
                    }
                }
            }

            int width = cols;

            for (int row = rows - 1; row >= 0; row--)
            {
                for (int column = 0; column < width; column++)
                {
                    if (charSnake[row, column] != ' ')
                    {
                        continue;
                    }

                    int currentRow = row - 1;
                    while (currentRow >= 0)
                    {
                        if (charSnake[currentRow, column] != ' ')
                        {
                            charSnake[row, column] = charSnake[currentRow, column];
                            charSnake[currentRow, column] = ' ';
                            break;
                        }

                        currentRow--;
                    }
                }
            }

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(charSnake[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}