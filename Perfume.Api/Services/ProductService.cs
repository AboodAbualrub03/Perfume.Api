using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Perfume.Api.Data;
using Perfume.Api.Dtos;
using Perfume.Api.Models;

namespace Perfume.Api.Services
{
    public class ProductService : IProductService
    {
       // private readonly List<Product> _products;
        private readonly AppDbContext _context;
        public ProductService(AppDbContext context)
        {
          _context = context;
        }

        public async Task<ProductDto?> GetByIdAsync(int id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
            if (product is null) return null;

            return new ProductDto
            {
                Id = product.Id,
                NameAr = product.NameAr,
                NameEn = product.NameEn,
                Description = product.Description,
                Price = product.Price,
                ImageUrl = product.ImageUrl
            };
        }

        public async Task<List<ProductDto>> GetAllAsync()
        {
            return await _context.Products.Select(p => new ProductDto
            {
                Id = p.Id,
                NameAr = p.NameAr,
                NameEn = p.NameEn,
                Description = p.Description,
                Price = p.Price,
                ImageUrl = p.ImageUrl
            }).ToListAsync();
        }

        public async Task<ProductDto> CreateAsync(CreateProductDto product)
        {


      

            var newProduct = new Product {  Description = product.Description,
                NameAr = product.NameAr,NameEn = product.NameEn,ImageUrl = product.ImageUrl,Price = product.Price };

               _context.Products.Add(newProduct);
             await  _context.SaveChangesAsync();
            return new ProductDto
            {   Id = newProduct.Id,
                NameEn = newProduct.NameEn,
                NameAr = newProduct.NameAr,
                ImageUrl = newProduct.ImageUrl,
                 Price = newProduct.Price,
                 Description = newProduct.Description,
                 

            };



        }

        public async Task<bool> UpdateAsync(int id, CreateProductDto dto)
        {

            var product = await _context.Products.FindAsync(id);
            if(product == null)
            {
                return false;
            }

            product.Price = dto.Price;
            product.Description = dto.Description;
            product.NameAr = dto.NameAr;
            product.NameEn = dto.NameEn;
            product.ImageUrl = dto.ImageUrl;
            
            
            await _context.SaveChangesAsync();
            return true;


        }
        public async Task<bool> DeleteAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);

            if(product == null)
            {
                return false;
            }
             _context.Products.Remove(product);

            await _context.SaveChangesAsync();
            return true;
        }
    }
}