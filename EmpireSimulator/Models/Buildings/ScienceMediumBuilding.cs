using EmpireSimulator.Models.Resourses;

namespace EmpireSimulator.Models.Buildings {
    public class ScienceMediumBuilding: MediumBuilding {
        public ScienceMediumBuilding(GameplayContext gameplayContext)
            : base(gameplayContext) {
            var effect = new InflowSummand(() => Count * 5);
            _gameplayContext.resoursesContext[ResourseType.Science].Summands.Add(effect);
            resourse = ResourseType.Science;
        }
    }
}
