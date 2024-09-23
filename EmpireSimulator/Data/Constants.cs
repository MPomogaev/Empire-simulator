using EmpireSimulator.Models.Resourses;
using EmpireSimulator.Models.GameEvents;
using System.Windows.Media;
using EmpireSimulator.Models.GameEffects;

namespace EmpireSimulator.Data
{
    internal static class Constants {
        public static readonly List<ResourseType> ResourseTypes = new(){
            ResourseType.Food,
            ResourseType.Production,
            ResourseType.Money,
            ResourseType.Science
        };

        public static readonly Dictionary<EventType, Brush> EventBrushes = new() {
            { EventType.Neutral, BrushConverter.GetBrushFromColorString("Black")},
            { EventType.Negative, BrushConverter.GetBrushFromColorString("Red")},
            { EventType.Positive, BrushConverter.GetBrushFromColorString("Green")},
        };

        public static readonly Dictionary<EffectType, Brush> EffectBrushes = new() {
            { EffectType.Neutral, BrushConverter.GetBrushFromColorString("Black")},
            { EffectType.Negative, BrushConverter.GetBrushFromColorString("Red")},
            { EffectType.Positive, BrushConverter.GetBrushFromColorString("Green")},
        };

        public static readonly string GameEndedMessage = "Конец";
    }
}
