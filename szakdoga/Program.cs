using szakdoga.Infrastructure;

class Program
{
    [STAThread]
    static void Main(string[] args)
    {
        FileHandler fileHandler = new FileHandler();

        string? filePath = fileHandler.GetFile();

        if (filePath == null)
        {
            Console.WriteLine("No file selected.");
            return;
        }

        FileReader reader = new FileReader();

        ProductionParser parser = new ProductionParser(reader);

        var productions = parser.ProductionParse(filePath);

        foreach (var production in productions)
        {
            Console.WriteLine($"{production.EndTime}");
        }





        /*
         * TODO: 
         * - Data reading:
         * Add JIG data reading
         * Add excel reading
         * 
         * 
         * Implement database from a CSV/excel (for statistical calculation speed. we dont want to query a whole CSV or Excel file especially with big data sets)
         * With that, create infrastructure layer.
         * 
         * 
         * - Start adding interfaces
         * 
         * 
         * 
         * 
         * - UI:
         * Create basic UI for starters; With that, create application layer
         * 
         * 
         * 
         */
    }
}