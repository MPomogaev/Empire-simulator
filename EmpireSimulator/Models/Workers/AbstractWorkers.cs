
namespace EmpireSimulator.Models.Workers {
    public abstract class AbstractWorkers {
        public virtual int MaxCount { get; set; } = 10;
        public virtual int Count { get; set; } = 0;

        public virtual AbstractWorkers Clone() {
            return (AbstractWorkers)this.MemberwiseClone();
        }
    }
}
