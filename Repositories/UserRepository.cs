using System.Data;
using Dapper;
using POC.DapperExample.Interfaces;
using POC.DapperExample.Models;

namespace POC.DapperExample.Repositories;

public class UserRepository : IRepository<User>
{
    private readonly IDbConnectionFactory _dbConnectionFactory;

    public UserRepository(IDbConnectionFactory dbConnectionFactory)
    {
        _dbConnectionFactory = dbConnectionFactory;
    }

    public List<User> GetAll()
    {
        using var connection = _dbConnectionFactory.CreateConnection();
        var users = connection
            .Query<User>("SELECT * FROM dbo.AspNetUsers")
            .ToList();
        return users;
    }

    public User GetById(int id)
    {
        using var connection = _dbConnectionFactory.CreateConnection();
        var user = connection
            .QueryFirstOrDefault<User>("SELECT * FROM dbo.AspNetUsers WHERE Id = @Id", new { Id = id });
        return user;
    }

    public void Insert(User user)
    {
        using var connection = _dbConnectionFactory.CreateConnection();
        var sql = @"INSERT INTO dbo.AspNetUsers (Id, Name, Email) VALUES (@Id, @Name, @Email)";
        var i = connection.Execute(sql, user);
    }

    public int Update(User user)
    {
        using var connection = _dbConnectionFactory.CreateConnection();
        var sql = @"UPDATE dbo.AspNetUsers SET Name = @Name, Email = @Email WHERE Id = @Id";
        var i = connection.Execute(sql, user);
        return i;
    }

    public int Delete(int id)
    {
        using var connection = _dbConnectionFactory.CreateConnection();
        var sql = @"DELETE FROM dbo.AspNetUsers WHERE Id = @Id";
        var i = connection.Execute(sql, new { Id = id });
        return i;
    }
}