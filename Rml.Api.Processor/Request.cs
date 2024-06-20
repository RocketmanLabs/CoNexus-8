namespace Rml.Api.Processor;

public class Request : _EventBase
{
    public Request() { }
    public Request()
    public DateTime TimestampUtc = DateTime.UtcNow;
    public string RequestId { get; set; }
    public string? RequestName { get; set; }
}
public class Response
{

}
