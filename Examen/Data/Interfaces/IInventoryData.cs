using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Model.Security;

namespace Data.Interfaces
{
    public interface IInventoryData : IBaseModelData<Inventory>
    {
        Task<bool> ActiveAsync(int id,bool status);
        Task<bool> UpdatePartialAsync(Inventory inventory);
    }
}
