using EmpireSimulator.Data;

namespace EmpireSimulator.Models.GameEvents {
    public abstract class EachTurnChanceEvent: AbstractEvent {
        private double _chance;
        public virtual double Chance { get => _chance; set { 
            if (value < 0 || value > 1) 
                throw new ArgumentOutOfRangeException("Chance must be between 0 and 1");
            _chance = value;
            }
        }

        protected string _name;
        public override string Name => _name;

        protected string _description;
        public override string Description => _description;

        protected override void SetEventListener() {
            _gameplayContext.turnCounter.NextTurnEvent += AddToEventListAction;
        }

        protected override bool IsHappened() => RandomGenerator.IsHappened(Chance); 

    }
}
