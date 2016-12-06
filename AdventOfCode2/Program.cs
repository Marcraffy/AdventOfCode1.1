namespace AdventOfCode2
{
    using AdventOfCode;
    using System;
    using System.IO;
    class Program
    {
        static void Main(string[] args)
        {
            var stream = new StreamReader("AoCInput2.txt");
            var input = stream.ReadToEnd();
            var directions = Directions.GetDirections(input);
            var keypad = new Keypad();
            Console.WriteLine(keypad.GetCode(directions));
        }
    }
}
