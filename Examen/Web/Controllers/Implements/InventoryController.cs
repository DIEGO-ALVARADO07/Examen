using Microsoft.AspNetCore.Mvc;
using Web.Controllers.Interface;
using Business.Interfaces;
using Entity.Model.Security;
using Entity.Dtos.InventoryDTO;

namespace Web.Controllers.Implements
{
    [Route("api/[controller]")]
    public class InventoryController : GenericController<InventoryDto, Inventory>, IInventoryController
    {
        private readonly IInventoryBusiness _inventoryBusiness;

        public InventoryController(IInventoryBusiness inventoryBusiness, ILogger<InventoryController> logger)
            : base(inventoryBusiness, logger)
        {
            _inventoryBusiness = inventoryBusiness;
        }

        protected override int GetEntityId(InventoryDto dto)
        {
            return dto.Id;
        }

        [HttpPatch]
        public async Task<IActionResult> UpdatePartial(UpdateInventoryDto dto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var result = await _inventoryBusiness.UpdatePartialInventoryAsync(dto);
                return Ok(new { Success = result });
            }
            catch (ArgumentException ex)
            {
                _logger.LogError($"Error de validación al actualizar parcialmente inventario: {ex.Message}");
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al actualizar parcialmente inventario: {ex.Message}");
                return StatusCode(500, "Error interno del servidor");
            }
        }

        [HttpDelete("active/{id}")]
        public async Task<IActionResult> Active(int id)  // ✅ Coincide perfectamente con la interfaz
        {
            try
            {
                var deleteDto = new DeleteLogicInventoryDto
                {
                    Id = id,
                    Status = false
                };
                var result = await _inventoryBusiness.DeleteLogicInventoryAsync(deleteDto);
                if (!result)
                    return NotFound($"Inventario con ID {id} no encontrado");
                return Ok(new { Success = true });
            }
            catch (ArgumentException ex)
            {
                _logger.LogError($"Error de validación al eliminar lógicamente inventario: {ex.Message}");
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al eliminar lógicamente inventario con ID {id}: {ex.Message}");
                return StatusCode(500, "Error interno del servidor");
            }
        }
    }
}