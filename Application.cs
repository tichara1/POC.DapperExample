using POC.DapperExample.Interfaces;
using POC.DapperExample.Models;

namespace POC.DapperExample;

public class Application
{
    private readonly IRepository<User> _userRepository;

    public Application(IRepository<User> userRepository)
    {
        _userRepository = userRepository;
    }
    public void Run(string[] strings)
    {
        var users = _userRepository.GetAll();

        foreach (var user in users)
        {
            Console.WriteLine($"ID: {user.Id}, Name: {user.Name}, Email: {user.Email}");
        }
    }
}