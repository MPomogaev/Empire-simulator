using System.Runtime.InteropServices;
using System.Windows;
using EmpireSimulator.Data;
using Microsoft.Extensions.Logging;

namespace EmpireSimulator {
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>


    public partial class App: Application {
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();

        public App() {
            AllocConsole();
            // Создание фабрики логгеров
            var loggerFactory = LoggerFactory.Create(builder => {
                builder.AddConsole(); // Вывод логов в консоль
                builder.AddDebug();
            });
            LogManager.Initialize(loggerFactory);

            var _logger = LogManager.GetLogger<App>();

            // Пример логирования
            _logger.LogInformation("Приложение запущено");
        }

    }

}
