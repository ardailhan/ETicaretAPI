using ETicaretAPI.Application.ViewModels.Products;
using FluentValidation;

namespace ETicaretAPI.Application.Validators.Products
{
    public class CreateProductValidator: AbstractValidator<VM_Create_Product>
    {
        public CreateProductValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty()
                .NotNull()
                   .WithMessage("Please enter a product name.")
                .MaximumLength(150)
                .MinimumLength(2)
                    .WithMessage("Please enter a product name with minimum 2 charachers and maximum 150 charachers.");
            RuleFor(p => p.Stock)
                .NotEmpty()
                .NotNull()
                    .WithMessage("Please enter a stock information.")
                .Must(s => s >= 0)
                    .WithMessage("Stock quantity should not be less then 0.");
            RuleFor(p => p.Price)
                .NotEmpty()
                .NotNull()
                    .WithMessage("Please enter a price information.")
                .Must(s => s >= 0)
                    .WithMessage("Price quantity should not be less then 0.");
        }
    }
}
