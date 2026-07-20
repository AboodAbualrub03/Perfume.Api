using Perfume.Api.Dtos;
using Perfume.Api.Models;

namespace Perfume.Api.Services
{
    public interface IProductService
    {
         Task<List<ProductDto>> GetAllAsync();

        Task<ProductDto?> GetByIdAsync(int id);

        Task<ProductDto> CreateAsync(CreateProductDto product);

        Task<bool> UpdateAsync(int id,CreateProductDto product);

        Task<bool> DeleteAsync(int id);




    }
}
