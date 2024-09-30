using EmpireSimulator.Data;

namespace EmpireSimulator.Models.GameEffects {
    public class EffectContext {
        public IndexedDictionary<AbstractEffect> seenEffects = new();
        public IndexedDictionary<AbstractEffect> unseenEffects = new();
        public Stack<AbstractEffect> expieredEffects = new();
        private int maxId = 0;

        public void Apply() {
            foreach (var effect in seenEffects.Values) {
                effect.NextTurn();
            }
            foreach (var effect in unseenEffects.Values) {
                effect.NextTurn();
            }
        }

        public int AddToEffects(AbstractEffect effect) {
            if (effect.IsShowed) {
                return seenEffects.Add(effect);
            }
            return unseenEffects.Add(effect);
            
        }

        public void RemoveFromEffects(AbstractEffect effect) {
            if (effect.IsShowed) {
                seenEffects.Remove(effect.Id);
                expieredEffects.Push(effect);
            } else {
                unseenEffects.Remove(effect.Id);
            }
        }
    }
}
