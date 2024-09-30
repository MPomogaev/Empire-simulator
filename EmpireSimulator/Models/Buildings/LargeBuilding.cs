using EmpireSimulator.Models.Resourses;

namespace EmpireSimulator.Models.Buildings {
    public abstract class LargeBuilding: AbstractBuilding {
        public LargeBuilding(GameplayContext gameplayContext) {
            _gameplayContext = gameplayContext;
            _cost = new() {
                { ResourseType.Production, 50 },
                { ResourseType.Money, 100 }
            };
            _upkeep = 5;
        }

    }
}
