﻿using EmpireSimulator.Data;
using EmpireSimulator.Models.GameEffects;
using System.Windows.Controls;


namespace EmpireSimulator.InterfaceObjects {
    /// <summary>
    /// Логика взаимодействия для EmpireInfoPanel.xaml
    /// </summary>
    public partial class EmpireInfoPanel: UserControl {
        private StackPositionsDictionary effectIdsMessagesIds = new();
        private Dictionary<int, EffectMessage> effectsMessages = new();
        public EmpireInfoPanel() {
            InitializeComponent();
        }

        public int AllPopulationCount { set => AllCounter.Counter = value; }

        public int UnavailablePopulationCount { set => UnavailableCounter.Counter = value; }

        public string EmpireName { set => EmpireNameLabel.Content = value; }

        public void SetEffect(AbstractEffect effect) {
            if (effectsMessages.ContainsKey(effect.Id)) {
                effectsMessages[effect.Id].DurationCount = effect.Duration;
            } else {
                AddEffect(effect);
            }
        }

        public void AddEffect(AbstractEffect effect) {
            var msg = new EffectMessage();
            msg.EffectName = effect.Name;
            msg.DurationCount = effect.Duration;
            msg.TypeColor = Constants.EffectBrushes[effect.Type];
            int msgId = EffectMessagesStack.Children.Add(msg);
            effectIdsMessagesIds[effect.Id] = msgId;
            effectsMessages[effect.Id] = msg;
        }

        public void RemoveEffect(AbstractEffect effect) {
            int effectId = effect.Id;
            int msgId = effectIdsMessagesIds.Remove(effectId);
            EffectMessagesStack.Children.RemoveAt(msgId);
            effectsMessages.Remove(effectId);
        }
    }
}
