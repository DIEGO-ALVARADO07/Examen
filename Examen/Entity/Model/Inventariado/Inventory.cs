using Entity.Enum;
using Entity.Model.Generic;

namespace Entity.Model.Security
{
    public class Inventory : GenericEntity
    {
        public int Id { get; set; }
        public string Location { get; set; }
        public int Amount { get; set; }     
        public TypeMovement TypeMovement { get; set; }
        public ICollection<Product> Products { get; set; }

    }
}
