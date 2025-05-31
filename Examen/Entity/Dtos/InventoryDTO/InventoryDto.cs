using Entity.Dtos.Base;
using Entity.Enum;


namespace Entity.Dtos.InventoryDTO
{
    /// <summary>
    /// DTO para mostrar información básica de un usuario (operación get all, create, update(patch-put))
    /// </summary>
    public class InventoryDto : GenericDTO
    {
        public string Location { get; set; }
        public int Amount { get; set; }
        public TypeMovement TypeMovement { get; set; }
    }
}
