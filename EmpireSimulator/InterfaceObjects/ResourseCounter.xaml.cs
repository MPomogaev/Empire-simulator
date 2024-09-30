using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Navigation;


namespace EmpireSimulator.InterfaceObjects {
    /// <summary>
    /// Логика взаимодействия для ResourseCounter.xaml
    /// </summary>
    public partial class ResourseCounter: UserControl {
        public ResourseCounter() {
            InitializeComponent();
        }

        public int? InflowCounter { set => InflowCounterLabel.Content = value; }

        public int? StorageCapacity { set => StorageCapacityLabel.Content = value; }

        public int? MaxStorageCapacity { set => MaxStorageCapacityLabel.Content = value; }

        public Brush Color { set {
                InflowCounterLabel.Foreground = value;
                StorageCapacityLabel.Foreground = value;
                MaxStorageCapacityLabel.Foreground = value;
            } 
        }
    }
}
