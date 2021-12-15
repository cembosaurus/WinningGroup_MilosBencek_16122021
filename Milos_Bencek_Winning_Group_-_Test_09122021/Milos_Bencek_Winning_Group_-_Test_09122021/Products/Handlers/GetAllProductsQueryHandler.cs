using MediatR;
using Milos_Bencek_Winning_Group___Test_09122021.Interfaces;
using Milos_Bencek_Winning_Group___Test_09122021.Models;
using Milos_Bencek_Winning_Group___Test_09122021.Products.Queries;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Milos_Bencek_Winning_Group___Test_09122021.Products.Handlers
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, IEnumerable<Product>>
    {

        private readonly IProductService _productService;


        public GetAllProductsQueryHandler(IProductService productService)
        {
            _productService = productService;
        }


        public async Task<IEnumerable<Product>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var result = await _productService.GetAll(request.page, request.count, cancellationToken);

            return result;
        }
    }
}
