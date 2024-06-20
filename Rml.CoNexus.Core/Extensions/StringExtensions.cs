using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace Rml.CoNexus.Core.Extensions;

public static class StringExtensions
{
    public static bool CanBeSerialized(this object? maybeJson)
    {
        if (maybeJson is null) return false;
        try
        {
            string json = JsonConvert.SerializeObject(maybeJson);
            return true;
        }
        catch
        {
            return false;
        }
    }
}