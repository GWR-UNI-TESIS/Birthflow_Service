using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace BirthflowService.API.Helpers
{
    public class AddDeviceInfoHeader : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            operation.Parameters.Add(new OpenApiParameter
            {
                Name = "Device-Info",
                In = ParameterLocation.Header,
                Required = false, // Cambia a true si es obligatorio
                Description = "Información del dispositivo",
                Schema = new OpenApiSchema { Type = "string" }
            });
        }
    }
}
