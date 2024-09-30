using EmpireSimulator.Models.Resourses;

namespace EmpireSimulator.Models.Buildings {
    public class ScienceSmallBuilding: SmallBuilding {
        public ScienceSmallBuilding(GameplayContext gameplayContext)
            : base(gameplayContext) { 
            resourse = ResourseType.Science; 
        }
    }
}
