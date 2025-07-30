using Middleware.CustomMiddleware;

//creates an instance of webapplicaiton builder
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<MyMiddleware>(); //register the custom middleware to the service collection
//creates an instance of webapplicaiton 
var app = builder.Build();

//middleware 1
app.Use(async (HttpContext context, RequestDelegate next) =>
{
    await context.Response.WriteAsync("hello this is middleware");
    await next(context);
});

// middleware 2
app.Use(async (HttpContext context, RequestDelegate next) =>
{
    await context.Response.WriteAsync("\n\n");
    await next(context);
});

//middleware 3
// app.UseMiddleware<MyMiddleware>();
app.MyMiddleware();     //custom middleware extension method

//middleware 4
//this is terminal middleware or short-circuiting middleware
app.Run(async (HttpContext context) =>
{
    await context.Response.WriteAsync("hello this is actually 4th middleware\n\n");
});

app.Run();