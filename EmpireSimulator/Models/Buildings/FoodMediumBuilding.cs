using EmpireSimulator.Models.Resourses;

namespace EmpireSimulator.Models.Buildings {
    public class FoodMediumBuilding: MediumBuildingHasStorage {
        public FoodMediumBuilding(GameplayContext gameplayContext)
            : base(gameplayContext) {
            var effect = new InflowSummand(() => Count * 10);
            _gameplayContext.resoursesContext[ResourseType.Food].Summands.Add(effect);
            resourse = ResourseType.Food;
        }
    }
}
