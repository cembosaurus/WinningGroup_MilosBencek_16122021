using MediatR;
using Milos_Bencek_Winning_Group___Test_09122021.Models;
using System.Collections.Generic;

namespace Milos_Bencek_Winning_Group___Test_09122021.Products.Queries
{
    public class GetProductsByFantasticQuery : IRequest<IEnumerable<Product>>
    {
        public int page { get; set; }
        public int count { get; set; }

        public bool Value { get; set; }
        public int Type { get; set; }
        public string Name { get; set; } = null!;
    }
}
