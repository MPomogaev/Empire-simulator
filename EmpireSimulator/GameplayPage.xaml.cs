using System.Windows;
using System.Windows.Controls;
using EmpireSimulator.Models;
using EmpireSimulator.Data;
using System.Reflection;

namespace EmpireSimulator {
    /// <summary>
    /// Логика взаимодействия для Gameplay.xaml
    /// </summary>
    public partial class GameplayPage: Page {

        readonly Thread gameplayThread;
        readonly GameplayManager gameplayManager;
        readonly Dictionary<ResourseType, InterfaceObjects.ProgressBar> resoursesBars;

        public GameplayPage() {
            InitializeComponent();
            resoursesBars = new() {
                { ResourseType.Food, FoodBar },
                { ResourseType.Production, ProductionBar },
                { ResourseType.Science, ScienceBar },
                { ResourseType.Money, MoneyBar },
            };
            gameplayManager = new(this);
            SetWorkerCount();
            foreach (var resourse in Constants.ResourseTypes) {
                var bar = resoursesBars[resourse];
                bar.AddClick = new((object sender, RoutedEventArgs e) => {
                    if (gameplayManager.TryAddWorker(resourse)) {
                        SetWorkerCount();
                        bar.NewValue++;
                        bar.SetSlider();
                    }
                });
                bar.RemoveClick = new((object sender, RoutedEventArgs e) => {
                    if (gameplayManager.TryRemoveWorker(resourse)) {
                        SetWorkerCount();
                        bar.NewValue--;
                        bar.SetSlider();
                    }
                });
            }
            gameplayThread = new Thread(() => {
                gameplayManager.StartGameAsync();
            });
            gameplayThread.Start();
        }

        public void SetTimeCounter(int count) {
            TimeCounter.Counter = count;
        }

        public void SetProgressBars(WorkerContext context) {
            foreach (var resourse in Constants.ResourseTypes) {
                resoursesBars[resourse].MaxValue = context.GetMaxWorkers(resourse);
                resoursesBars[resourse].NewValue = context.GetWorkers(resourse);
                resoursesBars[resourse].SetBar();
            }
        }

        public void LeaveGame(object sender, RoutedEventArgs e) {
            gameplayManager.StopGame();
            MenuPage menuPage = new();
            this.NavigationService.Navigate(menuPage);
        }

        private void SetWorkerCount() {
            FreeWorkersCounter.Counter = gameplayManager.FreeWorkerCount;
            AllWorkersCounter.Counter = gameplayManager.AllWorkerCount;
        }

    }
}
