using EmpireSimulator.Data;
using EmpireSimulator.Models.Resourses;
using EmpireSimulator.Models.Workers;
using System.Reflection.Emit;
using System.Security.Cryptography;

namespace EmpireSimulator.Models
{
    class GameplayManager
    {
        int TimeCount = 0;
        bool ContinuePlaying = true;
        GameplayPage Page;
        WorkerContext NewWorkerContext = new();
        WorkerContext CurentWorkerContext = new();
        ResoursesContext ResoursesContext = new();

        public GameplayManager(GameplayPage _Page) {
            Page = _Page;
        }

        public int FreeWorkerCount { get { return NewWorkerContext.FreeWorkersCount; } }
        public int AllWorkerCount { get { return NewWorkerContext.AllWorkersCount; } }

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
            var workers = NewWorkerContext[resourse].Count;
            var maxWorkers = NewWorkerContext[resourse].MaxCount;
            if (NewWorkerContext.FreeWorkersCount > 0 && maxWorkers > workers) {
                NewWorkerContext[resourse].Count += 1;
                NewWorkerContext.FreeWorkersCount -= 1;
                return true;
            }
            return false;
        }

        public bool TryRemoveWorker(ResourseType resourse) {
            var workers = NewWorkerContext[resourse].Count;
            var maxWorkers = NewWorkerContext[resourse].MaxCount;
            if (workers > 0) {
                NewWorkerContext[resourse].Count -= 1;
                NewWorkerContext.FreeWorkersCount += 1;
                return true;
            }
            return false;
        }

        public void StopGame() {
            ContinuePlaying = false;
        }

        private void MakeTurn() {
            ++TimeCount;
            ResoursesContext.UpdateResourses(CurentWorkerContext);
        }

        private void UpdateGui() {
            Page.SetTimeCounter(TimeCount);
            Page.SetProgressBars(NewWorkerContext);
            Page.SetResourses(ResoursesContext);
        }

        private void GetNextTurnData() {
            CurentWorkerContext.Copy(NewWorkerContext);
        }
    }
}
