using Newtonsoft.Json;

namespace ABU.CanvasSharp.Core.Models;

public record Calendar
{
    [JsonProperty("ics")]
    public string? Ics { get; set; }
}