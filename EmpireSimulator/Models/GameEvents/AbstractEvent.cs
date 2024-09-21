
namespace EmpireSimulator.Models.GameEvents {
    public abstract class AbstractEvent {
        public abstract void Happen();
        public abstract void SetEventListener(GameplayContext gameplayContext);
        public virtual string? Name { get => null; }
        public virtual string? Description { get => null; }

        public virtual int Id { get => _id; }
        protected int _id;
        public virtual EventType Type { get => _type; }
        protected EventType _type = EventType.Neutral;
        protected GameplayContext _gameplayContext;

        protected virtual void AddToEventListAction(object obj, EventArgs args) {
            if (IsHappend()) {
                _id = _gameplayContext.eventContext.AddEvent(this);
            }
        }
        protected virtual void RemoveFromEventList() {
            _gameplayContext.eventContext.RemoveEvent(_id);
        }
        protected virtual bool IsHappend() => true;
    }
}
