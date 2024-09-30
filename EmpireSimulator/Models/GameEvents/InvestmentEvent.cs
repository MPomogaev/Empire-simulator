using EmpireSimulator.Models.Resourses;
using EmpireSimulator.Data;

namespace EmpireSimulator.Models.GameEvents {
    public class InvestmentEvent: EachTurnChanceEvent {
        private int investments;

        public InvestmentEvent() {
            Chance = 0.02;
            _name = "Инвестиции";
            _type = EventType.Positive;
        }

        public override void Happen() {
            int maxStorage = _gameplayContext.resoursesContext[ResourseType.Money].MaxStorageCapacity.Value;
            double percent = RandomGenerator.RandomPercent(0.05, 0.15);
            investments = (int)Math.Round(maxStorage * percent);
            var money = (MoneyResourse)_gameplayContext.resoursesContext[ResourseType.Money];
            money.AddToStorage(investments);
            _gameplayContext.eventContext.RemoveEvent(Id);
        }

        public override string? Description => "вы получили " + investments + " денег";

    }
}
