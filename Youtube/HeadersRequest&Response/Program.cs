using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Primitives;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", (HttpContext context) =>
{
    // string path = context.Request.Path;
    // string method = context.Request.Method;
    var userAgent = "";
    if (context.Request.Headers.ContainsKey("User-Agent"))
    {
        userAgent = context.Request.Headers["User-Agent"];
    }
    context.Response.Headers["Content-Type"] = "text/html";
    context.Response.Headers["Custom-Header"] = "hello world";
    var myHeader = context.Response.Headers["Custom-Header"];
    context.Response.StatusCode = 200; 
    // return $"path is {path} and method is {method}";
    return $"user agent is <h2>{userAgent}</h2> and this is my custom header: <h2>{myHeader}</h2>";
});

app.Run(async (HttpContext context) =>
{
    string path = context.Request.Path;
    string method = context.Request.Method;

    if (path == "/" || path == "/Home")
    {
        context.Response.StatusCode = 200;
        await context.Response.WriteAsync("Hello from the home page");
    }
    else if (path == "/Contact")
    {
        context.Response.StatusCode = 200;
        await context.Response.WriteAsync("Hello from the contact page");
    }
    else if (method == "GET" && path == "/Product")
    {
        context.Response.StatusCode = 200; //send status code before response
        if (context.Request.Query.ContainsKey("id") && context.Request.Query.ContainsKey("name"))
        {
            var id = context.Request.Query["id"];
            var name = context.Request.Query["name"];

            await context.Response.WriteAsync($"you selected a product with ID : {id} and name {name}");
            return;
        }
        await context.Response.WriteAsync("Hello from the product page");
    }
    else if (method == "POST" && path == "/Product")
    {
        string id = "";
        string name = "";
        StreamReader reader = new StreamReader(context.Request.Body);
        string data = await reader.ReadToEndAsync();
        Dictionary<string, StringValues> dict = QueryHelpers.ParseQuery(data);

        if (dict.ContainsKey("id"))
        {
            id = dict["id"];
        }
        if (dict.ContainsKey("name"))
        {
            name = dict["id"];
        }

        await context.Response.WriteAsync($"this is data: {data}, and this is id : {id} and name {name}");
    }
    else
    {
        context.Response.StatusCode = 404;
        await context.Response.WriteAsync("the page you are looking for is not found");
    }
});

app.Run();
