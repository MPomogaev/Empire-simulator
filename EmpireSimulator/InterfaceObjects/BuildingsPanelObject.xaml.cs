using EmpireSimulator.InterfaceObjects.Buildings;
using EmpireSimulator.Models.Resourses;
using System.Windows.Controls;

namespace EmpireSimulator.InterfaceObjects {
    /// <summary>
    /// Логика взаимодействия для BuildingsPanel.xaml
    /// </summary>
    public partial class BuildingsPanelObject: UserControl {
        private Dictionary<ResourseType, BuildingsBlock> resourseBuildings;

        public BuildingsPanelObject() {
            InitializeComponent();
            resourseBuildings = new() {
                { ResourseType.Food, FoodBuildings },
                { ResourseType.Production, ProductionBuildings },
                { ResourseType.Money, MoneyBuildings },
                { ResourseType.Science, ScienceBuildings },
            };
        }

        public BuildingsBlock this[ResourseType resourseType] { 
            get => resourseBuildings[resourseType]; 
        }
    }
}
