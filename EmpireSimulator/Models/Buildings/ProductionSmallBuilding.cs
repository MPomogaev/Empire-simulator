

using EmpireSimulator.Models.Resourses;

namespace EmpireSimulator.Models.Buildings {
    public class ProductionSmallBuilding: SmallBuilding {
        public ProductionSmallBuilding(GameplayContext gameplayContext)
            : base(gameplayContext) {
            resourse = ResourseType.Production;
        }
    }
}
