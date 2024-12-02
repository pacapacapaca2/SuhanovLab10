using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class RoleController : ControllerBase
{
    [HttpGet("admin")]
    [Authorize(Roles = "Administrator")]
    public IActionResult AdminOnly()
    {
        return Ok("Это доступно только для администратора.");
    }

    [HttpGet("public")]
    [AllowAnonymous]
    public IActionResult PublicPage()
    {
        return Ok("Это доступно для всех.");
    }
}
