namespace Hussy.Net;

public static partial class Hussy
{
    /// <summary>
    /// Imitates a <see langword="for"/> loop.
    /// </summary>
    /// <param name="startingValue">The value to start iterating with.</param>
    /// <param name="iterationCondition">The condition for each iteration to execute.</param>
    /// <param name="iterator">The mutation that should be applied to the iterator value.</param>
    /// <param name="action">The action to invoke with every iteration.</param>
    /// <typeparam name="T">Specifies the type of data the iterator works with.</typeparam>
    public static void F<T>(
        T startingValue,
        Func<T, bool> iterationCondition,
        Func<T, T> iterator,
        Action<T> action)
    {
        var currentValue = startingValue;
        while (iterationCondition(currentValue))
        {
            action(currentValue);
            currentValue = iterator(currentValue);
        }
    }
}