using EmpireSimulator.Data;
using EmpireSimulator.Models.GameEvents;
using EmpireSimulator.Models.Resourses;

namespace EmpireSimulator.Models
{
    public class GameplayManager
    {
        GameplayPage Page;
        GameplayContext context;

        public GameplayManager(GameplayPage _Page) {
            Page = _Page;
            context = new(this);
            context.eventContext.SetPossibleEvents(context);
        }

        public int AvailableWorkerCount { get {
                lock (context.newWorkerContext) {
                    return context.newWorkerContext.AvailableWorkersCount;
                }
            } 
        }
        public int AllWorkerCount { get {
                lock (context.newWorkerContext) {
                    return context.newWorkerContext.AllWorkersCount;
                }
            }
        }
        public int UnavailableWorkerCount {
            get {
                lock (context.newWorkerContext) {
                    return context.newWorkerContext.UnavailableWorkersCount;
                }
            }
        }

        public async void StartGameAsync() {
            try {
                while (context.continuePlaying) {
                    Page.Dispatcher.Invoke(() => {
                        UpdateGui();
                        GetNextTurnData();
                    });
                    var nextTurnDelay = Task.Delay(2000);
                    MakeTurn();
                    await nextTurnDelay;
                }
                Page.Dispatcher.Invoke(() => {
                    Page.AddMessage(Constants.GameEndedMessage);
                });
            } catch (TaskCanceledException ex) {
                //throw ex;
                //need to emplement logging
            }
        }

        public bool TryAddWorker(ResourseType resourse) {
            lock (context.newWorkerContext) {
                var workers = context.newWorkerContext[resourse].Count;
                var maxWorkers = context.newWorkerContext[resourse].MaxCount;
                if (context.newWorkerContext.AvailableWorkersCount > 0 && maxWorkers > workers) {
                    context.newWorkerContext[resourse].Count += 1;
                    context.newWorkerContext.AvailableWorkersCount -= 1;
                    return true;
                }
                return false;
            }
        }

        public bool TryRemoveWorker(ResourseType resourse) {
            lock (context.newWorkerContext) {
                var workers = context.newWorkerContext[resourse].Count;
                var maxWorkers = context.newWorkerContext[resourse].MaxCount;
                if (workers > 0) {
                    context.newWorkerContext[resourse].Count -= 1;
                    context.newWorkerContext.AvailableWorkersCount += 1;
                    return true;
                }
                return false;
            }
        }

        public void StopGame() {
            context.continuePlaying = false;
        }

        private void MakeTurn() {
            context.turnCounter.NextTurn();
            context.eventContext.Happen();
        }

        private void UpdateGui() {
            int turn = context.turnCounter.Count;
            Page.SetTimeCounter(turn);
            Page.SetProgressBars(context.newWorkerContext);
            context.resoursesContext.UpdateResourses(context.newWorkerContext);
            Page.SetResourses(context.resoursesContext);
            Page.SetWorkerCount();
            var events = context.eventContext.HappendEvents;
            if (events.Count > 0) {
                Page.AddNewTurn(turn);
            }
            foreach (var _event in events) {
                Page.AddEventMessage(_event);
            }
        }

        private void GetNextTurnData() {
            context.curentWorkerContext.Copy(context.newWorkerContext);
        }
    }
}
