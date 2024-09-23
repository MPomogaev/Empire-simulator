
namespace EmpireSimulator.Models.GameEffects {
    public class EffectContext {
        public Dictionary<int, AbstractEffect> effects = new();
        public List<AbstractEffect> expieredEffects = new();
        private List<int> unusedIds = new List<int>();
        private int maxId = 0;

        public void Apply() {
            expieredEffects.Clear();
            foreach (var effect in effects.Values) {
                effect.NextTurn();
                if (effect.Duration <= 0) {
                    effect.End();
                    RemoveFromEffects(effect);
                }
            }
        }

        public int AddToEffects(AbstractEffect effect) {
            int id = ChooseId();
            effects[id] = effect;
            return id;
        }

        public void RemoveFromEffects(AbstractEffect effect) {
            effects.Remove(effect.Id);
            expieredEffects.Add(effect);
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
