using Microsoft.AspNetCore.Mvc;
using Entity.Model.Security;
using Entity.Dtos.ProductDTO;

namespace Web.Controllers.Interface
{
    public interface IProductController : IGenericController<ProductDto, Product>
    {
        Task<IActionResult> UpdatePartial (UpdateProductDto dto);
        Task<IActionResult> Active(int id);

    }
}