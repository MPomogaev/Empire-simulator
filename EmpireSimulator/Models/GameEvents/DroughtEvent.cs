using EmpireSimulator.Data;
using EmpireSimulator.Models.GameEffects;
using EmpireSimulator.Models.Resourses;

namespace EmpireSimulator.Models.GameEvents {
    public class DroughtEvent: EachTurnChanceEvent {
        private const int duration = 5;
        private int summond;

        public DroughtEvent() {
            Chance = 0.04;
            _name = "Засуха";
            _type = EventType.Negative;
        }

        public override void Happen() {
            summond = -CalculateSummond();
            var effect = new AddSummondEffect(_gameplayContext, duration, ResourseType.Food, summond);
            effect.SetName(Name);
            effect.SetEffectType(EffectType.Negative);
            effect.Start();
            _gameplayContext.eventContext.RemoveEvent(Id);
        }

        public override string? Description => "теряете " + summond 
            + " еды на " + duration + " ходов";

        private int CalculateSummond() {
            int workerCount = _gameplayContext.curentWorkerContext.AllWorkersCount;
            int workerOutput = FoodResourse.BaseWorkerOutput;
            double percent = RandomGenerator.RandomPercent(0.1, 0.3);
            return (int)Math.Round(workerOutput * workerCount * percent);
        }
    }
}
