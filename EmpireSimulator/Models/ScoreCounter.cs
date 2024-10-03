using EmpireSimulator.Data;
using EmpireSimulator.Models.Buildings;

namespace EmpireSimulator.Models {
    public class ScoreCounter {
        GameplayContext _gameplayContext;
        public int Count {  get; set; }

        public ScoreCounter(GameplayContext gameplayContext) {
            _gameplayContext = gameplayContext;
        }

        public void NextTurn() {
            int turnCount = 1;
            turnCount += _gameplayContext.curentWorkerContext.AllWorkersCount;
            var buildings = _gameplayContext.buildingContext;
            foreach (var resourse in Constants.ResourseTypes) {
                turnCount += _gameplayContext.buildingContext[resourse, BuildingType.Small].Count;
                turnCount += 2 * _gameplayContext.buildingContext[resourse, BuildingType.Medium].Count;
                turnCount += 3 * _gameplayContext.buildingContext[resourse, BuildingType.Large].Count;
            }
            Count += turnCount;
        }

        public void Save() {
            FileManager.SaveScore(Count, _gameplayContext.EmpireName);
        }

    }
}
