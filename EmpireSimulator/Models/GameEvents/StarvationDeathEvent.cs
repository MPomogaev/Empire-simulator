using EmpireSimulator.Models.Resourses;

namespace EmpireSimulator.Models.GameEvents {
    public class StarvationDeathEvent: AbstractEvent {
        public override void Happen() {
            lock (_gameplayContext.newWorkerContext) {
                _gameplayContext.newWorkerContext.RemovePopulation();
            }
            _gameplayContext.eventContext.RemoveEvent(Id);
        }

        public override void SetEventListener(GameplayContext gameplayContext) {
            _gameplayContext = gameplayContext;
            var food = (FoodResourse)_gameplayContext.resoursesContext[ResourseType.Food];
            food.Starvation += AddToEventListAction;
        }

        public override string? Name => "Голод!";

        public override string? Description => "1 ед. населения умерла от голода(";

        public override EventType Type => EventType.Negative;
    }
}
