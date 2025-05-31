using AutoMapper;
using Entity.Dtos.InventoryDTO;
using Entity.Dtos.ProductDTO;
using Entity.Model.Security;

public class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<Product, ProductDto>();
        CreateMap<ProductDto, Product>();
    }
}
