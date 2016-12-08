namespace AdventOfCode
{
    using System.Collections.Generic;
    
    public enum Move
    {
        Up = 1,
        Down,
        Left,
        Right
    }

    public class Directions
    {
        public List<Move> MoveList { get; set; }

        public Directions(char[] input)
        {
            MoveList = new List<Move>();
            foreach (var direction in input)
            {
                switch (direction)
                {
                    case 'U':
                        {
                            MoveList.Add(Move.Up);
                            break;
                        }
                    case 'D':
                        {
                            MoveList.Add(Move.Down);
                            break;
                        }
                    case 'L':
                        {
                            MoveList.Add(Move.Left);
                            break;
                        }
                    case 'R':
                        {
                            MoveList.Add(Move.Right);
                            break;
                        }
                }
            }
        }

        public static List<Directions> GetDirections(string input)
        {
            var directions = new List<Directions>();
            var inputList = new List<char[]>();
            var tempString = "";
            foreach (var item in input)
            {
                if (item == '\n')
                {
                    inputList.Add(tempString.ToCharArray());
                    tempString = "";
                }
                else
                {
                    tempString += item;
                }
            }
            if (tempString != "")
            {
                inputList.Add(tempString.ToCharArray());
            }
            foreach (var item in inputList)
            {
                directions.Add(new Directions(item));
            }
            return directions;
        }
    }
}
