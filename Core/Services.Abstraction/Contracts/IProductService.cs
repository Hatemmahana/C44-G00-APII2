using Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstraction.Contracts
{
    public interface IProductService
    {
        //GetAllProduct
        Task<IEnumerable<ProductResultDto>> GetAllProductAsync();
        //GetAllBrands
        Task<IEnumerable<BrandResultDto>> GetAllBrandAsync();
        //GetProductById
        Task<ProductResultDto> GetProductByIdAsync(int id);
        //GetAllType
        Task<IEnumerable<TypeResultDto>> GetAllTypesAsync();
    }
}
