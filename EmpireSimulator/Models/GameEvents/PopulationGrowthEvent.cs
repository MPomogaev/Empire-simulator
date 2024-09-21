using EmpireSimulator.Models.Resourses;
using EmpireSimulator.Data;

namespace EmpireSimulator.Models.GameEvents {
    public class PopulationGrowthEvent: AbstractEvent {

        private FoodResourse foodResourse;

        public override void Happen() {
            lock(_gameplayContext.newWorkerContext) {
                _gameplayContext.newWorkerContext.AvailableWorkersCount++;
            }
            RemoveFromEventList();
        }

        public override void SetEventListener(GameplayContext gameplayContext) {
            _gameplayContext = gameplayContext;
            foodResourse = (FoodResourse)_gameplayContext.resoursesContext[ResourseType.Food];
            _gameplayContext.turnCounter.NextTurnEvent += AddToEventListAction;
        }

        string _description = "eстевтсвенный прирост населения ";
        public override string? Name => "Новое население";
        public override string? Description => _description;
        public override EventType Type => EventType.Positive;

        protected override bool IsHappend() {
            var workerContext = _gameplayContext.curentWorkerContext;
            double consumption = foodResourse.GetConsuption(workerContext);
            double production = foodResourse.GetProduction(workerContext);
            if (production == 0) {
                return false;
            }
            double linierChance = production / (production + consumption);
            double curvedChance = Data.ChanceCurves.CurveLinierChance(linierChance, ChanceScale.Small);
            return RandomGenerator.IsHappened(curvedChance);
        }

    }
}
