
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

    }
}
