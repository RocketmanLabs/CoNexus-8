namespace Rml.CoNexus.Eventing;

public enum EventLevel
{
    UNKNOWN = 0,
    TRACE,          
    DEBUG,         
    INFO,           
    WARNING,         
    ERROR,
    FATAL
};
/* _EventBase:
 *      string EventId {get;}
 *      string EventName {get;}
 *      EventSeverity Severity {get;}
 *      string? CorrelationId {get; set;}
 *      object? Payload {get; set;}