
namespace EmpireSimulator.Models.Resourses {
    public abstract class HasStorageResourse: AbstractResourse {
        private int _StorageCapacity = 0;
        public override int? StorageCapacity { get => _StorageCapacity; }
        private int _MaxStorageCapacity = 100;
        public override int? MaxStorageCapacity { get => _MaxStorageCapacity; }
        public virtual void AddToStorage(int value) {
            if (_StorageCapacity + value > _MaxStorageCapacity) {
                _StorageCapacity = value;
            } else {
                _StorageCapacity += value;
            }
        }

        public virtual void RemoveFromStorage(int value) {
            AddToStorage(-value);
        }
        public virtual void SetMaxStorageCapacity(int newMax) {
            _MaxStorageCapacity = newMax;
            if (_StorageCapacity > _MaxStorageCapacity) {
                _StorageCapacity = _MaxStorageCapacity;
            }
        }
        public virtual void SetStorageCapacity(int newCapacity) {
            if (newCapacity > _MaxStorageCapacity) {
                throw new ArgumentException("newCapacity can't be more than MaxCapacity");
            }
            _StorageCapacity = newCapacity;
        }
    }
}
