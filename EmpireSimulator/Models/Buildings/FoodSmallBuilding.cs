using EmpireSimulator.Models.Resourses;

namespace EmpireSimulator.Models.Buildings {
    public class FoodSmallBuilding: SmallBuilding {
        public FoodSmallBuilding(GameplayContext gameplayContext)
            : base(gameplayContext) {
            resourse = ResourseType.Food;
        }

    }
}
