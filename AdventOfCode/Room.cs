namespace AdventOfCode
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Room
    {
        public string Name { get; set; }
        public int SectorId { get; set; }
        public string CheckSum { get; set; }

        public Room(string input)
        {
            var strings = input.Split(new char[] { '-', '[', ']' }, StringSplitOptions.RemoveEmptyEntries);
            CheckSum = strings[strings.Length - 1];
            SectorId = Convert.ToInt32(strings[strings.Length - 2]);
            Name = "";
            for (int index = 0; index < strings.Length - 2; index++)
                Name += strings[index];
        }

        public List<Room> ParseString(string input)
        {
            var strings = input.Split('\n');
            var result = new List<Room>();
            foreach (var item in strings)
                result.Add(new Room(item));
            return result;
        }

        public
    }
}
