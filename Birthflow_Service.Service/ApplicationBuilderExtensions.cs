using BirthflowService.API.Middlewares;
using BirthflowService.API.Models;
using Microsoft.AspNetCore.SignalR;
using Swashbuckle.AspNetCore.Swagger;

namespace BirthflowService.API
{
    public static class ApplicationBuilderExtensions
    {
        public static void ConfigurePipeline(this WebApplication app, IConfiguration swaggerConfig)
        {
            if (app.Environment.IsDevelopment())
            {
                // Leer configuración de Swagger desde el archivo JSON
                var swaggerOptions = new SwashbuckleSwaggerOptions();
                swaggerConfig.Bind(swaggerOptions);

                app.UseSwagger();

                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint(swaggerOptions.Endpoint, $"{swaggerOptions.Title} {swaggerOptions.Version}");
                    c.RoutePrefix = swaggerOptions.RoutePrefix;
                });
            }
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseMiddleware<DeviceInfoMiddleware>();

            app.MapControllers();
        }
    }
}
