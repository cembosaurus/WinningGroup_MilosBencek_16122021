namespace Milos_Bencek_Winning_Group___Test_09122021.Interfaces
{
    public interface ITestDBDatabaseSettings
    {
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
        string ProductsCollectionName { get; set; }
    }
}