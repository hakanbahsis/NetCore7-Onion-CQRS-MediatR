using Api.Application.Bases;
using Api.Application.Features.Products.Exceptions;

namespace Api.Application.Features.Products.Rules;
public class ProductRules:BaseRules
{
    public Task ProductTitleMustNotBeSame(IList<Product> products,string requestTitle)
    {
        if (products.Any(x=>x.Title==requestTitle)) throw new ProductTitleMustNotBeSameException();
        return Task.CompletedTask;
    }
}
