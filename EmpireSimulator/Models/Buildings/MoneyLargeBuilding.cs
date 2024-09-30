using EmpireSimulator.Models.Resourses;

namespace EmpireSimulator.Models.Buildings {
    public class MoneyLargeBuilding: LargeBuilding {
        public MoneyLargeBuilding(GameplayContext gameplayContext)
            : base(gameplayContext) {
            resourse = ResourseType.Money;
            var effect = new InflowMultiplier(() => Count > 0 ? Count * 1.3 : 1);
            _gameplayContext.resoursesContext[resourse].Multipliers.Add(effect);
        }
    }
}
