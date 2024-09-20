using EmpireSimulator.Models.GameEvents;
using EmpireSimulator.Models.Resourses;
using EmpireSimulator.Models.Workers;

namespace EmpireSimulator.Models {
    public class GameplayContext {
        public WorkerContext newWorkerContext = new();
        public WorkerContext curentWorkerContext = new();
        public ResoursesContext resoursesContext = new();
        public EventContext eventContext = new();
        public TurnCounter turnCounter = new();
    }
}
