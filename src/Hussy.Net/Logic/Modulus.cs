namespace Hussy.Net;

/// <summary>
/// Defines static methods for common programming tasks.
/// </summary>
public static partial class Hussy
{
    /// <summary>
    /// Determines whether the specified value is divisible by all the specified operands.
    /// </summary>
    /// <param name="value">The value to check for divisibility.</param>
    /// <param name="operands">The operands to check for divisibility against the value.</param>
    /// <returns>
    /// <c>true</c> if the value is divisible by all the operands; otherwise, <c>false</c>.
    /// </returns>
    public static bool MD(this int value, params int[] operands)
    {
        foreach (int operand in operands)
            if (value % operand != 0)
                return false;

        return true;
    }
}