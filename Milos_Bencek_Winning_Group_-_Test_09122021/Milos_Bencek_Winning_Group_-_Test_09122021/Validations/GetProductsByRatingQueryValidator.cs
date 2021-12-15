using FluentValidation;
using Milos_Bencek_Winning_Group___Test_09122021.Products.Queries;

namespace Milos_Bencek_Winning_Group___Test_09122021.Validations
{
    public class GetProductsByRatingQueryValidator : AbstractValidator<GetProductsByRatingQuery>
    {
        public GetProductsByRatingQueryValidator()
        {

            RuleFor(x => x.count)
                .GreaterThan(0)
                .When(x => x.page > 0)
                .WithMessage("Incorrect page size!");

            RuleFor(x => x.page)
                .GreaterThan(0)
                .When(x => x.count > 0)
                .WithMessage("Incorrect page number!");

            RuleFor(x => x.MinRating)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Min rating should be greater or equal to 0!")
                .LessThanOrEqualTo(x => x.MaxRating)
                .WithMessage("Min rating should be less or equal to Max rating!");

            RuleFor(x => x.MaxRating)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Max rating should be greater or equal to 0!")
                .GreaterThanOrEqualTo(x => x.MinRating)
                .WithMessage("Max rating should be greater or equal to Min rating!");

        }
    }
}
