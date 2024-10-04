using System.IO;
using System.Xml.Linq;

namespace EmpireSimulator.Data {
    public class FileManager {
        static readonly public string dataPath = ".\\data";
        static readonly public string scoreFile = "score.txt";
        static readonly public string scorePath = Path.Combine(dataPath, scoreFile);

        public static XDocument GetScoresFile() {
            CheckDirectory(dataPath);
            return LoadXmlFile(scorePath, "scores");
        }

        public static XDocument LoadXmlFile(string path, string root) {
            XDocument document;
            CheckFile(path);
            try {
                document = XDocument.Load(path);
            } catch (System.Xml.XmlException ex) {
                document = new XDocument(new XElement(root));
            }
            return document;
        }

        public static void CheckDirectory(string name) {
            if (!Directory.Exists(name)) {
                Directory.CreateDirectory(name);
            }
        }

        public static void CheckFile(string name) {
            if (!File.Exists(name)) {
                using (var stream = File.Create(name)) { }
            }
        }
    }
}
