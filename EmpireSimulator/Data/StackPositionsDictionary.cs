namespace EmpireSimulator.Data {
    public class StackPositionsDictionary {
        protected Dictionary<int, int> dict = new Dictionary<int, int>();

        public virtual int Remove(int index) {
            int value = dict[index];
            dict.Remove(index);
            foreach (var key in dict.Keys) {
                if (dict[key] > value)
                    dict[key]--;
            }
            return value;
        }

        public virtual int this[int index] {
            get => dict[index];
            set => dict[index] = value;
        }
    }
}
