using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using POC.DapperExample.Configurations;
using POC.DapperExample.Interfaces;

namespace POC.DapperExample.Services;

public class MssqlDbConnectionFactory : IDbConnectionFactory
{
    private readonly DatabaseSettings _configuration;

    public MssqlDbConnectionFactory(IOptions<DatabaseSettings> options)
    {
        _configuration = options.Value;
    }

    public IDbConnection CreateConnection()
    {
        return new SqlConnection(_configuration.DefaultConnection);
    }
}