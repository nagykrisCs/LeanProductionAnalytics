using System.IO;
using LeanProductionAnalytics.Domain;

namespace LeanProductionAnalytics.Infrastructure
{
    class JigParser
    {
        private FileReader _reader;
        
        public JigParser(FileReader reader)
        {
            _reader = reader;
        }

        // Method to Parse opened Jig files and return it as objects
        public IEnumerable<Jig> JigParse(string filePath)
        {
            IEnumerable<string> jigData = _reader.ReadTextFile(filePath);

            foreach (var lines in jigData)
            {
                var cells = lines.Split(",");

                Jig jig = new Jig();

                jig.SetupId = cells[0].Trim();
                jig.JobId = cells[1].Trim();
                jig.MachineId = cells[2].Trim();
                jig.OperatorId = cells[3].Trim();
                jig.Step = cells[4].Trim();
                jig.Duration = int.Parse(cells[5].Trim());

                yield return jig;
            }
        }
    }
}
