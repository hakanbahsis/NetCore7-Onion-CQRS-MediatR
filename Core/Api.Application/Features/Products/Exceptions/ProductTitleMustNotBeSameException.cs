using Api.Application.Bases;

namespace Api.Application.Features.Products.Exceptions;
public class ProductTitleMustNotBeSameException:BaseExceptions
{
    public ProductTitleMustNotBeSameException():base("Ürün Başlığı Zaten Mevcut")
    {
        
    }
}
