using LeanProductionAnalytics.Infrastructure;
using LeanProductionAnalytics.Infrastructure.Persistance;
using LeanProductionAnalytics.Infrastructure.Persistence.Repositories;



class Program
{
    [STAThread]
    static void Main(string[] args)
    {
        // Get the file path from the user
        FileHandler fileHandler = new FileHandler();

        string filePath = fileHandler.GetFile();

        // TODO: Handle in method instead of main.
        if (filePath == null)
        {
            Console.WriteLine("No file selected.");
            return;
        }

        // Read the file given by the user
        FileReader reader = new FileReader();

        // Parse the file into objects
        ProductionParser parser = new ProductionParser(reader);
        var productions = parser.ProductionParse(filePath);

        // Initialize DbContext and its settings
        AppDbContextFactory dbContextSettings = new AppDbContextFactory();
        AppDbContext dbContext = dbContextSettings.CreateDbContext(args);

        // Initialize the Database communicator
        ProductionRepository productionRepository = new ProductionRepository(dbContext);

        // Write read file into DB
        foreach (var production in productions)
        {
            productionRepository.InsertProductionRow(production);
        }

        // Read table
        productionRepository.ReadProdTable();



        /*
         * TODO:
         * Clear up main. Create classes for that.
         * 
         * Data handling:
         * - Create a new class for reading/writing data + saving changes.
         * Create DOCKER local server for the DB
         * 
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