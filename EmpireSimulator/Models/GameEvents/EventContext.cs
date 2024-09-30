
using EmpireSimulator.Data;
using Microsoft.Extensions.Logging;

namespace EmpireSimulator.Models.GameEvents {
    public class EventContext {
        private List<AbstractEvent> possibleEvents = new() {
            new StarvationDeathEvent(),
            new PopulationGrowthEvent(),
            new WorkerStrinkeEvent(),
            new GoodWhetherEvent(),
            new InvestmentEvent(),
            new DiseaseDisableEvent(1, 5),
            new DiseaseEvent(),
            new ScienceBreakthroughEvent(),
            new DroughtEvent(),
            new MoneyWasteEvent(),
        };
        private ILogger logger;
        private List<AbstractEvent> happendEvents = new();
        private IndexedDictionary<AbstractEvent> events = new();
        private int maxId = 0;

        public List<AbstractEvent> HappendEvents { get => happendEvents; }

        public EventContext() {
            logger = LogManager.GetLogger<EventContext>();
        }

        public void AddEvent(AbstractEvent newEvent) {
            int id = events.Add(newEvent);
            newEvent.Id = id;
            //logger.LogInformation("adding event " + id);
        }

        public void RemoveEvent(int id) {
            //logger.LogInformation("remove event " + id);
            events.Remove(id);
        }

        public void Happen() {
            happendEvents.Clear();
            foreach(var _event in events.Values) {
                _event.Happen();
                happendEvents.Add(_event);
            }
        }

        public void SetPossibleEvents(GameplayContext gameplayContext) {
            foreach (var _event in possibleEvents) {
                _event.SetEvent(gameplayContext);
            }
        }
    }
}
