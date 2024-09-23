
namespace EmpireSimulator.Models.GameEffects {
    public abstract class AbstractEffect {
        protected int? _duration;
        public virtual int? Duration { get => _duration; }
        protected int _id;
        public virtual int Id { get => _id; }
        public virtual string Name { get; }
        public virtual EffectType Type { get => EffectType.Neutral; }
        protected GameplayContext _gameplayContext;

        public abstract void Start();

        public abstract void End();

        public virtual void NextTurn() {
            _duration--;
        }
    }
}
