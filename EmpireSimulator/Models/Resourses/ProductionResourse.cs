using EmpireSimulator.Models.Workers;

namespace EmpireSimulator.Models.Resourses
{
    public class ProductionResourse: HasStorageResourse {
        private static readonly int BaseWorkerOutput = 1;

        public override int CalculateBaseInflow(WorkerContext workerContext) {
            return BaseWorkerOutput * workerContext[ResourseType.Production].Count;
        }

        public override void NextTurnUpdate(WorkerContext workerContext) {
            AddToStorage(Inflow);
            _Inflow = CalculateInflow(workerContext);
        }

        public override void RemoveFromStorage(int value) {
            if (value > StorageCapacity) {
                throw new ArgumentException("tried to remove from storage more production than it has");
            }
            base.RemoveFromStorage(value);
        }

    }
}
