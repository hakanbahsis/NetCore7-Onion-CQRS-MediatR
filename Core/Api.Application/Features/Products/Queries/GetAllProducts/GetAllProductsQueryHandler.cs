using Microsoft.EntityFrameworkCore;

namespace Api.Application.Features.Products.Queries.GetAllProducts;
public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQueryRequest, IList<GetAllProductsQueryResponse>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetAllProductsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IList<GetAllProductsQueryResponse>> Handle(GetAllProductsQueryRequest request, CancellationToken cancellationToken)
    {
        var products = await _unitOfWork.GetReadRepository<Product>().GetAllAsync(include:x=>x.Include(b=>b.Brand));
        _mapper.Map<BrandDto,Brand>(new Brand());

        //List<GetAllProductsQueryResponse> response = new();
        //foreach (var product in products)
        //{
        //   response.Add( new GetAllProductsQueryResponse
        //    {
        //        Title = product.Title,
        //        Description = product.Description,
        //        Discount = product.Discount,
        //        Price = product.Price-(product.Price*product.Discount/100),
        //    });
        //}

        var map = _mapper.Map<GetAllProductsQueryResponse, Product>(products);
        foreach (var item in map)
            item.Price -= (item.Price * item.Discount / 100);

       return map;
       
    }
}
