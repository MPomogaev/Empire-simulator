﻿using EmpireSimulator.Models.Workers;

namespace EmpireSimulator.Models.Resourses
{
    public class MoneyResourse: AbstractResourse {
        private static readonly int BaseWorkerOutput = 5;
        private static readonly int BaseWorkerConsuption = 1;

        public MoneyResourse() {
            _MaxStorageCapacity = 1000;
            _StorageCapacity = 100;
        }

        public override int CalculateInflow(WorkerContext workerContext) {
            return BaseWorkerOutput * workerContext[ResourseType.Money].Count
                - GetConsuption(workerContext);
        }

        public override void NextTurnUpdate(WorkerContext workerContext) {
            _StorageCapacity += _Inflow;
            if (_StorageCapacity > MaxStorageCapacity) {
                _StorageCapacity = MaxStorageCapacity.Value;
            }
            _Inflow = CalculateInflow(workerContext);
        }

        private int GetConsuption(WorkerContext workerContext) {
            return BaseWorkerConsuption * workerContext.AllWorkersCount;
        }
    }
}
