using System.ComponentModel.DataAnnotations;
using AutoMapper;
using Microsoft.Extensions.Logging;
using Entity;
using Business.Interfaces;
using Data.Interfaces;
using Entity.Model.Security;
using Abp.Domain.Entities;
using Entity.Dtos.InventoryDTO;


namespace Business.Implements
{
    /// <summary>
    /// Contiene la logica de negocio de los metodos especificos para la entidad Rol
    /// Extiende BaseBusiness heredando la logica de negocio de los metodos base 
    /// </summary>
    public class InventoryBusiness : BaseBusiness<Inventory, InventoryDto>, IInventoryBusiness
    {
        ///<summary>Proporciona acceso a los metodos de la capa de datos de roles</summary>
        private readonly IInventoryData _inventoryData;

        /// <summary>
        /// Constructor de la clase RolBusiness
        /// Inicializa una nueva instancia con las dependencias necesarias para operar con roles.
        /// </summary>
        public InventoryBusiness(IInventoryData inventoryData, IMapper mapper, ILogger<InventoryBusiness> logger)
      : base(inventoryData, mapper, logger)
        {
            _inventoryData = inventoryData;
        }


        ///<summary>
        /// Actualiza parcialmente un rol en la base de datos
        /// </summary>
        public async Task<bool> UpdatePartialInventoryAsync(UpdateInventoryDto dto)
        {
            if (dto.Id <= 0)
                throw new ArgumentException("ID inválido.");


            var rol = _mapper.Map<Inventory>(dto);

            var result = await _inventoryData.UpdatePartialAsync(rol); // esto ya retorna bool
            return result;
        }

        ///<summary>
        /// Desactiva un rol en la base de datos
        /// </summary>
        public async Task<bool> DeleteLogicInventoryAsync(DeleteLogicInventoryDto dto)
        {
            if (dto == null || dto.Id <= 0)
                throw new ValidationException("El ID del inventario es inválido");
            var exists = await _inventoryData.GetByIdAsync(dto.Id)
                ?? throw new EntityNotFoundException
                {
                    EntityType = typeof(Inventory),
                    Id = dto.Id
                };
            return await _inventoryData.ActiveAsync(dto.Id, dto.Status);
        }

    }
}