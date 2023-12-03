var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// HEADERS
//app.MapGet("/", (HttpContext context) =>
//{
//    context.Request.Headers.TryGetValue("User-Agent", out var userAgent);
//    context.Request.Headers.TryGetValue("SecretCode", out var secreteCode);

//    return $"User Agent: {userAgent}, Secret code: {secreteCode}";
//});

app.MapGet("/", () => "Hello");
app.MapPost("/data", async (HttpContext context) =>
{
    using StreamReader reader = new(context.Request.Body);
    string text = await reader.ReadToEndAsync();
    return $"Server load data: {text}";
});

app.MapPost("/new", (Employee employee) =>
{
    employee.Id = Guid.NewGuid().ToString();
    return employee;
});

app.Run();


class Employee
{
    public string Id { set; get; } = "";
    public string Name { set; get; } = "";
    public int Age { set; get; }
}
