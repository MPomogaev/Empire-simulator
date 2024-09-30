
namespace EmpireSimulator.Models.GameEffects {
    public class StrikeEffect: DisabledPopulationEffect {
        private int _populationCount;
        public StrikeEffect(GameplayContext gameplayContext, int populationCount, int duration)
            : base(gameplayContext, populationCount, duration) {
            _name = "Забастовка";
            _isShowed = true;
        }
    }
}
