namespace HelpdeskBot.Utils
{
    public class SessionCheckMiddleware
    {
        private readonly RequestDelegate _next;

        public SessionCheckMiddleware(RequestDelegate next)
        { 
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (context.Session.GetInt32("ClienteId") == null)
            {
                //context.Response.Redirect("/Account/Login");
                //return;
            }

            await _next(context);
        }
    }

}
