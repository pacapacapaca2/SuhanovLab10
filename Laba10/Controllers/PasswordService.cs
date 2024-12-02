using Microsoft.AspNetCore.Mvc;
using BCrypt.Net;

[ApiController]
[Route("api/[controller]")]
public class PasswordController : ControllerBase
{
    [HttpPost("hash")]
    public IActionResult HashPassword([FromBody] string password)
    {
        if (string.IsNullOrEmpty(password))
        {
            return BadRequest("Пароль не может быть пустым.");
        }

        string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);
        return Ok(hashedPassword);
    }

    [HttpPost("verify")]
    public IActionResult VerifyPassword([FromBody] PasswordVerificationRequest request)
    {
        bool isValid = BCrypt.Net.BCrypt.Verify(request.Password, request.HashedPassword);
        return Ok(isValid);
    }
}

public class PasswordVerificationRequest
{
    public string Password { get; set; }
    public string HashedPassword { get; set; }
}
