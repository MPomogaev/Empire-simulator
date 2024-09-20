using System.Windows.Media;

namespace EmpireSimulator.Data {
    public static class BrushConverter {
        public static Brush GetBrushFromColorString(string colorString) {
            Color color = (Color)ColorConverter.ConvertFromString(colorString);
            return new SolidColorBrush(color);
        }
    }
}
