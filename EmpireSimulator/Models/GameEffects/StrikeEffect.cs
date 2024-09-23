
namespace EmpireSimulator.Models.GameEffects {
    public class StrikeEffect: AbstractEffect {
        public override string Name => "Забастовка";
        private int _populationCount;
        public StrikeEffect(GameplayContext gameplayContext, int populationCount, int duration) {
            _duration = duration;
            _populationCount = populationCount;
            _gameplayContext = gameplayContext;
        }

        public override void Start() {
            _id = _gameplayContext.effectContext.AddToEffects(this);
            var workers = _gameplayContext.newWorkerContext;
            lock (workers) {
                workers.MakeUnavailable(_populationCount);
            }
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
