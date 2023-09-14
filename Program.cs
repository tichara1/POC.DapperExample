using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using POC.DapperExample;
using POC.DapperExample.Configurations;
using POC.DapperExample.Interfaces;
using POC.DapperExample.Models;
using POC.DapperExample.Repositories;
using POC.DapperExample.Services;


var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .Build();

var serviceCollection = new ServiceCollection()
    .AddTransient<IDbConnectionFactory, MssqlDbConnectionFactory>()
    .AddTransient<IRepository<User>, UserRepository>()
    .AddTransient<Application>()
    .Configure<DatabaseSettings>(configuration.GetSection("ConnectionStrings"));

var serviceProvider = serviceCollection.BuildServiceProvider();

var application = serviceProvider.GetService<Application>();

try
{
    application?.Run(args);
}
catch (Exception e)
{
    Console.WriteLine(e);
    throw;
}