using EmpireSimulator.Models.Resourses;

namespace EmpireSimulator.Models.Buildings {
    public class BuildingContext {
        private Dictionary<ResourseType, Dictionary<BuildingType, AbstractBuilding>> buildings;
        private GameplayContext _gameplayContext;

        public BuildingContext(GameplayContext gameplayContext) {
            _gameplayContext = gameplayContext;
            buildings = new() { { ResourseType.Food, new() {
                    { BuildingType.Small, new FoodSmallBuilding(_gameplayContext) },
                    { BuildingType.Medium, new FoodMediumBuilding(_gameplayContext) },
                    { BuildingType.Large, new FoodLargeBuilding(_gameplayContext) },
                }}, { ResourseType.Production, new() {
                    { BuildingType.Small, new ProductionSmallBuilding(_gameplayContext) },
                    { BuildingType.Medium, new ProductionMediumBuilding(_gameplayContext) },
                    { BuildingType.Large, new ProductionLargeBuilding(_gameplayContext) },
                }}, { ResourseType.Science, new() {
                    { BuildingType.Small, new ScienceSmallBuilding(_gameplayContext) },
                    { BuildingType.Medium, new ScienceMediumBuilding(_gameplayContext) },
                    { BuildingType.Large, new ScienceLargeBuilding(_gameplayContext) },
                }}, { ResourseType.Money, new() {
                    { BuildingType.Small, new MoneySmallBuilding(_gameplayContext) },
                    { BuildingType.Medium, new MoneyMediumBuilding(_gameplayContext) },
                    { BuildingType.Large, new MoneyLargeBuilding(_gameplayContext) },
                }},
            };
        }

        public AbstractBuilding this[ResourseType resourse, BuildingType building] {
            get => buildings[resourse][building];
        }
    }
}
