using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empire_simulator.models
{
    class GameplayManager
    {
        int timeCount = 0;
        bool continuePlaying = true;
        GameplayPage page;

        public GameplayManager(GameplayPage _page) {
            page = _page;
        }

        public void StartGame() {
            while (continuePlaying) {
                Thread.Sleep(2000);
                page.Dispatcher.Invoke(new Action(() => {
                    MakeTurn();
                }));
            }
        }

        public void MakeTurn() {
            page.SetTimeCounter(++timeCount);
        }

        public void StopGame() {
            continuePlaying = false;
        }
    }
}
