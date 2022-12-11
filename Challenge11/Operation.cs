namespace Challenge11
{
    using System.Numerics;

    internal class Operation
    {
        private string OperationSign { get; }
        private BigInteger Operand { get; }
        private bool UseOld { get; }

        internal Operation(string operation)
        {
            var elements = operation.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            OperationSign = elements[4];
            var operand = elements[5];
            if (operand == "old")
            {
                Operand = BigInteger.Zero;
                UseOld = true;
            }
            else
            {
                Operand = int.Parse(operand);
                UseOld = false;
            }
        }

        internal BigInteger NewWorry(BigInteger old)
        {
            var operand = UseOld ? old : Operand;
            return OperationSign switch
            {
                "*" => old * operand,
                "+" => old + operand,
                _ => throw new ArgumentOutOfRangeException()
            };
        }
    }
}
