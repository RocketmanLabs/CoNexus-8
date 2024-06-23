using Rml.CoNexus.Core;
using Rml.CoNexus.Core.CnxEvaluation;
using Rml.CoNexus.Core.CnxParticipation;
using Rml.CoNexus.Core.CnxResults;

namespace Rml.CoNexus.UnitTests;

public class ExtensionMethod_Tests
{
    [Fact]
    public void XM_Results_scaling()
    {
        Participant p = new("Michael Burnham", remainAnonymous: false);
        Axis axis = new("", null, 1, "", "", AxisType.CONTRIBUTIONS, VoteMethod.RATE, scale);
        Result res1 = new Result(p, axis, 7);
    }
}
