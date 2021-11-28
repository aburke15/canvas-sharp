using System.Net.Mime;
using System.Text;
using ABU.CanvasSharp.Infrastructure.Abstractions;
using ABU.CanvasSharp.Web.Requests;
using Ardalis.GuardClauses;
using Microsoft.AspNetCore.Mvc;

namespace ABU.CanvasSharp.Web.Controllers;

[ApiController, Route("api/v1/canvas")]
public class CanvasController : ControllerBase
{
    private readonly ICanvasApiClient _client;
    
    public CanvasController(ICanvasApiClient client)
    {
        _client = Guard.Against.Null(client, nameof(client));
    }
    
    [HttpGet("courses")]
    [Produces(MediaTypeNames.Application.Json)]
    public async Task<IActionResult> GetCoursesAsync(CancellationToken ct = default)
    {
        var results = await _client.GetCoursesAsync(ct);
        return Ok(results);
    }

    [HttpGet("scopes")]
    [Produces(MediaTypeNames.Application.Json)]
    public async Task<IActionResult> GetScopesAsync(CancellationToken ct = default)
    {
        var results = await _client.GetScopesAsync(ct);
        return Content(results, MediaTypeNames.Application.Json, Encoding.UTF8);
    }

    [HttpGet("{accountId:long}/notifications/{includePast:bool}")]
    [Produces(MediaTypeNames.Application.Json)]
    public async Task<IActionResult> GetNotificationsAsync([FromRoute] long accountId, [FromRoute] bool includePast = false, CancellationToken ct = 
    default)
    {
        await _client.CreateNotificationAsync(accountId, ct);
        return Content("Done", MediaTypeNames.Application.Json, Encoding.UTF8);
    }
}