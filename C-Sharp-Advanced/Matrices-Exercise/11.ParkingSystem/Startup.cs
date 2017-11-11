namespace _11.ParkingSystem
{
    using System;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            var size = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
                .ToArray();
            var matrix = new int[size[0]][];
            for (int row = 0; row < matrix.Length; row++)
            {
                matrix[row] = new int[size[1]];
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    matrix[row][col] = 0;
                }
            }
            var line = Console.ReadLine();
            while (line != "stop")
            {
                var input = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                int enterRow = input[0];
                int enterCol = 0;
                int parkRow = input[1];
                int parkCol = input[2];
                bool parked = false;
                if (matrix[parkRow][parkCol] == 0)
                {
                    matrix[parkRow][parkCol] = 1;
                    parked = true;
                }
                else
                {
                    for (int i = 1; i < size[1]; i++)
                    {
                        if (parkCol - i > 0)
                        {
                            if (matrix[parkRow][parkCol - i] == 0)
                            {
                                matrix[parkRow][parkCol - i] = 1;
                                parkCol -= i;
                                parked = true;
                                break;
                            }
                        }
                        if (parkCol + i < size[1])
                        {
                            if (matrix[parkRow][parkCol + i] == 0)
                            {
                                matrix[parkRow][parkCol + i] = 1;
                                parkCol += i;
                                parked = true;
                                break;
                            }
                        }
                    }
                }
                if (!parked)
                {
                    Console.WriteLine($"Row {parkRow} full");
                }
                else
                {
                    int sum = Math.Abs(parkCol - enterCol) + Math.Abs(parkRow - enterRow);
                    Console.WriteLine(sum + 1);
                }
                line = Console.ReadLine();
            }
        }
    }
}