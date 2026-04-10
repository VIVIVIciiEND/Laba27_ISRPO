var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "привет от ИСП-232 Автор : Динара");

app.Run();
