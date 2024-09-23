using EmpireSimulator.Data;
using EmpireSimulator.Models.GameEvents;
using EmpireSimulator.Models.Resourses;

namespace EmpireSimulator.Models.Workers
{
    public class WorkerContext
    {
        private Dictionary<ResourseType, AbstractWorkers> Workers = new() {
            { ResourseType.Food, new FoodWorkers() },
            { ResourseType.Production, new ProductionWorkers() },
            { ResourseType.Science, new ScienceWorkers() },
            { ResourseType.Money, new MoneyWorkers() },
        };

        private readonly double unavailabelChosenChance = 1.0/6;

        public int UnavailableWorkersCount { get; set; } = 0;

        public int AvailableWorkersCount { get; set; } = 10;

        public int AllWorkersCount {
            get {
                int sum = AvailableWorkersCount + UnavailableWorkersCount;
                foreach (var worker in Workers) {
                    sum += worker.Value.Count;
                }
                return sum;
            }
        }

        public void Copy(WorkerContext other)
        {   
            Workers = new();
            foreach(var resourse in Constants.ResourseTypes) {
                Workers[resourse] = other[resourse].Clone();
            }
            AvailableWorkersCount = other.AvailableWorkersCount;
            UnavailableWorkersCount = other.UnavailableWorkersCount;
        }

        public int RemovePopulation(int count) {
            int removed = 0;
            while (count > removed) {
                if (RemovePopulation()) {
                    ++removed;
                } else {
                    break;
                }
            }
            return removed;
        }

        public bool RemovePopulation() {
            if (UnavailableWorkersCount > 0 && 
                Data.RandomGenerator.IsHappened(unavailabelChosenChance)) {
                UnavailableWorkersCount--;
                return true;
            }
            if (AvailableWorkersCount > 0) {
                AvailableWorkersCount--;
                return true;
            }
            var workedResourses = Workers
                .Where(wrk => wrk.Value.Count > 0)
                .Select(wrk => wrk.Key).ToList();
            if (workedResourses.Count > 0) {
                var resourse = RandomResourse.Next(workedResourses);
                Workers[resourse].Count--;
                return true;
            }
            return false;
        }

        public void MakeAvailable(int count) {
            if (UnavailableWorkersCount - count < 0) {
                count = UnavailableWorkersCount;
            }
            UnavailableWorkersCount -= count;
            AvailableWorkersCount += count;
        }

        public void MakeUnavailable(int count) {
            int removed = RemovePopulation(count);
            UnavailableWorkersCount += removed;
        }

        public void NewPopulation(int count) {
            AvailableWorkersCount += count;
        }

        public AbstractWorkers this[ResourseType resourse] => Workers[resourse];

    }
}
