using AutoMapper;
using Entity.Dtos.InventoryDTO;
using Entity.Model.Security;

public class InventoryProfile : Profile
{
    public InventoryProfile()
    {
        CreateMap<Inventory, InventoryDto>();
        CreateMap<InventoryDto, Inventory>();
    }
}
