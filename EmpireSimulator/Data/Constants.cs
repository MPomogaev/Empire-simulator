using EmpireSimulator.Models.Resourses;
using EmpireSimulator.Models.GameEvents;
using System.Windows.Media;

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
    }
}
