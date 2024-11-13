using Microsoft.Extensions.Logging;

namespace ExtensionMethodsLibrary.Helpers
{
    public static class LoggerExtensions
    {
        public static void LogException(this ILogger logger, Exception exception, string message = "")
        {
            logger.LogError(exception, message);
        }
    }
}
