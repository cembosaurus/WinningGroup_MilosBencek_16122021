using FluentValidation;
using Milos_Bencek_Winning_Group___Test_09122021.Products.Queries;

namespace Milos_Bencek_Winning_Group___Test_09122021.Validations
{
    public class GetProductsByFantasticQueryValidator : AbstractValidator<GetProductsByFantasticQuery>
    {
        public GetProductsByFantasticQueryValidator()
        {

            RuleFor(x => x.count)
                .GreaterThan(0)
                .When(x => x.page > 0)
                .WithMessage("Incorrect page size!");

            RuleFor(x => x.page)
                .GreaterThan(0)
                .When(x => x.count > 0)
                .WithMessage("Incorrect page number!");

            RuleFor(x => x.Value)
                .NotEmpty()
                .WithMessage("Fantastic value must be present in query!");

        }
    }
}
