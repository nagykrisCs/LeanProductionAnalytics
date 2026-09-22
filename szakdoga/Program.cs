using LeanProductionAnalytics.Domain;
using LeanProductionAnalytics.Infrastructure;
using LeanProductionAnalytics.Infrastructure.Persistance;
using LeanProductionAnalytics.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;



class Program
{
    [STAThread]
    static void Main(string[] args)
    {
        // INIT CLASSES

        // File Manager
        FileInteractionManager fileHandler = new FileInteractionManager();
        // Parser
        ProductionParser parser = new ProductionParser(fileHandler);

        // DbContext +
        AppDbContextFactory dbContextSettings = new AppDbContextFactory();
        // + its settings
        AppDbContext dbContext = dbContextSettings.CreateDbContext(args);
        // Database communicator
        ProductionRepository productionRepository = new ProductionRepository(dbContext);

        // ---------------------------------------------------------------------------------

        // Get the file path from the user
        string filePath = fileHandler.GetFile();

        // Parse the file into objects
        var productions = parser.ProductionParse(filePath);

        // Write file into DB
        productionRepository.InsertProductionTable(productions);

        // Read table
        productionRepository.ReadProductionTable();

        // ASAP TODO: Create repository for new data model.  Check commented section in FileInteractionManager

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