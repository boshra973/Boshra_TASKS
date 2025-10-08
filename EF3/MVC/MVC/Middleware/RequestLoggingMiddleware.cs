namespace MVC.Middleware
{
    public class RequestLoggingMiddleware
    {
        // deligate
        private readonly RequestDelegate next;

        public RequestLoggingMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var path = context.Request.Path;
            var user = context.User.Identity.IsAuthenticated ? context.User.Identity.Name : "Anonymous";
            var timestamp = DateTime.Now;

            // output appear in console 3adi
            Console.WriteLine($"[{timestamp}] User: {user}, Path: {path}");

            await next(context);// to wait for the next request
        }
    }
}
