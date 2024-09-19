using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmpireSimulator.Models.Workers;

namespace EmpireSimulator.Models.Resourses
{
    public class ScienceResourse: AbstractResourse {
        private static readonly int BaseWorkerOutput = 1;

        public override int CalculateInflow(WorkerContext workerContext) {
            return BaseWorkerOutput * workerContext[ResourseType.Science].Count;
        }

        public override void NextTurnUpdate(WorkerContext workerContext) {
            _Inflow = CalculateInflow(workerContext);
        }

        public override int? StorageCapacity => null;

        public override int? MaxStorageCapacity => null;
    }
}
