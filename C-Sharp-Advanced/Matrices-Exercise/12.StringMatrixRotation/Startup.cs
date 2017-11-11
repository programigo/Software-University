namespace _12_StringMatrixRotation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class Startup
    {
        public static void Main()
        {
            var matrix = new List<Queue<char>>();

            var rotations = new Queue<int>();
            var rotRegex = new Regex(@"(\d+)");

            // parse input
            while (true)
            {
                var cmd = Console.ReadLine();

                if (cmd == "END")
                {
                    break;
                }

                if (rotRegex.IsMatch(cmd))
                {
                    var degree = rotRegex.Match(cmd).Groups[1].Value;
                    rotations.Enqueue(int.Parse(degree));
                }
                else
                {
                    matrix.Add(new Queue<char>(cmd.ToCharArray()));
                }
            }

            // extend queues
            var width = matrix.Max(s => s.Count);
            var height = matrix.Count;

            foreach (var q in matrix)
            {
                if (q.Count < width)
                {
                    while (q.Count != width)
                    {
                        q.Enqueue(' ');
                    }
                }
            }

            // compute target rotation
            var totalRotation = rotations.Sum();
            var degreeReach = (totalRotation >= 360) ? totalRotation % 360 : totalRotation;

            var quarterRotations = degreeReach / 90;

            // apply rotation
            bool compareWidth = true;
            for (int i = 0; i < quarterRotations; i++)
            {
                var buffer = new List<Queue<char>>();
                for (int c = 0; c < ((compareWidth) ? width : height); c++)
                {
                    var q = new Queue<char>();

                    for (int r = matrix.Count - 1; r >= 0; r--)
                    {
                        var symbol = matrix[r].Dequeue();
                        q.Enqueue(symbol);
                    }
                    buffer.Add(q);
                }

                matrix = buffer;

                compareWidth = !compareWidth;
            }

            // print
            foreach (var item in matrix)
            {
                while (item.Count > 0)
                {
                    Console.Write(item.Dequeue());
                }
                Console.WriteLine();
            }
        }
    }
}