using EmpireSimulator.Data;
using EmpireSimulator.Models.Resourses;
using System.Reflection.Metadata;

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

        public int FreeWorkersCount { get; set; } = 10;

        public int AllWorkersCount { get; set; } = 10;

        public AbstractWorkers this[ResourseType resourse] => Workers[resourse];

    }
}
