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

        Console.WriteLine($"Parsed {productions.Count} production rows");
    }
}