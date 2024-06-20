using Newtonsoft.Json;
using Rml.CoNexus.Core.Extensions;
using System.Net;

namespace Rml.CoNexus.API;

public class CnxResponse
{
    public HttpStatusCode StatusCode;
    public string? UserMessage { get; set; }
    public string? AdminMessage { get; set; }
    public string? JsonPayload { get; private set; }
    public bool IsSerialized { get; private set; }

    public string? SavePayload(object? payload, bool blockSerialization, bool forceSerialization)
    {
        if (payload is null)
        {
            JsonPayload = null;
        }
        else
        {
            JsonPayload = (blockSerialization, forceSerialization, payload.CanBeSerialized()) switch
            {
                (false, false, true) => JsonConvert.SerializeObject(payload),
                (false, false, false) => payload?.ToString(),
                (false, true, _) => JsonConvert.SerializeObject(payload),
                _ => payload.ToString(),
            };
        }
        return JsonPayload;
    }
}

