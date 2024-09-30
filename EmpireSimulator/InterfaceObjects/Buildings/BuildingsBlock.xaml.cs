using EmpireSimulator.Models.Buildings;
using System.Diagnostics;
using System.Windows.Controls;
using System.Windows.Media;

namespace EmpireSimulator.InterfaceObjects.Buildings {
    /// <summary>
    /// Логика взаимодействия для BuildingsBlock.xaml
    /// </summary>
    public partial class BuildingsBlock: UserControl {
        private Dictionary<BuildingType, BuildingCounter> counters;

        public BuildingsBlock() {
            InitializeComponent();
            counters = new() {
                { BuildingType.Small, SmallCounter },
                { BuildingType.Medium, MediumCounter },
                { BuildingType.Large, LargeCounter },
            };
        }

        public Brush Color { set {
                Small.Color = value;
                Medium.Color = value;
                Large.Color = value;
            } 
        }

        public BuildingCounter this[BuildingType type] { get => counters[type]; }
    }
}
