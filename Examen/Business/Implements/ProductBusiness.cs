using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Text;
using AutoMapper;
using Business.Interfaces;
using Data.Interfaces;
using Entity.Dtos.InventoryDTO;
using Entity.Model.Security;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Abp.Domain.Entities;
using Entity.Dtos.ProductDTO;

namespace Business.Implements
{
    /// <summary>
    /// Contiene la logica de negocio de los metodos especificos para la entidad Rol
    /// Extiende BaseBusiness heredando la logica de negocio de los metodos base 
    /// </summary>
    public class ProductBusiness : BaseBusiness<Product, ProductDto>, IProductBusiness
    {
        private readonly IProductData _productData;

        public ProductBusiness(IProductData productData, IMapper mapper, ILogger<ProductBusiness> logger)
            : base(productData, mapper, logger)
        {
            _productData = productData;
        }

        /// <summary>
        /// Actualiza parcialmente los datos de un usuario.
        /// </summary>
        /// <param name="dto">Objeto UpdateUserDto con los datos a modificar.</param>
        /// <returns> True si la actualización fue exitosa; de lo contrario, false.</returns>
        /// <exception cref="ArgumentException"> Se lanza si el ID del usuario es inválido.</exception>
        public async Task<bool> UpdateParcialAsync(UpdateProductDto dto)
        {
            if (dto.Id <= 0)
                throw new ArgumentException("ID inválido.");

            var user = _mapper.Map<Product>(dto);

            var result = await _productData.UpdatePartial(user); // esto ya retorna bool
            return result;
        }

        /// <summary>
        /// Activa o desactiva un usuario de forma lógica según su ID.
        /// </summary>
        /// <param name="dto">Objeto DeleteLogicalUserDto" con el ID y estado deseado.</param>
        /// <returns>True si se actualizó el estado correctamente; de lo contrario, false.</returns>
        /// <exception cref="ValidationException">Si el ID es inválido.</exception>
        /// <exception cref="EntityNotFoundException">Si el usuario no existe.</exception>
        public async Task<bool> ActiveAsync(DeleteLogicProductDto dto)
        {
            if (dto == null || dto.Id <= 0)
                throw new ValidationException(new ValidationResult("El ID del usuario es inválido"), null, null);

            var exists = await _productData.GetByIdAsync(dto.Id)
                ?? throw new EntityNotFoundException(typeof(Product), dto.Id); 

            return await _productData.ActiveAsync(dto.Id, dto.Status);
        }
    }

}