using LoggerLibrary;
using LoggerLibrary.Inteface;

ILogger logger = new FileLogger("logs//application.log", 2*1024);

try
{
    PlatformCriticalModule();
    logger.Info("Операция выполнена успешно.");
}
catch (InvalidOperationException ex)
{
    logger.Error("Некорректная операция: " + ex.Message);
}
catch (Exception ex)
{
    logger.Error("Произошла непредвиденная ошибка.", ex);
}


void PlatformCriticalModule()
{
    throw new InvalidOperationException("Демонстрация исключения.");
}