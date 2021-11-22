using System.Reflection.Metadata.Ecma335;
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
    public async Task<IActionResult> Get(CancellationToken ct)
    {
        var results = await _client.GetCoursesAsync(ct);
        Console.WriteLine(results);
        
        await Task.Delay(1000, ct);
        return Ok(results);
    }
}