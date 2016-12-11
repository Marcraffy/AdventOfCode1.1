namespace AdventOfCode4
{
    using System;
    using System.IO;
    using AdventOfCode;

    class Program
    {
        static void Main()
        {
            Console.WriteLine("PART 1:");
            Console.WriteLine(Room.GetSumOfId(Room.GetValidRooms(Room.ParseString(new StreamReader("AoCInput4.txt").ReadToEnd()))));
            Console.WriteLine("PART 2:");
            Room.Search(Room.ParseString(new StreamReader("AoCInput4.txt").ReadToEnd()), "north").ForEach((Room room) => room.PrintRoom());
        }
    }
}
