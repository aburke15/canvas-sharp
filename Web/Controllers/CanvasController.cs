using Microsoft.AspNetCore.Mvc;

namespace ABU.CanvasSharp.Web.Controllers;

[ApiController, Route("api/v1/canvas")]
public class CanvasController : ControllerBase
{
    public CanvasController()
    {
        
    }
    
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        await Task.Delay(1000);
        return Ok();
    }
}