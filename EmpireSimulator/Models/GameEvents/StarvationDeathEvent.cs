using EmpireSimulator.Models.Resourses;

namespace EmpireSimulator.Models.GameEvents {
    public class StarvationDeathEvent: PopulationDeathEvent {

        public StarvationDeathEvent() { 
            deathCount = 1;
            _name = "Голод!";
            _description = "1 ед. населения умерла от голода(";
        }

        protected override void SetEventListener() {
            var food = (FoodResourse)_gameplayContext.resoursesContext[ResourseType.Food];
            food.Starvation += AddToEventListAction;
        }
    }
}
