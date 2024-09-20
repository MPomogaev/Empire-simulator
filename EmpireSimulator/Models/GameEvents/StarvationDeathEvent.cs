using EmpireSimulator.Models.Resourses;

namespace EmpireSimulator.Models.GameEvents {
    public class StarvationDeathEvent: AbstractEvent {
        private GameplayContext _gameplayContext;

        public override void Happen() {
            lock (_gameplayContext.newWorkerContext) {
                _gameplayContext.newWorkerContext.RemovePopulation();
            }
            _gameplayContext.eventContext.RemoveEvent(Id);
        }

        public override void SetEventListener(GameplayContext gameplayContext) {
            _gameplayContext = gameplayContext;
            var food = (FoodResourse)_gameplayContext.resoursesContext[ResourseType.Food];
            food.Starvation += (obj, args) => {
                _id = _gameplayContext.eventContext.AddEvent(this);
            };
        }

        public override string? Name => "Голодная смерть!";

        public override string? Description => "1 ед. населения умерла от голода(";
    }
}
