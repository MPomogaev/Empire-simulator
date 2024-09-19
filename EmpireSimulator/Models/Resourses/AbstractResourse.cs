using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmpireSimulator.Models.Workers;

namespace EmpireSimulator.Models.Resourses
{
    public abstract class AbstractResourse {
        public abstract int CalculateInflow(WorkerContext workerContext);
        public abstract void NextTurnUpdate(WorkerContext workerContext);
        protected int _Inflow = 0;
        public virtual int? Inflow { get => _Inflow; }
        protected int _StorageCapacity = 0;
        public virtual int? StorageCapacity { get => _StorageCapacity; }
        protected int _MaxStorageCapacity = 100;
        public virtual int? MaxStorageCapacity { get => _MaxStorageCapacity; }
    }
}
