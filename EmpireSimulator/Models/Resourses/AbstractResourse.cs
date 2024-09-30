using EmpireSimulator.Data;
using EmpireSimulator.Models.Workers;

namespace EmpireSimulator.Models.Resourses
{
    public abstract class AbstractResourse {
        public abstract void NextTurnUpdate(WorkerContext workerContext);
        public abstract int CalculateBaseInflow(WorkerContext workerContext);
        protected int _Inflow = 0;
        public virtual int Inflow { get => _Inflow; }
        public IndexedDictionary<InflowSummand> Summands { get; } = new();
        public IndexedDictionary<InflowMultiplier> Multipliers { get; } = new();
        public virtual int? StorageCapacity => null;
        public virtual int? MaxStorageCapacity => null;

        public  virtual int GetConsumption(WorkerContext workerContext) {  return 0; }

        protected virtual int ApplyInflowEffects(int inflow) {
            foreach (var summand in Summands.Values) {
                inflow = summand.Sum(inflow);
            }
            double _inflow = inflow;
            foreach (var multiplier in Multipliers.Values) {
                _inflow = multiplier.Multipy(inflow);
            }
            return (int)Math.Round(_inflow);
        }

        protected virtual int CalculateInflow(WorkerContext workerContext) {
            return ApplyInflowEffects(CalculateBaseInflow(workerContext)) 
                - GetConsumption(workerContext);
        }

    }
}