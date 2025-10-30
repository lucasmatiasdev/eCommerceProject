using eCommerceProject.Application.Services.Interfaces.Logging;
using Microsoft.Extensions.Logging;

namespace eCommerceProject.Application.Services.Implementations
{
    public class SerilogLoggerAdapter<T>(ILogger<T> logger) : IAppLogger<T>
    {
        public void LogInformation(string message) => logger.LogInformation(message);

        public void LogWarning(string message) => logger.LogWarning(message);

        public void LogError(Exception ex, string message) => logger.LogError(ex, message);
    }
}
