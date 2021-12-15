using MediatR;
using Milos_Bencek_Winning_Group___Test_09122021.Interfaces;
using Milos_Bencek_Winning_Group___Test_09122021.Models;
using Milos_Bencek_Winning_Group___Test_09122021.Products.Queries;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Milos_Bencek_Winning_Group___Test_09122021.Products.Handlers
{
    public class GetProductsByFantasticQueryHandler : IRequestHandler<GetProductsByFantasticQuery, IEnumerable<Product>>
    {

        private readonly IProductService _productService;


        public GetProductsByFantasticQueryHandler(IProductService productService)
        {
            _productService = productService;
        }



        public async Task<IEnumerable<Product>> Handle(GetProductsByFantasticQuery request, CancellationToken cancellationToken)
        {
            var result = await _productService.GetByFantastic(request.page, request.count, request.Value, cancellationToken);

            return result;
        }
    }
}
