
using EmpireSimulator.Data;
using EmpireSimulator.Models.Resourses;

namespace EmpireSimulator.Models.GameEvents {
    public class WorkerStrinkeEvent: AbstractEvent {
        private MoneyResourse moneyResourse;
        private bool isHappening = false;
        private int duration = 3;
        private int unavailableCount = 0;

        public override void Happen() {
            var workers = _gameplayContext.newWorkerContext;
            if (isHappening) {
                duration--;
                if (duration <= 0) {
                    RemoveFromEventList();
                    isHappening = false;
                    lock (workers) {
                        workers.AvailableWorkersCount += unavailableCount;
                        workers.UnavailableWorkersCount -= unavailableCount;
                    }
                }
                return;
            }
            double consumption = moneyResourse.GetConsuption(_gameplayContext.curentWorkerContext);
            double outflow = -moneyResourse.Inflow.Value;
            int allPopulation = _gameplayContext.curentWorkerContext.AllWorkersCount;
            int maxUnavailable = (int)Math.Round((outflow / consumption) * allPopulation);
            unavailableCount = RandomGenerator.RandomInt(1, maxUnavailable + 1);
            lock (workers) {
                workers.RemovePopulation(unavailableCount);
                workers.UnavailableWorkersCount += unavailableCount;
            }
            isHappening = true;
            duration = 3;
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
            if (moneyResourse.Inflow >= 0 || isHappening) {
                return false;
            }
            if (!RandomGenerator.IsHappened(0.5)) {
                return false;
            }
            return true;
        }
    }
}
