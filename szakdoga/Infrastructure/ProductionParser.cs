using szakdoga.Domain;

namespace szakdoga.Infrastructure
{
    public class ProductionParser
    {
        private FileReader _reader;

        public ProductionParser(FileReader reader)
        {
            _reader = reader;
        }

        // Method to Parse opened Production files into objects
        public IEnumerable<Production> ProductionParse(string filePath)
        {
            IEnumerable<string> productionData = _reader.ReadFile(filePath);

            foreach (var lines in productionData)
            {
                var cells = lines.Split(",");

                Production production = new Production();

                production.JobId = cells[0].Trim();
                production.ProductName = cells[1].Trim();
                production.Operation = cells[2].Trim();
                production.MachineId = cells[3].Trim();
                production.OperatorId = cells[4].Trim();
                production.Shift = cells[5].Trim();

                production.StartTime = DateTime.ParseExact(cells[6].Trim(), "yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);

                production.EndTime = DateTime.ParseExact(cells[7].Trim(), "yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);

                production.ProcessingTime = int.Parse(cells[8].Trim());
                production.QueueTime = int.Parse(cells[9].Trim());
                production.RejectQuantity = int.Parse(cells[10].Trim());

                production.JigExchangeRequired = bool.Parse(cells[11].Trim());

                production.SetupTime = int.Parse(cells[12].Trim());

                yield return production;
            }
        }
    }
}