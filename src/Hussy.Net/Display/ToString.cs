namespace Hussy.Net;

public static partial class Hussy
{
    public static string Ts<T>(this T input) =>
        input.ToString();
}