namespace Heladeria.Repository.Interfaces
{
    public interface IProductRepository : IRepository<Models.DTO.ProductDTO>
    {
        Task GetAllAsync(object value);
    }
}