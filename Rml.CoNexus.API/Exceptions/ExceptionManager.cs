using Rml.Api.Processor.Exceptions;

namespace Rml.CoNexus.API.Exceptions;

public static class ExceptionManager
{
    private static IDictionary<string, Exception> _map = new Dictionary<string, Exception>();

    static ExceptionManager()
    {
        var nullex = new UnexpectedNullException(); _map.Add(nullex.ErrorCode, nullex);
        var rngex = new RangeException(); _map.Add(rngex.ErrorCode, rngex);
    }


}
