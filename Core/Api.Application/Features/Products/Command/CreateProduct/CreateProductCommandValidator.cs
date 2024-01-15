namespace Api.Application.Features.Products.Command.CreateProduct;
public class CreateProductCommandValidator:AbstractValidator<CreateProductCommandRequest>
{
    public CreateProductCommandValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty()
            .NotNull()
            .WithName("Başlık");
        
        RuleFor(x => x.Description)
            .NotEmpty()
            .NotNull()
            .WithName("Açıklama");

        RuleFor(x => x.BrandId)
            .GreaterThan(0)
            .WithName("Marka");

        RuleFor(x => x.Price)
            .GreaterThan(0)
            .WithName("Fiyat");

        RuleFor(x => x.Discount)
            .GreaterThanOrEqualTo(0)
            .WithName("İndirim Oranı");

        RuleFor(x => x.CategoryIds)
            .NotEmpty()
            .NotNull()
            .Must(categories => categories.Any())
            .WithName("Kategoriler");
            
    }
}
