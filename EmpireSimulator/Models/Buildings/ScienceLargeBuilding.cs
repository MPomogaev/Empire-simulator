using EmpireSimulator.Models.Resourses;

namespace EmpireSimulator.Models.Buildings {
    public class ScienceLargeBuilding: LargeBuilding {
        public ScienceLargeBuilding(GameplayContext gameplayContext)
            : base(gameplayContext) {
            resourse = ResourseType.Science;
            var effect = new InflowMultiplier(() => Count > 0 ? Count * 1.3 : 1);
            _gameplayContext.resoursesContext[resourse].Multipliers.Add(effect);
        }
    }
}
