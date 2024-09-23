using EmpireSimulator.Models.Workers;

namespace EmpireSimulator.Models.Resourses
{
    public abstract class AbstractResourse {
        public abstract void NextTurnUpdate(WorkerContext workerContext);
        protected abstract int CalculateBaseInflow(WorkerContext workerContext);
        protected int _Inflow = 0;
        public virtual int? Inflow { get => _Inflow; }
        protected int _StorageCapacity = 0;
        public virtual int? StorageCapacity { get => _StorageCapacity; }
        protected int _MaxStorageCapacity = 100;
        public virtual int? MaxStorageCapacity { get => _MaxStorageCapacity; }
        protected Dictionary<int, InflowSummand> summands = new();
        protected Dictionary<int, InflowMultiplier> multipliers = new();
        protected virtual int ApplyInflowEffects(int inflow) {
            foreach (var summand in summands.Values) {
                inflow = summand.Sum(inflow);
            }
            foreach (var multiplier in multipliers.Values) {
                inflow = multiplier.Multipy(inflow);
            }
            return inflow;
        }
        protected virtual int CalculateInflow(WorkerContext workerContext) {
            return ApplyInflowEffects(CalculateBaseInflow(workerContext));
        }
    }
}