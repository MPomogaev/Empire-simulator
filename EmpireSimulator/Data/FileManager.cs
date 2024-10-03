using System.IO;
using System.Xml.Linq;

namespace EmpireSimulator.Data {
    public class FileManager {
        static private string dataPath = ".\\data";

        public static void SaveScore(int score, string empireName) {
            XDocument document = new XDocument(
                new XElement("score-info",
                    new XElement("score", score),
                    new XElement("empire-name", empireName))
                );
            LoadXmlDockToFile(dataPath, "score.txt", document);
        }

        private static void LoadXmlDockToFile(string directoryName, string fileName, XDocument document) {
            string path = Path.Combine(directoryName, fileName);
            CheckDirectory(directoryName);
            document.Save(path);
        }

        private static void CheckDirectory(string name) {
            if (!Directory.Exists(name)) {
                Directory.CreateDirectory(name);
            }
        }
    }
}
