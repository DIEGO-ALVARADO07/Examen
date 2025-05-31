using Entity.Model.Generic;

namespace Entity.Model.Security
{
    public class Product : GenericEntity
    {
     public int Price { get; set; }
     public int IdInventario { get; set; } 
     public Inventory Inventory { get; set; } 

    }
}
