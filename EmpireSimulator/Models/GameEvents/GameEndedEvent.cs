using EmpireSimulator.Models.Resourses;

namespace EmpireSimulator.Models.GameEvents {
    public class GameEndedEvent: AbstractEvent {

        public override void SetEventListener(GameplayContext gameplayContext) {
            _gameplayContext = gameplayContext;
            var food = (FoodResourse)_gameplayContext.resoursesContext[ResourseType.Food];
            food.Starvation += StarvationEndGame;
        }

        public override void Happen() {
            _gameplayContext.Manager.StopGame();
        }

        private void StarvationEndGame(object obj, EventArgs args) {
            if (_gameplayContext.newWorkerContext.AllWorkersCount <= 0) {
                Happen();
            }
        }
    }
}
