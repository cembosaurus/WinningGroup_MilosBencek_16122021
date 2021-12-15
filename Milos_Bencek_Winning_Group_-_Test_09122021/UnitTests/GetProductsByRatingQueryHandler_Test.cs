using MediatR;
using Milos_Bencek_Winning_Group___Test_09122021.Interfaces;
using Milos_Bencek_Winning_Group___Test_09122021.Models;
using Milos_Bencek_Winning_Group___Test_09122021.Products.Queries;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace UnitTests
{
    class GetProductsByRatingQueryHandler_Test
    {

        private IEnumerable<Product> _sampleList;

        [SetUp]
        public void Setup()
        {
            _sampleList = new List<Product>(){
                new Product() {
                id = "",
                Id = 1,
                SKU = "sku",
                Name = "name",
                Price = 1.23,
                Attribute = new ProductAttribute() {
                    Fantastic = new Fantastic() { Value = true, Type = 1, Name = "fantastic"},
                    Rating = new Rating() { Name = "rating", Type = 2, Value = 2.7 }
                    }
                }
            };


        }


        [Test]
        public void Handle_WhenCalled_WithGetProductsByRatingQuery_ReturnsIEnumerableOfProductOrderedById()
        {
            var query = new GetProductsByRatingQuery() { count = 5, page = 1, MinRating = 2, MaxRating = 3 };
            var handler = new Mock<IRequestHandler<GetProductsByRatingQuery, IEnumerable<Product>>>();
            var service = new Mock<IProductService>();

            service.Setup(s => s.GetByRating(query.count, query.page, query.MinRating, query.MaxRating, new CancellationToken()).Result).Returns(_sampleList);
            var serviceGetByRatingResult = service.Object.GetByRating(query.count, query.page, query.MinRating, query.MaxRating, new CancellationToken()).Result;

            handler.Setup(h => h.Handle(query, new CancellationToken()).Result).Returns(serviceGetByRatingResult);
            var handlerResult = handler.Object.Handle(query, new CancellationToken()).Result;

            Assert.That(handlerResult, Is.Not.Empty);
            Assert.That(handlerResult, Is.TypeOf(_sampleList.GetType()));
            Assert.GreaterOrEqual(handlerResult.Min(h => h.Attribute.Rating.Value), query.MinRating);
            Assert.LessOrEqual(handlerResult.Max(h => h.Attribute.Rating.Value), query.MaxRating);
            Assert.AreEqual(handlerResult.FirstOrDefault(r => r.Id == 1).Name, "name");
            Assert.AreEqual(handlerResult.FirstOrDefault(r => r.Attribute.Fantastic.Value == true).Id, 1);
            Assert.AreEqual(handlerResult.FirstOrDefault(r => r.Attribute.Rating.Value == 2.7).Id, 1);
            Assert.That(handlerResult, Is.Ordered.By("Id"));
        }


    }
}
