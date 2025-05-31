using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Entity.Dtos.Base;

namespace Entity.Dtos.InventoryDTO
{
    /// <summary>
    /// DTO para mostrar información básica de un usuario (operación get all, create, update(patch-put))
    /// </summary>
    public class UpdateInventoryDto : BaseDto
    {
        public string Location { get; set; }
        public int Amount { get; set; }
    }
}
