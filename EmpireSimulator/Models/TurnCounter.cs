
namespace EmpireSimulator.Models {
    public class TurnCounter {
        private int _count = 0;
        public int Count{ get => _count;}

        public void NextTurn() {
            _count++;
        }
    }
}
