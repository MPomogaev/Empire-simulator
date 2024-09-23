using EmpireSimulator.Models.GameEffects;
using EmpireSimulator.Models.GameEvents;
using EmpireSimulator.Models.Resourses;
using EmpireSimulator.Models.Workers;

namespace EmpireSimulator.Models {
    public class GameplayContext {
        public WorkerContext newWorkerContext = new();
        public WorkerContext curentWorkerContext = new();
        public ResoursesContext resoursesContext = new();
        public EventContext eventContext = new();
        public EffectContext effectContext = new();
        public TurnCounter turnCounter = new();
        public bool continuePlaying = true;
        private GameplayManager _manager;
        public GameplayManager Manager { get { return _manager; } }

        public GameplayContext(GameplayManager manager) {
            _manager = manager;
        }
    }
}
