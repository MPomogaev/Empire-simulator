using EmpireSimulator.Data;
using EmpireSimulator.Models.Resourses;
using EmpireSimulator.Models.Workers;
using System.Reflection.Emit;
using System.Security.Cryptography;

namespace EmpireSimulator.Models
{
    class GameplayManager
    {
        bool ContinuePlaying = true;
        GameplayPage Page;
        GameplayContext context = new();

        public GameplayManager(GameplayPage _Page) {
            Page = _Page;
            context.eventContext.SetPossibleEvents(context);
        }

        public int FreeWorkerCount { get {
                lock (context.newWorkerContext) {
                    return context.newWorkerContext.FreeWorkersCount;
                }
            } 
        }
        public int AllWorkerCount { get {
                lock (context.newWorkerContext) {
                    return context.newWorkerContext.AllWorkersCount;
                }
            }
        }

        public async void StartGameAsync() {
            try {
                while (ContinuePlaying) {
                    Page.Dispatcher.Invoke(() => {
                        UpdateGui();
                        GetNextTurnData();
                    });
                    var nextTurnDelay = Task.Delay(2000);
                    MakeTurn();
                    await nextTurnDelay;
                }
            } catch (TaskCanceledException ex) {
                //throw ex;
                //need to emplement logging
            }
        }

        public bool TryAddWorker(ResourseType resourse) {
            lock (context.newWorkerContext) {
                var workers = context.newWorkerContext[resourse].Count;
                var maxWorkers = context.newWorkerContext[resourse].MaxCount;
                if (context.newWorkerContext.FreeWorkersCount > 0 && maxWorkers > workers) {
                    context.newWorkerContext[resourse].Count += 1;
                    context.newWorkerContext.FreeWorkersCount -= 1;
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
                    context.newWorkerContext.FreeWorkersCount += 1;
                    return true;
                }
                return false;
            }
        }

        public void StopGame() {
            ContinuePlaying = false;
        }

        private void MakeTurn() {
            context.turnCounter.NextTurn();
            context.eventContext.Happen();
        }

        private void UpdateGui() {
            Page.SetTimeCounter(context.turnCounter.Count);
            Page.SetProgressBars(context.newWorkerContext);
            context.resoursesContext.UpdateResourses(context.newWorkerContext);
            Page.SetResourses(context.resoursesContext);
            Page.SetWorkerCount();
            foreach(var _event in context.eventContext.HappendEvents) {
                Page.AddEventMessage(_event);
            }
        }

        private void GetNextTurnData() {
            context.curentWorkerContext.Copy(context.newWorkerContext);
        }
    }
}
