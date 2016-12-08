namespace AdventOfCode
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using AdventOfCode;

    public class Triangle
    {
        private int[] triangle { get; set; }

        public Triangle(int[] input)
        {
            triangle = new int[] { input[0], input[1], input[2] };
        }

        public int Get(int index) =>
            triangle[index];

        public static List<Triangle> GetTriangles(List<int[]> triangles)
        {
            var result = new List<Triangle>();

            foreach (var tri in triangles)
            {
                result.Add(new Triangle(tri));
            }

            return result;
        }

        public static List<int[]> ParseString(string input)
        {
            var buffer = "";
            var currentPos = 0;
            var result = new List<int[]>();
            int[] array = new int[3];

            foreach (var item in input)
            {
                if (item == '\n')
                {
                    result.Add(array);
                    array = new int[3];
                    currentPos = 0;
                    continue;
                }

                if (item == ' ')
                {
                    array[currentPos] = Convert.ToInt32(buffer);
                    currentPos++;
                    continue;
                }

                buffer += item;
            }

            return result;
        }

        public static List<Triangle> ParseStringToTriangles(string input) =>
            GetTriangles(ParseString(input));
    }

    public static class TriangleChecker
    {
        public static bool IsTriangleValid(Triangle triangle)
        {
            var isValid = false;
            isValid = triangle.Get(0) + triangle.Get(1) > triangle.Get(2) ? true : isValid;
            isValid = triangle.Get(0) + triangle.Get(2) > triangle.Get(1) ? true : isValid;
            isValid = triangle.Get(1) + triangle.Get(2) > triangle.Get(0) ? true : isValid;
            return isValid;
        }

        public static int countValidTriangles(List<Triangle> triangles)
        {
            var count = 0;
            foreach (var triangle in triangles)
            {
                count += IsTriangleValid(triangle) ? 1 : 0;
            }
            return count;
        }
    }
}
