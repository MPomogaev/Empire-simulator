
namespace EmpireSimulator.Models.GameEvents {
    public abstract class AbstractEvent {
        public abstract void Happen();
        protected abstract void SetEventListener();
        public virtual string? Name { get => null; }
        public virtual string? Description { get => null; }

        public virtual int Id { get; set; }
        public virtual EventType Type { get => _type; }
        protected EventType _type = EventType.Neutral;
        protected GameplayContext _gameplayContext;

        public void SetContext(GameplayContext gameplayContext) {
            _gameplayContext = gameplayContext;
        }

        public void SetEvent(GameplayContext gameplayContext) {
            SetContext(gameplayContext);
            SetEventListener();
        }

        protected virtual void AddToEventListAction(object obj, EventArgs args) {
            if (IsHappened()) {
                _gameplayContext.eventContext.AddEvent(this);
            }
        }

        protected virtual bool IsHappened() => true;
    }
}
