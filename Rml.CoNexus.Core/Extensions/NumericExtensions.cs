namespace Rml.CoNexus.Core.Extensions;

public static class NumericExtensions
{
    public static string PctComplete(this int count, int remaining) => count != 0 ? (remaining / count * 100).ToString() : "0 %";
}

