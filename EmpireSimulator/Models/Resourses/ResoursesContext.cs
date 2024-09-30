using System;
using EmpireSimulator.Data;
using EmpireSimulator.Models.Workers;
namespace EmpireSimulator.Models.Resourses
{
    public class ResoursesContext
    {
        private Dictionary<ResourseType, AbstractResourse> Resourses = new() {
            { ResourseType.Food, new FoodResourse()},
            { ResourseType.Production, new ProductionResourse()},
            { ResourseType.Money, new MoneyResourse()},
            { ResourseType.Science, new ScienceResourse()},
        };

        public AbstractResourse this[ResourseType resourse]
        {
            get
            {
                return Resourses[resourse];
            }
        }

        public void UpdateResourses(WorkerContext workerContext)
        {
            foreach (var resourses in Resourses.Values)
            {
                resourses.NextTurnUpdate(workerContext);
            }
        }
    }
}
