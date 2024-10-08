﻿using System.Windows;
using System.Windows.Controls;


namespace EmpireSimulator.InterfaceObjects {
    /// <summary>
    /// Логика взаимодействия для NamedCounter.xaml
    /// </summary>
    public partial class NamedCounter: UserControl {
        public NamedCounter() {
            InitializeComponent();
        }

        public string CounterName { set => CounterNameLabel.Content = value; }
        public int Counter { set => CounterLabel.Content = value; }
        public bool IsBold { set {
                if (!value) {
                    CounterLabel.FontWeight = FontWeights.Normal;
                    CounterNameLabel.FontWeight = FontWeights.Normal;
                }
            } 
        }
    }
}
