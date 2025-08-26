var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseRouting();

app.Use(async (context, next) =>
{
    Endpoint endpoint = context.GetEndpoint();
    if (endpoint != null)
        await context.Response.WriteAsync($"{endpoint.DisplayName} ");
    await next(context);
});

app.UseEndpoints(endpoint =>
{
    endpoint.Map("/Home", async (HttpContext context) =>
    {
        await context.Response.WriteAsync("Hello, World! This is the Home endpoint.");
    });
    endpoint.MapGet("/Product", async (context) =>
    {
        await context.Response.WriteAsync("Hello, World! This is the Product endpoint.");
    });
    endpoint.MapPost("/Product", async (context) =>
    {
        await context.Response.WriteAsync("new product another another new hello created");
    });
});

app.Run(async (HttpContext context) =>
{
    await context.Response.WriteAsync("404 page is not found");
});

app.Run();