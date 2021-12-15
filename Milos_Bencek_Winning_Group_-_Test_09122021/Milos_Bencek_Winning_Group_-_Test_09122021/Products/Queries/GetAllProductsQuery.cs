using MediatR;
using Milos_Bencek_Winning_Group___Test_09122021.Models;
using System.Collections.Generic;

namespace Milos_Bencek_Winning_Group___Test_09122021.Products.Queries
{
    public class GetAllProductsQuery : IRequest<IEnumerable<Product>>
    {
        public int page { get; set; }
        public int count { get; set; }
    }
}
