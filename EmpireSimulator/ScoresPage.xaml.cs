using EmpireSimulator.Data;
using EmpireSimulator.InterfaceObjects;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Xml.Linq;

namespace EmpireSimulator {
    /// <summary>
    /// Логика взаимодействия для ScoresPage.xaml
    /// </summary>
    public partial class ScoresPage: Page {
        public ScoresPage() {
            InitializeComponent();
            XDocument scoresDocument = FileManager.GetScoresFile();
            foreach(var score in scoresDocument.Root.Elements()) {
                ScoreEntry entry = new();
                entry.EmpireName = score.Element("empire-name").Value;
                entry.Score = int.Parse(score.Element("score").Value);
                ScoresGrid.Children.Add(entry);
            }
        }

        public void Back(object sender, RoutedEventArgs e) {
            MenuPage menuPage = new();
            this.NavigationService.Navigate(menuPage);
        }

        private void ScrollViewer_MouseWheel(object sender, MouseWheelEventArgs e) {
            if (e.Delta > 0) {
                MyScrollViewer.ScrollToVerticalOffset(MyScrollViewer.VerticalOffset - 20);
            } else {
                MyScrollViewer.ScrollToVerticalOffset(MyScrollViewer.VerticalOffset + 20);
            }

            e.Handled = true;
        }
    }
}
