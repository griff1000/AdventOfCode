namespace Challenge10
{
    internal class Instruction
    {
        private int CyclesToComplete { get; }
        private int CyclesExecuted { get; set; }
        private bool UpdateRegister => CyclesToComplete > 1;
        private int RegisterIncrement { get; }
        internal bool InstructionComplete => CyclesExecuted >= CyclesToComplete;

        internal Instruction(string instruction)
        {
            var parts = instruction.Split(' ');
            if (parts[0] == "noop")
            {
                CyclesToComplete = 1;
                RegisterIncrement = 0;
            }
            else
            {
                CyclesToComplete = 2;
                RegisterIncrement = int.Parse(parts[1]);
            }
            CyclesExecuted = 0;
        }

        internal int Execute(int registerValue)
        {
            CyclesExecuted++;
            if (UpdateRegister && InstructionComplete)
            {
                return registerValue + RegisterIncrement;

            }
            return registerValue;
        }
    }
}
