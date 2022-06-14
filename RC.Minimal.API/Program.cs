
using RC.Minimal.API.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseSwagger();

app.MapGet("/", () => "Welcome!");

app.MapGet("/user/{username}", (String username, IUserRepository repository) => {
    return  repository.GetUser(username);  
});

app.MapGet("/user/counter", (IUserRepository repository) => {
    return repository.CounterUsers();
});

app.MapGet("/user", (IUserRepository repository) => {
    return repository.GetUsers();
});

app.UseSwaggerUI();

app.Run();

public partial class Program { }