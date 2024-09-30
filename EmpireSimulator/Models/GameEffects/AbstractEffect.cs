
using Microsoft.Extensions.Logging;

namespace EmpireSimulator.Models.GameEffects {
    public abstract class AbstractEffect {
        protected int? _duration;
        public virtual int? Duration { get => _duration; }
        protected int _id;
        public virtual int Id { get => _id; }
        protected string? _name;
        public virtual string? Name { get => _name; }
        protected EffectType _type = EffectType.Neutral;
        public virtual EffectType Type { get => _type; }
        protected GameplayContext _gameplayContext;
        protected bool _isShowed = true;
        public bool IsShowed => _isShowed;
        protected ILogger logger = null;

        public abstract void Start();

        public abstract void End();

        public virtual void NextTurn() {
            if (logger != null) {
                logger.LogInformation(Name + " effect ");
            }
            _duration--;
            if (Duration <= 0) {
                End();
                _gameplayContext.effectContext.RemoveFromEffects(this);
            }
        }

        protected virtual void AddToEffects() {
            _id = _gameplayContext.effectContext.AddToEffects(this);
        }
    }
}
