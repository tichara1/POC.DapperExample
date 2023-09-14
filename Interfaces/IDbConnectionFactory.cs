using System.Data;

namespace POC.DapperExample.Interfaces;

public interface IDbConnectionFactory
{
    IDbConnection CreateConnection();
}