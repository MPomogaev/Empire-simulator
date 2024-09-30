using EmpireSimulator.Data;
using EmpireSimulator.Models.GameEffects;

namespace EmpireSimulator.Models.GameEvents {
    public class ScienceBreakthroughEvent: EachTurnChanceEvent {

        public ScienceBreakthroughEvent() {
            _name = "Научный прорыв";
            _type = EventType.Positive;
        }

        public override void Happen() {
            var resourseType = RandomGenerator.RandomResourse();
            double multiplyValue = Math.Round(RandomGenerator.RandomDouble(1.1, 1.3), 2);
            int duration = 10;
            var effect = new AddMultiplierEffect(_gameplayContext, duration, resourseType, multiplyValue);
            effect.SetEffectType(EffectType.Positive);
            effect.SetName(Name);
            effect.Start();
            _description = "благодаря вашим учёным приток "
                + Constants.ResourseNames[resourseType]
                + " увеличен в " + multiplyValue
                + " на следующие " + duration + " ходов";
            _gameplayContext.eventContext.RemoveEvent(Id);
        }

        public override double Chance { get {
                var science = _gameplayContext.resoursesContext[Resourses.ResourseType.Science];
                int allWorkers = _gameplayContext.curentWorkerContext.AllWorkersCount;
                int inflow = science.Inflow;
                double koef = inflow/(double)allWorkers;
                return ChanceCurves.CurveLinierChance(koef, ChanceScale.Small);
            }
        }

    }
}
