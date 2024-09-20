
namespace EmpireSimulator.Models.GameEvents {
    public abstract class AbstractEvent {
        public abstract void Happen();
        public abstract void SetEventListener(GameplayContext gameplayContext);
        public virtual string? Name { get => null; }
        public virtual string? Description { get => null; }
        public virtual int Id { get => _id; }
        protected int _id;
    }
}
