using FluentValidation;
using Milos_Bencek_Winning_Group___Test_09122021.Products.Queries;

namespace Milos_Bencek_Winning_Group___Test_09122021.Validations
{
    public class GetProductsByPriceQueryValidator : AbstractValidator<GetProductsByPriceQuery>
    {
        public GetProductsByPriceQueryValidator()
        {

            RuleFor(x => x.count)
                .GreaterThan(0)
                .When(x => x.page > 0)
                .WithMessage("Incorrect page size!");

            RuleFor(x => x.page)
                .GreaterThan(0)
                .When(x => x.count > 0)
                .WithMessage("Incorrect page number!");

            RuleFor(x => x.MinPrice)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Min price should be greater or equal to 0!")
                .LessThanOrEqualTo(x => x.MaxPrice)
                .WithMessage("Min price should be less or equal to Max price!");

            RuleFor(x => x.MaxPrice)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Max price should be greater or equal to 0!")
                .GreaterThanOrEqualTo(x => x.MinPrice)
                .WithMessage("Max price should be greater or equal to Min price!");

        }
    }
}
