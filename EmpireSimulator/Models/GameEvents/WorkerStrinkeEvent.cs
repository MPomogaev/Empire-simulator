
using EmpireSimulator.Data;
using EmpireSimulator.Models.GameEffects;
using EmpireSimulator.Models.Resourses;

namespace EmpireSimulator.Models.GameEvents {
    public class WorkerStrinkeEvent: AbstractEvent {
        private MoneyResourse moneyResourse;
        private bool isHappening = false;
        private int duration = 10;
        private int unavailableCount = 0;
        private int lastStrikeTurn;

        public override void Happen() {
            double consumption = moneyResourse.GetConsuption(_gameplayContext.curentWorkerContext);
            double outflow = -moneyResourse.Inflow.Value;
            int allPopulation = _gameplayContext.curentWorkerContext.AllWorkersCount;
            int maxUnavailable = (int)Math.Round((outflow / consumption) * allPopulation);
            unavailableCount = RandomGenerator.RandomInt(1, maxUnavailable + 1);
            var effect = new StrikeEffect(_gameplayContext, unavailableCount, duration);
            effect.Start();
            lastStrikeTurn = _gameplayContext.turnCounter.Count;
            _gameplayContext.eventContext.RemoveEvent(_id);
        }

        public override void SetEventListener(GameplayContext gameplayContext) {
            _gameplayContext = gameplayContext;
            moneyResourse = (MoneyResourse)_gameplayContext.resoursesContext[Resourses.ResourseType.Money];
            moneyResourse.NoMoneyLeft += AddToEventListAction;
        }

        public override EventType Type => EventType.Negative; 

        public override string? Name => "Забастовка";

        public override string? Description => GetDescription();

        private string GetDescription() {
            return unavailableCount
                + " ед. населения отказываются работать ещё "
                + duration + " ходов";
        }

        protected override bool IsHappend() {
            int turn = _gameplayContext.turnCounter.Count;
            if (turn - lastStrikeTurn < duration || moneyResourse.Inflow >= 0) {
                return false;
            }
            if (!RandomGenerator.IsHappened(0.5)) {
                return false;
            }
            return true;
        }
    }
}
