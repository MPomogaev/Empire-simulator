using EmpireSimulator.Data;
using Microsoft.Extensions.Logging;
using System.Linq.Expressions;
using System.Windows.Controls;
using System.Windows.Media;

namespace EmpireSimulator {
    public class PopMessagesAnimator {
        ILogger _logger;
        private bool isRolling;

        private List<PopMessage> popMessages = new() {
            new("Болезнь", Data.BrushConverter.GetBrushFromColorString("Red")),
            new("Забастовка", Data.BrushConverter.GetBrushFromColorString("Red")),
            new("Смерть", Data.BrushConverter.GetBrushFromColorString("Red")),
            new("Засуха", Data.BrushConverter.GetBrushFromColorString("Red")),
            new("Неожиданные траты", Data.BrushConverter.GetBrushFromColorString("Red")),
            new("Война", Data.BrushConverter.GetBrushFromColorString("Red")),
            new("Хорошая погода", Data.BrushConverter.GetBrushFromColorString("Green")),
            new("Новое население", Data.BrushConverter.GetBrushFromColorString("Green")),
            new("Научный прорыв", Data.BrushConverter.GetBrushFromColorString("Green")),
            new("Инвестиции", Data.BrushConverter.GetBrushFromColorString("Green")),
            new("Праздник", Data.BrushConverter.GetBrushFromColorString("Green")),
            new("Перемирие", Data.BrushConverter.GetBrushFromColorString("Green")),
            new("Мигранты", Data.BrushConverter.GetBrushFromColorString("Black")),
        };
        private MenuPage _menuPage;

        public PopMessagesAnimator(MenuPage menuPage) {
            _menuPage = menuPage;
            _logger = LogManager.GetLogger<PopMessagesAnimator>();
        }

        public void Start() {
            isRolling = true;
            while (true) {
                lock ((object)isRolling) {
                    if (!isRolling) {
                        break;
                    }
                    _menuPage.Dispatcher.Invoke(Next);
                }
                Thread.Sleep(1500);
            }
        }

        public void Stop() {
            lock ((object)isRolling) {
                isRolling = false;
            }
        }

        private void Next() {
            PopMessage content = popMessages[RandomGenerator.RandomInt(popMessages.Count)];
            Label newMessage = new();
            newMessage.Content = content.Text;
            newMessage.Foreground = content.Color;
            _menuPage.AddMessageToCanvas(newMessage);
        }

    }

    public struct PopMessage {
        public PopMessage(string text, Brush brush) {
            Text = text;
            Color = brush;
        }

        public string Text { get; set; }
        public Brush Color { get; set; }
    }
}
