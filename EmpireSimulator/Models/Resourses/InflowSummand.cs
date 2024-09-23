
namespace EmpireSimulator.Models.Resourses {
    public class InflowSummand {
        Func<int> _summand;
        public InflowSummand(Func<int> summand) {
            _summand = summand;
        }

        public int Sum(int inflow) {
            return inflow + _summand();
        }
    }
}
