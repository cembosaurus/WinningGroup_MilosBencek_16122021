using MediatR;
using Milos_Bencek_Winning_Group___Test_09122021.Interfaces;
using Milos_Bencek_Winning_Group___Test_09122021.Models;
using Milos_Bencek_Winning_Group___Test_09122021.Products.Queries;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Milos_Bencek_Winning_Group___Test_09122021.Products.Handlers
{
    public class GetProductsByPriceQueryHandler : IRequestHandler<GetProductsByPriceQuery, IEnumerable<Product>>
    {

        private readonly IProductService _productService;


        public GetProductsByPriceQueryHandler(IProductService productService)
        {
            _productService = productService;
        }



        public async Task<IEnumerable<Product>> Handle(GetProductsByPriceQuery request, CancellationToken cancellationToken)
        {
            var result = await _productService.GetByPrice(request.page, request.count, request.MinPrice, request.MaxPrice, cancellationToken);

            return result;
        }
    }
}
