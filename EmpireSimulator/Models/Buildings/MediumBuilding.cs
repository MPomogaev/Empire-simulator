using EmpireSimulator.Models.Resourses;

namespace EmpireSimulator.Models.Buildings {
    public abstract class MediumBuilding: AbstractBuilding {
        public MediumBuilding(GameplayContext gameplayContext) {
            _gameplayContext = gameplayContext;
            _cost = new() {
                { ResourseType.Production, 50 },
                { ResourseType.Money, 100 }
            };
            _upkeep = 5;
        }

        protected int effectId;
    }
}
