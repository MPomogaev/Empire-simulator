
using EmpireSimulator.Models.GameEffects;

namespace EmpireSimulator.Models.GameEvents {
    public abstract class DisablePopulationEvent: AbstractEvent {
        public int _unavaileCount;
        public int _duration;

        public override void Happen() {
            var effect = new DisabledPopulationEffect(_gameplayContext, _unavaileCount, _duration);
            effect.Start();
            _gameplayContext.eventContext.RemoveEvent(Id);
        }

        protected string? _name;
        public override string? Name => _name;

        protected string? _description;
        public override string? Description => _description;

        public override EventType Type => EventType.Negative;
    }
}
