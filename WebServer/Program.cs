var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Добро пожаловать на сервер!");
app.MapGet("/about", () => "это мой превый asp.Net core сервер");
app.MapGet("/time", () => $"время на сервере {DateTime.Now}");
app.MapGet("/hello/{name}", (string name) => $"привет , {name}");
app.MapGet("/sum/{a}/{b}", (int a, int b) => $"{a + b}");
app.Run();
