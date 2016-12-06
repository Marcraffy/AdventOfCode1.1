namespace AdventOfCode
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Keypad
    {
        private static int[,] keypad = new int[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };

        public int X { get; set; }
        public int Y { get; set; }
        
        public int DecodeDirections(Directions directions, int start)
        {
            int currentPosition = start;
            var temp = Coord(currentPosition);
            X = temp[0];
            Y = temp[1];
            foreach (var move in directions.MoveList)
            {
                currentPosition = MoveKey(move);
            }
            return currentPosition;
        }

        public int GetCode(List<Directions> directions)
        {
            int result = 0;
            int currentPosition = 5;
            foreach (var direction in directions)
            {
                currentPosition = DecodeDirections(direction, currentPosition);
                result = result * 10 + currentPosition;
            }
            return result;
        }

        public int Key(int x, int y) =>
            keypad[y, x];

        public int[] Coord(int key)
        {
            var coord = new int[2];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (Key(i,j) == key)
                    {
                        coord = new int[] { i, j };
                    }
                }
            }
            return coord;
        }

        public int MoveKey(Move direction)
        {
            switch (direction)
            {
                case Move.Up:
                    {
                        Y -= Y == 0 ? 0 : 1;
                        break;
                    }
                case Move.Down:
                    {
                        Y += Y == 2 ? 0 : 1;
                        break;
                    }
                case Move.Left:
                    {
                        X -= X == 0 ? 0 : 1;
                        break;
                    }
                case Move.Right:
                    {
                        X += X == 2 ? 0 : 1;
                        break;
                    }
            }
            return Key(X, Y);
        }
        
    }
}
