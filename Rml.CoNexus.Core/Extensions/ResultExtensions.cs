using Rml.CoNexus.Core.CnxResults;

namespace Rml.CoNexus.Core.Extensions;

public static class ResultExtensions
{

    public static bool NormalizeResults(this Results results)
    {
        decimal avg = results.Average(x => x.Value);
        if (avg == 0) return false;

        decimal scaleFactor = 100 / avg;
        foreach (Result result in results)
        {
            result.Normalized = result.Value * (100.0m / avg);
        }
        return true;
    }

    public static void ScaleResults(this IEnumerable<Result> results, int scaleMin, int scaleMax)
    {
        foreach (Result result in results)
        {
            result.Scaled = (scaleMax - scaleMin) / ((result.Value - scaleMin) / 100);
        }
    }
}