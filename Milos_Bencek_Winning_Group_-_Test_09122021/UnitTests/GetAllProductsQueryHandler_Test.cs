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
    class GetAllProductsQueryHandler_Test
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
        public void Handle_WhenCalled_WithGetAllProductsQuery_ReturnsIEnumerableOfProductOrderedById()
        {
            var query = new GetAllProductsQuery() { count = 5, page = 1};
            var handler = new Mock<IRequestHandler<GetAllProductsQuery, IEnumerable<Product>>>();
            var service = new Mock<IProductService>();
           
            service.Setup(s => s.GetAll(query.count, query.page, new CancellationToken()).Result).Returns(_sampleList);
            var serviceGetAllResult = service.Object.GetAll(query.count, query.page, new CancellationToken()).Result;

            handler.Setup(h => h.Handle(query, new CancellationToken()).Result).Returns(serviceGetAllResult);
            var handlerResult = handler.Object.Handle(query, new CancellationToken()).Result;

            Assert.That(handlerResult, Is.Not.Empty);
            Assert.That(handlerResult, Is.TypeOf(_sampleList.GetType()));
            Assert.AreEqual(handlerResult.FirstOrDefault(r => r.Id == 1).Name, "name");
            Assert.AreEqual(handlerResult.FirstOrDefault(r => r.Attribute.Fantastic.Value == true).Id, 1);
            Assert.AreEqual(handlerResult.FirstOrDefault(r => r.Attribute.Rating.Value == 2.7).Id, 1);
            Assert.That(handlerResult, Is.Ordered.By("Id"));
        }

    }
}
