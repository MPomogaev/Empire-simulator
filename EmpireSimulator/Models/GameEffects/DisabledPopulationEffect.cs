using EmpireSimulator.Data;

namespace EmpireSimulator.Models.GameEffects {
    public class DisabledPopulationEffect: AbstractEffect {
        protected int _populationCount;
        public DisabledPopulationEffect(GameplayContext gameplayContext, int populationCount, int duration) {
            _duration = duration;
            _populationCount = populationCount;
            _gameplayContext = gameplayContext;
            _isShowed = false;
            logger = LogManager.GetLogger<DisabledPopulationEffect>();
        }

        public override void Start() {
            var workers = _gameplayContext.newWorkerContext;
            lock (workers) {
                workers.MakeUnavailable(_populationCount);
            }
            AddToEffects();
        }

        public override void End() {
            var workers = _gameplayContext.newWorkerContext;
            lock (workers) {
                workers.MakeAvailable(_populationCount);
            }
        }

        public override EffectType Type => EffectType.Negative;
    }
}
