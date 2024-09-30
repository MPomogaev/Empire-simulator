using EmpireSimulator.Data;
using EmpireSimulator.Models.GameEvents;
using Microsoft.Extensions.Logging;
using System.Dynamic;

namespace EmpireSimulator.Models.GameEffects {
    public class DiseaseEffect: AbstractEffect {
        public DiseaseEffect(GameplayContext gameplayContext) {
            _gameplayContext = gameplayContext;
            logger = LogManager.GetLogger<DiseaseEffect>();
        }
        public override string? Name => "Болезнь";
        public override int? Duration => null;
        public override EffectType Type => EffectType.Negative;

        public override void Start() => AddToEffects();

        public override void End() {}

        public override void NextTurn() {
            double chance = ChanceCurves.CurveLinierChance(CalculateEndChance(), ChanceScale.High);
            if (RandomGenerator.IsHappened(chance)) {
                End();
                _gameplayContext.effectContext.RemoveFromEffects(this);
                return;
            }
            int availablePopulation = _gameplayContext.curentWorkerContext.AvailableWorkersCount;
            int effectedPopulation = (int) Math.Round(availablePopulation * 0.2);
            double koef = GetSciencePerPersona() * 2;
            koef = ChanceCurves.CurveLinierChance(koef, ChanceScale.High);
            logger.LogInformation(Name + " chance koef: " + koef);
            int disabled = 0, dead = 0;
            for (int i = 0; i < effectedPopulation; i++) {
                chance = RandomGenerator.RandomPercent(1) * koef;
                if (chance < 0.05) {
                    dead++;
                    continue;
                }
                if (chance < 0.25) {
                    disabled++;
                }
            }
            var events = _gameplayContext.eventContext;
            if (dead > 0) {
                var evnt = new DiseaseDethEvent(dead);
                evnt.SetContext(_gameplayContext);
                events.AddEvent(evnt);
            }
            if (disabled > 0) {
                var evnt = new DiseaseDisableEvent(disabled, 3);
                evnt.SetContext(_gameplayContext);
                events.AddEvent(evnt);
            }
        }

        private double CalculateEndChance() {
            int science = _gameplayContext.resoursesContext[Resourses.ResourseType.Science].Inflow;
            int people = _gameplayContext.curentWorkerContext.AllWorkersCount;
            double koef = GetSciencePerPersona();
            if (koef > 1) {
                koef = 1;
            }
            double linierChance = koef / 2;
            return ChanceCurves.CurveLinierChance(linierChance, ChanceScale.Medium);
        }

        private double GetSciencePerPersona() {
            double science = _gameplayContext.resoursesContext[Resourses.ResourseType.Science].Inflow;
            double people = _gameplayContext.curentWorkerContext.AllWorkersCount;
            if (people == 0) {
                return 0;
            }
            return science / people;
        }
    }
}
