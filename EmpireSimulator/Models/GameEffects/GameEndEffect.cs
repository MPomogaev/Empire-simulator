
namespace EmpireSimulator.Models.GameEffects {
    public class GameEndEffect: AbstractEffect {

        public GameEndEffect(GameplayContext gameplayContext) {
            _gameplayContext = gameplayContext;
        }

        public override void Start() {
            _gameplayContext.Manager.StopGame();
        }

        public override void End() {
        }
    }
}
