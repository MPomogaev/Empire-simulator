using EmpireSimulator.Models.Resourses;

namespace EmpireSimulator.Models.Buildings {
    public class MoneyMediumBuilding: MediumBuildingHasStorage {
        public MoneyMediumBuilding(GameplayContext gameplayContext)
            : base(gameplayContext) {
            var effect = new InflowSummand(() => Count * 20);
            _gameplayContext.resoursesContext[ResourseType.Money].Summands.Add(effect);
            resourse = ResourseType.Money;
        }
    }
}
