namespace BirthflowService.API.Middlewares
{
    public class DeviceInfoMiddleware
    {
        private readonly RequestDelegate _next;

        public DeviceInfoMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var deviceInfo = context.Request.Headers["Device-Info"].ToString();
            context.Items["DeviceInfo"] = deviceInfo;
            await _next(context);
        }
    }
}
