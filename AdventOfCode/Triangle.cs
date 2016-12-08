namespace AdventOfCode
{
    using System;
    using System.Collections.Generic;

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
                    array[currentPos] = Convert.ToInt32(buffer);
                    result.Add(array);
                    array = new int[3];
                    currentPos = 0;
                    buffer = "";
                    continue;
                }

                if (item == ' ')
                {
                    if (buffer.Length == 0)
                    {
                        continue;
                    }

                    array[currentPos] = Convert.ToInt32(buffer);
                    currentPos++;
                    buffer = "";
                    continue;
                }

                buffer += item;
            }
            if (buffer.Length != 0)
            {
                array[currentPos] = Convert.ToInt32(buffer);
                result.Add(array);
            }

            return result;
        }

        public static List<Triangle> ParseStringToTriangles(string input) =>
            GetTriangles(ParseString(input));
    }
}
