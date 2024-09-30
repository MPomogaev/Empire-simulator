
namespace EmpireSimulator.Models.GameEvents {
    public class DiseaseDethEvent: PopulationDeathEvent {

        public DiseaseDethEvent(int _deathCount) {
            deathCount = _deathCount;
            _name = "Болезнь";
            _description = deathCount + " ед. населения умерла от болезни(";
        }

        protected override void SetEventListener() {
            _gameplayContext.turnCounter.NextTurnEvent += AddToEventListAction;
        }

    }
}
