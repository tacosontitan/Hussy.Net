namespace Hussy.Net.Playground.Leetcode.Easy;

/// <summary>
/// Represents a solution and its tests for the leetcode two-sum problem.
/// </summary>
/// <see href="https://leetcode.com/problems/two-sum/description/"/>
public sealed partial class TwoSum
{
    /// <summary>
    ///     Given an array of integers <paramref name="numbers"/> and an integer <paramref name="target"/>,
    ///     return the indices of the two numbers within <paramref name="numbers"/> that add up to the
    ///     specified <paramref name="target"/>.
    /// </summary>
    /// <param name="numbers">The array of numbers to look through.</param>
    /// <param name="target">
    ///     The target number which the two numbers in <paramref name="numbers"/> must add up to.
    /// </param>
    /// <returns>
    ///     The indices of the two numbers within <paramref name="numbers"/> that add up to the
    ///     specified <paramref name="target"/>.
    /// </returns>
    /// <remarks>
    ///     <para>You can return the answer in <i>any</i> order.</para>
    ///     <para>
    ///         <b>Requirements:</b>
    ///         <list type="bullet">
    ///             <item>You may <b>NOT</b> use the same element twice.</item>
    ///         </list>
    ///     </para>
    ///     <para>
    ///         <b>Assumptions:</b>
    ///         <list type="bullet">
    ///             <item>
    ///                 Each sequence of <paramref name="numbers"/> will have <i>exactly
    ///                 <b>one</b></i> solution.
    ///             </item>
    ///         </list>
    ///     </para>
    ///     <para>
    ///         <b>Constraints:</b>
    ///         <list type="bullet">
    ///             <item>
    ///                 <c>2</c> is less than or equal to <paramref name="numbers"/><c>.Length</c> is less than or equal to <c>104</c>
    ///             </item>
    ///             <item>
    ///                 <c>-109</c> is less than or equal to <c>nums[i]</c> is less than or equal to <c>109</c>
    ///             </item>
    ///             <item>
    ///                 <c>-109</c> is less than or equal to <paramref name="target"/> is less than or equal to <c>109</c>
    ///             </item>
    ///             <item>Only one valid answer exists.</item>
    ///         </list>
    ///     </para>
    /// </remarks>
    private delegate IEnumerable<int> TestFunction(
        int[] numbers,
        int target);
}