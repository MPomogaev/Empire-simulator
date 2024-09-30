
namespace EmpireSimulator.Data {
    public static class ChanceCurves {

        private static Dictionary<ChanceScale, PowerRoot> CurveScale = new() {
            { ChanceScale.Smaller, new(2, 1) },
            { ChanceScale.Small, new(5, 3) },
            { ChanceScale.Medium, new(1, 1) },
            { ChanceScale.High, new(2, 3) },
        };

        public static double CurveLinierChance(double linierChance, ChanceScale scale) {
            if (linierChance > 1) {
                linierChance = 1;
            }
            if (linierChance < 0) {
                linierChance = 0;
            }
            var powerRoot = CurveScale[scale];
            double chance = Math.Pow(linierChance, powerRoot.Power/powerRoot.Root);
            return chance;
        }

        private struct PowerRoot {
            public double Power {  get; set; }
            public double Root { get; set; }

            public PowerRoot(int power, int root) {
                Power = power;
                Root = root;
            }
        }
    }
}
