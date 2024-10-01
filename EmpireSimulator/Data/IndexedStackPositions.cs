namespace EmpireSimulator.Data {
    public class IndexedStackPositions: StackPositionsDictionary {
        public Stack<int> unusedIndex = new Stack<int>();
        private int maxIndex = 0;

        public int Add(int stackPosition) {
            int index = unusedIndex.Count == 0 ? maxIndex++ : unusedIndex.Pop();
            dict[index] = stackPosition;
            return index;
        }

        public override int Remove(int index) {
            unusedIndex.Push(index);
            return base.Remove(index);
        }

        public override int this[int index] {
            set {
                if (!dict.ContainsKey(index)){
                    throw new ArgumentOutOfRangeException("IndexedStackPositions has no key " + index);
                }
                dict[index] = value;
            }
        }
    }
}
