using EmpireSimulator.Data;

namespace EmpireSimulator.Models.GameEvents {
    public class DiseaseDisableEvent: DisablePopulationEvent {

        public DiseaseDisableEvent(int count, int duration) {
            _unavaileCount = count; 
            _duration = duration;
            _name = "Болезнь";
            _description = count + " ед. населения заболело";
        }

        protected override void SetEventListener() {
            _gameplayContext.turnCounter.NextTurnEvent += AddToEventListAction;
        }

        protected override bool IsHappened() {
            return RandomGenerator.IsHappened(0.05);
        }
    }
}
