using System.Text.RegularExpressions;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Добро пожаловать на сервер!");
app.MapGet("/about", () => "это мой превый asp.Net core сервер");
app.MapGet("/time", () => $"время на сервере {DateTime.Now}");
app.MapGet("/hello/{name}", (string name) => $"привет , {name}");
app.MapGet("/sum/{a}/{b}", (int a, int b) => $"{a + b}");
app.MapGet("student", () => new
{
    Name = "Динара Жанатпаева",
    Group = "исп-232",
    Year = 18,
    IsActive = true

});
app.MapGet("/subjects", () => new[]
{
    "РПМ",
"РМП" ,
"ИСРПО" ,
"СП" ,
});
app.MapGet("/product/{id}", (int id) => new Product(
Id: id,
Name: $"товар #{id}",
Price: id * 99.99m,
InStock: id % 2 == 0

));
app.Run();
record Product(int Id, string Name, decimal Price, bool InStock);