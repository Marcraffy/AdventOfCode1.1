﻿namespace AdventOfCode3
{
    using AdventOfCode;
    using System;
    using System.IO;

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(TriangleChecker.countValidTriangles(Triangle.ParseStringToTriangles(new StreamReader("AoCInput3.txt").ReadToEnd())));
        }
    }
}
