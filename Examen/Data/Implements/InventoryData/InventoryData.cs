
using Data.Implements.BaseData;
using Data.Interfaces;
using Entity.Context;
using Entity.Model.Security;
using Microsoft.EntityFrameworkCore;


namespace Data.Implements.InventoryData
{   
    public class InventoryData : BaseModelData<Inventory> , IInventoryData
    {

        public InventoryData(ApplicationDbContext context) : base(context)
            
        {
            
        }

        public async Task<bool> ActiveAsync(int id,bool status)
        {
            var user = await _context.Inventorys.FirstOrDefaultAsync(u => u.Status == status);
            if (user == null) return false;
            user.Status = !status;
            _context.Inventorys.Update(user);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> UpdatePartialAsync(Inventory inventory)
        {
            var existingInventory = await _context.Inventorys.FindAsync(inventory.Id);
            if (existingInventory == null) return false;
            // Actualiza solo los campos q no son nulos
            _context.Inventorys.Update(existingInventory);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
