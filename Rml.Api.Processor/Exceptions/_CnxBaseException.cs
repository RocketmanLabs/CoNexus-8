using Newtonsoft.Json;

namespace Rml.Api.Processor.Exceptions;

// TODO: add logging, respect noLog
public abstract class _CnxBaseException : ApplicationException
{
    public _CnxBaseException(bool noLog = false) : base() { }
    public _CnxBaseException(string adminMsg, string? usrMsg, bool noLog = false) : base(adminMsg) { UserMessage = usrMsg; }
    public _CnxBaseException(string? adminMsg, string? usrMsg, Exception inner, bool noLog = false) : base(adminMsg, inner) { UserMessage = usrMsg; }

    /// <summary>
    /// Set during instantiation as a friendlier message than the exceptions, which is meant for admins.
    /// </summary>
    protected string? UserMessage { get; set; }

    protected Type Type => this.GetType();

    protected virtual string? Serialize() => JsonConvert.SerializeObject(this);
    protected virtual object? Deserialize(string json) => JsonConvert.DeserializeObject(json);
}
public class UnexpectedNullException : _CnxBaseException, IManagedException
{
    public static string ErrorCode => "NULL";

    public UnexpectedNullException(bool noLog = false) : base(noLog) { }
    public UnexpectedNullException(string adminMsg, string? usrMsg, bool noLog = false) : base(adminMsg, usrMsg, noLog) { }
    public UnexpectedNullException(string? adminMsg, string? usrMsg, Exception inner, bool noLog = false) : base(adminMsg, usrMsg, inner, noLog) { }
}
public class RangeException : _CnxBaseException, IManagedException
{
    public static string ErrorCode => "RNG";

    public RangeException(bool noLog = false) : base(noLog) { }
    public RangeException(string adminMsg, string? usrMsg, bool noLog = false) : base(adminMsg, usrMsg, noLog) { }
    public RangeException(string? adminMsg, string? usrMsg, Exception inner, bool noLog = false) : base(adminMsg, usrMsg, inner, noLog) { }
}
