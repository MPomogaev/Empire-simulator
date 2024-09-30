using EmpireSimulator.Models.Workers;

namespace EmpireSimulator.Models.Resourses
{
    public class ScienceResourse: AbstractResourse {
        private static readonly int BaseWorkerOutput = 1;

        public override int CalculateBaseInflow(WorkerContext workerContext) {
            return BaseWorkerOutput * workerContext[ResourseType.Science].Count;
        }

        public override void NextTurnUpdate(WorkerContext workerContext) {
            _Inflow = CalculateInflow(workerContext);
        }

    }
}
