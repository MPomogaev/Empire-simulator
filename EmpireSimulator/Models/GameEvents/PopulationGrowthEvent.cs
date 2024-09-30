using EmpireSimulator.Models.Resourses;
using EmpireSimulator.Data;

namespace EmpireSimulator.Models.GameEvents {
    public class PopulationGrowthEvent: EachTurnChanceEvent {

        public PopulationGrowthEvent() {
            _description = "eстевтсвенный прирост населения ";
            _name = "Новое население";
            _type = EventType.Positive;
        }

        public override void Happen() {
            lock(_gameplayContext.newWorkerContext) {
                _gameplayContext.newWorkerContext.AvailableWorkersCount++;
            }
            _gameplayContext.eventContext.RemoveEvent(Id);
        }

        public override double Chance { get { 
                var foodResourse = (FoodResourse)_gameplayContext.resoursesContext[ResourseType.Food];
                var workerContext = _gameplayContext.curentWorkerContext;
                double production = foodResourse.CalculateBaseInflow(workerContext);
                if (production == 0) {
                    return 0;
                }
                double consumption = foodResourse.GetConsumption(workerContext);
                double linierChance = production / (production + consumption);
                double curvedChance = ChanceCurves.CurveLinierChance(linierChance, ChanceScale.Smaller);
                return curvedChance;
            }
        }

    }
}
