using POC.DapperExample.Models;

namespace POC.DapperExample.Interfaces;

public interface IRepository<TModel> where TModel : class
{
    List<User> GetAll();
    User GetById(int id);
    void Insert(User user);
    int Update(User user);
    int Delete(int id);
}