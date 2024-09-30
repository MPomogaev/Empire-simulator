using System.Windows.Controls;
using System.Windows.Media;

namespace EmpireSimulator.InterfaceObjects.Buildings {
    /// <summary>
    /// Логика взаимодействия для BorderedSquare.xaml
    /// </summary>
    public partial class BorderedSquare: UserControl {
        public BorderedSquare() {
            InitializeComponent();
        }

        public Brush Color {  set => BackgroundRectangle.Fill = value; }
    }
}
