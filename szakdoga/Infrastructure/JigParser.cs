using System.IO;
using LeanProductionAnalytics.Domain;

namespace LeanProductionAnalytics.Infrastructure
{
    class JigParser
    {
        private FileInteractionManager _fileInteractionManager;
        
        public JigParser(FileInteractionManager fileInteractionManager)
        {
            _fileInteractionManager = fileInteractionManager;
        }

        // Method to Parse opened Jig file into objects
        //public IEnumerable<JigStep> JigParse(string filePath)
        //{
        //    IEnumerable<string> jigData = _fileInteractionManager.ReadTextFile(filePath);

        //    foreach (var lines in jigData)
        //    {
        //        var cells = lines.Split(",");

        //        JigStep jig = new JigStep();

        //        jig.SetupId = cells[0].Trim();
        //        jig.JobId = cells[1].Trim();
        //        jig.MachineId = cells[2].Trim();
        //        jig.OperatorId = cells[3].Trim();
        //        jig.Step = cells[4].Trim();
        //        jig.Duration = int.Parse(cells[5].Trim());

        //        yield return jig;
        //    }
        //}
    }
}
