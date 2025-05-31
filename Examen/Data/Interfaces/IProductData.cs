using Entity.Model.Security;

namespace Data.Interfaces
{
    public interface IProductData : IBaseModelData<Product>
    {
        Task<bool> ActiveAsync(int id, bool status);
        Task<bool> UpdatePartial(Product product);
    }
}
