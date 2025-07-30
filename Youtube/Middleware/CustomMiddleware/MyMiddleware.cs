namespace Middleware.CustomMiddleware
{
    public class MyMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            // throw new NotImplementedException();
            // before logic
            await context.Response.WriteAsync("custom middleware started!\n\n");
            await next(context);
            // after logic
            await context.Response.WriteAsync("finish\n\n");
        }
    }

    public static class CustomMiddlewareExtension
    {
        public static IApplicationBuilder MyMiddleware(this IApplicationBuilder app)
        {
            return app.UseMiddleware<MyMiddleware>();
        }
    }
}