using ParadiseApi.Data;
using ParadiseApi.Models;

namespace ParadiseApi.Middleware
{
    public class LoggingMiddleware
    {
        public readonly RequestDelegate _next;

        public LoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, LogDataContext contextDB)
        {
            await _next.Invoke(context);

            Logging log = new Logging();

            log.Date = DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss");
            log.RequestBody = "";
            using (var reader = new StreamReader(context.Request.Body))
            {
                log.RequestBody = await reader.ReadToEndAsync();
            }
            log.RequestPath = context.Request.Path;
            log.StatusCode = context.Response.StatusCode;

            try
            {
                contextDB.Logs.Add(log);
                await contextDB.SaveChangesAsync();
            }
            catch(Exception e)
            {
                Console.WriteLine("Not save logs " + e);
            }

        }
    }
}
