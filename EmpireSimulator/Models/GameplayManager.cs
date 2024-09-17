using EmpireSimulator.Data;
using System.Security.Cryptography;

namespace EmpireSimulator.Models
{
    class GameplayManager
    {
        int timeCount = 0;
        bool continuePlaying = true;
        GameplayPage page;
        WorkerContext workerContext = new();

        public GameplayManager(GameplayPage _page) {
            page = _page;
        }

        public int FreeWorkerCount { get { return workerContext.FreeWorkersCount; } }
        public int AllWorkerCount { get { return workerContext.AllWorkersCount; } }

        public async void StartGameAsync() {
            try {
                page.Dispatcher.Invoke(new(() => UpdateGui()));
                while (continuePlaying) {
                    var waitTask = Task.Delay(2000);
                    MakeTurn();
                    await waitTask;
                    page.Dispatcher.Invoke(new(() => {
                        UpdateGui();
                    }));
                }
            } catch (TaskCanceledException ex) {
                //throw ex;
                //need to emplement logging
            }
        }

        public void MakeTurn() {
            ++timeCount;
        }

        public void UpdateGui() {
            page.SetTimeCounter(timeCount);
            page.SetProgressBars(workerContext);
        }

        public bool TryAddWorker(ResourseType resourse) {
            var workers = workerContext.GetWorkers(resourse);
            var maxWorkers = workerContext.GetMaxWorkers(resourse);
            if (workerContext.FreeWorkersCount > 0 && maxWorkers > workers) {
                workerContext.SetWorkers(resourse, workers + 1);
                workerContext.FreeWorkersCount -= 1;
                return true;
            }
            return false;
        }

        public bool TryRemoveWorker(ResourseType resourse) {
            var workers = workerContext.GetWorkers(resourse);
            var maxWorkers = workerContext.GetMaxWorkers(resourse);
            if (workers > 0) {
                workerContext.SetWorkers(resourse, workers - 1);
                workerContext.FreeWorkersCount += 1;
                return true;
            }
            return false;
        }

        public void StopGame() {
            continuePlaying = false;
        }
    }
}
