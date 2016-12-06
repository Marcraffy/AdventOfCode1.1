namespace AdventOfCode1
{
    using AdventOfCode;
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main(string[] args)
        {
            var agent = new Agent();
            var input = "R8, R4, R4, R8".ToCharArray(); // "R2, L1, R2, R1, R1, L3, R3, L5, L5, L2, L1, R4, R1, R3, L5, L5, R3, L4, L4, R5, R4, R3, L1, L2, R5, R4, L2, R1, R4, R4, L2, L1, L1, R190, R3, L4, R52, R5, R3, L5, R3, R2, R1, L5, L5, L4, R2, L3, R3, L1, L3, R5, L3, L4, R3, R77, R3, L2, R189, R4, R2, L2, R2, L1, R5, R4, R4, R2, L2, L2, L5, L1, R1, R2, L3, L4, L5, R1, L1, L2, L2, R2, L3, R3, L4, L1, L5, L4, L4, R3, R5, L2, R4, R5, R3, L2, L2, L4, L2, R2, L5, L4, R3, R1, L2, R2, R4, L1, L4, L4, L2, R2, L4, L1, L1, R4, L1, L3, L2, L2, L5, R5, R2, R5, L1, L5, R2, R4, R4, L2, R5, L5, R5, R5, L4, R2, R1, R1, R3, L3, L3, L4, L3, L2, L2, L2, R2, L1, L3, R2, R5, R5, L4, R3, L3, L4, R2, L5, R5".ToCharArray();
            var instructions = new Instructions(input);
            instructions.Stretch();
            var agents = new List<Agent>();
            foreach (var instruction in instructions.InstructionList)
            {
                agents.Add(new Agent (agent.X, agent.Y));
                agent.Move(instruction);
                var istrue = false;
                foreach (var item in agents)
                {
                    if (agent.X == item.X && agent.Y == item.Y)
                    {
                        istrue = true;
                        break;
                    }
                }
                if (istrue)
                {
                    break;
                }
            }

            Console.WriteLine(Math.Abs(agent.X) + Math.Abs(agent.Y));
            Console.Read();
        }
    }
}
