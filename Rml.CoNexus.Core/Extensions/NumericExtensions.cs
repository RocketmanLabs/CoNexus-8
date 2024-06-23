using System.Runtime.CompilerServices;

namespace Rml.CoNexus.Core.Extensions;

public static class NumericExtensions
{
    public static string PctComplete(this int count, int remaining) => count != 0 ? (remaining / count * 100).ToString() : "0 %";
    public static int Min(this int a, int b) => a < b ? a : b;
    public static int Max(this int a, int b) => a < b ? b : a;
    public static string Show(this bool flag, string prompt) => $"{prompt}: {flag.ToString()}";
}

