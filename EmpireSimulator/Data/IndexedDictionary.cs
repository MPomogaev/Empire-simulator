
namespace EmpireSimulator.Data {
    public class IndexedDictionary<ValueType> {
        private Dictionary<int, ValueType> values = new();
        private Stack<int> unusedKeys = new();
        private int maxIndex = 0;

        public int Add(ValueType value) {
            int index;
            if (unusedKeys.Count == 0) {
                index = maxIndex++;
            } else {
                index = unusedKeys.Pop();
            }
            values[index] = value;
            return index;
        }

        public void Remove(int index) {
            values.Remove(index);
            unusedKeys.Push(index);
        }

        public bool ContainsKey(int index) {
            return values.ContainsKey(index);
        }

        public IEnumerable<ValueType> Values { get => values.Values; }

        public ValueType this[int index] => values[index];
    }
}
