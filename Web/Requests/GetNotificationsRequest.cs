using System.ComponentModel.DataAnnotations;
using JetBrains.Annotations;

namespace ABU.CanvasSharp.Web.Requests;

public record GetNotificationsRequest
{
    [Required, UsedImplicitly] 
    public bool IncludePast { get; init; }
}