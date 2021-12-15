using Milos_Bencek_Winning_Group___Test_09122021.Interfaces;
using Milos_Bencek_Winning_Group___Test_09122021.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MongoDB.Driver.Linq;

namespace Milos_Bencek_Winning_Group___Test_09122021.Services
{
    public class ProductService : IProductService
    {

        private readonly IMongoCollection<Product> _products;


        public ProductService(ITestDBDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);

            var database = client.GetDatabase(settings.DatabaseName);

            _products = database.GetCollection<Product>(settings.ProductsCollectionName);
        }




        public async Task<IEnumerable<Product>> GetAll(int page, int count, CancellationToken cancellationToken = default)
        {
            var result = _products.AsQueryable();

            result = count > 0 ? result.Skip(--page * count).Take(count) : result;

            return await result.OrderBy(o => o.Id).ToListAsync(cancellationToken);
        }


        public async Task<IEnumerable<Product>> GetByPrice(int page, int count, double minPrice, double maxPrice, CancellationToken cancellationToken = default)
        {
            var result = _products.AsQueryable().Where(p => p.Price >= minPrice && p.Price <= maxPrice);

            result = count > 0 ? result.Skip(--page * count).Take(count) : result;

            return await result.OrderBy(o => o.Price).ToListAsync(cancellationToken);
        }


        public async Task<IEnumerable<Product>> GetByFantastic(int page, int count, bool fantastic, CancellationToken cancellationToken = default)
        {
            var result = _products.AsQueryable().Where(p => p.Attribute.Fantastic.Value == fantastic);

            result = count > 0 ? result.Skip(--page * count).Take(count) : result;

            return await result.OrderBy(o => o.Id).ToListAsync(cancellationToken);
        }



        public async Task<IEnumerable<Product>> GetByRating(int page, int count, double minRating, double maxRating, CancellationToken cancellationToken = default)
        {
            var result = _products.AsQueryable().Where(p => p.Attribute.Rating.Value >= minRating && p.Attribute.Rating.Value <= maxRating);

            result = count > 0 ? result.Skip(--page * count).Take(count) : result;

            return await result.OrderBy(o => o.Attribute.Rating.Value).ToListAsync(cancellationToken);
        }









        //................................................... Endpoints mplementation not in task requirements:

        public Product Get(string id) => _products.Find(p => p.id == id).FirstOrDefault();

        public Product Create(Product product)
        {
            _products.InsertOne(product);
            return product;
        }

        public void Update(string id, Product productIn) => _products.ReplaceOne(p => p.id == id, productIn);

        public void Remove(Product productIn) => _products.DeleteOne(p => p.id == productIn.id);

        public void Remove(string id) => _products.DeleteOne(p => p.id == id);
        //.....................................................................................................

    }
}
