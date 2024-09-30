using EmpireSimulator.Models.Resourses;

namespace EmpireSimulator.Models.Buildings {
    public class ProductionLargeBuilding: LargeBuilding {
        public ProductionLargeBuilding(GameplayContext gameplayContext)
            : base(gameplayContext) {
            resourse = ResourseType.Production;
            var effect = new InflowMultiplier(() => Count > 0 ? Count * 1.3 : 1);
            _gameplayContext.resoursesContext[resourse].Multipliers.Add(effect);
        }

    }
}
