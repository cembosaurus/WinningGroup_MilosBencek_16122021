using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Milos_Bencek_Winning_Group___Test_09122021.Models;
using Milos_Bencek_Winning_Group___Test_09122021.Products.Queries;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Milos_Bencek_Winning_Group___Test_09122021.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }



        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Product>), StatusCodes.Status200OK)]
        public async Task<ActionResult> GetAll([FromQuery] GetAllProductsQuery query, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(query);

            return Ok(result);
        }


        [Route("Price")]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Product>), StatusCodes.Status200OK)]
        public async Task<ActionResult> GetByPrice([FromQuery] GetProductsByPriceQuery query, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(query);

            return Ok(result);
        }



        [Route("Fantastic")]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Product>), StatusCodes.Status200OK)]
        public async Task<ActionResult> GetByFantastic([FromQuery] GetProductsByFantasticQuery query, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(query);

            return Ok(result);
        }



        [Route("Rating")]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Product>), StatusCodes.Status200OK)]
        public async Task<ActionResult> GetByRating([FromQuery] GetProductsByRatingQuery query, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(query);

            return Ok(result);
        }

    }
}
