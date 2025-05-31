using Business.Interfaces;
using Entity.Dtos.ProductDTO;
using Entity.Model.Security;

namespace Business.Interfaces
{
    ///<summary>
    /// Define los métodos de negocio específicos para la gestíon de usuarios.
    ///Hereda operaciones CRUD genéricas de <see cref="IBaseBusiness{User, UserDto}"/>.
    ///</summary>
    public interface IProductBusiness : IBaseBusiness<Product, ProductDto>
    {
        Task<bool> UpdateParcialAsync(UpdateProductDto dto);
        Task<bool> ActiveAsync(DeleteLogicProductDto dto);

    }
}
    