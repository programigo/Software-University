namespace _05_Rubiks_Matrix
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        private static int[][] matrix = new int[1][];
        private static int rowSize = 0;
        private static int colSize = 0;

        public static void Main()
        {
            int[] size = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            rowSize = size[0];
            colSize = size[1];
            matrix = new int[rowSize][];

            PopulateMatrix();

            ShuffleMatrix();

            ReorderMatrix();
        }

        private static void PopulateMatrix()
        {
            for (int row = 0; row < rowSize; row++)
            {
                matrix[row] = new int[rowSize];

                for (int col = 0; col < colSize; col++)
                {
                    matrix[row][col] = (row * rowSize) + col + 1;
                }
            }
        }

        private static void ShuffleMatrix()
        {
            int commandCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < commandCount; i++)
            {
                string[] command = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                int rowOrCol = int.Parse(command[0]);
                int shiftTimes = int.Parse(command[2]);

                switch (command[1])
                {
                    case "left":
                        ShiftLeft(rowOrCol, shiftTimes);
                        break;

                    case "right":
                        ShiftRight(rowOrCol, shiftTimes);
                        break;

                    case "up":
                        ShiftUp(rowOrCol, shiftTimes);
                        break;

                    case "down":
                        ShiftDown(rowOrCol, shiftTimes);
                        break;
                }
            }
        }

        private static void ReorderMatrix()
        {
            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    int targetN = (row * rowSize) + col + 1;

                    if (matrix[row][col] == targetN)
                    {
                        Console.WriteLine("No swap required");
                    }
                    else
                    {
                        int index = -1;
                        for (int nestedRow = row; nestedRow < matrix.Length; nestedRow++)
                        {
                            index = Array.IndexOf(matrix[nestedRow], targetN);

                            if (index > -1)
                            {
                                matrix[nestedRow][index] = matrix[row][col];
                                matrix[row][col] = targetN;

                                Console.WriteLine($"Swap ({row}, {col}) with ({nestedRow}, {index})");
                                break;
                            }
                        }
                    }
                }
            }
        }

        private static void ShiftLeft(int row, int shiftTimes)
        {
            Queue<int> q = new Queue<int>();

            for (int col = 0; col < matrix[row].Length; col++)
            {
                q.Enqueue(matrix[row][col]);
            }

            for (int i = 0; i < shiftTimes; i++)
            {
                int temp = q.Dequeue();
                q.Enqueue(temp);
            }

            for (int col = 0; col < matrix[row].Length; col++)
            {
                matrix[row][col] = q.Dequeue();
            }
        }

        private static void ShiftRight(int row, int shiftTimes)
        {
            Queue<int> q = new Queue<int>();

            for (int col = matrix[row].Length - 1; col >= 0; col--)
            {
                q.Enqueue(matrix[row][col]);
            }

            for (int i = 0; i < shiftTimes; i++)
            {
                int temp = q.Dequeue();
                q.Enqueue(temp);
            }

            for (int col = matrix[row].Length - 1; col >= 0; col--)
            {
                matrix[row][col] = q.Dequeue();
            }
        }

        private static void ShiftUp(int col, int shiftTimes)
        {
            Queue<int> q = new Queue<int>();

            for (int row = 0; row < matrix.Length; row++)
            {
                q.Enqueue(matrix[row][col]);
            }

            for (int i = 0; i < shiftTimes; i++)
            {
                int temp = q.Dequeue();
                q.Enqueue(temp);
            }

            for (int row = 0; row < matrix.Length; row++)
            {
                matrix[row][col] = q.Dequeue();
            }
        }

        private static void ShiftDown(int col, int shiftTimes)
        {
            Queue<int> q = new Queue<int>();

            for (int row = matrix.Length - 1; row >= 0; row--)
            {
                q.Enqueue(matrix[row][col]);
            }

            for (int i = 0; i < shiftTimes; i++)
            {
                int temp = q.Dequeue();
                q.Enqueue(temp);
            }

            q = new Queue<int>(q.Reverse());

            for (int row = 0; row < matrix.Length; row++)
            {
                matrix[row][col] = q.Dequeue();
            }
        }
    }
}