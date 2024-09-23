using EmpireSimulator.Data;
using EmpireSimulator.Models.GameEffects;
using System.Windows.Controls;


namespace EmpireSimulator.InterfaceObjects {
    /// <summary>
    /// Логика взаимодействия для EmpireInfoPanel.xaml
    /// </summary>
    public partial class EmpireInfoPanel: UserControl {
        private Dictionary<int, int> effectIdsMessagesIds = new();
        private Dictionary<int, EffectMessage> effectsMessages = new();
        public EmpireInfoPanel() {
            InitializeComponent();
        }

        public int AllPopulationCount { set => AllCounter.Counter = value; }

        public int UnavailablePopulationCount { set => UnavailableCounter.Counter = value; }

        public void SetEffect(AbstractEffect effect) {
            if (effectIdsMessagesIds.ContainsKey(effect.Id)) {
                effectsMessages[effect.Id].DurationCount = effect.Duration.Value;
            } else {
                AddEffect(effect);
            }
        }

        public void AddEffect(AbstractEffect effect) {
            var msg = new EffectMessage();
            msg.EffectName = effect.Name;
            msg.DurationCount = effect.Duration.Value;
            msg.TypeColor = Constants.EffectBrushes[effect.Type];
            int msgId = EffectMessagesStack.Children.Add(msg);
            effectIdsMessagesIds[effect.Id] = msgId;
            effectsMessages[effect.Id] = msg;
        }

        public void RemoveEffect(AbstractEffect effect) {
            int msgId = effectIdsMessagesIds[effect.Id];
            EffectMessagesStack.Children.RemoveAt(msgId);
        }
    }
}
