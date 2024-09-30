
namespace EmpireSimulator.Models.Resourses {
    public class InflowMultiplier {
        Func<double> _multiplier;
        public InflowMultiplier(Func<double> multiplier) {
            _multiplier = multiplier;
        }

        public double Multipy(int inflow) {
            return inflow * _multiplier();
        }
    }
}
