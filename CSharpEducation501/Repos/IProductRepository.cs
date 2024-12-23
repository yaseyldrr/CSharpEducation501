using CSharpEducation501.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpEducation501.Repos
{
    public interface IProductRepository
    {
        // ASenkron metot: 
        Task<List<ResultProductDto>> GetAllProductAsync();
        Task CreateProductAsync(CreateProductDto createProductDto);
        Task UpdateProductAsync(UpdateProductDto updateProductDto);

        Task DeleteProductAsync(int id);
        Task GetByProductIdAsync(int id);
    }
}
