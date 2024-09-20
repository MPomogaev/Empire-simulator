
namespace EmpireSimulator.Models.GameEvents {
    public class EventContext {
        private List<AbstractEvent> possibleEvents = new() {
            new StarvationDeathEvent(),
        };
        private Dictionary<int, AbstractEvent> events = new();
        private List<int> unusedIds = new List<int>();
        private int maxId = 0;

        public int AddEvent(AbstractEvent newEvent) {
            int id = ChooseId();
            events[id] = newEvent;
            return id;
        }

        public void RemoveEvent(int id) {
            events.Remove(id);
        }

        public void Happen() {
            foreach(var _event in events.ToList()) {
                _event.Value.Happen();
            }
        }

        public void SetPossibleEvents(GameplayContext gameplayContext) {
            foreach (var _event in possibleEvents) {
                _event.SetEventListener(gameplayContext);
            }
        }

        private int ChooseId() {
            int id;
            if (unusedIds.Count > 0) {
                 id = unusedIds.First();
                unusedIds.RemoveAt(0);
            } else {
                id = maxId++;
            }
            return id;
        }
    }
}
