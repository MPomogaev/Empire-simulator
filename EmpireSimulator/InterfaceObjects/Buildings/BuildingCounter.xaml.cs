using System.Windows.Controls;

namespace EmpireSimulator.InterfaceObjects.Buildings {
    /// <summary>
    /// Логика взаимодействия для BuildingCounter.xaml
    /// </summary>
    public partial class BuildingCounter: UserControl {
        public BuildingCounter() {
            InitializeComponent();
        }

        public Action OnMinusClick { get; set; }

        public Action OnPlusClick { get; set; }

        public int Counter { set => CounterLabel.Content =  value; }

        private void MinusClick(object sender, System.Windows.Input.MouseButtonEventArgs e) {
            OnMinusClick();
        }

        private void PlusClick(object sender, System.Windows.Input.MouseButtonEventArgs e) {
            OnPlusClick();
        }

    }
}
