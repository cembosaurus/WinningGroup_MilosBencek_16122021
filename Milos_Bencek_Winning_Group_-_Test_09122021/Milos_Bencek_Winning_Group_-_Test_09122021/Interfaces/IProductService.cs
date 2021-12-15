using Milos_Bencek_Winning_Group___Test_09122021.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Milos_Bencek_Winning_Group___Test_09122021.Interfaces
{
    public interface IProductService
    {
        Product Create(Product product);
        Task<IEnumerable<Product>> GetAll(int page, int count, CancellationToken cancellationToken);
        Task<IEnumerable<Product>> GetByPrice(int page, int count, double minPrice, double maxPrice, CancellationToken cancellationToken);
        Task<IEnumerable<Product>> GetByFantastic(int page, int count, bool fantastic, CancellationToken cancellationToken);
        Task<IEnumerable<Product>> GetByRating(int page, int count, double minRating, double maxRating, CancellationToken cancellationToken);
        Product Get(string id);
        void Remove(Product productIn);
        void Remove(string id);
        void Update(string id, Product productIn);
    }
}