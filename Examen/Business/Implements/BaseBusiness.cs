using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Business.Interfaces;
using Microsoft.Extensions.Logging;
using Data.Interfaces;
using FluentValidation.Results;
using Entity.Dtos.Base;
using Entity.Model.Base;
using Entity.Model.Security;

namespace Business.Implements
{
    /// <summary>
    /// Clase base que implementa la lógica de negocio común para operaciones CRUD genéricas.
    /// Proporciona implementaciones estándar para crear, leer, actualizar y eliminar entidades,
    /// incluyendo validación, mapeo automático entre DTOs y entidades, y logging.
    /// </summary>
    /// <typeparam name="TDto">Tipo del objeto de transferencia de datos (DTO) utilizado para comunicación con capas superiores</typeparam>
    /// <typeparam name="TEntity">Tipo de la entidad de dominio que representa el modelo de datos</typeparam>
    /// <remarks>
    /// Esta clase hereda de ABaseBusiness y extiende su funcionalidad añadiendo:
    /// - Mapeo automático entre DTOs y entidades usando AutoMapper
    /// - Validación de DTOs usando FluentValidation
    /// - Logging detallado de todas las operaciones
    /// - Manejo consistente de errores
    /// </remarks>
    public class BaseBusiness<T, D> : ABaseBusiness<T, D> where T : BaseEntity where D : BaseDto
    {
        protected readonly IMapper _mapper;
        protected readonly IBaseModelData<T> _data;
        protected readonly ILogger _logger;

        public BaseBusiness(
            IBaseModelData<T> data,
            IMapper mapper,
            ILogger logger)
            : base()
        {
            _data = data;
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger;
        }

        public override async Task<List<D>> GetAllAsync()
        {
            try
            {
                var entities = await _data.GetAllAsync();
                _logger.LogInformation($"Obteniendo todos los registros de {typeof(T).Name}");
                return _mapper.Map<IList<D>>(entities).ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al obtener registros de {typeof(T).Name}: {ex.Message}");
                throw;
            }
        }

        public override async Task<D> GetByIdAsync(int id)
        {
            try
            {
                var entities = await _data.GetByIdAsync(id);
                _logger.LogInformation($"Obteniendo {typeof(T).Name} con ID: {id}");
                return _mapper.Map<D>(entities);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al obtener {typeof(T).Name} con ID {id}: {ex.Message}");
                throw;
            }
        }

        public override async Task<D> CreateAsync(D dto)
        {
            try
            {
                var entity = _mapper.Map<T>(dto);
                entity = await _data.CreateAsync(entity);
                _logger.LogInformation($"Creando nuevo {typeof(T).Name}");
                return _mapper.Map<D>(entity);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al crear {typeof(T).Name} desde DTO: {ex.Message}");
                throw;
            }
        }

        public override async Task<D> UpdateAsync(D dto)
        {
            try
            {
                var entity = _mapper.Map<T>(dto);
                entity = await _data.UpdateAsync(entity);
                _logger.LogInformation($"Actualizando {typeof(T).Name} desde DTO");
                return _mapper.Map<D>(entity);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al actualizar {typeof(T).Name} desde DTO: {ex.Message}");
                throw;
            }
        }

        public override async Task<bool> DeleteAsync(int id)
        {
            try
            {
                _logger.LogInformation($"Eliminando {typeof(T).Name} con ID: {id}");
                return await _data.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al eliminar {typeof(T).Name} con ID {id}: {ex.Message}");
                throw;
            }
        }
    }
}
