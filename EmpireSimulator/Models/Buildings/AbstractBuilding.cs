using EmpireSimulator.Models.Resourses;

namespace EmpireSimulator.Models.Buildings {
    public abstract class AbstractBuilding {
        protected GameplayContext _gameplayContext;
        protected ResourseType resourse;
        protected int _count = 0;
        public virtual int Count { get { return _count; } set { _count = value; } }
        protected Dictionary<ResourseType, int> _cost;
        public virtual Dictionary<ResourseType, int> Cost { get => _cost; }
        protected int _upkeep;
        public virtual int Upkeep { get => _upkeep; }
        public virtual bool Build() {
            if (_cost.Keys.Contains(ResourseType.Production)) {
                var productionCount = 
                    _gameplayContext.resoursesContext[ResourseType.Production].StorageCapacity;
                if (_cost[ResourseType.Production] > productionCount) {
                    return false;
                }
            }
            foreach (var resourse in _cost.Keys) {
                var storage = _gameplayContext.resoursesContext[resourse];
                if (storage is not HasStorageResourse) {
                    throw new Exception("in building cost there is resourse without storage(not HasStorageResourse)");
                }
                var hasStorageResourse = (HasStorageResourse)storage;
                hasStorageResourse.RemoveFromStorage(Cost[resourse]);
            }
            Count += 1;
            return true;
        }
        public virtual bool Destroy() {
            if (Count == 0) {
                return false;
            }
            foreach (var resourse in _cost.Keys) {
                var storage = _gameplayContext.resoursesContext[resourse];
                if (storage is not HasStorageResourse) {
                    throw new Exception("in building cost there is resourse without storage(not HasStorageResourse)");
                }
                ((HasStorageResourse)storage).AddToStorage(Cost[resourse]);
            }
            Count -= 1;
            return true;
        }
    }
}
