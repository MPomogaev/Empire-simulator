using EmpireSimulator.Models.Resourses;

namespace EmpireSimulator.Models.Buildings {
    public abstract class SmallBuilding: AbstractBuilding {
        public SmallBuilding(GameplayContext gameplayContext) {
            _gameplayContext = gameplayContext;
            _cost = new() {
                { ResourseType.Production, 20 },
                { ResourseType.Money, 50 }
            };
            _upkeep = 2;
        }

        public override bool Build() {
            if (base.Build()) {
                _gameplayContext.newWorkerContext[resourse].MaxCount += 5;
                return true;
            }
            return false;
        }

        public override bool Destroy() {
            if (base.Destroy()) {
                _gameplayContext.newWorkerContext[resourse].MaxCount -= 5;
                return true;
            }
            return false;
        }

    }
}
