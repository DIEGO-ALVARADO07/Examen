using Entity.Model.Base;
using Entity.Model.Security;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Dapper.SqlMapper;

namespace Data.Interfaces

{
    /// <summary>
    /// Interfaz que me define los métodos generales
    /// </summary>
    /// <typeparam name="T"></typeparam>

    public interface IBaseModelData<T> where T : BaseEntity
    {
        Task<T> GetByIdAsync(int id);
        Task<List<T>> GetAllAsync();
        Task<T> CreateAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<bool> DeleteAsync(int id);
    }
}
