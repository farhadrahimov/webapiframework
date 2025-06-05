using Serilog;

namespace OBAWebAPI.Framework.ApiResponse.Infrastructure.Middlewares
{
    public class LoggingConfiguration
    {
        public static void ConfigureSerilog()
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Information()
                .WriteTo.File("logs/requests-.log", rollingInterval: RollingInterval.Day)
                .CreateLogger();
        }
    }
}
