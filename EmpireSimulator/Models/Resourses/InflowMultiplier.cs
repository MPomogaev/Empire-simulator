
namespace EmpireSimulator.Models.Resourses {
    public class InflowMultiplier {
        Func<int> _multiplier;
        public InflowMultiplier(Func<int> multiplier) {
            _multiplier = multiplier;
        }

        public int Multipy(int inflow) {
            return inflow * _multiplier();
        }
    }
}
