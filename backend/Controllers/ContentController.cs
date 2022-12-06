using Microsoft.AspNetCore.Mvc;
using backend.Model;
using System.Linq;
namespace backend.Controllers;

[ApiController]
[Route("content")]
public class ContentController: ControllerBase
{
    [HttpPost("register")]
    public async Task<IActionResult> ContentRegister([FromBody]Post post)
    {
        BdccodexContext context = new BdccodexContext();
        await context.AddAsync(post);
        await context.SaveChangesAsync();
        return Ok();
    }
}
