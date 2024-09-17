using EmpireSimulator.Models;

namespace EmpireSimulator.Data {
    internal static class Constants {
        public static readonly List<ResourseType> ResourseTypes = new(){
            ResourseType.Food,
            ResourseType.Production,
            ResourseType.Money,
            ResourseType.Science
        };
    }
}
