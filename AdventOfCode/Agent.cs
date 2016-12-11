namespace AdventOfCode
{

    public enum MapDirection
    {
        North = 1,
        East,
        South,
        West
    }

    public class Agent
    {

        public MapDirection Face { get; set; }
        public int X { get; private set; }
        public int Y { get; private set; }

        public Agent()
        {
            X = 0;
            Y = 0;
            Face = MapDirection.North;
        }

        public Agent(int x, int y)
        {
            X = x;
            Y = y;
            Face = MapDirection.North;
        }

        public Agent(int x, int y, MapDirection d)
        {
            X = x;
            Y = y;
            Face = d;
        }

        public void Move(Instruction move)
        {
            if (move.Direction == Turn.Straight)
            {
                switch (Face)
                {
                    case MapDirection.North:
                        {
                            Y++;
                            break;
                        }
                    case MapDirection.East:
                        {
                            X++;
                            break;
                        }
                    case MapDirection.South:
                        {
                            Y--;
                            break;
                        }
                    case MapDirection.West:
                        {
                            X--;
                            break;
                        }
                }
                return;
            }
            switch (Face)
            {
                case MapDirection.North:
                    {
                        Face = move.Direction == Turn.Left ? MapDirection.West : MapDirection.East;
                        X += Face == MapDirection.West ? -move.Move : move.Move;
                        break;
                    }
                case MapDirection.East:
                    {
                        Face = move.Direction == Turn.Left ? MapDirection.North : MapDirection.South;
                        Y += Face == MapDirection.North ? move.Move : -move.Move;
                        break;
                    }
                case MapDirection.South:
                    {
                        Face = move.Direction == Turn.Left ? MapDirection.East : MapDirection.West;
                        X += Face == MapDirection.East ? move.Move : -move.Move;
                        break;
                    }
                case MapDirection.West:
                    {
                        Face = move.Direction == Turn.Left ? MapDirection.South : MapDirection.North;
                        Y += Face == MapDirection.South ? -move.Move : move.Move;
                        break;
                    }
            }
        }
    }
}
