
namespace EmpireSimulator.Models {
    public class TurnCounter {
        private int _count = 0;
        public int Count{ get => _count;}

        public void NextTurn() {
            _count++;
            OnNextTurn();
        }

        public event EventHandler NextTurnEvent;
        protected void OnNextTurn() {
            NextTurnEvent?.Invoke(this, EventArgs.Empty);
        }
    }
}
