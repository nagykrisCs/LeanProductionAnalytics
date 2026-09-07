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

        public List<Production> ProductionParse(string filePath)
        {
            string data = _reader.ReadFile(filePath);

            List<Production> productions = new List<Production>();

            string[] lines = data.Split(
                Environment.NewLine,
                StringSplitOptions.RemoveEmptyEntries
            );

            for (int i = 0; i < lines.Length; i++)
            {
                string[] cells = lines[i].Split(',');

                Production production = new Production();

                production.JobId = cells[0].Trim();
                production.ProductName = cells[1].Trim();
                production.Operation = cells[2].Trim();
                production.MachineId = cells[3].Trim();
                production.OperatorId = cells[4].Trim();
                production.Shift = cells[5].Trim();

                production.StartTime = DateTime.Parse(cells[6].Trim());
                production.EndTime = DateTime.Parse(cells[7].Trim());

                production.ProcessingTime = int.Parse(cells[8].Trim());
                production.QueueTime = int.Parse(cells[9].Trim());
                production.RejectQuantity = int.Parse(cells[10].Trim());

                production.JigExchangeRequired = bool.Parse(cells[11].Trim());

                production.SetupTime = int.Parse(cells[12].Trim());

                productions.Add(production);
            }

            return productions;
        }
    }
}