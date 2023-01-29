namespace ParadiseApi.Middleware
{
    public class LoggingMiddleware
    {
        public readonly RequestDelegate _next;
        public LoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            await _next.Invoke(context);

            string data = DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss");
            string requestUser = context.Request.Headers.UserAgent.ToString();
            string requestBody = "";
            using (var reader = new StreamReader(context.Request.Body))
            {
                requestBody = await reader.ReadToEndAsync();
            }
            string requestPath = context.Request.Path;
            string responce = context.Response.StatusCode.ToString();


            Console.WriteLine($"{data}" +
                              $"\t\t\n User:{requestUser} " +
                              $"\t\t\n Request body: {requestBody} " +
                              $"\t\t\n Path {requestPath}" +
                              $"\t\t\n Status {responce}");

        }
    }
}
