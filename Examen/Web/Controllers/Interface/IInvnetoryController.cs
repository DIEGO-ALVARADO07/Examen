using Entity.Dtos.InventoryDTO;
using Entity.Model.Security;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Interface
{
    public interface IInventoryController : IGenericController<InventoryDto, Inventory>
    {
        Task<IActionResult> UpdatePartial(UpdateInventoryDto dto);
        Task<IActionResult> Active(int id);
       
    }
}