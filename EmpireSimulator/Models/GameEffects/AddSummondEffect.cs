using EmpireSimulator.Models.Resourses;

namespace EmpireSimulator.Models.GameEffects
{
    public class AddSummondEffect : AbstractEffect
    {
        private int _value;
        private ResourseType _resourseType;
        private int summandId;

        public AddSummondEffect(GameplayContext gameplayContext, int duration, ResourseType resourseType, int value)
        {
            _duration = duration;
            _value = value;
            _resourseType = resourseType;
            _gameplayContext = gameplayContext;
        }

        public void SetName(string name) => _name = name;
        public void SetEffectType(EffectType type) => _type = type;

        public override void Start()
        {
            var summand = new InflowSummand(() => _value);
            summandId = _gameplayContext.resoursesContext[_resourseType].Summands.Add(summand);
            AddToEffects();
        }

        public override void End()
        {
            _gameplayContext.resoursesContext[_resourseType].Summands.Remove(summandId);
        }
    }
}
