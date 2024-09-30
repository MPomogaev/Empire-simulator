using EmpireSimulator.Models.Resourses;

namespace EmpireSimulator.Models.Buildings {
    public class MoneySmallBuilding: SmallBuilding {
        public MoneySmallBuilding(GameplayContext gameplayContext)
            : base(gameplayContext) {
            resourse = ResourseType.Money;
        }
    }
}
