namespace EmpireSimulator.Models.Buildings {
    public abstract class MediumBuildingHasStorage: MediumBuilding {
        public MediumBuildingHasStorage(GameplayContext gameplayContext)
            : base(gameplayContext) { }

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
