using TodoApp.Api.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.AddLogging();


var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();