namespace AdventOfCode
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Keypad
    {
        private static char[,] keypad = new char[,] { { '0', '0', '1', '0', '0' }, { '0', '2', '3', '4', '0' }, { '5', '6', '7', '8', '9' }, { '0', 'A', 'B', 'C', '0' }, {  '0', '0', 'D', '0', '0' } };

        public int X { get; private set; }
        public int Y { get; private set; }
        
        public char DecodeDirections(Directions directions, char start)
        {
            var currentPosition = start;
            var temp = Coord(currentPosition);
            X = temp[0];
            Y = temp[1];
            foreach (var move in directions.MoveList)
            {
                currentPosition = MoveKey(move);
            }
            return currentPosition;
        }

        public string GetCode(List<Directions> directions)
        {
            var result = "";
            var currentPosition = '5';
            foreach (var direction in directions)
            {
                currentPosition = DecodeDirections(direction, currentPosition);
                result += currentPosition;
            }
            return result;
        }

        public char Key(int x, int y) =>
            keypad[y, x];

        public int[] Coord(char key)
        {
            var coord = new int[2];
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (Key(i,j) == key)
                    {
                        coord = new int[] { i, j };
                    }
                }
            }
            return coord;
        }

        public char MoveKey(Move direction)
        {
            switch (direction)
            {
                case Move.Up:
                    {
                        Y -= new char[] { '5', '2', '1', '4', '9' }.Contains(Key(X, Y)) ? 0 : 1;
                        break;
                    }
                case Move.Down:
                    {
                        Y += new char[] { '5', 'A', 'D', 'C', '9' }.Contains(Key(X, Y)) ? 0 : 1;
                        break;
                    }
                case Move.Left:
                    {
                        X -= new char[] { '5', '2', '1', 'A', 'D' }.Contains(Key(X, Y)) ? 0 : 1;
                        break;
                    }
                case Move.Right:
                    {
                        X += new char[] { 'C', 'D', '1', '4', '9' }.Contains(Key(X, Y)) ? 0 : 1;
                        break;
                    }
            }
            return Key(X, Y);
        }
        
    }
}
