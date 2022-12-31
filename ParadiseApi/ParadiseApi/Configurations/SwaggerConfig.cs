using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection;

namespace ParadiseApi.Configurations
{
    public class SwaggerConfig
    {
        public static void AddConfig(SwaggerGenOptions options)
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Version = "v1",
                Title = "Paradise API",
                Description = "An ASP.NET Core Web API for video hosting ",
                Contact = new OpenApiContact
                {
                    Name = "JustKaneri",
                    Url = new Uri("https://github.com/JustKaneri")
                }
            });

            var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
        }
    }
}
