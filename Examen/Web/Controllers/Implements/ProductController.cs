using Microsoft.AspNetCore.Mvc;
using Web.Controllers.Interface;
using Business.Interfaces;
using Entity.Model.Security;
using Entity.Dtos.InventoryDTO;
using Entity.Dtos.ProductDTO;

namespace Web.Controllers.Implements
{
    [Route("api/[controller]")]
    public class ProductController : GenericController<ProductDto, Product>, IProductController
    {
        private readonly IProductBusiness _productBusiness;

        public ProductController(IProductBusiness productBusiness, ILogger<ProductController> logger)
            : base(productBusiness, logger)
        {
            _productBusiness = productBusiness;
        }

        protected override int GetEntityId(ProductDto dto)
        {
            return dto.Id;
        }

        [HttpPatch]
        public async Task<IActionResult> UpdatePartial(UpdateProductDto dto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var result = await _productBusiness.UpdateParcialAsync(dto);
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

        [HttpDelete("logic/{id}")]
        public async Task<IActionResult> Active(int id)
        {
            try
            {
                var deleteDto = new DeleteLogicProductDto { Id = id, Status = false };
                var result = await _productBusiness.ActiveAsync(deleteDto); // Fix: Added the missing 'id' argument
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