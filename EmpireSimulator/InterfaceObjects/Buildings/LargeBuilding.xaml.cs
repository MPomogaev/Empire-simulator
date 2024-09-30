using System.Windows.Controls;
using System.Windows.Media;

namespace EmpireSimulator.InterfaceObjects.Buildings {
    /// <summary>
    /// Логика взаимодействия для LargeBuilding.xaml
    /// </summary>
    public partial class LargeBuilding: UserControl {
        public LargeBuilding() {
            InitializeComponent();
        }

        public Brush Color { set {
                Square1.Color = value;
                Square2.Color = value;
                Square3.Color = value;
            } 
        }

    }
}
