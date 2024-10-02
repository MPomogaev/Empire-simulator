using EmpireSimulator.Data;
using Microsoft.Extensions.Logging;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace EmpireSimulator
{
    /// <summary>
    /// Логика взаимодействия для MenuPage.xaml
    /// </summary>
    public partial class MenuPage : Page
    {
        ILogger _logger;
        IndexedStackPositions stackPositions = new();
        PopMessagesAnimator animator;
        Thread thr;
        public MenuPage()
        {
            InitializeComponent();
            Loaded += MessagesAnimation;
            _logger = LogManager.GetLogger<MenuPage>();
            animator = new(this);
        }

        public void GoToGameplay(object sender, RoutedEventArgs e) {
            LeavePage();
            GameplayPage gameplayPage = new();
            this.NavigationService.Navigate(gameplayPage);
        }

        public void Exit(object sender, RoutedEventArgs e) {
            LeavePage();
            Application.Current.Shutdown();
        }

        public void AddMessageToCanvas(Label message) {
            int stackPosition = MessagesCanvas.Children.Add(message);
            int stackPositionId = stackPositions.Add(stackPosition);
            message.Style = (Style)FindResource("MessagesLabelStyle");
            message.FontSize = RandomGenerator.RandomInt(16, 42);
            double maxWidth = MessagesCanvas.ActualWidth;
            double x = RandomGenerator.RandomDouble(maxWidth * 0.9);
            Canvas.SetLeft(message, x);
            DoubleAnimation animation = new DoubleAnimation {
                From = ActualHeight, 
                To = -50,  
                Duration = new Duration(TimeSpan.FromSeconds(40)), 
                AutoReverse = false 
            };
            animation.Completed += (object o, EventArgs args) => {
                int stackPosition = stackPositions.Remove(stackPositionId);
                MessagesCanvas.Children.RemoveAt(stackPosition);
            };
            message.BeginAnimation(Canvas.TopProperty, animation);
        }

        private void LeavePage() {
            animator.Stop();
            thr.Join();
        }

        private void MessagesAnimation(object sender, RoutedEventArgs e) {
            thr = new(animator.Start);
            thr.Start();
        }
    }
}
