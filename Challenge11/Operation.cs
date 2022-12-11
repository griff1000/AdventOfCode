namespace Challenge11
{
    internal class Operation
    {
        /// <summary>
        /// Product of the input test divisors, i.e. 2 * 3 * 5 * 7 * 11 * 13 * 17 * 19
        /// </summary>
        private const int RealInputDivisor = 9699690;

        private string OperationSign { get; }
        private long Operand { get; }
        private bool UseOld { get; }

        internal Operation(string operation)
        {
            var elements = operation.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            OperationSign = elements[4];
            var operand = elements[5];
            if (operand == "old")
            {
                Operand = 0;
                UseOld = true;
            }
            else
            {
                Operand = int.Parse(operand);
                UseOld = false;
            }
        }

        internal long NewWorry(long old)
        {
            var operand = UseOld ? old : Operand;
            var result = OperationSign switch
            {
                "*" => old * operand,
                "+" => old + operand,
                _ => throw new ArgumentOutOfRangeException()
            };
            // All the test divisors are prime, so you can keep the new worry relatively small
            // by dividing by the product of all of them and taking the remainder.
            return result % RealInputDivisor;
        }
    }
}
