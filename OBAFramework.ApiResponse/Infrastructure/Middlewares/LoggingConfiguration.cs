using Serilog;

namespace OBAFramework.ApiResponse.Infrastructure.Middlewares
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
