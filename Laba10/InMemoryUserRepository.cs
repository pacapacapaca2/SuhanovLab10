using System;
using System.Collections.Generic;
using System.Linq;

public class InMemoryUserRepository
{
    private readonly List<User> _users = new List<User>
    {
        new User { Id = 1, Username = "admin", Email = "admin@example.com" },
        new User { Id = 2, Username = "user1", Email = "user1@example.com" }
    };

    // Эмуляция "параметризованного" запроса
    public User GetUserByUsername(string username)
    {
        // Имитация проверки на SQL-инъекции
        if (username.Contains("'") || username.Contains("--") || username.Contains(";"))
        {
            throw new ArgumentException("Введенное имя пользователя содержит недопустимые символы.");
        }

        // Выполнение поиска в списке (эмуляция безопасного параметризованного запроса)
        return _users.FirstOrDefault(u => u.Username.Equals(username, StringComparison.OrdinalIgnoreCase));
    }

    public void AddUser(User user)
    {
        _users.Add(user);
    }
}

public class User
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
}
