using System.Windows;
using System.Windows.Controls;
using EmpireSimulator.Models;
using EmpireSimulator.Data;
using System.Reflection;
using EmpireSimulator.Models.Resourses;
using EmpireSimulator.Models.Workers;

namespace EmpireSimulator
{
    /// <summary>
    /// Логика взаимодействия для Gameplay.xaml
    /// </summary>
    public partial class GameplayPage: Page {

        readonly Thread gameplayThread;
        readonly GameplayManager gameplayManager;
        readonly Dictionary<ResourseType, InterfaceObjects.ProgressBar> resoursesBars;
        readonly Dictionary<ResourseType, InterfaceObjects.ResourseCounter> resoursesCounters;

        public GameplayPage() {
            InitializeComponent();
            resoursesBars = new() {
                { ResourseType.Food, FoodBar },
                { ResourseType.Production, ProductionBar },
                { ResourseType.Science, ScienceBar },
                { ResourseType.Money, MoneyBar },
            };
            resoursesCounters = new() {
                { ResourseType.Food, FoodResourseCounter },
                { ResourseType.Production, ProductionResourseCounter },
                { ResourseType.Science, ScienceResourseCounter },
                { ResourseType.Money, MoneyResourseCounter },
            };
            gameplayManager = new(this);
            SetWorkerCount();
            foreach (var resourse in Constants.ResourseTypes)
                SetProgressBarButtons(resourse);
            gameplayThread = new Thread(() => {
                gameplayManager.StartGameAsync();
            });
            gameplayThread.Start();
        }

        public void SetProgressBarButtons(ResourseType resourse) {
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

        public void AddMsg(string msg) {
            Label msgLabel = new();
            msgLabel.Content = msg;
            MessagesPanel.Children.Add(msgLabel);
        }

        public void SetTimeCounter(int count) {
            TimeCounter.Counter = count;
        }

        public void SetProgressBars(WorkerContext context) {
            foreach (var resourse in Constants.ResourseTypes) {
                resoursesBars[resourse].MaxValue = context[resourse].MaxCount;
                resoursesBars[resourse].NewValue = context[resourse].Count;
                resoursesBars[resourse].SetBar();
            }
        }

        public void SetResourses(ResoursesContext resoursesContext) {
            foreach(var resourseType in Constants.ResourseTypes) {
                var resourse = resoursesContext[resourseType];
                var counter = resoursesCounters[resourseType];
                counter.InflowCounter = resourse.Inflow;
                counter.StorageCapacity = resourse.StorageCapacity;
                counter.MaxStorageCapacity = resourse.MaxStorageCapacity;
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
