namespace _09.RectangleIntersection
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            var rectangles = new Dictionary<string, Rectangle>();

            var inputInfo = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            for (int i = 0; i < inputInfo[0]; i++)
            {
                var rectangleInfo = Console.ReadLine().Split(' ');
                var id = rectangleInfo[0];
                var width = double.Parse(rectangleInfo[1]);
                var height = double.Parse(rectangleInfo[2]);
                var topLeftHoriz = double.Parse(rectangleInfo[3]);
                var topLeftVert = double.Parse(rectangleInfo[4]);

                var rectangle = new Rectangle(id, width, height, topLeftHoriz, topLeftVert);

                rectangles[id] = rectangle;
            }

            for (int i = 0; i < inputInfo[1]; i++)
            {
                var checkIds = Console.ReadLine().Split(' ');
                var result = rectangles[checkIds[0]].IntersectsWith(rectangles[checkIds[1]]);

                Console.WriteLine(result.ToString().ToLower());
            }
        }
    }
}