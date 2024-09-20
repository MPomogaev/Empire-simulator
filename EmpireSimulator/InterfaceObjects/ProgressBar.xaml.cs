using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace EmpireSimulator.InterfaceObjects {
    /// <summary>
    /// Логика взаимодействия для slider.xaml
    /// </summary>
    public partial class ProgressBar: UserControl {

        public ProgressBar(): this(0, 1) {}

        public ProgressBar(int value, int maxValue) {
            InitializeComponent();
            NewValue = value;
            MaxValue = maxValue;
            SetBar();
        }

        public Brush Color {
            set { ProgressBarRectangle.Fill = value; }
        }

        public int MaxValue { get; set; }

        public int NewValue { get; set; }

        public string ProgressBarName {
            get { return (string)ProgressBarNameLabel.Content;  }
            set { ProgressBarNameLabel.Content = value; }
        }

        public RoutedEventHandler AddClick { set => AddButton.Click += value; }

        public RoutedEventHandler RemoveClick { set => RemoveButton.Click += value; }

        public void SetBar() {
            if (NewValue > MaxValue) {
                throw new ArgumentException("progress bar Value more then MaxValue");
            }
            SetColumns(ProgressBarColumn, EmptyProgressBarColumn);
            SetSlider();
        }

        public void SetSlider() {
            if (NewValue > MaxValue) {
                throw new ArgumentException("slider Value more then MaxValue");
            }
            ValueLabel.Content = NewValue;
            MaxValueLabel.Content = MaxValue;
            SetColumns(SliderColumn, EmptySliderColumn);    
        }

        private void SetColumns(ColumnDefinition left, ColumnDefinition right) {
            left.Width = new GridLength(NewValue, GridUnitType.Star);
            right.Width = new GridLength(MaxValue - NewValue, GridUnitType.Star);
        }
    }
}
