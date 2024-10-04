using System.Windows.Controls;

namespace EmpireSimulator.InterfaceObjects {
    /// <summary>
    /// Логика взаимодействия для ScoreEntry.xaml
    /// </summary>
    public partial class ScoreEntry: UserControl {
        public ScoreEntry() {
            InitializeComponent();
        }

        public string EmpireName { set => EmpireNameLabel.Content = value; }
        public int Score { set => EmpireScoreCounter.Counter = value; }
    }
}
