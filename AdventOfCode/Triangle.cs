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

        private static int[] ParseSnippet(string input)
        {
            var array = new List<int>();
            var stringArray = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var item in stringArray)
                array.Add(Convert.ToInt32(item));

            return array.ToArray();
        }

        public static List<int[]> ParseString(string input)
        {
            var snippets = input.Split('\n');
            var result = new List<int[]>();
            var index = 0;
            var arrayOne = new List<int>();
            var arrayTwo = new List<int>();
            var arrayThree = new List<int>();

            foreach (var snippet in snippets)
            {
                var array = ParseSnippet(snippet);
                arrayOne.Add(array[0]);
                arrayTwo.Add(array[1]);
                arrayThree.Add(array[2]);
                index++;
                if (index == 3)
                {
                    result.Add(arrayOne.ToArray());
                    result.Add(arrayTwo.ToArray());
                    result.Add(arrayThree.ToArray());
                    index = 0;
                    arrayOne = new List<int>();
                    arrayTwo = new List<int>();
                    arrayThree = new List<int>();
                }
            }

            return result;
        }

        public static List<Triangle> ParseStringToTriangles(string input) =>
            GetTriangles(ParseString(input));
    }
}
