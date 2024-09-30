
using EmpireSimulator.Models.Resourses;

namespace EmpireSimulator.Data {
    public static class RandomGenerator {
        static Random random = new Random((int)DateTime.Now.Ticks);


        public static bool IsHappened(double chance) {
            if (random.NextDouble() < chance) {
                return true;
            }
            return false;
        }

        public static int RandomInt(int maxInt) {
            return RandomInt(0, maxInt);
        }

        public static int RandomInt(int minInt, int maxInt) {
            return random.Next(minInt, maxInt);
        }

        public static double RandomDouble(double maxDouble) {
            return RandomDouble(0, maxDouble);
        }

        public static double RandomDouble(double minDouble, double maxDouble) {
            return minDouble + random.NextDouble() * (maxDouble - minDouble);
        }

        public static double RandomPercent(double max) {
            return RandomPercent(0, max);
        }

        public static double RandomPercent(double min, double max) {
            if (min < 0 || max > 1) {
                throw new ArgumentException("chance must be beatwen  0 and 1");
            }
            return RandomDouble(min, max);
        }

        public static ResourseType RandomResourse() {
            int resoursesCount = Constants.ResourseTypes.Count;
            return Constants.ResourseTypes[RandomInt(0, resoursesCount)];
        }
    }
}
