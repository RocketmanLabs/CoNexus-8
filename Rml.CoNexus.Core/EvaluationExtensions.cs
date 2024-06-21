namespace Rml.CoNexus.Core;

public static class EvaluationExtensions
{
    public static void UpdateProgress(this EvaluationProgress progress, Votes votes)
    {
        progress.ItemCount = votes.Count;
        progress.ItemsRemaining = votes.UnvotedCount;
    } 
}

