namespace Rml.CoNexus.Core.Constants;

public enum VotingMethod : byte
{
    UNKNOWN = 0,
    RATE,
    PAIRS,
    DIRECT,
    MULCH
}
public enum AxisRole : byte
{
    UNKNOWN = 0,
    WEIGHTS,        // uses PAIRS & crits to develop weights/crit @ inq level
    COSTS,          // uses DIRECT & CostSpecs to capture costs... directly
    CURRENT,        // X-axis data
    ALTERNATIVE     // weights are common to all, this is X-axis data
}
