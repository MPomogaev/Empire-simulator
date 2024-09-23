using EmpireSimulator.Models.Workers;

namespace EmpireSimulator.Models.Resourses
{
    public class ScienceResourse: AbstractResourse {
        private static readonly int BaseWorkerOutput = 1;

        protected override int CalculateBaseInflow(WorkerContext workerContext) {
            return BaseWorkerOutput * workerContext[ResourseType.Science].Count;
        }

        public override void NextTurnUpdate(WorkerContext workerContext) {
            _Inflow = CalculateInflow(workerContext);
        }

        public override int? StorageCapacity => null;

        public override int? MaxStorageCapacity => null;
    }
}
