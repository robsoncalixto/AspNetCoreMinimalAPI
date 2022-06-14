namespace RC.Minimal.API.Repositories;

public interface IUserRepository
{
    object GetUsers();
    object GetUser(string username);
    int CounterUsers();

}

