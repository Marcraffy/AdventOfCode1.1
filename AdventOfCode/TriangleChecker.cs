namespace AdventOfCode
{
    using System.Collections.Generic;

    public static class TriangleChecker
    {
        public static bool IsTriangleValid(Triangle triangle)
        {
            var isValid = true;
            isValid = triangle.Get(0) + triangle.Get(1) > triangle.Get(2) ? isValid : false;
            isValid = triangle.Get(0) + triangle.Get(2) > triangle.Get(1) ? isValid : false;
            isValid = triangle.Get(1) + triangle.Get(2) > triangle.Get(0) ? isValid : false;
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
