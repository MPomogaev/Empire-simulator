using System.Windows.Controls;
using System.Windows.Media;


namespace EmpireSimulator.InterfaceObjects {
    /// <summary>
    /// Логика взаимодействия для EffectMessage.xaml
    /// </summary>
    public partial class EffectMessage: UserControl {
        public EffectMessage() {
            InitializeComponent();
        }

        public string EffectName { set => EffectNameLabel.Content = value; }
        public int DurationCount {  set => DurationCountLabel.Content = value;}
        public Brush TypeColor { set => EffectNameLabel.Foreground = value; }
    }
}
