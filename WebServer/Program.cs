using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;
using Microsoft.Win32.SafeHandles;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// app.MapGet("/", () => "Добро пожаловать на сервер!");
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
// app.Use(async (context, next) =>
// {
//     Console.WriteLine($"[LOG] {context.Request.Method} {context.Request.Path}");
//     await next(context);
//     Console.WriteLine($"[LOG] ответ отправлен {context.Response.StatusCode}");

// });

// app.User(async (context, next) =>
// {
//     yar key = context.Request.Query["key"];
//     (? key = secret){

//     }
//     await next(context);
// });

app.Use(async (context, next) =>
{
    var method = context.Request.Method;
    var path = context.Request.Path;
    Console.WriteLine($"-> {method} {path}");
    await next(context);
});
app.MapGet("/", () => Results.Ok(new
{
    Message = "добро пожаловать",
    Version = "1.0",
    Time = DateTime.Now.ToString("HH:mm:ss")
}));
app.MapGet("/me", () => Results.Ok(new
{
    Name = "Жанатпаева Динара",
    Group = "исп-232",
    Course = 3,
    Skills = new[] { "C#", "html", "css", "js", "app.net" }

}));
app.MapGet("/calc/{a}/{b}", (double a, double b) =>
Results.Ok(new
{
    A = a,
    B = b,
    Sum = a + b,
    Diff = a - b,
    Mul = a * b,
    Div = b != 0 ? a / b : 0
})
);
app.MapFallback(() => Results.NotFound(new
{
    Error = "Маршрут не найден",
    Code = 404
}));

app.Run();
record Product(int Id, string Name, decimal Price, bool InStock);