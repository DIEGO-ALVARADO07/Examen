using Business.Interfaces;
using Entity.Dtos.InventoryDTO;
using Entity.Model.Security;

namespace Business.Interfaces
{
    ///<summary>
    /// Define los métodos de negocio especifícos para la gestión de roles.
    /// Hereda operaciones CRUD genéricas de <see cref="IBaseBusiness{Rol, RolDto}"/>.
    //</summary>
    public interface IInventoryBusiness : IBaseBusiness<Inventory, InventoryDto>
    {

        /// <summary>
        /// Actualiza parcialmente los datos de un rol.
        /// </summary>
        /// <param name="dto">Objeto que contiene los datos actualizados del rol, como nombre o estado.</param>
        ///<returns>True si la actualización fue exitosa; de lo contario false</returns>
        Task<bool> UpdatePartialInventoryAsync(UpdateInventoryDto dto);

        /// <summary>
        /// Realiza un borrado lógico del rol, marcándolo como inactivo en lugar de eliminarlo físicamente.
        /// </summary>
        /// <param name="id">ID del rol a desactivar.</param>
        ///<returns>True si el borrado lógico fue exitoso; de lo contario false</returns>
        Task<bool> DeleteLogicInventoryAsync(DeleteLogicInventoryDto dto);
    }
}