using EmpireSimulator.Data;
using EmpireSimulator.Models.Resourses;

namespace EmpireSimulator.Models.Workers
{
    public class WorkerContext
    {
        Dictionary<ResourseType, AbstractWorkers> Workers = new() {
            { ResourseType.Food, new FoodWorkers() },
            { ResourseType.Production, new ProductionWorkers() },
            { ResourseType.Science, new ScienceWorkers() },
            { ResourseType.Money, new MoneyWorkers() },
        };

        public void Copy(WorkerContext other)
        {   
            Workers = new();
            foreach(var resourse in Constants.ResourseTypes) {
                Workers[resourse] = other[resourse].Clone();
            }
            FreeWorkersCount = other.FreeWorkersCount;
            AllWorkersCount = other.AllWorkersCount;
        }

        public bool RemovePopulation() {
            if (FreeWorkersCount > 0) {
                FreeWorkersCount--;
                AllWorkersCount--;
                return true;
            }
            var workedResourses = Workers
                .Where(wrk => wrk.Value.Count > 0)
                .Select(wrk => wrk.Key).ToList();
            if (workedResourses.Count > 0) {
                var resourse = RandomResourse.Next(workedResourses);
                Workers[resourse].Count--;
                AllWorkersCount--;
                return true;
            }
            return false;
        }

        public int FreeWorkersCount { get; set; } = 10;

        public int AllWorkersCount { get; set; } = 10;

        public AbstractWorkers this[ResourseType resourse] => Workers[resourse];

    }
}
