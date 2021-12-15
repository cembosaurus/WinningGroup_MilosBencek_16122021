using MediatR;
using Milos_Bencek_Winning_Group___Test_09122021.Interfaces;
using Milos_Bencek_Winning_Group___Test_09122021.Models;
using Milos_Bencek_Winning_Group___Test_09122021.Products.Queries;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Milos_Bencek_Winning_Group___Test_09122021.Products.Handlers
{
    public class GetProductsByRatingQueryHandler : IRequestHandler<GetProductsByRatingQuery, IEnumerable<Product>>
    {

        private readonly IProductService _productService;


        public GetProductsByRatingQueryHandler(IProductService productService)
        {
            _productService = productService;
        }



        public async Task<IEnumerable<Product>> Handle(GetProductsByRatingQuery request, CancellationToken cancellationToken)
        {
            var result = await _productService.GetByRating(request.page, request.count, request.MinRating, request.MaxRating, cancellationToken);

            return result;
        }

    }
}
