namespace EmpireSimulator.Models {
    public class WorkerContext {
        Dictionary<ResourseType, int> MaxWorkers = new() {
            { ResourseType.Food, 10 },
            { ResourseType.Production, 10 },
            { ResourseType.Science, 10 },
            { ResourseType.Money, 10 },
        };

        Dictionary<ResourseType, int> Workers = new() {
            { ResourseType.Food, 0 },
            { ResourseType.Production, 0 },
            { ResourseType.Science, 0 },
            { ResourseType.Money, 0 },
        };

        public int FreeWorkersCount { get; set; } = 10;

        public int AllWorkersCount { get; set; } = 10;

        public void SetMaxWorkers(ResourseType resourse, int value) 
            => MaxWorkers[resourse] = value;

        public int GetMaxWorkers(ResourseType resourse)
            => MaxWorkers[resourse];

        public void SetWorkers(ResourseType resourse, int value)
            => Workers[resourse] = value;

        public int GetWorkers(ResourseType resourse)
            => Workers[resourse];
    }
}
