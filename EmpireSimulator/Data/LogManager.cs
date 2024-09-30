using Microsoft.Extensions.Logging;

namespace EmpireSimulator.Data {

    public static class LogManager {
        private static ILoggerFactory _loggerFactory;

        // Метод для инициализации логгера
        public static void Initialize(ILoggerFactory loggerFactory) {
            _loggerFactory = loggerFactory;
        }

        public static ILogger GetLogger<T>() {
            return _loggerFactory.CreateLogger<T>();
        }
    }
}
