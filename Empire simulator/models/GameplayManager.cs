using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empire_simulator.models
{
    class GameplayManager
    {
        bool continuePlaying = true;
        GameplayPage page;
        object locker = new();

        public GameplayManager(GameplayPage _page) {
            page = _page;
        }

        public void StartGame() {
            bool curentState;
            do {
                Thread.Sleep(2000);
                page.Dispatcher.Invoke(new Action(() => {
                    page.AddMessage("123");
                }));
            } while (continuePlaying);
        }

        public void StopGame() {
            continuePlaying = false;
        }
    }
}
