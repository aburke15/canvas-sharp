using System.Net.Mime;
using System.Text;
using ABU.CanvasSharp.Infrastructure.Abstractions;
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
    
    [HttpGet]
    [Produces(MediaTypeNames.Application.Json)]
    public async Task<IActionResult> Get(CancellationToken ct)
    {
        var results = await _client.GetCoursesAsync(ct);
        return Content(results, MediaTypeNames.Application.Json, Encoding.UTF8);
    }
}