using EmpireSimulator.Models.Workers;

namespace EmpireSimulator.Models.Resourses
{
    public class MoneyResourse: HasStorageResourse {
        private static readonly int BaseWorkerOutput = 5;
        private static readonly int BaseWorkerConsuption = 1;

        public MoneyResourse() {
            SetMaxStorageCapacity(1000);
            SetStorageCapacity(100);
        }

        public override int CalculateBaseInflow(WorkerContext workerContext) {
            return BaseWorkerOutput * workerContext[ResourseType.Money].Count;
        }

        public override void NextTurnUpdate(WorkerContext workerContext) {
            AddToStorage(_Inflow);
            _Inflow = CalculateInflow(workerContext);
            if(StorageCapacity < 0) {
                OnNoMoneyLeft();
            }
        }

        public event EventHandler NoMoneyLeft;
        protected void OnNoMoneyLeft() {
            NoMoneyLeft?.Invoke(this, EventArgs.Empty);
        }

        public override int GetConsumption(WorkerContext workerContext) {
            return BaseWorkerConsuption * workerContext.AllWorkersCount - workerContext.UnavailableWorkersCount;
        }
    }
}
