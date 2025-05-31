using Business.Interfaces;
using Entity.Dtos.ProductDTO;
using Entity.Model.Security;

namespace Business.Interfaces
{
    ///<summary>
    /// Define los m�todos de negocio espec�ficos para la gest�on de usuarios.
    ///Hereda operaciones CRUD gen�ricas de <see cref="IBaseBusiness{User, UserDto}"/>.
    ///</summary>
    public interface IProductBusiness : IBaseBusiness<Product, ProductDto>
    {
        Task<bool> UpdateParcialAsync(UpdateProductDto dto);
        Task<bool> ActiveAsync(DeleteLogicProductDto dto);

    }
}
    