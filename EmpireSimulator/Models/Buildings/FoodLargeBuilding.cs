using EmpireSimulator.Models.Resourses;

namespace EmpireSimulator.Models.Buildings {
    public class FoodLargeBuilding: LargeBuilding {
        public FoodLargeBuilding(GameplayContext gameplayContext)
            : base(gameplayContext) {
            resourse = ResourseType.Food;
            var effect = new InflowMultiplier(() =>  Count > 0 ? Count * 1.3: 1);
            _gameplayContext.resoursesContext[resourse].Multipliers.Add(effect);
        }
    }
}
