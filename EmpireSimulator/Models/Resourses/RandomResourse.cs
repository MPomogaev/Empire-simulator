using EmpireSimulator.Data;

namespace EmpireSimulator.Models.Resourses {
    public static class RandomResourse {
        private static Random ResourseChoser = new Random((int)DateTime.Now.Ticks);

        public static ResourseType Next() {
            int resourseInt = ResourseChoser.Next(0, Constants.ResourseTypes.Count());
            return Constants.ResourseTypes[resourseInt];
        }

        public static ResourseType Next(List<ResourseType> from) {
            int resourseInt = ResourseChoser.Next(0, from.Count());
            return from[resourseInt];
        }

        public static ResourseType NextExcept(List<ResourseType> except) {
            var resoursesList = Constants.ResourseTypes.Except(except).ToList();
            return Next(resoursesList);
        }
    }
}
