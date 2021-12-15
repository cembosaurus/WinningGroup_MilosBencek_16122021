using Milos_Bencek_Winning_Group___Test_09122021.Interfaces;

namespace Milos_Bencek_Winning_Group___Test_09122021.DAL
{
    public class TestDBDatabaseSettings : ITestDBDatabaseSettings
    {
        public string ConnectionString { get; set; } = null!;
        public string DatabaseName { get; set; } = null!;
        public string ProductsCollectionName { get; set; } = null!;
    }
}
