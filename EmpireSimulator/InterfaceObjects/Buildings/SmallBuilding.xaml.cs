using System.Windows.Controls;
using System.Windows.Media;

namespace EmpireSimulator.InterfaceObjects.Buildings {
    /// <summary>
    /// Логика взаимодействия для SmallBuilding.xaml
    /// </summary>
    public partial class SmallBuilding: UserControl {
        public SmallBuilding() {
            InitializeComponent();
        }

        public Brush Color { set => Square.Color = value; }
    }
}
