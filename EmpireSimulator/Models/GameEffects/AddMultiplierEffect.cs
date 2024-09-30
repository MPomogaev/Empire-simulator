using EmpireSimulator.Models.Resourses;
using System.Security.AccessControl;

namespace EmpireSimulator.Models.GameEffects {
    internal class AddMultiplierEffect: AbstractEffect {
        private double _value;
        private ResourseType _resourseType;
        private int multiplierId;

        public AddMultiplierEffect(GameplayContext gameplayContext, int duration, ResourseType resourseType, double value) {
            _duration = duration;
            _value = value;
            _resourseType = resourseType;
            _gameplayContext = gameplayContext;
        }

        public void SetName(string name) => _name = name;
        public void SetEffectType(EffectType type) => _type = type;

        public override void Start() {
            var multiplier = new InflowMultiplier(() => _value);
            multiplierId = _gameplayContext.resoursesContext[_resourseType].Multipliers.Add(multiplier);
            AddToEffects();
        }

        public override void End() {
            _gameplayContext.resoursesContext[_resourseType].Multipliers.Remove(multiplierId);
        }
    }
}
