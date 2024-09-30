using EmpireSimulator.Models.Resourses;

namespace EmpireSimulator.Models.Buildings {
    public class ProductionMediumBuilding: MediumBuildingHasStorage {
        public ProductionMediumBuilding(GameplayContext gameplayContext)
            : base(gameplayContext) {
            var effect = new InflowSummand(() => Count * 5);
            _gameplayContext.resoursesContext[ResourseType.Production].Summands.Add(effect);
            resourse = ResourseType.Production;
        }
    }
}
