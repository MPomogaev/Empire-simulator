using EmpireSimulator.Models.Workers;

namespace EmpireSimulator.Models.Resourses
{
    public class FoodResourse: HasStorageResourse {
        public static readonly int BaseWorkerOutput = 2;
        public static readonly int BaseWorkerConsuption = 1;

        public FoodResourse() {
            SetStorageCapacity(30);
        }

        public event EventHandler Starvation;
        protected virtual void OnStarvation() {
            Starvation?.Invoke(this, EventArgs.Empty);
        }

        public override int CalculateBaseInflow(WorkerContext workerContext) {
            return BaseWorkerOutput * workerContext[ResourseType.Food].Count;
        }

        public override void NextTurnUpdate(WorkerContext workerContext) {
            StorageUpdate(workerContext);
            _Inflow = CalculateInflow(workerContext);
        }

        public override int GetConsumption(WorkerContext workerContext) {
            return BaseWorkerConsuption * workerContext.AllWorkersCount;
        }

        private void StorageUpdate(WorkerContext workerContext) {
            AddToStorage(Inflow);
            if (StorageCapacity < 0) {
                SetStorageCapacity(0);
                OnStarvation();
            }
        }
    }
}
