using EmpireSimulator.Models.Workers;

namespace EmpireSimulator.Models.Resourses
{
    public class ProductionResourse: AbstractResourse {
        private static readonly int BaseWorkerOutput = 1;

        protected override int CalculateBaseInflow(WorkerContext workerContext) {
            return BaseWorkerOutput * workerContext[ResourseType.Production].Count;
        }

        public override void NextTurnUpdate(WorkerContext workerContext) {
            _StorageCapacity += _Inflow;
            if (_StorageCapacity > MaxStorageCapacity) {
                _StorageCapacity = MaxStorageCapacity.Value;
            }
            _Inflow = CalculateInflow(workerContext);
        }

    }
}
