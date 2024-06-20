namespace Rml.CoNexus.Eventing;

public abstract class _EventBase
{
    /// <summary>
    /// Ctor for routine event.
    /// </summary>
    /// <param name="name"></param>
    /// <param name="correlationId"></param>
    /// <param name="payload"></param>
    public _EventBase(string name, string? correlationId, object? payload = null)
    {
        EventId = Guid.NewGuid().ToString();
        EventName = name;
        CorrelationId = correlationId;
    }
    public _EventBase(string name, string? correlationId, object? payload = null)
    {
        EventId = Guid.NewGuid().ToString();
        EventName = name;
        CorrelationId = correlationId;
    }

    public DateTime TimestampUtc { get; set; } = DateTime.UtcNow;
    public string EventId { get; private set; }
    public string EventName { get; private set; }
    public string Category { get; private set; }
    public EventLevel Level { get; private set; } = EventLevel.INFO;

    public string? CorrelationId { get; private set; }
    public string? ResponseEndpoint { get; private set; }
    protected virtual object? Payload { get; set; }
    protected bool HasPayload => Payload is not null;
}
/* _EventBase (public):
 *      string EventId {get;}
 *      string EventName {get;}
 *      EventLevel Level {get;}
 *      string? CorrelationId {get; set;}
 * _EventBase (protected)
 *      object? Payload {get; set;}
 */