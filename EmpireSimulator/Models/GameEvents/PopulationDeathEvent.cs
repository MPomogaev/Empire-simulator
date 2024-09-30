
namespace EmpireSimulator.Models.GameEvents {
    public abstract class PopulationDeathEvent: AbstractEvent {
        public int deathCount;

        public override void Happen() {
            lock (_gameplayContext.newWorkerContext) {
                _gameplayContext.newWorkerContext.RemovePopulation(deathCount);
            }
            _gameplayContext.eventContext.RemoveEvent(Id);
        }

        protected string? _name;
        public override string? Name => _name;

        protected string? _description;
        public override string? Description => _description;

        public override EventType Type => EventType.Negative;
    }
}
