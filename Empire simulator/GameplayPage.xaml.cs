using Empire_simulator.models;
using System.Windows;
using System.Windows.Controls;

namespace Empire_simulator {
    /// <summary>
    /// Логика взаимодействия для Gameplay.xaml
    /// </summary>
    public partial class GameplayPage: Page {

        Thread gameplayThread;
        GameplayManager gameplayManager;

        public GameplayPage() {
            InitializeComponent();
            gameplayManager = new(this);
            gameplayThread = new Thread(() => {
                gameplayManager.StartGame();
            });
            gameplayThread.Start();
        }

        public void AddMessage(string msg) {
            Label newMsg = new();
            newMsg.Content = msg;
            MessagesStack.Children.Add(newMsg);
        }

        public void LeaveGame(object sender, RoutedEventArgs e) {
            gameplayManager.StopGame();
            MenuPage menuPage = new();
            this.NavigationService.Navigate(menuPage);
        }
        
    }
}
