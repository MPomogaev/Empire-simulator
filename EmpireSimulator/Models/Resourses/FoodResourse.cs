using EmpireSimulator.Models.Workers;

namespace EmpireSimulator.Models.Resourses
{
    public class FoodResourse: AbstractResourse {
        private static readonly int BaseWorkerOutput = 2;
        private static readonly int BaseWorkerConsuption = 1;

        public event EventHandler Starvation;
        protected virtual void OnStarvation() {
            Starvation?.Invoke(this, EventArgs.Empty);
        }

        public override int CalculateInflow(WorkerContext workerContext) {
            return BaseWorkerOutput * workerContext[ResourseType.Food].Count
                - GetConsuption(workerContext);
        }

        public override void NextTurnUpdate(WorkerContext workerContext) {
            StorageUpdate(workerContext);
            _Inflow = CalculateInflow(workerContext);
        }

        private void StorageUpdate(WorkerContext workerContext) {
            _StorageCapacity += _Inflow;
            if (_StorageCapacity > MaxStorageCapacity) {
                _StorageCapacity = MaxStorageCapacity.Value;
            }
            if (_StorageCapacity < 0) {
                OnStarvation();
            }
        }

        private int GetConsuption(WorkerContext workerContext) {
            return BaseWorkerConsuption * workerContext.AllWorkersCount;
        }
    }
}
