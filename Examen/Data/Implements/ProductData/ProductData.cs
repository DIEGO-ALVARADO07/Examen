using Data.Implements.BaseData;
using Data.Interfaces;
using Entity.Context;
using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Implements.ProductData
{
    public class ProductData : BaseModelData<Product> , IProductData 
    {
        public ProductData(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<bool> ActiveAsync(int id, bool active)
        {
            var user = await _context.Set<Product>().FindAsync(id);
            if (user == null)
                return false;

            user.Status = active;
            _context.Entry(user).Property(u => u.Status).IsModified = true;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdatePartial(Product product)
        {
            var existingProduct = await _context.Set<Product>().FindAsync(product.Id);
            if (existingProduct == null) return false;

            _context.Entry(existingProduct).CurrentValues.SetValues(product);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
