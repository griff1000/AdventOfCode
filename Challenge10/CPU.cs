namespace Challenge10
{
    internal class CPU
    {
        internal int Register { get; private set; }

        internal CPU()
        {
            Register = 1;
        }

        internal void ExecuteInstruction(Instruction instruction)
        {
            Register = instruction.Execute(Register);
        }

        internal int SignalStrength(int cycleNumber)
        {
            return cycleNumber * Register;
        }
    }
}
