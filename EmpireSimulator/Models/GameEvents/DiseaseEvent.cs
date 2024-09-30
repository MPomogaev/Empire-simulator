using EmpireSimulator.Models.GameEffects;

namespace EmpireSimulator.Models.GameEvents {
    public class DiseaseEvent: EachTurnChanceEvent {
        public DiseaseEvent() {
            Chance = 0.02;
            _name = "Болезнь!";
            _description = "новая болезнь заражает и убивает людей инвестируйте в науку, чтобы избавиться от неё";
        }

        public override EventType Type => EventType.Negative;

        public override void Happen() {
            var effect = new DiseaseEffect(_gameplayContext);
            effect.Start();
            _gameplayContext.eventContext.RemoveEvent(Id);
        }

    }
}
