using EmpireSimulator.Data;
using EmpireSimulator.Models.Buildings;
using System.Xml.Linq;

namespace EmpireSimulator.Models {
    public class ScoreCounter {
        GameplayContext _gameplayContext;
        static private int scoresCount = 10;
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
            XDocument document = FileManager.GetScoresFile();
            var elements = document.Root.Elements();
            var element = new XElement("score-info",
                    new XElement("score", Count),
                    new XElement("empire-name", _gameplayContext.EmpireName));
            bool isPlaced = false;
            foreach (var entry in elements) {
                if (int.Parse(entry.Element("score").Value) <= Count) {
                    entry.AddBeforeSelf(element);
                    isPlaced = true;
                    break;
                }
            }
            if (!isPlaced) {
                elements.Last().AddAfterSelf(element);
            }
            if (elements.Count() > scoresCount) {
                elements.Last().Remove();
            }
            document.Save(FileManager.scorePath);
        }

    }
}
