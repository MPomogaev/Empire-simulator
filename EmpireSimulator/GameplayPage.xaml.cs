using System.Windows;
using System.Windows.Controls;
using EmpireSimulator.Models;
using EmpireSimulator.Data;
using EmpireSimulator.Models.GameEffects;
using EmpireSimulator.Models.Resourses;
using EmpireSimulator.Models.Workers;
using EmpireSimulator.Models.GameEvents;
using EmpireSimulator.InterfaceObjects;
using Microsoft.Extensions.Logging;
using EmpireSimulator.Models.Buildings;

namespace EmpireSimulator
{
    /// <summary>
    /// Логика взаимодействия для Gameplay.xaml
    /// </summary>
    public partial class GameplayPage: Page {

        readonly Thread gameplayThread;
        readonly GameplayManager gameplayManager;
        readonly Dictionary<ResourseType, InterfaceObjects.ProgressBar> resoursesBars;
        readonly Dictionary<ResourseType, ResourseCounter> resoursesCounters;

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
            foreach(var resourseType in Constants.ResourseTypes) {
                var buildingBlock = BuildingsPanel[resourseType];
                foreach(var buildingType in Constants.BuildingTypes) {
                    var building = buildingBlock[buildingType];
                    building.OnMinusClick = new(() => {
                        gameplayManager.DestroyBuilding(resourseType, buildingType);
                    });
                    building.OnPlusClick = new(() => {
                        gameplayManager.BuildBuilding(resourseType, buildingType);
                    });
                }
            }
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

        public void AddEventMessage(AbstractEvent _event) {
            var entry = new EventMessage();
            entry.EventName = _event.Name;
            entry.EventDescription = _event.Description;
            entry.TypeColor = Constants.EventBrushes[_event.Type];
            MessagesStack.Children.Add(entry);
        }

        public void AddMessage(string msg) {
            Label entry = new Label();
            entry.Style = this.FindResource("labelStyle") as Style;
            entry.FontSize = 20;
            entry.Content = msg;
            entry.Margin = new Thickness(5);
            MessagesStack.Children.Add(entry);
        }

        public void SetBuildingsCounter(ResourseType resourse, BuildingType building, int value) {
            var counter = BuildingsPanel[resourse][building];
            counter.Counter = value;
        }

        public void SetTimeCounter(int count) {
            TimeCounter.Counter = count;
        }

        public void AddNewTurn(int turn) {
            AddMessage("Ход " + turn);
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
            gameplayThread.Join();
            MenuPage menuPage = new();
            this.NavigationService.Navigate(menuPage);
        }

        public void SetWorkerCount() {
            AvailableWorkersCounter.Counter = gameplayManager.AvailableWorkerCount;
            InfoPanel.AllPopulationCount = gameplayManager.AllWorkerCount;
            InfoPanel.UnavailablePopulationCount = gameplayManager.UnavailableWorkerCount;
        }

        public void SetEffect(AbstractEffect effect) {
            InfoPanel.SetEffect(effect);
        }

        public void RemoveEffect(AbstractEffect effect) {
            InfoPanel.RemoveEffect(effect);
        }

    }
}
