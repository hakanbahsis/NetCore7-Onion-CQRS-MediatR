namespace Api.Application.Features.Products.Command.DeleteProduct;
public class DeleteProductCommandRequest:IRequest
{
    public int Id { get; set; }
}
