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
        public string NameWithSpaces { get; set; }
        public string NameDecrypted { get; set; }
        public int SectorId { get; set; }
        public string CheckSum { get; set; }

        public Room(string input)
        {
            var strings = input.Split(new char[] { '-', '[', ']', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            CheckSum = strings[strings.Length - 1];
            SectorId = Convert.ToInt32(strings[strings.Length - 2]);
            Name = "";
            NameWithSpaces = "";
            NameDecrypted = "";
            for (int index = 0; index < strings.Length - 2; index++)
                Name += strings[index];
            for (int index = 0; index < strings.Length - 2; index++)
            {
                NameWithSpaces += strings[index] + ((index == (strings.Length - 3)) ? "" : " ");
            }
            DecryptName();
        }

        public void PrintRoom()
        {
            Console.WriteLine($"{NameDecrypted} \t{SectorId}");
        }

        public static List<Room> ParseString(string input)
        {
            var strings = input.Split('\n');
            var result = new List<Room>();
            foreach (var item in strings)
                result.Add(new Room(item));
            return result;
        }

        private void DecryptName()
        {
            var alphabet = "abcdefghijklmnopqrstuvwxyz";
            foreach (var item in NameWithSpaces)
            {
                if (item == ' ')
                {
                    NameDecrypted += ' ';
                    continue;
                }

                NameDecrypted += alphabet[(alphabet.IndexOf(item) + SectorId) % alphabet.Length];
            }
        }

        public bool IsCheckSumValid()
        {
            var alphabet = "abcdefghijklmnopqrstuvwxyz";
            var charCount = new Dictionary<char, int>();

            foreach (var letter in alphabet)
            {
                charCount.Add(letter, Name.Count(character => letter == character));
            }

            if (CheckSum == GetCheckSum(charCount))
            {
                return true;
            }

            return false;
        }

        public static List<Room> GetValidRooms(List<Room> rooms)
        {
            var validRooms = new List<Room>();

            foreach (var room in rooms)
                if (room.IsCheckSumValid())
                    validRooms.Add(room);

            return validRooms;
        }

        public static int GetSumOfId(List<Room> rooms)
        {
            int count = 0;
            foreach (var room in rooms)
            {
                count += room.SectorId;
            }
            return count;
        }

        private static string GetCheckSum(Dictionary<char, int> count)
        {
            var checkSum = count.OrderByDescending(x => x.Value).Take(5);
            var checkSumString = "";
            foreach (var pair in checkSum)
            {
                checkSumString += pair.Key;
            }
            return checkSumString;
        }

        public static List<Room> Search(List<Room> rooms, string param) => 
            rooms.FindAll(room => room.NameDecrypted.ToLowerInvariant().Contains(param.ToLowerInvariant()));
    }
}
