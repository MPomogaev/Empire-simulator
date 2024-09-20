using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;


namespace EmpireSimulator.InterfaceObjects {
    /// <summary>
    /// Логика взаимодействия для EventMessage.xaml
    /// </summary>
    public partial class EventMessage: UserControl {
        public EventMessage() {
            InitializeComponent();
        }

        public string EventName { set => EventNameLabel.Content = value; }

        public string EventDescription { set => EventDescriptionTextBlock.Text = value; }

        public Brush TypeColor { set => EventNameLabel.Foreground = value; }
    }
}
