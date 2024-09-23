using EmpireSimulator.Models.Workers;

namespace EmpireSimulator.Models.Resourses
{
    public class FoodResourse: AbstractResourse {
        private static readonly int BaseWorkerOutput = 2;
        private static readonly int BaseWorkerConsuption = 1;

        public FoodResourse() {
            _StorageCapacity = 30;
        }

        public event EventHandler Starvation;
        protected virtual void OnStarvation() {
            Starvation?.Invoke(this, EventArgs.Empty);
        }

        protected override int CalculateBaseInflow(WorkerContext workerContext) {
            return GetProduction(workerContext) - GetConsuption(workerContext);
        }

        public override void NextTurnUpdate(WorkerContext workerContext) {
            StorageUpdate(workerContext);
            _Inflow = CalculateInflow(workerContext);
        }

        public int GetConsuption(WorkerContext workerContext) {
            return BaseWorkerConsuption * workerContext.AllWorkersCount;
        }

        public int GetProduction(WorkerContext workerContext) {
            return BaseWorkerOutput * workerContext[ResourseType.Food].Count;
        }

        private void StorageUpdate(WorkerContext workerContext) {
            _StorageCapacity += _Inflow;
            if (_StorageCapacity > MaxStorageCapacity) {
                _StorageCapacity = MaxStorageCapacity.Value;
            }
            if (_StorageCapacity < 0) {
                _StorageCapacity = 0;
                OnStarvation();
            }
        }
    }
}
