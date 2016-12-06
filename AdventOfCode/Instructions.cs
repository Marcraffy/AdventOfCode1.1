namespace AdventOfCode
{
    using System;
    using System.Collections.Generic;

    public enum Turn
    {
        Right = 1,
        Left,
        Straight
    }

    public struct Instruction
    {
        public Turn Direction { get; set; }
        public int Move { get; set; }
    }

    public class Instructions
    {
        public List<Instruction> InstructionList { get; set; }

        public Instructions(char[] input)
        {
            InstructionList = new List<Instruction>();
            var oldDirection = "";
            var oldMoves = "";
            foreach (var item in input)
            {
                switch (item)
                {
                    case ',':
                        break;
                    case ' ':
                        {
                            InstructionList.Add(new Instruction
                            {
                                Direction = oldDirection == "R" ? Turn.Right : Turn.Left,
                                Move = Convert.ToInt32(oldMoves)
                            });
                            oldDirection = "";
                            oldMoves = "";
                            break;
                        }
                    case 'R':
                        {
                            oldDirection = "R";
                            break;
                        }
                    case 'L':
                        {
                            oldDirection = "L";
                            break;
                        }
                    default:
                        {
                            oldMoves += item;
                            break;
                        }
                }
            }
            InstructionList.Add(new Instruction
            {
                Direction = oldDirection == "R" ? Turn.Right : Turn.Left,
                Move = Convert.ToInt32(oldMoves)
            });
        }

        public void Stretch()
        {
            var tempList = new List<Instruction>();
            foreach (var item in InstructionList)
            {
                for (int i = 0; i < item.Move; i++)
                {
                    tempList.Add(new Instruction { Direction = i > 0 ? Turn.Straight : item.Direction, Move = 1 });
                }
            }
            InstructionList = tempList;
        }
    }
}
