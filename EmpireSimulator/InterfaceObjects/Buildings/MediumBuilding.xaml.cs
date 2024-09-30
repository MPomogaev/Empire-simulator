using System.Windows.Controls;
using System.Windows.Media;

namespace EmpireSimulator.InterfaceObjects.Buildings {
    /// <summary>
    /// Логика взаимодействия для MidleBuilding.xaml
    /// </summary>
    public partial class MediumBuilding: UserControl {
        public MediumBuilding() {
            InitializeComponent();
        }

        public Brush Color { set {
                Square1.Color = value;
                Square2.Color = value;
            } 
        }
    }
}
