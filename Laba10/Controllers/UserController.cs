using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly InMemoryUserRepository _repository;

    public UserController(InMemoryUserRepository repository)
    {
        _repository = repository;
    }

    // Получение пользователя по имени (с защитой от "SQL-инъекций")
    [HttpGet("{username}")]
    public IActionResult GetUser(string username)
    {
        try
        {
            var user = _repository.GetUserByUsername(username);
            if (user == null)
            {
                return NotFound("Пользователь не найден.");
            }

            return Ok(user);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    // Добавление нового пользователя
    [HttpPost]
    public IActionResult AddUser([FromBody] User user)
    {
        _repository.AddUser(user);
        return CreatedAtAction(nameof(GetUser), new { username = user.Username }, user);
    }
}
